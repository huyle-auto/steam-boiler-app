using HiveMQtt.Client;
using HiveMQtt.Client.Events;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.ReasonCodes;
using HiveMQtt.MQTT5.Types;
using SteamBoilerApp.Configs;
using SteamBoilerApp.MVP.Contracts;
using System.Diagnostics;

namespace SteamBoilerApp.MVP.Services
{
    public class MqttV50Service : IMqttV50Service
    {
        private readonly MqttConfigV50 _mqttConfig;
        private IHiveMQClient _client;

        public MqttV50Service(MqttConfigV50 mqttConfig)
        {
            _mqttConfig = mqttConfig;

            InitializeClient();

            InitializeEvents();
        }

        public bool IsConnected { get; private set; }

        public event EventHandler<bool>? MqttConnected;
        public event EventHandler? MqttDisconnected;
        public event EventHandler<MqttMessage>? MqttMessageReceived;

        // -------------------------------------- INITIALIZATION ---------------------------------------
        private void InitializeClient(bool cleanStart = false)
        {
            var options = new HiveMQClientOptions
            {
                Host = _mqttConfig.Host,
                Port = _mqttConfig.Port,
                ClientId = _mqttConfig.ClientId,

                UserName = _mqttConfig.Username,
                Password = _mqttConfig.Password,

                UseTLS = _mqttConfig.UseTls,
                AllowInvalidBrokerCertificates = true,

                KeepAlive = _mqttConfig.KeepAliveSeconds,
                SessionExpiryInterval = _mqttConfig.SessionExpiryInterval,
                CleanStart = cleanStart,

                ConnectTimeoutInMs = _mqttConfig.ConnectTimeoutMs,
                ResponseTimeoutInMs = _mqttConfig.ResponseTimeoutMs,

                AutomaticReconnect = true,
            };

            _client = new HiveMQClient(options);
        }

        private void InitializeEvents()
        {
            _client.OnConnAckReceived += OnConnAckReceived;

            // Fires for both graceful and ungraceful disconnection
            _client.AfterDisconnect += OnAfterDisconnect;

            _client.OnMessageReceived += OnMessageReceived;
        }

        // ------------------------------------------ EVENTS -------------------------------------------
        private void OnConnAckReceived(object? sender, OnConnAckReceivedEventArgs e)
        {
            if (e.ConnAckPacket.ReasonCode == ConnAckReasonCode.Success)
            {
                IsConnected = true;
                MqttConnected?.Invoke(this, e.ConnAckPacket.SessionPresent);
            }
        }

        private void OnAfterDisconnect(object? sender, AfterDisconnectEventArgs e)
        {
            IsConnected = false;
            MqttDisconnected?.Invoke(this, EventArgs.Empty);
        }

        private void OnMessageReceived(object? sender, OnMessageReceivedEventArgs e)
        {
            var message = new MqttMessage
            {
                Topic = e.PublishMessage.Topic,
                Payload = e.PublishMessage.Payload ?? Array.Empty<byte>(),
                PayloadAsString = e.PublishMessage.PayloadAsString,
                QoS = (int)e.PublishMessage.QoS ,
                Retain = e.PublishMessage.Retain,
                Duplicate = e.PublishMessage.Duplicate,
                PayloadFormat = (int)e.PublishMessage.PayloadFormatIndicator,
                MessageExpiryInterval = e.PublishMessage.MessageExpiryInterval,
                TopicAlias = e.PublishMessage.TopicAlias,
                ResponseTopic = e.PublishMessage.ResponseTopic,
                CorrelationData = e.PublishMessage.CorrelationData,
                UserProperties = e.PublishMessage.UserProperties.ToList(),
                SubscriptionIdentifiers = e.PublishMessage.SubscriptionIdentifiers.ToList(),
                ContentType = e.PublishMessage.ContentType
            };
            
            MqttMessageReceived?.Invoke(this, message);
        }

