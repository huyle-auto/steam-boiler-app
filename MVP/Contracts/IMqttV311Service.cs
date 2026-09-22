using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IMqttV311Service
    {
        bool IsConnected { get; }

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
        void BuildClientOptions(bool isForceCleanSession = false);

        Task StartAsync();
        Task StopAsync();
        Task PingAsync();

        Task PublishAsync(string topic, string payload, int qos = 0, bool retain = false);
        Task SubscribeAsync(List<MqttTopicFilter> topics);
        Task UnsubscribeAsync(List<string> topics);

        event EventHandler MqttConnected;
        event EventHandler MqttDisconnected;
        event EventHandler MqttReconnecting;

        event EventHandler<MqttApplicationMessageReceivedEventArgs> MqttMessageReceived; 
        event EventHandler<ApplicationMessageProcessedEventArgs> MqttMessagePublished;   
        event EventHandler<ApplicationMessageSkippedEventArgs> MqttMessageSkipped;
        event EventHandler<ManagedProcessFailedEventArgs>? MqttSynchronizingSubscriptionsFailed;
    }
}
