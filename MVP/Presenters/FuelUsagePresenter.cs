using Microsoft.VisualBasic.Logging;
using SteamBoilerApp.ChildMVP.Models;
using SteamBoilerApp.ChildMVP.Presenters;
using SteamBoilerApp.ChildMVP.Views;
using SteamBoilerApp.MVP.Contracts;

namespace SteamBoilerApp.MVP.Presenters
{
    public class FuelUsagePresenter
    {
        private readonly IFuelUsageView _fuelUsageView;
        private readonly IFuelUsageModel _fuelUsageModel;
        private readonly System.Windows.Forms.Timer _timer;
        private readonly IDatabaseHealthService _dbHealthService;

        private bool _isViewLoaded = false;
        private DateTime _lastRecordTimestamp;

        public FuelUsagePresenter(IFuelUsageView fuelUsageView, IFuelUsageModel fuelUsageModel, IDatabaseHealthService dbHealthService)
        {
            this._fuelUsageView = fuelUsageView;
            this._fuelUsageModel = fuelUsageModel;
            this._fuelUsageView.OnViewLoad += FuelUsageView_OnViewLoad;
            this._fuelUsageView.OnFuelUseDayChanged += FuelUsageView_OnFuelUseDayChanged;
            this._fuelUsageView.OnFuelFeedDayChanged += FuelUsageView_OnFuelFeedDayChanged;
            this._fuelUsageView.OnRefreshAllLogClicked += FuelUsageView_OnFuelFeedDayChanged;

            // Timer for auto-refresh data
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 10000;

            // DB
            this._dbHealthService = dbHealthService;
            this._dbHealthService.DatabaseConnected += OnDBConnected;
            this._dbHealthService.DatabaseDisconnected += OnDBDisconnected;
        }

        private void OnDBConnected(object? sender, EventArgs e)
        {
            if (!_isViewLoaded) return;

            this._timer.Tick += OnTick;
            this._timer.Start();
        }

        private void OnDBDisconnected(object? sender, EventArgs e)
        {
            this._timer.Tick -= OnTick;
            this._timer.Stop();
        }

        private async void OnTick(object? sender, EventArgs e)
        {
            try
            {
                // 1. Fuel feed log
                var latest = await _fuelUsageModel.GetLatestFeedLogTimeAsync();

                if (latest > _lastRecordTimestamp)
                {
                    _lastRecordTimestamp = latest;
                    var log = await _fuelUsageModel.GetFuelFeedByDayAsync(_fuelUsageView.FuelFeedLogDate);;
                    _fuelUsageView.RefreshFuelLogKeepFilter(log);
                }

                // 2. Fuel usage by type
                var totalFuelByType = await this._fuelUsageModel.GetFuelFeedLogByDayAndTypeAsync(this._fuelUsageView.FuelUseDay);

                _fuelUsageView.ShowFuelUsageByType(totalFuelByType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void FuelUsageView_OnViewLoad(object? sender, EventArgs e)
        {
            if (_dbHealthService.IsConnected)
            {
                this._timer.Tick += OnTick;
                this._timer.Start();

                // 1. Show current day fuel feed log
                var log = await _fuelUsageModel.GetFuelFeedByDayAsync(_fuelUsageView.FuelFeedLogDate);
                _fuelUsageView.RefreshAllFuelLog(log);

                // 2. Show current day fuel usage by type
                var totalFuelByType = await this._fuelUsageModel.GetFuelFeedLogByDayAndTypeAsync(this._fuelUsageView.FuelUseDay);
                _fuelUsageView.ShowFuelUsageByType(totalFuelByType);
            }
        }

        private async void FuelUsageView_OnFuelFeedDayChanged(object? sender, EventArgs e)
        {
            try
            {
                var log = await _fuelUsageModel.GetFuelFeedByDayAsync(_fuelUsageView.FuelFeedLogDate);
                if (log != null)
                {
                    _fuelUsageView.RefreshAllFuelLog(log);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error in Fuel Usage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FuelUsageView_OnFuelUseDayChanged(object? sender, EventArgs e)
        {
            try
            {
                var totalFuelByType = await this._fuelUsageModel.GetFuelFeedLogByDayAndTypeAsync(this._fuelUsageView.FuelUseDay);

                _fuelUsageView.ShowFuelUsageByType(totalFuelByType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error in Fuel Usage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        public void Dispose()
        {
            this._fuelUsageView.OnFuelFeedDayChanged -= FuelUsageView_OnFuelFeedDayChanged;
            this._fuelUsageView.OnFuelUseDayChanged -= FuelUsageView_OnFuelUseDayChanged;
            this._fuelUsageView.OnViewLoad -= FuelUsageView_OnViewLoad;

            this._timer.Tick -= OnTick;
            this._dbHealthService.DatabaseConnected -= OnDBConnected;
            this._dbHealthService.DatabaseDisconnected -= OnDBDisconnected;
            this._timer.Dispose();
        }
    }
}
