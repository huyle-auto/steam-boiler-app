using HiveMQtt.Client.Events;
using HiveMQtt.MQTT5.Types;
using SteamBoilerApp.MVP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IMqttV50Service
    {
        bool IsConnected { get; }

        event EventHandler<bool>? MqttConnected;    // bool indicate Session Present flag, 1 = broker resumes, 0 = re-subscribe topics
        event EventHandler? MqttDisconnected;
        event EventHandler<MqttMessage>? MqttMessageReceived;

        Task<MqttResult> ConnectAsync();
        Task<MqttResult> DisconnectAsync();

        Task<MqttResult> PublishAsync(
            string topic, string payload, int qos);

        Task<MqttResult> SubscribeAsync(
            string topic, int qos,
            bool noLocal,
            bool retainAsPublished,
            int retainHandling);

        Task<MqttResult> UnsubscribeAsync(string topic);
    }
}
