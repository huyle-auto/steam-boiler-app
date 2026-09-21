using DocumentFormat.OpenXml.Office2010.Excel;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.Utils;
using System.Windows.Forms.DataVisualization.Charting;
using Color = System.Drawing.Color;

namespace SteamBoilerApp.MVP.Views
{
    public partial class PressureControlView : UserControl, IPressureControlView
    {
        private readonly System.Windows.Forms.Timer _countdownTimer;

        private readonly int MAX_POINTS = 300;

        public event EventHandler? ViewLoad;
        public event EventHandler? RefreshClicked;
        public event EventHandler? LiveDataClicked;
        public event EventHandler? ExportClicked;
        public event EventHandler? SavePidConfigClicked;
        public event EventHandler? AutoTuneClicked;
        public event EventHandler? ApplyParamClicked;
        public event EventHandler? CancelAutoTuneClicked;
        public event EventHandler<string>? AddFuelClicked;
        public event EventHandler ToggleAlarmClicked;
        public bool IsLiveData { get; set; } = false;

        public string ExportFullPath { get; set; }

        public DateTime FromDate => dtpFromDate.Value;
        public DateTime ToDate => dtpToDate.Value;

        private readonly int AUTO_TUNE_SECONDS = 60 * 30;   // 30 minutes
        private int _totalSeconds = 0;

        public double PressureSetpoint => (double)numPressureSetpoint.Value;
        public double SampleTime => (double)numSampleTime.Value;

        private List<KeyValuePair<string, double>> _fuelOptions = new();
        private int _fuelIndex = 0;

        // Status LED
        private Color _ledColor = Color.White;
        private bool _isLedOn = false;

        // Alarm state
        public bool IsAlarmEnabled { get; set; } = true;

        public enum PressureState
        {
            Stable,
            SlightlyLow,
            Low,
            SlightlyHigh,
            High,
            WaitingForResponse
        }

        public PressureControlView()
        {
            InitializeComponent();

            _countdownTimer = new System.Windows.Forms.Timer();
            _countdownTimer.Interval = 1000;
            _countdownTimer.Tick += Countdown;
        }

        private void SetupChartAppearance()
        {
            var font = new Font("Segoe UI", 12f, FontStyle.Regular);
            var area = chartPressure.ChartAreas[0];

            area.AxisX.LabelStyle.Font = font;
            area.AxisY.LabelStyle.Font = font;
            area.AxisX.TitleFont = font;
            area.AxisY.TitleFont = font;
            area.AxisY.TitleAlignment = StringAlignment.Far;

            var legend = chartPressure.Legends[0];
            legend.Docking = Docking.Top;
            legend.LegendStyle = LegendStyle.Row;
            legend.Alignment = StringAlignment.Far;
            legend.Font = font;
            legend.IsDockedInsideChartArea = false;

            // Enable zooming
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisY.ScaleView.Zoomable = true;

            // Enable selection cursor
            area.CursorX.IsUserEnabled = true;
            area.CursorX.IsUserSelectionEnabled = true;

            area.CursorY.IsUserEnabled = true;
            area.CursorY.IsUserSelectionEnabled = true;

            // Smoother zoom
            area.AxisX.ScaleView.SmallScrollSize = double.NaN;
            area.AxisY.ScaleView.SmallScrollSize = double.NaN;

            // Show scrollbar after zoom
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.IsPositionedInside = false;
            area.AxisY.ScrollBar.Enabled = false;

            // Right-click to reset zoom
            chartPressure.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    area.AxisX.ScaleView.ZoomReset();
                    area.AxisY.ScaleView.ZoomReset();
                }
            };

            // --------------------------- ALARMING LINES ------------------------------
            var stripLow = new StripLine();
            var stripHigh = new StripLine();

            // Common style
            var stripWidth = 0;
            var borderWidth = 1;
            var borderDashStyle = ChartDashStyle.Dash;

