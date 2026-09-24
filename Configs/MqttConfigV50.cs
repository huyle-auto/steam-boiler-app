using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SteamBoilerApp.Configs
{
    public class MqttConfigV50
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string ClientId { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        [JsonConverter(typeof(SecureStringConverter))]
        public SecureString? Password { get; set; }

        public bool UseTls { get; set; }
        public int KeepAliveSeconds { get; set; }
        public int SessionExpiryInterval { get; set; }
        public int ConnectTimeoutMs { get; set; }
        public int ResponseTimeoutMs { get; set; }
    }
}
