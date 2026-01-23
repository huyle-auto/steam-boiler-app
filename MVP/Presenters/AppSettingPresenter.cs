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

namespace SteamBoilerApp.MVP.Presenters
{
    public class AppSettingPresenter
    {
        private readonly IAppSettingView _appSettingView;
        private readonly IAppSettingModel _appSettingModel;
        private readonly IModbusTCPService _modbusService;
        private readonly IScheduleClientService _scheduleClientService;
        private readonly IToastNotificationService _toast;

        private readonly IDatabaseHealthService _dbHealthService;
        private readonly IDataAcquisitionService _dataAcqService;

        private const string MODBUS_DISCONNECT_TAG = "modbus_disconnect_notification";
        private const string DB_DISCONNECT_TAG = "db_disconnect_notification";

        public AppSettingPresenter(IAppSettingView appSettingView, IAppSettingModel appSettingModel, IModbusTCPService modbusService, IDatabaseHealthService dbHealthService, IDataAcquisitionService dataAcqService, IScheduleClientService scheduleClientService, IToastNotificationService toastService)
        {
            this._appSettingView = appSettingView;
            this._appSettingModel = appSettingModel;
            this._appSettingView.ConnectClicked += OnConnectClicked;
            this._appSettingView.DisconnectClicked += OnDisconnectClicked;
            this._appSettingView.CtrlRoomConnectClicked += OnCtrlRoomConnectClicked;
            this._appSettingView.CtrlRoomDisconnectClicked += OnCtrlRoomDisconnectClicked;

            this._modbusService = modbusService;
            this._modbusService.ModbusConnected += OnModbusConnected;
            this._modbusService.ModbusDisconnected += OnModbusDisconnected;
            this._modbusService.SnapshotUpdated += OnSnapshotUpdated;

            this._dbHealthService = dbHealthService;
            this._dbHealthService.DatabaseDisconnected += OnDBDisconnected;

            this._dataAcqService = dataAcqService;

            this._scheduleClientService = scheduleClientService;
            this._scheduleClientService.ScheduleServerConnected += OnScheduleServerConnected;
            this._scheduleClientService.ScheduleServerDisconnected += OnScheduleServerDisconnected;

            // Toast
            this._toast = toastService;
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
