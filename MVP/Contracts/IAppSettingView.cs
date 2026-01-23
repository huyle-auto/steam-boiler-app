using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IAppSettingView
    {
        public string IpAddress { get; }
        public int Port { get; }
        public int SlaveID { get; }

        public string CtrlRoomIpAddress { get; }
        public int CtrlRoomPort { get; }

        public void ShowConnectionState(bool state);
        public void ShowCtrlRoomState(bool state);

        public event EventHandler ConnectClicked;
        public event EventHandler DisconnectClicked;

        public event EventHandler CtrlRoomConnectClicked;
        public event EventHandler CtrlRoomDisconnectClicked;
    }
}
