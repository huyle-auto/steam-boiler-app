using SteamBoilerApp.ChildMVP.Models;
using SteamBoilerApp.ChildMVP.Presenters;
using SteamBoilerApp.ChildMVP.Views;
using SteamBoilerApp.Configs;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.MVP.Services;
using SteamBoilerApp.Utils;
using System.Diagnostics;

namespace SteamBoilerApp.MVP.Presenters
{
    public class PressureControlPresenter : IDisposable
    {
        private readonly System.Windows.Forms.Timer _chartTimer;
        private DateTime _lastTimestamp;

        private readonly System.Threading.Timer _pidTimer;
        private readonly int PID_TICK_TIME = 0; // Must be equal to advisory window time (-> ControlConfig)
        private readonly System.Windows.Forms.Timer _calcCountdownTimer;

        private readonly IPressureControlView _view;
        private readonly IPressureControlModel _model;

        private readonly IDataAcquisitionService _dataAcqService;
        private readonly IDatabaseHealthService _dbHealthService;
        private readonly IDataExportService _dataExportService;
        private readonly IScheduleClientService scheduleClientService;
        private readonly IModbusTCPService _modbusService;
        private readonly IPidAutoTuner _tuner;

        private readonly ControlConfig _controlConfig;

        private bool _polling = false;
        private bool _viewLoaded = false;

        private bool _isAutoTuning = false; // AUTO-TUNING = OFF, PID = ON intially
        private double _currentBaselinePressure = 0.0;

        private static readonly object _timeLocker = new object();
        private DateTime _nextAdvisoryDue = DateTime.MinValue;
        private DateTime _nextCommitDue = DateTime.MinValue;

        // PRODUCTION STATE FOR ALARM GUARD
        private DateTime? _productionEntryStart;
        private DateTime? _productionExitStart;

        private bool _isProduction = false;

        public PressureControlPresenter(IPressureControlView view, IPressureControlModel model, IDataAcquisitionService dataAcqService, IDatabaseHealthService dbHealthService, IDataExportService dataExportService, IScheduleClientService scheduleClientService, IModbusTCPService modbusService, IPidAutoTuner tuner, ControlConfig controlConfig)
        {
            this._view = view;
            this._model = model;

            this._view.LiveDataClicked += RefreshChartAsync;
            this._view.RefreshClicked += RefreshChartAsync;
            this._view.ExportClicked += OnExportClicked;
            this._view.ViewLoad += OnViewLoad;
            this._view.SavePidConfigClicked += OnSavePidConfigClicked;
            this._view.AutoTuneClicked += OnAutoTuneClicked;
            this._view.ApplyParamClicked += OnApplyParamClicked;
            this._view.CancelAutoTuneClicked += OnCancelAutoTuneClicked;
            this._view.AddFuelClicked += OnAddFuelClicked;
            this._view.ToggleAlarmClicked += OnToggleAlarmClicked;

            this._dataAcqService = dataAcqService;
            this._dbHealthService = dbHealthService;
            this._dataExportService = dataExportService;

            this._dbHealthService.DatabaseConnected += OnDBConnected;
            this._dbHealthService.DatabaseDisconnected += OnDBDisconnected;

            _chartTimer = new System.Windows.Forms.Timer();
            _chartTimer.Interval = 1000;

            this.scheduleClientService = scheduleClientService;
            this.scheduleClientService.JsonReceived += OnJsonReceived;

            this._modbusService = modbusService;
            this._modbusService.SnapshotUpdated += OnSnapshotUpdated;
            this._modbusService.ModbusConnected += OnModbusConnected;
            this._modbusService.ModbusDisconnected += OnModbusDisconnected;

            // Control Config
            _controlConfig = controlConfig;

            // PID Auto Tuner
            this._tuner = tuner;
            this._tuner.TuneCompleted += OnAutoTuneCompleted;
            this._tuner.TuneFailed += OnAutoTuneFailed;

            // PID Timer
            this._pidTimer = new System.Threading.Timer(
                async _ => await PidCalcAsync(),
                null,
                Timeout.Infinite,
                Timeout.Infinite
            );

            PID_TICK_TIME = (int)(_controlConfig.AdvisoryWindowSeconds * 1000) ;
            _pidTimer.Change(0, PID_TICK_TIME);

            this._calcCountdownTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            this._calcCountdownTimer.Tick += OnCalcTimerTick;
            this._calcCountdownTimer.Start();
        }

