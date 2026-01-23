using SteamBoilerApp.MachineSetting.Contract;
using SteamBoilerApp.MachineSetting.Contracts;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MachineSetting.Presenters
{
    internal class MachineSettingPresenter : IDisposable
    {
        private readonly IMachineSettingView _settingView;
        private readonly IMachineSettingModel _settingModel;
        private readonly IDataExportService _dataExportService;
        private readonly IDatabaseHealthService _dbHealthService;

        private bool _isViewLoaded = false;

        public MachineSettingPresenter(IMachineSettingView settingView, IMachineSettingModel settingModel, IDataExportService dataExportService, IDatabaseHealthService dbHealthService)
        {
            this._settingView = settingView;
            this._settingModel = settingModel;
            this._dataExportService = dataExportService;
            this._dbHealthService = dbHealthService;

            this._settingView.OnViewLoad += OnViewLoad;
            this._settingView.RefreshClicked += OnRefreshClicked;
            this._settingView.SaveClicked += OnSaveClicked;
            this._settingView.DeleteClicked += OnDeleteClicked;
            this._settingView.RunOrderClicked += OnRunOrderClicked;
            this._settingView.PauseOrderClicked += OnPauseOrderClicked;
            this._settingView.FinishOrderClicked += OnFinishOrderClicked;
            this._settingView.ExportClicked += OnExportClicked;
            this._dbHealthService.DatabaseConnected += OnDBConnected;
            this._dbHealthService.DatabaseDisconnected += OnDBDisconnected;
        }

        private async void OnDBConnected(object? sender, EventArgs e)
        {
            if (!_isViewLoaded)
            {
                return;
            }

            try
            {
                await LoadLookups();
                OnRefreshClicked(sender, e);
            }
            catch
            {
                return;
            }
        }

        private void OnDBDisconnected(object? sender, EventArgs e)
        {

        }

        private async void OnExportClicked(object? sender, EventArgs e)
        {
            string fullPath = _settingView.ExportFullPath;

            if (string.IsNullOrWhiteSpace(fullPath))
            {
                MessageBox.Show("Empty folder or file name.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var data = await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate);
                await _dataExportService.ExportExcelAsync(fullPath, data);
                if (MessageBox.Show("Exported succesfully. Go to destination folder?", "Data Export", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    // Navigate to destination folder
                    string explorer = Environment.ExpandEnvironmentVariables(@"%windir%\explorer.exe");

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = explorer,
                        UseShellExecute = true,
                        Arguments = $"/select,\"{fullPath}\""
                    };

                    Process.Start(psi);
                    ;
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show(
                    "The file is currently open in Excel.\nPlease close it and try again.\n\n" + ioEx.Message,
                    "Export Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnViewLoad(object? sender, EventArgs e)
        {
            _isViewLoaded = true;
            if (_dbHealthService.IsConnected)
            {
                OnRefreshClicked(sender, e);
                await LoadLookups();
            }
        }

        private async void OnRefreshClicked(object? sender, EventArgs e)
        {
            try
            {
                _settingView.ShowOrder(await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate));
                _settingView.ShowStatus("Data refreshed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void OnSaveClicked(object? sender, EventArgs e)
        {
            try
            {
                _settingModel.SaveOrder(_settingView.GetNewOrderData());
                MessageBox.Show("Order saved successfully", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _settingView.ShowOrder(await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnDeleteClicked(object? sender, EventArgs e)
        {
            try
            {
                await _settingModel.DeleteOrder(_settingView.SelectedOrderId);
                MessageBox.Show("Order deleted successfully", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _settingView.ShowOrder(await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnRunOrderClicked(object? sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure to RUN this order?",
                    "Confirm Run Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _settingModel.CheckUnfinishedOrder(_settingView.SelectedOrderId);
                    _settingModel.UpdateOrderStatus(_settingView.SelectedOrderId, "RUN");
                    MessageBox.Show("Order is running", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _settingView.ShowOrder(await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnPauseOrderClicked(object? sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure to PAUSE this order?",
                    "Confirm Pause Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _settingModel.UpdateOrderStatus(_settingView.SelectedOrderId, "PAUSE");
                    MessageBox.Show("Order is paused", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _settingView.ShowOrder(await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnFinishOrderClicked(object? sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure to FINISH this order?",
                    "Confirm Finish Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _settingModel.UpdateOrderStatus(_settingView.SelectedOrderId, "FINISH");
                    MessageBox.Show("Order is finshed", "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _settingView.ShowOrder(await _settingModel.GetAllOrders(_settingView.FromDate, _settingView.ToDate));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLookups()
        {
            try
            {
                var customers = await _settingModel.GetCustomers();
                var fluteTypes = await _settingModel.GetFluteTypes();
                var paperTypes = await _settingModel.GetPaperTypes();
                var paperGrammages = await _settingModel.GetPaperGrammages();

                _settingView.SetCustomers(customers);
                _settingView.SetFluteTypes(fluteTypes);
                _settingView.SetPaperTypes(paperTypes);
                _settingView.SetPaperGrammages(paperGrammages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error in machinesetting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Dispose()
        {
            this._settingView.OnViewLoad -= OnViewLoad;
            this._settingView.RefreshClicked -= OnRefreshClicked;
            this._settingView.SaveClicked -= OnSaveClicked;
            this._settingView.DeleteClicked -= OnDeleteClicked;
            this._settingView.RunOrderClicked -= OnRunOrderClicked;
            this._settingView.PauseOrderClicked -= OnPauseOrderClicked;
            this._settingView.FinishOrderClicked -= OnFinishOrderClicked;
            this._settingView.ExportClicked -= OnExportClicked;
            this._dbHealthService.DatabaseConnected -= OnDBConnected;
            this._dbHealthService.DatabaseDisconnected -= OnDBDisconnected;
        }
    }
}
