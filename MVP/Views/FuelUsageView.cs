using SteamBoilerApp.Models;
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
        public event EventHandler? OnRefreshAllLogClicked;

        private BindingSource _feedLogBs = [];

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

        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            OnRefreshAllLogClicked?.Invoke(this, EventArgs.Empty);
        }

        public void RefreshFuelLogKeepFilter(List<FuelFeedLog> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => RefreshFuelLogKeepFilter(data)));
                return;
            }

            // 1️. Capture filter and sort from BindingSource
            string? currentFilter = _feedLogBs.Filter;
            string? currentSort = _feedLogBs.Sort;

            // 2️. Replace data source only
            _feedLogBs.DataSource = BuildFeedLogTable(data);

            // 3️. Restore filter
            if (!string.IsNullOrWhiteSpace(currentFilter))
                _feedLogBs.Filter = currentFilter;

            // 4️. Restore sort
            if (!string.IsNullOrWhiteSpace(currentSort))
                _feedLogBs.Sort = currentSort;
        }

        public void RefreshAllFuelLog(List<FuelFeedLog> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => RefreshAllFuelLog(data)));
                return;
            }

            // 1. Reset the UI icons and internal filter/sort strings
            tableFuelFeedLog.CleanFilter();
            tableFuelFeedLog.CleanSort();
            tableFuelFeedLog.ClearSelection();

            // 2. Clear any active filter on the data source itself
            if (tableFuelFeedLog.DataSource is BindingSource bs)
            {
                bs.Filter = null;
                bs.Sort = null;
            }

            // 3. Load fresh table
            LoadFuelFeedLog(data);
        }

        public void LoadFuelFeedLog(List<FuelFeedLog> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => LoadFuelFeedLog(data)));
            }

            _feedLogBs.DataSource = BuildFeedLogTable(data);

            tableFuelFeedLog.AutoGenerateColumns = true;
            tableFuelFeedLog.AllowUserToAddRows = false;
            tableFuelFeedLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableFuelFeedLog.DataSource = _feedLogBs;

            tableFuelFeedLog.Columns["Id"].ReadOnly = true;
            tableFuelFeedLog.Columns["Id"].Visible = false;
            tableFuelFeedLog.Columns["Fuel Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableFuelFeedLog.Columns["Mass"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableFuelFeedLog.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tableFuelFeedLog.Columns["Timestamp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private static DataTable BuildFeedLogTable(List<FuelFeedLog> list)
        {
            var table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Fuel Type", typeof(string));
            table.Columns.Add("Mass", typeof(int));
            table.Columns.Add("Unit", typeof(string));

            table.Columns.Add("Timestamp", typeof(DateTime));

            foreach (var item in list)
            {
                table.Rows.Add(
                    item.FuelFeedLogId,
                    item.FuelType.FuelName,
                    item.FuelMass,
                    item.Unit.Symbol,
                    item.Timestamp
                );
            }

            return table;
        }

        private static void EnableDoubleBuffer(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)!
                .SetValue(control, true);
        }

        private void FuelUsageView_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffer(tableFuelFeedLog);
            OnViewLoad?.Invoke(this, EventArgs.Empty);
        }
    }
}
