using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using MQTTnet.Server;
using SteamBoilerApp.Configs;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Services
{
    public class MqttV311Service : IMqttV311Service
    {
        private readonly MqttConfig _mqttConfig;

        private IManagedMqttClient _managedClient;
        private ManagedMqttClientOptions _options;

        public bool IsConnected { get; private set; }

        public event EventHandler? MqttConnected;
        public event EventHandler? MqttDisconnected;
        public event EventHandler? MqttReconnecting;

        public event EventHandler<MqttApplicationMessageReceivedEventArgs>? MqttMessageReceived;
        public event EventHandler<ApplicationMessageProcessedEventArgs>? MqttMessagePublished;
        public event EventHandler<ApplicationMessageSkippedEventArgs>? MqttMessageSkipped;
        public event EventHandler<ManagedProcessFailedEventArgs>? MqttSynchronizingSubscriptionsFailed; // Fires when automatic subscriptions sync fails, may need to re-subscribe manually

        public MqttV311Service(MqttConfig mqttConfig)
        {
            _mqttConfig = mqttConfig;

            InitializeClient();

            InitializeEvents();
        }

        // -------------------------------------- INITIALIZATION ---------------------------------------
        /// <summary>
        /// IMPORTANT: How to wipe the subscriptions list for a severe mys-syncing between broker and client
        /// 1. Stop the client
        /// 2. Build options again with isForceCleanSession = true
        /// 3. Start the client again, don't subscribe to any topic
        /// 4. Stop the client again
        /// 5. Build options again with isForceCleanSession = false
        /// 6. Start the client again, and subscribe to topics again 
        /// 7. 👍
        /// </summary>
        private void InitializeClient()
        {
            var mqttFactory = new MqttFactory();

            _managedClient = mqttFactory.CreateManagedMqttClient();

            BuildClientOptions();
        }

        public void BuildClientOptions(bool isForceCleanSession = false)
        {
            var baseOptions = new MqttClientOptionsBuilder()
                .WithClientId(_mqttConfig.ClientId)
                .WithTcpServer(_mqttConfig.BrokerAddress, _mqttConfig.BrokerPort)
                .WithCredentials(_mqttConfig.Username, _mqttConfig.Password)
                .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V311)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(_mqttConfig.KeepAliveSeconds))
                .WithTimeout(TimeSpan.FromSeconds(_mqttConfig.ConnectTimeoutSeconds))
                .WithCleanSession(isForceCleanSession)
                .WithSessionExpiryInterval(3600) // Persistent session
                .WithTlsOptions(o =>
                {
                    o.WithSslProtocols(SslProtocols.Tls12 | SslProtocols.Tls13);

                    // Trust self-signed cert
                    o.WithCertificateValidationHandler(delegate { return true; });
                })
                .Build();

            _options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(baseOptions)
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(_mqttConfig.AutoReconnectSeconds))
                .WithMaxPendingMessages(_mqttConfig.MaxPendingMessages) // Limit queue to prevent RAM exhaustion
                .WithPendingMessagesOverflowStrategy(MqttPendingMessagesOverflowStrategy.DropNewMessage) // Drop new messages when queue is full)
                .Build();
        }

        private void InitializeEvents()
        {
            #region Lifecycle events

            _managedClient.ConnectedAsync += async (e) =>
            {
                IsConnected = true;
                MqttConnected?.Invoke(this, EventArgs.Empty);

                Debug.WriteLine("Mqtt Connected");
            };

            _managedClient.DisconnectedAsync += async (e) =>
            {
                IsConnected = false;
                MqttDisconnected?.Invoke(this, EventArgs.Empty);

                Debug.WriteLine($"MQTT DISCONNECTED: {e.Exception}");
            };

            _managedClient.ConnectingFailedAsync += async (e) =>
            {
                IsConnected = false;
                MqttReconnecting?.Invoke(this, EventArgs.Empty);

                Debug.WriteLine($"MQTT CONNECTION FAILED: {e.Exception}");
            };

            _managedClient.SynchronizingSubscriptionsFailedAsync += async (e) =>
            {
                MqttSynchronizingSubscriptionsFailed?.Invoke(this, e);
                Debug.WriteLine($"MQTT SUBSCRIPTION SYNC FAILED: {e.Exception}");
            };

            #endregion

            #region Message events

            // Receive
            _managedClient.ApplicationMessageReceivedAsync += async (e) =>
            {
                MqttMessageReceived?.Invoke(this, e);
            };

            // Publish
            _managedClient.ApplicationMessageProcessedAsync += async (e) =>
            {
                MqttMessagePublished?.Invoke(this, e);
            };

            // Skip due to overflowed queue
            _managedClient.ApplicationMessageSkippedAsync += async (e) =>
            {
                MqttMessageSkipped?.Invoke(this, e);
            };

            #endregion
        }

        // ----------------------------------- CONNECTIVITY METHODS ------------------------------------
        public async Task StartAsync()
        {
            if (_managedClient.IsStarted)
            {
                return;

            }

            try
            {
                await _managedClient.StartAsync(_options);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Failed to start MQTT client: {ex.Message}");
            }
        }

        public async Task StopAsync()
        {
            if (!_managedClient.IsStarted)
            {
                return;
            }

            try
            {
                await _managedClient.StopAsync(cleanDisconnect: true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to stop MQTT client: {ex.Message}");
            }
        }

        public async Task PingAsync()
        {
            try
            {
                await _managedClient.PingAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to ping MQTT broker: {ex.Message}");
            }
        }

        // --------------------------------- PUBLISH/SUBSCRIBE METHODS ---------------------------------
        public async Task PublishAsync(string topic, string payload, int qos = 0, bool retain = false)
        {
            try
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(payload)
                    .WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)qos)
                    .WithRetainFlag(retain)
                    .Build();

                await _managedClient.EnqueueAsync(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to publish topic {topic}: {ex.Message}");
            }
        }

        // Need to re-subscribe upon reconnection even with persistent session
        public async Task SubscribeAsync(List<MqttTopicFilter> topics)
        {
            try
            {
                await _managedClient.SubscribeAsync(topics);    // Subscribe to multiple topics
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to subscribe to topics: {string.Join(", ", topics.Select(t => t.Topic))}:\n {ex.Message}");
            }
        }

        public async Task UnsubscribeAsync(List<string> topics)
        {
            try
            {
                await _managedClient.UnsubscribeAsync(topics);    // Unsubscribe from multiple topics
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to unsubscribe from topics: {string.Join(", ", topics)}:\n {ex.Message}");
            }
        }

        // ---------------------------------------- DISPOSAL -------------------------------------------
        public void Dispose()
        {
            _managedClient.Dispose();
        }
    }
}
