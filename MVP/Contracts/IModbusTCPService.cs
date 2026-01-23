using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IModbusTCPService
    {
        Task<bool> ConnectAsync(string ipAddress, int port);    // AppSetting exclusive ("friend class" concept not in C#)
        Task<bool> DisconnectAsync();   // AppSetting exclusive ("friend class" concept not in C#)

        bool IsConnected { get; }

        double ReadAnalogInput(string tag);
        IReadOnlyList<SensorDatum> ExtractSensorValues(ModbusSnapshot snapshot);

        public event EventHandler ModbusConnected;
        public event EventHandler ModbusDisconnected;
        public event EventHandler<ModbusSnapshot>? SnapshotUpdated;
    }
}
