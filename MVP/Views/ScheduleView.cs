using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamBoilerApp.MVP.Views
{
    public partial class ScheduleView : UserControl, IScheduleView
    {
        public ScheduleView()
        {
            InitializeComponent();
        }

        public event EventHandler? ViewLoad;

        public void SetRuntimeData(Dictionary<string, string> data)
        {
            this.BeginInvoke(new Action(() =>
            {
                lblRemainTime.Text = data.ContainsKey("TimeRemaining") ? data["TimeRemaining"] : "N/A";
                lblCurrentSpeed.Text = data.ContainsKey("CurrentSpeed") ? data["CurrentSpeed"] : "N/A";
                lblRemainLineal.Text = data.ContainsKey("LinealRemain") ? data["LinealRemain"] : "N/A";
                lblRemainCuts.Text = data.ContainsKey("CutsRemain") ? data["CutsRemain"] : "N/A";
            }));
        }
        public void SetScheduleData(DataTable table)
        {
            this.BeginInvoke(new Action(() =>
            {
                tableSchedule.DataSource = table;
                tableSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewRow row in tableSchedule.Rows)
                {
                    // Check if the first column (index 0) value is 0
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "0")
                    {
                        row.DefaultCellStyle.BackColor = Color.LimeGreen;
                        row.DefaultCellStyle.ForeColor = Color.White;

                        break;
                    }
                }
            }));
        }

        private void ScheduleView_Load(object sender, EventArgs e)
        {
            ViewLoad?.Invoke(this, EventArgs.Empty);
        }
    }
}
