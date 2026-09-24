using SteamBoilerApp.Configs;
using SteamBoilerApp.HWConfig;
using SteamBoilerApp.MachineSetting.Views;
using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.MVP.Controls;
using SteamBoilerApp.MVP.Models;
using SteamBoilerApp.MVP.Presenters;
using SteamBoilerApp.MVP.Services;
using SteamBoilerApp.MVP.Views;
using SteamBoilerApp.Toast;
using System.Text.Json;

namespace SteamBoilerApp
{
    internal static class Program
    {
        private static readonly string mutexName = "SteamBoilerApp_Unique_Mutex_Name";
        private static Mutex mutex = new Mutex(true, mutexName);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // SINGLE INSTANCE CHECK
            if (!mutex.WaitOne(TimeSpan.Zero, false))
            {
                // Another instance is already running
                MessageBox.Show("Another instance of the application is already running.", "Instance Already Running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ------------------------------ APPLICATION CONTENT -------------------------------
            ToastRegistration.Register();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // HARDWARE CONFIGURATION
            string json = File.ReadAllText("Configs/modbus_settings.json");
            var modbusConfig = JsonSerializer.Deserialize<ModbusDeviceConfig>(json);

            string mqttV311Json = File.ReadAllText("Configs/mqtt_settings_v311.json");
            var mqttConfigV311 = JsonSerializer.Deserialize<MqttConfigV311>(mqttV311Json);

            string mqttV50Json = File.ReadAllText("Configs/mqtt_settings_v50.json");
            var mqttConfigV50 = JsonSerializer.Deserialize<MqttConfigV50>(mqttV50Json);

            // CONTROL CONFIGURATION
            string pidJson = File.ReadAllText("Configs/control_config.json");
            var controlConfig = JsonSerializer.Deserialize<ControlConfig>(pidJson);

            // SERVICE
            var toastService = new ToastNotificationService();
            var modbusService = new ModbusTCPService(modbusConfig ?? new ModbusDeviceConfig()); // Return empty config if deserialization fails to prevent crash
            var mqttV311Service = new MqttV311Service(mqttConfigV311 ?? new MqttConfigV311());  
            var mqttV50Service = new MqttV50Service(mqttConfigV50 ?? new MqttConfigV50()); 
            var dataExportService = new DataExportService();
            var dbHealthService = new DatabaseHealthService();
            var dataAcqService = new DataAcquisitionService();
            var scheduleClientService = new ScheduleClientService();

            // CONTROL
            var pidController = new PidController(controlConfig ?? new ControlConfig());
            var pidAutoTuner = new PidAutoTuner();

            // MACHINE SETTING
            var machineSettingView = new MachineSetting.Views.MachineSettingView();
            var machineSettingModel = new MachineSetting.Models.MachineSettingModel();
            var machineSettingPresenter = new MachineSetting.Presenters.MachineSettingPresenter(machineSettingView, machineSettingModel, dataExportService, dbHealthService);

            // APP SETTING
            var appSettingView = new MVP.Views.AppSettingView();
            var appSettingModel = new MVP.Models.AppSettingModel(modbusService);
            var appSettingPresenter = new MVP.Presenters.AppSettingPresenter(appSettingView, appSettingModel, modbusService, dbHealthService, dataAcqService, scheduleClientService, toastService, mqttV311Service, mqttV50Service);

            // OVERVIEW
            var overviewView = new OverviewView();
            var overviewModel = new OverviewModel(modbusService);
            var overviewPresenter = new OverviewPresenter(overviewView, overviewModel, modbusService);

            // FUEL USAGE
            var fuelUsageView = new MVP.Views.FuelUsageView();
            var fuelUsageModel = new MVP.Models.FuelUsageModel();
            var fuelUsagePresenter = new MVP.Presenters.FuelUsagePresenter(fuelUsageView, fuelUsageModel, dbHealthService);

            // PRESSURE CONTROL
            var pressureControlView = new PressureControlView();
            var pressureControlModel = new PressureControlModel(pidController);
            var pressureControlPresenter = new PressureControlPresenter(pressureControlView, pressureControlModel, dataAcqService, dbHealthService, dataExportService, scheduleClientService, modbusService, pidAutoTuner, controlConfig);

            // SCHEDULE
            var scheduleView = new ScheduleView();
            var scheduleModel = new ScheduleModel();
            var schedulePresenter = new SchedulePresenter(scheduleView, scheduleModel, dataExportService, scheduleClientService);

            // LOGIN
            using var loginView = new LoginView();
            using var loginPresenter = new LoginPresenter(loginView, new AuthService());

            // Only pass views to MainForm
            var mainForm = new MainForm(loginPresenter, machineSettingView, appSettingView, overviewView, fuelUsageView, pressureControlView, scheduleView);

            // ------------------------------ APPLICATION FLOW -------------------------------

            // ---- LOGIN PHASE ----
            bool loginSuccess = false;
            bool logoutRequested = false;

            // Subscribe
            loginPresenter.LoginSucceeded += (_, __) =>
            {
                loginSuccess = true;
                loginPresenter.Dispose();
            };

            mainForm.LogOutRequested += (_, __) =>
            {
                logoutRequested = true;
                mainForm.Dispose();
            };

            Application.Run(loginView); // Blocks until Login form closes

            if (!loginSuccess)   // Login form closes manually -> exit app
            {
                return; 
            }

            // ---- MAIN APP PHASE ----
            Application.Run(mainForm);

            // ---- LOGOUT PHASE ----
            if (logoutRequested)
            {
                Application.Restart();
            }

            // RELEASE MUTEX AT CLOSE
            mutex.ReleaseMutex();
        }
    }
}