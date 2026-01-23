using SteamBoilerApp.ChildMVP.Models;
using SteamBoilerApp.ChildMVP.Presenters;
using SteamBoilerApp.ChildMVP.Views;
using SteamBoilerApp.MVP.Contracts;

namespace SteamBoilerApp.MVP.Presenters
{
    public class FuelUsagePresenter
    {
        private readonly IFuelUsageView? _fuelUsageView;
        private readonly IFuelUsageModel? _fuelUsageModel;
        private readonly System.Windows.Forms.Timer _timer;
        private readonly IDatabaseHealthService _dbHealthService;

        private bool _isViewLoaded = false;

        public FuelUsagePresenter(IFuelUsageView fuelUsageView, IFuelUsageModel fuelUsageModel, IDatabaseHealthService dbHealthService)
        {
            this._fuelUsageView = fuelUsageView;
            this._fuelUsageModel = fuelUsageModel;
            this._fuelUsageView.OnViewLoad += FuelUsageView_OnViewLoad;
            this._fuelUsageView.OnFuelUseDayChanged += FuelUsageView_OnFuelUseDayChanged;
            this._fuelUsageView.OnFuelFeedDayChanged += FuelUsageView_OnFuelFeedDayChanged;
            this._fuelUsageView.OnAddNewLogClicked += FuelUsageView_OnAddNewLogClicked;

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

        private void OnTick(object? sender, EventArgs e)
        {
            FuelUsageView_OnFuelUseDayChanged(sender, e);
            FuelUsageView_OnFuelFeedDayChanged(sender, e);
        }

        private void FuelUsageView_OnViewLoad(object? sender, EventArgs e)
        {
            if (_dbHealthService.IsConnected)
            {
                this._timer.Tick += OnTick;
                this._timer.Start();
            }
        }

        private async void FuelUsageView_OnFuelFeedDayChanged(object? sender, EventArgs e)
        {
            try
            {
                var log = await _fuelUsageModel.GetFuelFeedLogAllAsync(_fuelUsageView.FuelFeedLogDate);
                if (log != null)
                {
                    _fuelUsageView.ShowFuelFeedLog(log);
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
                var totalFuelByType = await this._fuelUsageModel.GetFuelFeedLogByDayAsync(this._fuelUsageView.FuelUseDay);

                _fuelUsageView.ShowFuelUsageByType(totalFuelByType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error in Fuel Usage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void FuelUsageView_OnAddNewLogClicked(object? sender, EventArgs e)
        {
            using (var view = new AddFuelLogView())
            {
                // Assume MODEL has no memory leak potential with PRESENTER
                // -> no manual dispose -> GC collects all
                using (var presenter = new AddFuelLogPresenter(view, new AddFuelLogModel()))
                {
                    view.ShowDialog();
                }
            }
        }
    }
}
