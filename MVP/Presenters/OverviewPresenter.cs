using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Presenters
{
    public class OverviewPresenter
    {
        private readonly IOverviewView _overviewView;
        private readonly IOverviewModel _overviewModel;
        private readonly IModbusTCPService _modbusService;
        private readonly System.Windows.Forms.Timer _timer;

        public OverviewPresenter(IOverviewView overviewView, IOverviewModel overviewModel, IModbusTCPService modbusService)
        {
            this._overviewView = overviewView;
            this._overviewModel = overviewModel;
            this._modbusService = modbusService;
            this._overviewView.CboFuelDistClicked += OnCboFuelDistClicked;
            this._modbusService.ModbusConnected += OnModbusConnected;
            this._modbusService.ModbusDisconnected += OnModbusDisconnected;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 3000;
            _timer.Start();
        }

        private void OnModbusConnected(object? sender, EventArgs e)
        {
            _timer.Tick += OnTick;
            if (!_timer.Enabled)
            {
                _timer.Start();
            }
        }

        private void OnModbusDisconnected(object? sender, EventArgs e)
        {
            _timer.Tick -= OnTick;
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        private async void OnCboFuelDistClicked(object? sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> fuelFeedDist = await _overviewModel.GetFuelDist(_overviewView.FuelDistFromDate, _overviewView.FuelDistToDate);
                if (fuelFeedDist == null || fuelFeedDist.Count == 0 || fuelFeedDist.Values.Sum() == 0)
                {
                    _overviewView.ShowDistributionChart([]);
                    throw new Exception("No fuel distribution data found.");
                }
                else
                {
                    _overviewView.ShowDistributionChart(fuelFeedDist);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnTick(object? sender, EventArgs e)
        {
            try
            {
                var pressure = _overviewModel.ReadSteamPressure();
                _overviewView.SetPressureGauge(pressure);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
