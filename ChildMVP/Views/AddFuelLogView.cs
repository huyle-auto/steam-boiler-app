using SteamBoilerApp.ChildMVP.Contracts;
using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamBoilerApp.ChildMVP.Views
{
    public partial class AddFuelLogView : Form, IAddFuelLogView
    {
        public AddFuelLogView()
        {
            InitializeComponent();
        }

        private readonly int ID_FUEL_MASS_UNIT = 6;

        public event EventHandler? OnSaveClicked;
        public event EventHandler? OnCancelClicked;
        public event EventHandler? OnFormLoad;

        public FuelFeedLog GetFuelFeedLog()
        {
            if (cboFuelType.SelectedIndex == -1 || numFuelMass.Value == 0)
            {
                throw new Exception("Cannot add empty values.");
            }
            var log = new FuelFeedLog();
            log.FuelTypeId = (int)cboFuelType.SelectedValue;
            log.FuelMass = (int)numFuelMass.Value;
            log.UnitId = ID_FUEL_MASS_UNIT;
            log.Timestamp = dtpAddFuelTime.Value;
            return log;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClicked?.Invoke(this, EventArgs.Empty);
        }

        public void CloseOnSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddFuelLogView_Load(object sender, EventArgs e)
        {
            OnFormLoad?.Invoke(this, EventArgs.Empty);
        }

        public void LoadLookups(List<FuelType> fuelTypes)
        {
            cboFuelType.DataSource = fuelTypes;
            cboFuelType.DisplayMember = "FuelNameVn";
            cboFuelType.ValueMember = "FuelTypeId";
            cboFuelType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFuelType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
