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
