using MQTTnet;
using MQTTnet.Packets;
using MQTTnet.Extensions.ManagedClient;
using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.MVP.Services;
using SteamBoilerApp.Toast;
using SteamBoilerApp.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MQTTnet.Client;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;

namespace SteamBoilerApp.MVP.Presenters
{
    public class AppSettingPresenter
    {
        private readonly IAppSettingView _appSettingView;
        private readonly IAppSettingModel _appSettingModel;
        private readonly IModbusTCPService _modbusService;
        private readonly IMqttV311Service _mqttV311Service;
        private readonly IMqttV50Service _mqttV50Service;

        private readonly IScheduleClientService _scheduleClientService;
        private readonly IToastNotificationService _toast;

        private readonly IDatabaseHealthService _dbHealthService;
        private readonly IDataAcquisitionService _dataAcqService;

        private const string MODBUS_DISCONNECT_TAG = "modbus_disconnect_notification";
        private const string DB_DISCONNECT_TAG = "db_disconnect_notification";

        public AppSettingPresenter(
            IAppSettingView appSettingView, 
            IAppSettingModel appSettingModel, 
            IModbusTCPService modbusService, 
            IDatabaseHealthService dbHealthService, 
            IDataAcquisitionService dataAcqService, 
            IScheduleClientService scheduleClientService, 
            IToastNotificationService toastService,
            IMqttV311Service mqttV311Service,
            IMqttV50Service mqttV50Service)
        {
            this._appSettingView = appSettingView;
            this._appSettingModel = appSettingModel;
            this._appSettingView.ConnectClicked += OnConnectClicked;
            this._appSettingView.DisconnectClicked += OnDisconnectClicked;
            this._appSettingView.CtrlRoomConnectClicked += OnCtrlRoomConnectClicked;
            this._appSettingView.CtrlRoomDisconnectClicked += OnCtrlRoomDisconnectClicked;

            this._appSettingView.MqttV311ConnectClicked += OnMqttV311ConnectClicked;
            this._appSettingView.MqttV311DisconnectClicked += OnMqttV311DisconnectClicked;

            this._appSettingView.MqttV50ConnectClicked += OnMqttV50ConnectClicked;
            this._appSettingView.MqttV50DisconnectClicked += OnMqttV50DisconnectClicked;
            this._appSettingView.MqttV50PublishClicked += OnMqttV50PublishClicked;

            // Modbus
            this._modbusService = modbusService;
            this._modbusService.ModbusConnected += OnModbusConnected;
            this._modbusService.ModbusDisconnected += OnModbusDisconnected;
            this._modbusService.SnapshotUpdated += OnSnapshotUpdated;

            // Mqtt v3.1.1
            this._mqttV311Service = mqttV311Service;
            this._mqttV311Service.MqttConnected += OnMqttV311Connected;
            this._mqttV311Service.MqttDisconnected += (s, e) => _appSettingView.ShowMqttV311ConnectionState(false);
            this._mqttV311Service.MqttReconnecting += (s, e) => _appSettingView.ShowMqttV311ConnectionState(false);

            this._mqttV311Service.MqttMessageReceived += OnMqttV311MessageReceived;

            // Mqtt v5.0
            this._mqttV50Service = mqttV50Service;
            this._mqttV50Service.MqttConnected += OnMqttV50Connected;
            this._mqttV50Service.MqttDisconnected += (sender, e) =>
            {
                _appSettingView.ShowMqttV50ConnectionState(false);
            };
            this._mqttV50Service.MqttMessageReceived += (sender, e) =>
            {
                 Debug.WriteLine($"Topic {e.Topic}: {e.PayloadAsString}");
            };

            // Db
            this._dbHealthService = dbHealthService;
            this._dbHealthService.DatabaseDisconnected += OnDBDisconnected;

            this._dataAcqService = dataAcqService;

            this._scheduleClientService = scheduleClientService;
            this._scheduleClientService.ScheduleServerConnected += OnScheduleServerConnected;
            this._scheduleClientService.ScheduleServerDisconnected += OnScheduleServerDisconnected;

            // Toast
            this._toast = toastService;
        }

        private async void OnMqttV50Connected(object? sender, bool e)
        {
            _appSettingView.ShowMqttV50ConnectionState(true);

            if (e)
            {
                Debug.WriteLine("Session saved!");
            }
            else
            {
                var result = await _mqttV50Service.SubscribeAsync("mqttx/client/test", 1, false, false, 0);
                Debug.WriteLine("Subcribe to topic result: " + result.ReasonString);
            }
        }