        private void OnToggleAlarmClicked(object? sender, EventArgs e)
        {
            if (!_modbusService.IsConnected)
            {
                MessageBox.Show("Please connect Data Logger first.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.UpdateAlarmState();

            if (!_view.IsAlarmEnabled)
            {
                _isProduction = false;
            }
            else
            {
                // Do not set _isProduction = true here, let detection decide
                _productionEntryStart = DateTime.Now;
            }
        }

        private void InitCalcCheckpoint()
        {
            var now = DateTime.Now;

            _nextAdvisoryDue = now.AddSeconds(_controlConfig.AdvisoryWindowSeconds);
            _nextCommitDue = now.AddSeconds(_controlConfig.CommitWindowSeconds);

            _view.UpdateCountdowns(_nextAdvisoryDue - now, _nextCommitDue - now);
        }

        private void OnModbusConnected(object? sender, EventArgs e)
        {
            if (_dbHealthService.IsConnected)
            {
                InitCalcCheckpoint();

                _pidTimer.Change(0, PID_TICK_TIME);
                _calcCountdownTimer.Stop();
                _calcCountdownTimer.Start();
            }
        }

        private void OnModbusDisconnected(object? sender, EventArgs e)
        {
            _pidTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _calcCountdownTimer.Stop();
        }

        private void OnCalcTimerTick(object? sender, EventArgs e)
        {
            if (!_viewLoaded || !_modbusService.IsConnected)
            {
                return;
            }

            var now = DateTime.Now;

            var advisoryRemaining = _nextAdvisoryDue - now;
            var commitRemaining = _nextCommitDue - now;

            if (advisoryRemaining < TimeSpan.Zero)
            {
                advisoryRemaining = TimeSpan.Zero;
            }

            if (commitRemaining < TimeSpan.Zero)
            {
                commitRemaining = TimeSpan.Zero;
            }

            //// Freeze advisory countdown last cycle before commit due
            if (commitRemaining <= TimeSpan.FromSeconds(_controlConfig.AdvisoryWindowSeconds))
            {
                advisoryRemaining = TimeSpan.Zero;
            }

            _view.UpdateCountdowns(advisoryRemaining, commitRemaining);

            //Debug.WriteLine("advisory remaining: " + advisoryRemaining.TotalSeconds + " seconds");
            //Debug.WriteLine("commit remaining: " + commitRemaining.TotalSeconds + " seconds");
        }

        private async Task PidCalcAsync()
        {
            if (!_viewLoaded || !_modbusService.IsConnected)
            {
                return;
            }

            var now = DateTime.Now;

            var advisoryWindowSeconds = _controlConfig.AdvisoryWindowSeconds;
            var commitWindowSeconds = _controlConfig.CommitWindowSeconds;

            bool advisoryDue = now >= _nextAdvisoryDue.AddSeconds(-1/12);
            bool commitDue = now >= _nextCommitDue.AddSeconds(-1/12);

            //Debug.WriteLine("advisoryDue is: " + advisoryDue);
            //Debug.WriteLine("commitDue is: " + commitDue);

            try
            {
                if (commitDue)
                {
                    var averagePV = await _model.GetAveragePVAsync(from: DateTime.Now.AddSeconds(-commitWindowSeconds), DateTime.Now);
                    var energyMJ = _model.ComputePiOutput(setpoint: _view.PressureSetpoint, averagePV, deltaTimeSeconds: commitWindowSeconds);

                    if (energyMJ > 0)
                    {
                        var fuelOptions = await _model.CalculateEquivalentFuelKgAsync(energyMJ);
                        _view.EvaluatePressureState(averagePV, fuelOptions);
                    }
                    else
                    {
                        _view.EvaluatePressureState(averagePV, []);
                    }

                    lock (_timeLocker)
                    {
                        _nextCommitDue = now.AddSeconds(_controlConfig.CommitWindowSeconds);
                        _nextAdvisoryDue = now.AddSeconds(_controlConfig.AdvisoryWindowSeconds);
                    }

                    //Debug.WriteLine("Last commit time: " + now);
                }
                else if (advisoryDue)
                {
                    var averagePV = await _model.GetAveragePVAsync(from: DateTime.Now.AddSeconds(-_controlConfig.AdvisoryWindowSeconds), DateTime.Now);
                    var energyMJ = _model.ComputePOutput(setpoint: _view.PressureSetpoint, averagePV, deltaTimeSeconds: _controlConfig.AdvisoryWindowSeconds);

                    if (energyMJ > 0)
                    {
                        var fuelOptions = await _model.CalculateEquivalentFuelKgAsync(energyMJ);
                        _view.EvaluatePressureState(averagePV, fuelOptions);
                    }
                    else
                    {
                        _view.EvaluatePressureState(averagePV, []);
                    }

                    lock (_timeLocker)
                    {
                        _nextAdvisoryDue = now.AddSeconds(_controlConfig.AdvisoryWindowSeconds);
                    }

                    //Debug.WriteLine("Last advisory time: " + now);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in PID calc:" + ex.Message);
                FileLogger.Log("Error in PID calc: " + ex.Message);
            }
        }

        private async void OnViewLoad(object? sender, EventArgs e)
        {
            _viewLoaded = true;

            if (_modbusService.IsConnected)
            {
                InitCalcCheckpoint();
            }

            try
            {
                // Init PID controller with latest params
                var pidConfig = await _model.GetLatestPidConfigAsync();

                if (pidConfig == null)
                {
                    MessageBox.Show("Cannot find latest PID parameters. \nPlease create a new parameter set", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _view.SetPidConfig(pidConfig);  // Reset integral gain
                _model.ConfigurePid(pidConfig);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error initiating PID default: " + ex.Message);
                MessageBox.Show("Cannot find latest PID parameters. \nPlease tune a new parameter set. \n" + ex.Message, "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnJsonReceived(object? sender, string e)
        {

        }

        private void OnSnapshotUpdated(object? sender, ModbusSnapshot e)
        {
            try
            {
                var data = (List<SensorDatum>)_modbusService.ExtractSensorValues(e);
                var pressureRecord = data.Where(s => s.SensorId == 1).FirstOrDefault();

                if (pressureRecord == null)
                {
                    throw new Exception("pressureRecord is NULL");
                }

                // ------- RULE: either AUTO-TUNING or PID is active at a time -------

                if (_isAutoTuning)  // AUTO-TUNING
                {
                    _tuner.Update(Convert.ToDouble(pressureRecord.EngineeringValue));
                }
                else   // PID 
                {
                    _currentBaselinePressure = Convert.ToDouble(pressureRecord.EngineeringValue);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error handling snapshot: " + ex.Message);
            }
        }

        private void OnAutoTuneCompleted(object? sender, (double Kp, double Ki)? e)
        {
            _isAutoTuning = false;

            if (e == null)
            {
                MessageBox.Show("Auto Tuning failed. \nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Debug.WriteLine("$Auto tune result: Kp={0}, Ki={1}, Kd=0.0", e.Value.Kp, e.Value.Ki);
            _view.ShowAutoTuneResult(e.Value.Kp, e.Value.Ki, 0.0);
        }

        private void OnAutoTuneFailed(object? sender, string e)
        {
            _isAutoTuning = false;
            MessageBox.Show("Auto Tuning failed: \n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _tuner.Reset();
            _view.CloseAutoTunePanel();
        }

        private void OnAutoTuneClicked(object? sender, EventArgs e)
        {
            if (_isAutoTuning)
            {
                return;
            }

            if (!_modbusService.IsConnected)
            {
                MessageBox.Show("Please connect to Data Logger.", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("Are you sure to Auto Tune the controller? " +
                "\nPlease do not auto tune mid-process without administration. " +
                "\n Go back if you are not sure",
                "Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var instruction = MessageBox.Show("Please follow the instructions step-by-step.", "Instructions", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            _view.ShowAutoTunePanel();

            _isAutoTuning = true;

            _tuner.Start(_currentBaselinePressure);
            Debug.WriteLine("Started auto tuning with baseline pressure: " + _currentBaselinePressure.ToString("F2"));
        }

        private void OnApplyParamClicked(object? sender, EventArgs e)
        {
            _isAutoTuning = false;

            var apply = MessageBox.Show("Are you sure to apply new parameters? \nPlease do not apply mid-process. \n Follow update instructions from guide book.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (apply == DialogResult.Yes)
            {
                _view.ApplyAutoTuneResult();    // Apply and save in _view, load new set immediately
            }
        }

        private void OnCancelAutoTuneClicked(object? sender, EventArgs e)
        {
            _isAutoTuning = false;
            _tuner.Reset();
            _view.CloseAutoTunePanel();
        }

        private async void OnAddFuelClicked(object? sender, string e)
        {
            using var view = new AddFuelLogView();
            using var presenter = new AddFuelLogPresenter(view, new AddFuelLogModel());

            var success = view.ShowDialog();

            if (success == DialogResult.OK)
            {
                if (!_modbusService.IsConnected || !_dbHealthService.IsConnected)    // Regular feed if no connection
                {
                    return;
                }

                try
                {
                    var log = await _model.GetLatestFeedLogAsync();

                    if (log == null)
                    {
                        throw new Exception("Invalid Latest Feed Log");
                    }

                    double mass = (double)log.FuelMass;
                    double calorific = (double)log.FuelType.FuelLhv;

                    if (e == "tuner")
                    {
                        _tuner.RegisterFuelInput(fuelMassKg: mass, calorificValueMJPerKg: calorific);
                        Debug.WriteLine("Injected energy Auto-Tuner: " + mass * calorific + " MJ");
                    }
                    else if (e == "pid")
                    {
                        _model.InjectEnergy(mass * calorific);
                        _view.ShowMessageOnFuelInjected();
                        Debug.WriteLine("Injected energy for PID: " + mass * calorific + " MJ");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error adding fuel log while auto tuning: " + ex.Message);
                    FileLogger.Log("Error while auto tuning: " + ex.Message);
                }
            }
        }

        private async void OnSavePidConfigClicked(object? sender, EventArgs e)
        {
            try
            {
                var config = _view.GetPidConfig();
                await _model.SavePidConfigAsync(config);
                _model.ConfigurePid(config); // Reconfigure immediately to run

                MessageBox.Show("Saved paramter set successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eror initiating PID default: " + ex.Message);
                MessageBox.Show("Error saving parameter set: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDBConnected(object? sender, EventArgs e)
        {
            if (!_viewLoaded || !_modbusService.IsConnected)
            {
                return;
            }

            StartPolling();

            if (_modbusService.IsConnected)
            {
                InitCalcCheckpoint();
                _pidTimer.Change(0, PID_TICK_TIME);
                _calcCountdownTimer.Stop();
                _calcCountdownTimer.Start();
            }
        }

        private void OnDBDisconnected(object? sender, EventArgs e)
        {
            StopPolling();

            _pidTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _calcCountdownTimer.Stop();
        }

        private async void RefreshChartAsync(object? sender, EventArgs e)
        {
            if (_view.FromDate > _view.ToDate)
            {
                MessageBox.Show("Please set FROM earlier than TO", "Date/Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var data = await _dataAcqService.GetSensorDataAsync(sensorId: 1, fromDate: _view.FromDate, ToDate: _view.ToDate);

                // Add data points
                if (true)
                {
                    _view.LoadInitialData(data);
                    _lastTimestamp = _view.ToDate;
                }


                if (_view.IsLiveData)
                {
                    StartPolling();

                    // Clear annotations in Live Data
                    _view.ClearAnnotations();
                }
                else
                {
                    StopPolling();

                    // Add annotations on Refresh
                    await LoadFeedAnnotations(from: _view.FromDate, to: _view.ToDate);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("<Pressure Control> refresh error: " + ex.Message.ToString());
            }
        }

        private async void PollLatestAsync(object? sender, EventArgs e)
        {
            // Timer does not await Tick method. Guard if timer fires before operation is done
            if (_polling)
            {
                return;
            }

            _polling = true;
            try
            {
                var sw = Stopwatch.StartNew();

                var latest = await _dataAcqService.GetSensorLatestValueAsync(sensorId: 1, _lastTimestamp);

                if (latest == null)
                {
                    return;
                }

                sw.Stop();
                // Debug.WriteLine("PollLatestAsync latency: " + sw.ElapsedMilliseconds + " ms");

                // Draw chart
                _lastTimestamp = latest.Timestamp;
                _view.AppendSensorPoint(latest.Timestamp, Convert.ToDouble(latest.EngineeringValue));

                // ----------------------------------------------------------------------
                // -------------------- FLASHING LED & PROCESS ALARM --------------------
                // ----------------------------------------------------------------------
                var pressure = Convert.ToDouble(latest.EngineeringValue);

                // PRODUCTION ENTRY / EXIT DETECTION
                var now = DateTime.Now;

                if (pressure > _controlConfig.MinProductionPressure)
                {
                    _productionExitStart = null;

                    if (_productionEntryStart == null)
                    {
                        _productionEntryStart = now;
                    }

                    if ((now - _productionEntryStart.Value).TotalSeconds >= 30) // 30 seconds in production range, PRODUCTION confirmed
                    {
                        _isProduction = true;
                    }
                }
                else
                {
                    _productionEntryStart = null;

                    if (_productionExitStart == null)
                    {
                        _productionExitStart = now;
                    }
                    if ((now - _productionExitStart.Value).TotalSeconds >= 60) // 60 seconds out of production range, EXIT PRODUCTION confirmed
                    {
                        _isProduction = false;
                    }
                }

                // ALARMING
                if (!_view.IsAlarmEnabled)
                {
                    await _modbusService.WriteAllDigitalOutputsAsync([false, false, false, false]);

                    _view.FlashingStatusLED(Color.White);
                    _view.SetStatusText("Alarm OFF");

                    return; // Reset all alarm if toggled off
                }

                if (_modbusService.IsConnected && !_isProduction)
                {
                    await _modbusService.WriteAllDigitalOutputsAsync([false, false, false, false]);
                    return; // Reset all alarm if not in production
                }

                if (pressure >= _controlConfig.PressureHighHighLimit)   // HIGH HIGH
                {
                    _view.FlashingStatusLED(Color.Red);
                    _view.SetStatusText("Attention. Pressure VERY HIGH !");

                    if (_modbusService.IsConnected & _isProduction)
                    {
                        await _modbusService.WriteAllDigitalOutputsAsync([true, false, false, false]);
                    }
                }

                else if (pressure >= _controlConfig.PressureHighLimit)   // HIGH
                {
                    _view.FlashingStatusLED(Color.Yellow);
                    _view.SetStatusText("Pressure HIGH !");

                    if (_modbusService.IsConnected & _isProduction)
                    {
                        await _modbusService.WriteAllDigitalOutputsAsync([true, false, false, false]);
                    }
                }

                else if (pressure < _controlConfig.PressureLowLowLimit)    // LOW LOW
                {
                    _view.FlashingStatusLED(Color.Red);
                    _view.SetStatusText("Attention. Pressure VERY LOW !");

                    if (_modbusService.IsConnected & _isProduction)
                    {
                        await _modbusService.WriteAllDigitalOutputsAsync([true, false, false, false]);
                    }
                }

                else if (pressure < _controlConfig.PressureLowLimit)    // LOW
                {
                    _view.FlashingStatusLED(Color.Yellow);
                    _view.SetStatusText("Pressure LOW !");

                    if (_modbusService.IsConnected & _isProduction)
                    {
                        await _modbusService.WriteAllDigitalOutputsAsync([true, false, false, false]);
                    }
                }

                else // NORMAL
                {
                    _view.FlashingStatusLED(Color.LimeGreen);
                    _view.SetStatusText("Pressure GOOD");

                    if (_modbusService.IsConnected & _isProduction)
                    {
                        await _modbusService.WriteAllDigitalOutputsAsync([false, false, false, false]);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("<Pressure Control> latest value error: " + ex.InnerException?.Message ?? ex.Message);
            }
            finally
            {
                _polling = false;
            }
        }

        private void StartPolling()
        {
            _chartTimer.Tick -= PollLatestAsync;
            _chartTimer.Tick += PollLatestAsync;

            _chartTimer.Start();
        }

        private void StopPolling()
        {
            _chartTimer.Tick -= PollLatestAsync;

            _chartTimer.Stop();
        }

        public async Task LoadFeedAnnotations(DateTime from, DateTime to)
        {
            var logs = await _model.GetFeedLogByTimeRangeAsync(from, to);

            if (logs == null)
            {
                return;
            }

            // Clear all existing annotations 
            _view.ClearAnnotations();

            foreach (var log in logs)
            {
                _view.AddFeedAnnotation(
                    log.Timestamp,
                    $"{log.Timestamp.ToString("HH:mm:ss")}\n{log.FuelType.FuelName}: {log.FuelMass:0.#} {log.Unit.Symbol}"
                );
            }
        }

        private async void OnExportClicked(object? sender, EventArgs e)
        {
            string fullPath = _view.ExportFullPath;

            if (string.IsNullOrWhiteSpace(fullPath))
            {
                MessageBox.Show("Empty folder or file name.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var data = await _dataAcqService.GetSensorDataAsync(1, _view.FromDate, _view.ToDate);
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

        public void Dispose()
        {
            this._view.LiveDataClicked -= RefreshChartAsync;
            this._view.RefreshClicked -= RefreshChartAsync;
            this._view.ExportClicked -= OnExportClicked;
            this._view.ViewLoad -= OnViewLoad;
            this._view.SavePidConfigClicked -= OnSavePidConfigClicked;
            this._view.AutoTuneClicked -= OnAutoTuneClicked;
            this._view.ApplyParamClicked -= OnApplyParamClicked;
            this._view.CancelAutoTuneClicked -= OnCancelAutoTuneClicked;
            this._view.AddFuelClicked -= OnAddFuelClicked;
            this._dbHealthService.DatabaseConnected -= OnDBConnected;
            this._dbHealthService.DatabaseDisconnected -= OnDBDisconnected;
            this.scheduleClientService.JsonReceived -= OnJsonReceived;
            this._modbusService.SnapshotUpdated -= OnSnapshotUpdated;
            this._tuner.TuneCompleted -= OnAutoTuneCompleted;

            this._chartTimer.Tick -= PollLatestAsync;
            this._pidTimer.Dispose();

            this._calcCountdownTimer.Tick -= OnCalcTimerTick;
            this._calcCountdownTimer.Dispose();
        }
    }
}
