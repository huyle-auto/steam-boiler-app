using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamBoilerApp.MVP.Views
{
    public partial class AppSettingView : UserControl, IAppSettingView
    {
        public string IpAddress => txtIPAddress.Text;

        public int Port => int.Parse(txtPort.Text);

        public int SlaveID => int.Parse(txtSlaveID.Text);

        public string CtrlRoomIpAddress => txtCtrlRoomIPAddr.Text;

        public int CtrlRoomPort => int.Parse(txtCtrlRoomPort.Text);


        public AppSettingView()
        {
            InitializeComponent();
        }

        public event EventHandler? ConnectClicked;
        public event EventHandler? DisconnectClicked;
        public event EventHandler? CtrlRoomConnectClicked;
        public event EventHandler? CtrlRoomDisconnectClicked;
        public event EventHandler? MqttV311ConnectClicked;
        public event EventHandler? MqttV311DisconnectClicked;

        public event EventHandler? MqttV50ConnectClicked;
        public event EventHandler? MqttV50DisconnectClicked;
        public event EventHandler? MqttV50PublishClicked;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ShowConnectionState(bool state)
        {
            lblHandshakeStatus.BackColor = state ? Color.LimeGreen : Color.Red;
        }
        public void ShowCtrlRoomState(bool state)
        {
            lblCtrlRoomStatus.BackColor = state ? Color.LimeGreen : Color.Red;
        }

        public void ShowMqttV311ConnectionState(bool state)
        {
            lblMqttV311Status.BackColor = state ? Color.LimeGreen : Color.Red;
        }

        private void btnCtrlRoomConnect_Click(object sender, EventArgs e)
        {
            CtrlRoomConnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCtrlRoomDisconnect_Click(object sender, EventArgs e)
        {
            CtrlRoomDisconnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnMqttV311Connect_Click(object sender, EventArgs e)
        {
            MqttV311ConnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnMqttV311Disconnect_Click(object sender, EventArgs e)
        {
            MqttV311DisconnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnMqttV50Connect_Click(object sender, EventArgs e)
        {
            MqttV50ConnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnMqttV50Disconnect_Click(object sender, EventArgs e)
        {
            MqttV50DisconnectClicked?.Invoke(this, EventArgs.Empty);
        }

        private void MqttV50Publish_Click(object sender, EventArgs e)
        {
            MqttV50PublishClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ShowMqttV50ConnectionState(bool state)
        {
            lblMqttV50Status.BackColor = state ? Color.LimeGreen : Color.Red;
        }
    }
}
