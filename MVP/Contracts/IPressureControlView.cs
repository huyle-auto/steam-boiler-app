using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteamBoilerApp.MVP.Views.PressureControlView;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IPressureControlView
    {
        void LoadInitialData(List<SensorDatum> data);
        void AppendSensorPoint(DateTime timestamp, double value);
        void SetStatusText(string status);
        void FlashingStatusLED(Color color);

        void UpdateCountdowns(TimeSpan advisoryRemaining, TimeSpan commitRemaining);
        void SetPidConfig(PidControllerConfig pidConfig);
        PidControllerConfig GetPidConfig();

        void ShowAutoTunePanel();
        void CloseAutoTunePanel();
        void ShowAutoTuneResult(double Kp, double Ki, double Kd);
        void ApplyAutoTuneResult();

        void EvaluatePressureState(double avgPressure, Dictionary<string, double> fuelOptions);
        void ShowMessageOnFuelInjected();

        void UpdateAlarmState();

        void AddFeedAnnotation(DateTime timestamp, string text);
        void ClearAnnotations();

        DateTime FromDate { get; }
        DateTime ToDate { get; }
        bool IsLiveData { get; set; }
        public string ExportFullPath { get; set; }

        double PressureSetpoint { get; }
        double SampleTime { get; }

        event EventHandler ViewLoad;
        event EventHandler RefreshClicked;
        event EventHandler LiveDataClicked;
        event EventHandler ExportClicked;
        event EventHandler SavePidConfigClicked;
        event EventHandler AutoTuneClicked;
        event EventHandler ApplyParamClicked;
        event EventHandler CancelAutoTuneClicked;
        event EventHandler<string> AddFuelClicked;
        event EventHandler ToggleAlarmClicked;

        bool IsAlarmEnabled { get; set; }
    }
}
