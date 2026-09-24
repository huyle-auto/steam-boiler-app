using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Configs
{
    public class MqttConfigV311
    {
        // MQTT V3.1.1 Configuration
        public string BrokerAddress { get; set; } = string.Empty;
        public int BrokerPort { get; set; } = 1883;
        public string ClientIdV311 { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int KeepAliveSeconds { get; set; }
        public int AutoReconnectSeconds { get; set; }
        public int ConnectTimeoutSeconds { get; set; }
        public int DisconnectTimeoutSeconds { get; set; }
        public int MaxPendingMessages { get; set; }

        // Birth and Last Will messages
        public string BirthTopic { get; set; } = string.Empty;
        public string BirthMessagePayload { get; set; } = string.Empty;
        public string LastWillTopic { get; set; } = string.Empty;
        public string LastWillMessagePayload { get; set; } = string.Empty;

        // MQTT V5.0 Configuration
        public string ClientIdV50 { get; set; } = string.Empty;

    }
}
