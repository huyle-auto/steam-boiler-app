using SteamBoilerApp.MVP.Views;
using SteamBoilerApp.Models;
using SteamBoilerApp.Properties;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using SteamBoilerApp.MachineSetting.Views;
using System.Diagnostics;
using SteamBoilerApp.MVP.Presenters;

namespace SteamBoilerApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, UserControl> _views = new();
        private UserControl? _currentView;

        private readonly LoginPresenter _loginPresenter;
        private readonly UserControl _machineSettingView;
        private readonly UserControl _appSettingView;
        private readonly UserControl _overviewView;
        private readonly UserControl _fuelUsageView;
        private readonly UserControl _pressureControlView;
        private readonly UserControl _scheduleView;

        public event EventHandler? LogOutRequested;

        public MainForm(LoginPresenter loginPresenter, UserControl machineSettingView, UserControl appSettingView, UserControl overviewView, UserControl fuelUsageView, UserControl pressureControlView, UserControl scheduleView)
        {
            InitializeComponent();

            this._loginPresenter = loginPresenter;
            this._machineSettingView = machineSettingView;
            this._appSettingView = appSettingView;
            this._overviewView = overviewView;
            this._fuelUsageView = fuelUsageView;
            this._pressureControlView = pressureControlView;
            this._scheduleView = scheduleView;

            this._loginPresenter.LoginSucceeded += OnLoginSucceeded;
        }

        private void OnLoginSucceeded(object? sender, string e)
        {
            Debug.WriteLine("MainForm - Username is: " + e);
        }

        private void ShowHideSubMenu(Panel subMenu)
        {
            subMenu.Visible = subMenu.Visible ? false : true;
        }

        private void btnProductionData_Click(object sender, EventArgs e)
        {
            ShowHideSubMenu(panelProductionDataSubMenu);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            ShowHideSubMenu(panelChartSubMenu);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log Out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogOutRequested?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ShowHideSubMenu(panelUserSubMenu);

        }

        // Only pass injected Views instances (from entry point) 
        private void ShowView(string key, Func<UserControl> createView)
        {
            // Create only once
            if (!_views.ContainsKey(key))
            {
                var view = createView();
                view.Dock = DockStyle.None;
                _views[key] = view;
                panelMainContent.Controls.Add(view);
            }

            // Hide old view
            if (_currentView != null)
                _currentView.Visible = false;

            // Show new view
            _currentView = _views[key];
            _currentView.Visible = true;
            _currentView.BringToFront();
        }

        private void btnMachineSetting_Click(object sender, EventArgs e)
        {
            ShowView("MachineSetting", () => _machineSettingView);
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            ShowView("Overview", () => _overviewView);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.PerformLayout();
            ShowView("Overview", () => _overviewView);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowView("AppSetting", () => _appSettingView);
        }

        private void btnFuelUseChart_Click(object sender, EventArgs e)
        {
            ShowView("FuelUse", () => _fuelUsageView);
        }

        private void btnPressureControlChart_Click(object sender, EventArgs e)
        {
            ShowView("PressureControl", () => _pressureControlView);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ShowView("Schedule", () => _scheduleView);
        }
    }
}
