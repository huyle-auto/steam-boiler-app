using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Presenters
{
    public class SchedulePresenter
    {
        private readonly IScheduleView _view;
        private readonly IScheduleModel _model;
        private readonly IDataExportService _dataExportService;
        private readonly IScheduleClientService _scheduleClientService;

        private bool _isViewLoad = false;

        public SchedulePresenter(IScheduleView view, IScheduleModel model, IDataExportService dataExportService, IScheduleClientService scheduleClientService)
        {
            this._view = view;
            this._model = model;
            this._dataExportService = dataExportService;

            this._view.ViewLoad += OnViewLoad;
            this._scheduleClientService = scheduleClientService;
            this._scheduleClientService.JsonReceived += OnJsonReceived;
        }

        private void OnJsonReceived(object? sender, string json)
        {
            if (!_isViewLoad)
            {
                return;
            }

            try
            {
                var payload = JsonHandler.Parse(json);
                DataTable table = payload.GetTable("orders");

                _view.SetScheduleData(table);

                var runtime = payload.GetRuntime();
                _view.SetRuntimeData(runtime);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error at SchedulePresenter: " + ex.Message);
            }
        }

        private void OnViewLoad(object? sender, EventArgs e)
        {
            _isViewLoad = true;
        }
    }
}
