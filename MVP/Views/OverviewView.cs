using Microsoft.IdentityModel.Tokens;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SteamBoilerApp.MachineSetting.Views
{
    public partial class OverviewView : UserControl, IOverviewView
    {
        public OverviewView()
        {
            InitializeComponent();
            this.Load += OverviewView_Load;
        }

        private void OverviewView_Load(object? sender, EventArgs e)
        {
            LoadLookups();
            cboFuelDist.SelectedIndex = 3;  // Set to "Last month" for best reference
        }

        public DateTime FuelDistFromDate { get; set; }
        public DateTime FuelDistToDate { get; set; }

        public event EventHandler? CboFuelDistClicked;

        public void SetPressureGauge(double pressure)
        {
            gaugeSteamPressure.Value = Math.Round(pressure, 2, MidpointRounding.AwayFromZero);
        }

        public void ShowDistributionChart(Dictionary<string, int> data)
        {
            var series = chartFuelDist.Series["PieSeries"];
            series.Points.Clear();

            // Receive raw total mass, distribute into percentages here
            var totalMass = data.Values.Sum();

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, (double)item.Value / totalMass * 100.0);
            }

            series.Sort(PointSortOrder.Descending, "Y");
        }

        private void cboFuelDistribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFuelDist.Text)
            {
                case "Today":
                    FuelDistFromDate = DateTime.Today;  // 00:00:00 AM
                    FuelDistToDate = DateTime.Now;
                    break;
                case "Last 3 days":
                    FuelDistFromDate = DateTime.Today.AddDays(-3);
                    FuelDistToDate = DateTime.Now;
                    break;
                case "Last week":
                    FuelDistFromDate = DateTime.Today.AddDays(-7);
                    FuelDistToDate = DateTime.Now;
                    break;
                case "Last month":
                    FuelDistFromDate = DateTime.Today.AddDays(-30);
                    FuelDistToDate = DateTime.Now;
                    break;
                case "Last 3 months":
                    FuelDistFromDate = DateTime.Today.AddDays(-90);
                    FuelDistToDate = DateTime.Now;
                    break;
                case "Last 6 months":
                    FuelDistFromDate = DateTime.Today.AddDays(-180);
                    FuelDistToDate = DateTime.Now;
                    break;
                case "Last year":
                    FuelDistFromDate = DateTime.Today.AddDays(-365);
                    FuelDistToDate = DateTime.Now;
                    break;
            }
            CboFuelDistClicked?.Invoke(this, EventArgs.Empty);
        }

        public void LoadLookups()
        {
            cboFuelDist.Items.Clear();
            cboFuelDist.Items.Add("Today");
            cboFuelDist.Items.Add("Last 3 days");
            cboFuelDist.Items.Add("Last week");
            cboFuelDist.Items.Add("Last month");
            cboFuelDist.Items.Add("Last 3 months");
            cboFuelDist.Items.Add("Last 6 months");
            cboFuelDist.Items.Add("Last year");
        }
    }
}