        // ----------------------------------- CONNECTIVITY METHODS ------------------------------------
        public async Task<MqttResult> ConnectAsync()
        {
            try
            {
                var result = await _client.ConnectAsync();

                return new MqttResult
                {
                    IsSuccess = (int)result.ReasonCode < 0x80,
                    ReasonCode = (int)result.ReasonCode,
                    ReasonString = result.ReasonString ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HiveMQ v5.0 connection failed: {ex.Message}");

                return new MqttResult
                {
                    IsSuccess = false,
                    ReasonCode = -1,
                    ReasonString = ex.Message
                };
            }
        }

        public async Task<MqttResult> DisconnectAsync()
        {
            try
            {
                if (!_client.IsConnected())
                {
                    throw new Exception("Client is not connected.");
                }

                // This method returns a bool according to the source
                var result = await _client.DisconnectAsync();

                return new MqttResult
                {
                    IsSuccess = result,
                    ReasonCode = -1,
                    ReasonString = string.Empty
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HiveMQ v5.0 disconnection failed: {ex.Message}");

                return new MqttResult
                {
                    IsSuccess = false,
                    ReasonCode = -1,
                    ReasonString = ex.Message
                };
            }
        }

        // --------------------------------- PUBLISH/SUBSCRIBE METHODS ---------------------------------
        public async Task<MqttResult> PublishAsync(string topic, string payload, int qos = 1)
        {
            try
            {
                var result = await _client.PublishAsync(topic, payload, (QualityOfService)qos);

                var reasonCode = result.ReasonCode();

                return new MqttResult
                {
                    IsSuccess = reasonCode < 0x80,
                    ReasonCode = (int)reasonCode,
                    ReasonString = Enum.GetName(typeof(PubAckReasonCode), reasonCode) ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HiveMQ v5.0 publish failed: {ex.Message}");

                return new MqttResult
                {
                    IsSuccess = false,
                    ReasonCode = -1,
                    ReasonString = ex.Message
                };
            }
        }

        // Subscribe a single topic
        public async Task<MqttResult> SubscribeAsync(
            string topic,
            int qos = 1,
            bool noLocal = false,
            bool retainAsPublished = false,
            int retainHandling = 0)
        {
            try
            {
                var result = await _client.SubscribeAsync(topic, (QualityOfService)qos, noLocal, retainAsPublished, (RetainHandling)retainHandling);
                var sub = result.GetFirstSubscription();

                if (sub == null)
                {
                    throw new Exception("Subscription result is null.");
                }

                return new MqttResult
                {
                    IsSuccess = (int)sub.SubscribeReasonCode < 0x80,
                    ReasonCode = (int)sub.SubscribeReasonCode,
                    ReasonString = Enum.GetName(typeof(SubAckReasonCode), sub.SubscribeReasonCode) ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HiveMQ v5.0 subscription failed: {ex.Message}");

                return new MqttResult
                {
                    IsSuccess = false,
                    ReasonCode = -1,
                    ReasonString = ex.Message
                };
            }
        }

        // Subscribe multiple topics
        public async Task<MqttResult> SubscribeAsync(SubscribeOptions options)
        {
            try
            {
                var result = await _client.SubscribeAsync(options);

                if (result.Subscriptions.Count == 0)
                {
                    throw new Exception("Subscription result is empty.");
                }

                var failedSubscription = result.Subscriptions.FirstOrDefault(s => (int)s.SubscribeReasonCode >= 0x80);

                if (failedSubscription != null)
                {
                    var reasonCode = failedSubscription.SubscribeReasonCode;

                    return new MqttResult
                    {
                        IsSuccess = false,
                        ReasonCode = (int)failedSubscription.SubscribeReasonCode,
                        ReasonString = $"Subscription failed for topic:" + $"{failedSubscription.TopicFilter.Topic}: " + $"{Enum.GetName(typeof(SubAckReasonCode), reasonCode) ?? string.Empty}"
                    };
                }
                else
                {
                    return new MqttResult
                    {
                        IsSuccess = true,
                        ReasonCode = 0,
                        ReasonString = "All subscriptions succeeded."
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HiveMQ v5.0 subscription failed: {ex.Message}");

                return new MqttResult
                {
                    IsSuccess = false,
                    ReasonCode = -1,
                    ReasonString = ex.Message
                };
            }
        }

        public async Task<MqttResult> UnsubscribeAsync(string topic)
        {
            try
            {
                var result = await _client.UnsubscribeAsync(topic);

                var sub = result.Subscriptions.FirstOrDefault(s => s.TopicFilter.Topic == topic);

                if (sub == null)
                {
                    throw new Exception("Unsubscribe result is null.");
                }

                return new MqttResult
                {
                    IsSuccess = (int)sub.UnsubscribeReasonCode < 0x80,
                    ReasonCode = (int)sub.UnsubscribeReasonCode,
                    ReasonString = Enum.GetName(typeof(UnsubAckReasonCode), sub.UnsubscribeReasonCode) ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HiveMQ v5.0 unsubscription failed: {ex.Message}");

                return new MqttResult
                {
                    IsSuccess = false,
                    ReasonCode = -1,
                    ReasonString = ex.Message
                };
            }
        }

        // ---------------------------------------- DISPOSAL -------------------------------------------
        public void Dispose()
        {
            _client.OnConnAckReceived -= OnConnAckReceived;
            _client.AfterDisconnect -= OnAfterDisconnect;
            _client.OnMessageReceived -= OnMessageReceived;

            _client.Dispose();
        }
    }

    public class MqttResult
    {
        public bool IsSuccess { get; init; }
        public int ReasonCode { get; init; }    // -1 to indicate exception, otherwise the MQTT reason code
        public string ReasonString { get; init; } = string.Empty;
    }

    public class MqttMessage
    {
        public string? Topic { get; init; }

        public byte[] Payload { get; init; } = Array.Empty<byte>();

        public string PayloadAsString { get; init; } = string.Empty;

        public int QoS { get; init; }

        public bool Retain { get; init; }

        public bool Duplicate { get; init; }

        public int PayloadFormat { get; init; } // 0 = Unspecified, 1 = UTF-8 encoded character data

        public int? MessageExpiryInterval { get; init; }

        public int? TopicAlias { get; init; }

        public string? ResponseTopic { get; init; }

        public byte[]? CorrelationData { get; init; }

        public IReadOnlyList<KeyValuePair<string, string>> UserProperties { get; init; }
            = Array.Empty<KeyValuePair<string, string>>();

        public IReadOnlyList<int> SubscriptionIdentifiers { get; init; }
            = Array.Empty<int>();

        public string? ContentType { get; init; }
    }
}
