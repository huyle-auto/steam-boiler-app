using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.ViewModels;
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
    public partial class FuelUsageView : UserControl, IFuelUsageView
    {
        public FuelUsageView()
        {
            InitializeComponent();
        }

        public DateTime FuelUseDay => dtpFuelUsageDay.Value;
        public DateTime FuelFeedLogDate => dtpFuelFeedLog.Value;

        public event EventHandler? OnViewLoad;
        public event EventHandler? OnFuelUseDayChanged;
        public event EventHandler? OnFuelFeedDayChanged;
        public event EventHandler? OnAddNewLogClicked;

        public void ShowFuelUsageByType(Dictionary<string, int> data)
        {
            List<Label> fuelNames = new List<Label> {
                lblFirstFuelName, lblSecondFuelName, lblThirdFuelName, lblFourthFuelName
            };

            List<Label> fuelUsed = new List<Label> {
                lblFirstFuelUsed, lblSecondFuelUsed, lblThirdFuelUsed, lblFourthFuelUsed
            };

            // Hide all first
            for (int i = 0; i < fuelNames.Count; i++)
            {
                fuelNames[i].Visible = false;
                fuelUsed[i].Visible = false;
            }

            int index = 0;

            foreach (var item in data)
            {
                if (index >= fuelNames.Count)
                    break; // prevent overflow if more than 3 types  

                fuelNames[index].Text = item.Key;       // Fuel name
                fuelUsed[index].Text = item.Value.ToString(); // Fuel mass

                fuelNames[index].Visible = true;
                fuelUsed[index].Visible = true;

                index++;
            }
        }

        private void dtpFuelUsage_ValueChanged(object sender, EventArgs e)
        {
            OnFuelUseDayChanged?.Invoke(this, EventArgs.Empty);
        }

        private void dtpFuelFeedLog_ValueChanged(object sender, EventArgs e)
        {
            OnFuelFeedDayChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddFuelLog_Click(object sender, EventArgs e)
        {
            OnAddNewLogClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ShowFuelFeedLog(List<FuelFeedSummary> data)
        {
            tableFuelFeedLog.DataSource = data;
            tableFuelFeedLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FuelUsageView_Load(object sender, EventArgs e)
        {
            OnViewLoad?.Invoke(this, EventArgs.Empty);
        }
    }
}
