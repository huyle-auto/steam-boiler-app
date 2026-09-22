using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Configs
{
    public class MqttConfig
    {
        public string BrokerAddress { get; set; } = string.Empty;
        public int BrokerPort { get; set; } = 1883;
        public string ClientId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int KeepAliveSeconds { get; set; }
        public int AutoReconnectSeconds { get; set; }
        public int ConnectTimeoutSeconds { get; set; }
        public int DisconnectTimeoutSeconds { get; set; }
        public int MaxPendingMessages { get; set; }
    }
}