            // LOW
            stripLow.IntervalOffset = 6.8;
            stripLow.StripWidth = stripWidth;
            stripLow.BorderWidth = borderWidth;
            stripLow.BorderColor = Color.Orange;
            stripLow.BorderDashStyle = borderDashStyle;

            // HIGH
            stripHigh.IntervalOffset = 9.4;
            stripHigh.StripWidth = stripWidth;
            stripHigh.BorderWidth = borderWidth;
            stripHigh.BorderColor = Color.Red;
            stripHigh.BorderDashStyle = borderDashStyle;

            area.AxisY.StripLines.Add(stripLow);
            area.AxisY.StripLines.Add(stripHigh);

        }

        private void SetupChartContent()
        {
            chartPressure.Series.Clear();
            chartPressure.ChartAreas.Clear();

            var area = new ChartArea("MainArea");
            area.AxisX.LabelStyle.Format = "HH:mm";
            area.AxisX.IntervalType = DateTimeIntervalType.Seconds;
            area.AxisX.Interval = 10;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.Title = "Value (bar)";
            area.AxisY.Maximum = 16;
            area.AxisY.IntervalType = DateTimeIntervalType.Number;
            area.AxisY.Interval = 1;

            chartPressure.ChartAreas.Add(area);

            var series = new Series("Boiler Pressure")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                IsXValueIndexed = false
            };
            series.EmptyPointStyle.Color = Color.Transparent;

            chartPressure.Series.Add(series);

            area.AxisX.IsStartedFromZero = false;
            area.AxisX.ScaleView.Zoomable = false;
        }

        private static void EnableDoubleBuffer(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)!
                .SetValue(control, true);
        }

        private void PressureControlView_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffer(chartPressure);
            SetupChartContent();
            SetupChartAppearance();
            ViewLoad?.Invoke(this, EventArgs.Empty);

            // Avoid identical FromDate & ToDate at startup
            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = DateTime.Now.AddMinutes(-10);

            SetupPidControls();
        }

        public void LoadInitialData(List<SensorDatum> data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => LoadInitialData(data)));
                return;
            }

            // Adjust X-axis interval
            AdjustXAxisInterval(chartPressure);

            var area = chartPressure.ChartAreas[0];

            area.AxisX.Minimum = dtpFromDate.Value.ToOADate();
            area.AxisX.Maximum = dtpToDate.Value.ToOADate();

            var series = chartPressure.Series[0];
            series.Points.Clear();

            SensorDatum? prev = null;

            // Empty chart (with axes) if no data found
            if (data.Count == 0)
            {
                series.Points.AddXY(dtpToDate.Value, double.NaN);
                chartPressure.Invalidate();
                return;
            }

            // Plot data, fill empty with gaps
            foreach (var d in data)
            {
                if (prev != null)
                {
                    var gap = d.Timestamp - prev.Timestamp;

                    if (gap.TotalSeconds > 5)
                    {
                        series.Points.AddXY(d.Timestamp, double.NaN);
                    }
                }

                series.Points.AddXY(d.Timestamp, d.EngineeringValue);
                prev = d;
            }

            chartPressure.Invalidate();
        }

        public void AppendSensorPoint(DateTime timestamp, double value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => AppendSensorPoint(timestamp, value)));
                return;
            }

            var series = chartPressure.Series[0];
            series.Points.AddXY(timestamp, value);

            // Manually move the window
            var area = chartPressure.ChartAreas[0];
            area.AxisX.Maximum = timestamp.ToOADate();
            area.AxisX.Minimum = timestamp.AddMinutes(-10).ToOADate();

            if (series.Points.Count >= MAX_POINTS)
                series.Points.RemoveAt(0);

            chartPressure.Invalidate();
        }

        public void SetStatusText(string status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => SetStatusText(status)));
                return;
            }

            txtStatus.Text = status;
        }

        public void FlashingStatusLED(Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => FlashingStatusLED(color)));
                return;
            }

            _ledColor = color;

            _isLedOn = !_isLedOn;

            ledStatus.BackColor = _isLedOn ? _ledColor : Color.White;
        }

        private void AdjustXAxisInterval(Chart chart)
        {
            if (chart.Series.Count == 0)
                return;

            var area = chart.ChartAreas[0];
            var axisX = area.AxisX;

            DateTime from = dtpFromDate.Value;
            DateTime to = dtpToDate.Value;

            if (from >= to)
                return;

            TimeSpan range = to - from;

            // 1. Choose label format by range
            string labelFormat;
            if (range.TotalDays >= 365)
                labelFormat = "yyyy";
            else if (range.TotalDays >= 7)
                labelFormat = "dd/MM";
            else if (range.TotalHours >= 24)
                labelFormat = "dd/MM HH:mm";
            else if (range.TotalMinutes >= 1)
                labelFormat = "HH:mm";
            else
                labelFormat = "HH:mm:ss";

            axisX.LabelStyle.Format = labelFormat;
            axisX.IsLabelAutoFit = false;
            axisX.LabelAutoFitStyle = LabelAutoFitStyles.None;

            // 2. Measure real label width
            string sampleLabel = to.ToString(labelFormat);
            using var g = chart.CreateGraphics();
            float labelWidth = g.MeasureString(sampleLabel, axisX.LabelStyle.Font).Width;

            // 3. Calculate how many labels fit
            float axisPixelWidth =
                chart.ClientSize.Width * area.Position.Width / 100f;

            int maxLabels = (int)(axisPixelWidth / labelWidth * 0.9f);
            if (maxLabels < 1) maxLabels = 1;

            // 4. Ideal interval in seconds
            double visibleSeconds = range.TotalSeconds;
            double idealInterval = visibleSeconds / maxLabels;

            // 5. Human-friendly intervals (seconds)
            int[] intervals =
            {
                1, 2, 5, 10, 15, 30,    // seconds
                60, 120, 300, 600, 900, 1800,   // minutes
                3600,        // 1 hour
                7200,        // 2 hours
                14400,       // 4 hours
                86400,       // 1 day
                172800,      // 2 days
                604800       // 1 week
            };

            int chosenInterval = intervals
                .FirstOrDefault(i => i >= idealInterval);

            if (chosenInterval == 0)
                chosenInterval = intervals[^1];

            // 6. Apply interval
            axisX.IntervalType = DateTimeIntervalType.Seconds;
            axisX.Interval = chosenInterval;
            axisX.MajorGrid.IntervalType = axisX.IntervalType;
            axisX.MajorGrid.Interval = axisX.Interval;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            IsLiveData = false;
            RefreshClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLiveData_Click(object sender, EventArgs e)
        {
            IsLiveData = true;
            LiveDataClicked?.Invoke(this, EventArgs.Empty);
            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = DateTime.Now.AddMinutes(-10);
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "Excel Workbook|*.xlsx";
            dialog.Title = "Select File Location and File Name";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.FileName = DateTime.Now.ToString("pressure_dd-MM-yy") + ".xlsx"; // Optional: provide a default file name

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportFullPath = dialog.FileName;
                ExportClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        private void SetupPidControls()
        {
            // Set default PID mode
            cboTuneMode.Items.Add("Auto-Tuning");
            cboTuneMode.Items.Add("Manual");
            cboTuneMode.SelectedIndex = 0;  // Auto-tuning

            numKp.ReadOnly = true;
            numKi.ReadOnly = true;
            numKd.ReadOnly = true;

            numSampleTime.ReadOnly = true;

            numOutputMin.ReadOnly = true;
            numOutputMax.ReadOnly = true;
        }

        public void SetPidConfig(PidControllerConfig pidConfig)
        {
            txtConfigName.Text = pidConfig.ConfigName;
            cboTuneMode.SelectedIndex = pidConfig.ControlMode == "Manual" ? 1 : 0;
            numKp.Value = (decimal)pidConfig.Kp;
            numKi.Value = (decimal)pidConfig.Ki;
            numKd.Value = (decimal)pidConfig.Kd;
            numOutputMin.Value = (decimal)pidConfig.OutputMin;
            numOutputMax.Value = (decimal)pidConfig.OutputMax;
            numDeadband.Value = (decimal)pidConfig.Deadband;
        }

        public PidControllerConfig GetPidConfig()
        {
            return new PidControllerConfig
            {
                ControllerName = "SteamPressurePID",
                ConfigName = txtConfigName.Text,
                SensorId = 1,
                Kp = (double)numKp.Value,
                Ki = (double)numKi.Value,
                Kd = (double)numKd.Value,
                OutputMin = (double)numOutputMin.Value,
                OutputMax = (double)numOutputMax.Value,
                Deadband = (double)numDeadband.Value,
                IsEnabled = true,
                ControlMode = (cboTuneMode.Text == "Manual" ? "Manual" : "Auto"),
                LastUpdated = DateTime.Now
            };
        }

        private void btnSavePidConfig_Click(object sender, EventArgs e)
        {
            SavePidConfigClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cboTuneMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuneMode.SelectedIndex == 0) // Auto-Tuning
            {
                numKp.ReadOnly = true;
                numKi.ReadOnly = true;
                numKd.ReadOnly = true;
                numOutputMin.ReadOnly = true;
                numOutputMax.ReadOnly = true;
            }
            else // Manual
            {
                numKp.ReadOnly = false;
                numKi.ReadOnly = false;
                numKd.ReadOnly = false;
                numOutputMin.ReadOnly = false;
                numOutputMax.ReadOnly = false;
            }
        }

        public void UpdateCountdowns(TimeSpan advisoryRemaining, TimeSpan commitRemaining)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateCountdowns(advisoryRemaining, commitRemaining)));
                return;
            }

            lblMinorCntdown.Text = $"{FormatTime(advisoryRemaining)}";
            lblMajorCntdown.Text = $"{FormatTime(commitRemaining)}";
        }

        private static string FormatTime(TimeSpan ts)
        {
            if (ts < TimeSpan.Zero)
            {
                ts = TimeSpan.Zero;
            }

            return string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);
        }

        private void picBoxAutoTune_Click(object sender, EventArgs e)
        {
            AutoTuneClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ShowAutoTunePanel()
        {
            // Use brand new panel data
            panelAutoTuning.Visible = true;
            btnApply.Visible = false;
            _totalSeconds = AUTO_TUNE_SECONDS;
            _countdownTimer.Start();
            lblAutoKp.Text = "0.00";
            lblAutoKi.Text = "0.00";
            lblAutoKd.Text = "0.00";

            // Disable PID operation panel while auto-tuning
            panelPidOperation.Enabled = false;
        }

        public void CloseAutoTunePanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => CloseAutoTunePanel()));
                return;
            }

            panelAutoTuning.Visible = false;
            btnApply.Visible = false;
            _countdownTimer.Stop();
            lblTimer.Text = "--:--";

            // Re-enable PID operation panel
            panelPidOperation.Enabled = true;
        }

        private void Countdown(object? sender, EventArgs e)
        {
            lblTimer.Text = "30:00";

            if (_totalSeconds > 0)
            {
                _totalSeconds--;
                // Calculate minutes and seconds
                int minutes = _totalSeconds / 60;
                int seconds = _totalSeconds % 60;
                // Format the time as "MM:SS"
                lblTimer.Text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            }
            else
            {
                // Stop the timer when the countdown reaches zero
                _countdownTimer.Stop();
                lblTimer.Text = "00:00";
            }
        }

        public void ShowAutoTuneResult(double Kp, double Ki, double Kd)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowAutoTuneResult(Kp, Ki, Kd)));
                return;
            }

            lblAutoKp.Text = Kp.ToString("F2");
            lblAutoKi.Text = Ki.ToString("F2");
            lblAutoKd.Text = Kd.ToString("F2");

            btnApply.Visible = true;
        }

        public void ApplyAutoTuneResult()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ApplyAutoTuneResult()));
                return;
            }

            numKp.Text = lblAutoKp.Text;
            numKi.Text = lblAutoKi.Text;
            numKd.Text = lblAutoKd.Text;

            _countdownTimer.Stop();  // Stop tickling
            panelAutoTuning.Visible = false;    // Applied, close panel

            SavePidConfigClicked?.Invoke(this, EventArgs.Empty);    // Save newest params

            // Re-enable PID operation panel
            panelPidOperation.Enabled = true;
        }

        public void EvaluatePressureState(double avgPressure, Dictionary<string, double> fuelOptions)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => EvaluatePressureState(avgPressure, fuelOptions)));
                return;
            }

            double error = avgPressure - (double)numPressureSetpoint.Value;

            var state = PressureState.WaitingForResponse;

            if (Math.Abs(error) <= (double)numDeadband.Value)
            {
                state = PressureState.Stable;
            }

            else if (error < -(double)numDeadband.Value)
            {

                state = Math.Abs(error) < (double)numDeadband.Value * 2 ? PressureState.SlightlyLow : PressureState.Low;
            }
            else if (error > (double)numDeadband.Value)
            {
                state = Math.Abs(error) < (double)numDeadband.Value * 2 ? PressureState.SlightlyHigh : PressureState.High;
            }

            BuildStatusMessage(state, fuelOptions);
        }

        private void BuildStatusMessage(PressureState state, Dictionary<string, double> fuelOptions)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => BuildStatusMessage(state, fuelOptions)));
                return;
            }

            _fuelOptions = fuelOptions.OrderBy(x => x.Key).ToList();
            _fuelIndex = 0;

            string title = "";
            string prompt = "";
            string evidence = "";

            switch (state)
            {
                case PressureState.Stable:
                    title = "Pressure Stable";
                    prompt = "Please wait.";
                    evidence = "";

                    FileLogger.Log($"Setpoint: {numPressureSetpoint.Value}. Pressure Stable. Please wait", "prompt.txt");
                    break;
                case PressureState.SlightlyLow:
                    title = "Pressure slightly low";
                    prompt = BuildFuelPrompt();
                    evidence = "";

                    FileLogger.Log($"Setpoint: {numPressureSetpoint.Value}. Pressure slightly low. {BuildFuelPrompt()}", "prompt.txt");
                    break;
                case PressureState.Low:
                    title = "Pressure LOW";
                    prompt = BuildFuelPrompt();
                    evidence = "";

                    FileLogger.Log($"Setpoint: {numPressureSetpoint.Value}. Pressure LOW. {BuildFuelPrompt()}", "prompt.txt");
                    break;
                case PressureState.SlightlyHigh:
                    title = "Pressure slightly high";
                    prompt = "Please wait.";
                    evidence = "";

                    FileLogger.Log($"Setpoint: {numPressureSetpoint.Value}. Pressure slightly high. Please wait", "prompt.txt");
                    break;
                case PressureState.High:
                    title = "Pressure HIGH";
                    prompt = "DO NOT feed fuel.";
                    evidence = "";

                    FileLogger.Log($"Setpoint: {numPressureSetpoint.Value}. Pressure HIGH. DO NOT feed fuel", "prompt.txt");
                    break;
                case PressureState.WaitingForResponse:
                    title = "Waiting for pressure response...";
                    prompt = "Please wait.";
                    evidence = "";

                    FileLogger.Log($"Waiting for pressure response... Please wait", "prompt.txt");
                    break;
                default:
                    break;
            }

            lblOperationTitle.Text = title;
            lblOperationPrompt.Text = prompt;
            lblOperationEvidence.Text = evidence;
        }

        private string BuildFuelPrompt()
        {
            if (_fuelOptions.Count == 0)
            {
                return "No fuel recommendation available. Please wait";
            }

            KeyValuePair<string, double> fuel = _fuelOptions.ToList()[_fuelIndex];
            return $"If you feed now: ~{fuel.Value} kg {fuel.Key}";
        }

        public void ShowMessageOnFuelInjected()
        {
            string title = "Waiting for pressure response...";
            string prompt = "Please wait.";
            string evidence = "";

            lblOperationTitle.Text = title;
            lblOperationPrompt.Text = prompt;
            lblOperationEvidence.Text = evidence;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _countdownTimer.Stop();
            lblTimer.Text = "--:--";

            panelAutoTuning.Visible = false;
            CancelAutoTuneClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyParamClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddFuelAutoTune_Click(object sender, EventArgs e)
        {
            AddFuelClicked?.Invoke(this, "tuner");
        }

        private void btnAddFuelPid_Click(object sender, EventArgs e)
        {
            AddFuelClicked?.Invoke(this, "pid");
        }

        private void picBoxChangeOption_Click(object sender, EventArgs e)
        {
            if (_fuelOptions.Count <= 1)
                return;

            _fuelIndex = (_fuelIndex + 1) % _fuelOptions.Count;
            lblOperationPrompt.Text = BuildFuelPrompt();
        }

        private void btnToggleAlarm_Click(object sender, EventArgs e)
        {
            ToggleAlarmClicked?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateAlarmState()
        {
            IsAlarmEnabled = !IsAlarmEnabled;

            btnToggleAlarm.Text = IsAlarmEnabled ? "ON" : "OFF";
            btnToggleAlarm.BackColor = IsAlarmEnabled ? Color.Red : Color.Gray;
            btnToggleAlarm.ForeColor = IsAlarmEnabled ? Color.White : Color.Black;

            pictureBoxAlarmOn.Visible = IsAlarmEnabled;
            pictureBoxAlarmOff.Visible = !IsAlarmEnabled;
        }

        public void AddFeedAnnotation(DateTime timestamp, string text)
        {
            var chart = chartPressure;

            var point = GetNearestPoint(timestamp);

            double y;

            if (point != null)
            {
                y = point.YValues[0];

                // Highlight point
                point.MarkerStyle = MarkerStyle.Circle;
                point.MarkerSize = 8;
                point.MarkerColor = Color.Coral;
            }
            else
            {
                y = chart.ChartAreas[0].AxisY.Maximum * 0.95;
            }

            var annotation = new RectangleAnnotation
            {
                Text = text,
                BackColor = Color.White,
                ForeColor = Color.Black,
                LineColor = Color.LightGray,
                LineWidth = 1,
                Font = new Font("Segoe UI", 10),
                AnchorAlignment = ContentAlignment.BottomCenter,
                AnchorOffsetY = -10,
                AllowMoving = true
            };

            annotation.AxisX = chart.ChartAreas[0].AxisX;
            annotation.AxisY = chart.ChartAreas[0].AxisY;

            annotation.AnchorX = timestamp.ToOADate();
            annotation.AnchorY = y;

            chart.Annotations.Add(annotation);

            // Set visibility based on current checkbox
            annotation.Visible = checkBoxAnnotation.Checked;
        }

        private DataPoint? GetNearestPoint(DateTime timestamp)
        {
            var series = chartPressure.Series[0];

            if (series.Points.Count == 0)
                return null;

            double targetX = timestamp.ToOADate();

            DataPoint? closest = null;
            double minDiff = double.MaxValue;

            foreach (var p in series.Points)
            {
                double diff = Math.Abs(p.XValue - targetX);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    closest = p;
                }
            }

            return closest;
        }

        public void ClearAnnotations()
        {
            chartPressure.Annotations.Clear();

            // Clear markers
            var series = chartPressure.Series[0];

            foreach (var p in series.Points)
            {
                p.MarkerStyle = MarkerStyle.None;
            }
        }

        private void checkBoxAnnotation_CheckedChanged(object sender, EventArgs e)
        {
            foreach(var annotation in chartPressure.Annotations)
            {
                annotation.Visible = checkBoxAnnotation.Checked;
            }

            chartPressure.Invalidate();
        }
    }
}
