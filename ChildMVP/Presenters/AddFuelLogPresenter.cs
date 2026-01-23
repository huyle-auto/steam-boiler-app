using SteamBoilerApp.ChildMVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.ChildMVP.Presenters
{
    public class AddFuelLogPresenter : IDisposable
    {
        private readonly IAddFuelLogView _view;
        private readonly IAddFuelLogModel _model;

        public AddFuelLogPresenter(IAddFuelLogView view, IAddFuelLogModel model)
        {
            _view = view;
            _model = model;
            _view.OnSaveClicked += OnSaveClicked;
            _view.OnCancelClicked += OnCancelClicked;
            _view.OnFormLoad += OnFormLoad;
        }

        public void Dispose()
        {
            _view.OnSaveClicked -= OnSaveClicked;
            _view.OnCancelClicked -= OnCancelClicked;
            _view.OnFormLoad -= OnFormLoad;
        }

        private void OnCancelClicked(object? sender, EventArgs e)
        {
            _view.Close();
        }

        private async void OnSaveClicked(object? sender, EventArgs e)
        {
            try
            {
                await _model.SaveFuelFeedLog(_view.GetFuelFeedLog());
                MessageBox.Show("Add Fuel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.CloseOnSuccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnFormLoad(object? sender, EventArgs e)
        {
            try
            {
                _view.LoadLookups(await _model.GetFuelTypesAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