        private async void OnMqttV50PublishClicked(object? sender, EventArgs e)
        {
            var payload = new
            {
                status = "Boiler SCADA is running"
            };

            string jsonPayload = JsonSerializer.Serialize(payload);

            await _mqttV50Service.PublishAsync("factory/boiler/scada/status", jsonPayload, 1);
        }

        private async void OnMqttV50DisconnectClicked(object? sender, EventArgs e)
        {
            await _mqttV50Service.DisconnectAsync();
        }

        private async void OnMqttV50ConnectClicked(object? sender, EventArgs e)
        {
            await _mqttV50Service.ConnectAsync();
        }

        private void OnMqttV311MessageReceived(object? sender, MqttApplicationMessageReceivedEventArgs e)
        {
            string payloadString = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);

            // Debug.WriteLine($"Topic {e.ApplicationMessage.Topic}: {payloadString}");
        }

        private async void OnMqttV311Connected(object? sender, EventArgs e)
        {
            _appSettingView.ShowMqttV311ConnectionState(true);

            // Subscribe to topics
            var topics = new List<MqttTopicFilter>
            {
                new MqttTopicFilterBuilder().WithTopic("factory/mqtt-broker/status").WithAtMostOnceQoS().Build()
            };

            await _mqttV311Service.SubscribeAsync(topics);
        }

        private async void OnMqttV311ConnectClicked(object? sender, EventArgs e)
        {
            await _mqttV311Service.StartAsync();
        }

        private async void OnMqttV311DisconnectClicked(object? sender, EventArgs e)
        {
            await _mqttV311Service.StopAsync();
        }

        private async void OnSnapshotUpdated(object? sender, ModbusSnapshot e)
        {
            if (!_dbHealthService.IsConnected)
            {
                return;
            }

            try
            {
                var data = _modbusService.ExtractSensorValues(e);
                await _dataAcqService.SaveSensorDataAsync(data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot retrieve and save async: " + ex.Message);
                return;
            }
        }

        private void OnScheduleServerConnected(object? sender, EventArgs e)
        {
            _appSettingView.ShowCtrlRoomState(true);
        }

        private void OnScheduleServerDisconnected(object? sender, EventArgs e)
        {
            _appSettingView.ShowCtrlRoomState(false);
        }

        private async void OnCtrlRoomConnectClicked(object? sender, EventArgs e)
        {
            await this._scheduleClientService.ConnectAsync(_appSettingView.CtrlRoomIpAddress, _appSettingView.CtrlRoomPort);
        }

        private async void OnCtrlRoomDisconnectClicked(object? sender, EventArgs e)
        {
            await this._scheduleClientService.DisconnectAsync();
        }

        private void OnModbusConnected(object? sender, EventArgs e)
        {
            _appSettingView.ShowConnectionState(true);  // View already loaded at this point (manual connect/disconnect)
        }

        private void OnModbusDisconnected(object? sender, EventArgs e)
        {
            _appSettingView.ShowConnectionState(false); // View already loaded at this point (manual connect/disconnect)

            // Windows Notification
            try
            {
                string imgName = "system_notif_bg_16_9.jpg";
                _toast.ShowWithActions(
                    "Modbus Disconnected",
                    "Please connect in app Settings - Data Logger. \nContact Admin - Zalo: 0359245916",
                    imgName,
                    MODBUS_DISCONNECT_TAG,
                    onAction: (action) =>
                    {
                        if (action == "open")
                        {
                            MessageBox.Show("Test Open Action", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    });
            }
            catch (Exception ex)
            {
                FileLogger.Log("System Notification Error: " + ex.Message);
            }
        }

        private void OnDBDisconnected(object? sender, EventArgs e)
        {
            // Windows Notification
            try
            {
                string imgName = "system_notif_bg_16_9.jpg";
                _toast.ShowWithActions(
                    "Database Disconnected",
                    "\nPlease contact Admin - Zalo: 0359245916",
                    imgName,
                    DB_DISCONNECT_TAG,
                    onAction: (action) =>
                    {
                        if (action == "open")
                        {
                            MessageBox.Show("Test Open Action", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    });
            }
            catch (Exception ex)
            {
                FileLogger.Log("System Notification Error: " + ex.Message);
            }
        }

        private async void OnConnectClicked(object? sender, EventArgs e)
        {
            try
            {
                bool connectOk = await _appSettingModel.ConnectAsync(_appSettingView.IpAddress, _appSettingView.Port);

                if (connectOk)
                {
                    MessageBox.Show("Connected to Data Logger successfully.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to connect to Data Logger.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnDisconnectClicked(object? sender, EventArgs e)
        {
            try
            {
                bool disconnectOk = await _appSettingModel.DisconnectAsync();
                if (disconnectOk)
                {
                    MessageBox.Show("Disconnected to Data Logger successfully.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to disconnect to Data Logger.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
