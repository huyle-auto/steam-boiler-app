using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IScheduleClientService
    {
        Task<bool> ConnectAsync(string ip, int port);
        Task DisconnectAsync();

        public bool IsConnected { get; set; }

        public event EventHandler<string>? JsonReceived;
        public event EventHandler? ScheduleServerConnected;
        public event EventHandler? ScheduleServerDisconnected;
    }
}
