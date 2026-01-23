using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Controls
{
    public sealed class PidAutoTuner : IPidAutoTuner
    {
        public enum TuneState
        {
            Idle,
            WaitingForFuel,
            Collecting,
            Completed,
            Failed
        }

        private readonly List<(DateTime t, double pressure)> _samples = new();

        private double _baselinePressure;
        private double _totalInjectedEnergyMJ;
        private DateTime _startTime;

        private readonly TimeSpan _maxTuneDuration = TimeSpan.FromMinutes(30);

        public TuneState State { get; private set; } = TuneState.Idle;

        public (double Kp, double Ki)? Result { get; private set; }

        private const double MinResponseFraction = 0.05; // min acceptable response -> 5% of operating range (0.8 - 1.6 bar)
        private const double PlateauSlopeThreshold = 0.0005; // bar/sec (adjustable)
        private const int PlateauWindowSeconds = 120; // last 2 minutes


        public event EventHandler<(double Kp, double Ki)?>? TuneCompleted;
        public event EventHandler<string>? TuneFailed;

        public PidAutoTuner() { }

        // ----------------------------------------------------

        public void Start(double currentPressure)
        {
            _samples.Clear();
            _totalInjectedEnergyMJ = 0.0;
            _baselinePressure = currentPressure;
            _startTime = DateTime.UtcNow;

            State = TuneState.WaitingForFuel;
        }

        // ----------------------------------------------------
        // Called when operator feeds fuel
        // ----------------------------------------------------
        public void RegisterFuelInput(double fuelMassKg, double calorificValueMJPerKg)
        {
            if (State != TuneState.WaitingForFuel)
                return;

            _totalInjectedEnergyMJ += fuelMassKg * calorificValueMJPerKg;
            State = TuneState.Collecting;
        }

        // ----------------------------------------------------
        // Called periodically (e.g. every 1–2 seconds)
        // ----------------------------------------------------
        public void Update(double pressure)
        {
            if (State != TuneState.Collecting)
                return;

            var now = DateTime.UtcNow;
            _samples.Add((now, pressure));

            if (now - _startTime >= _maxTuneDuration)
            {
                TryComputePid();
            }
        }

        public void Reset()
        {
            _samples.Clear();
            _totalInjectedEnergyMJ = 0.0;

            _baselinePressure = double.NaN;
            _startTime = DateTime.MinValue;

            State = TuneState.Idle;
        }

        // ----------------------------------------------------
        private void TryComputePid()
        {
            if (_samples.Count < 100 || _totalInjectedEnergyMJ <= 0)
            {
                Fail("Insufficient samples or no energy input");
                return;
            }

            double finalPressure = _samples.Last().pressure;
            double deltaPressure = finalPressure - _baselinePressure;

            // --- A. Minimum response check ---
            double operatingRange = 16.0; // <-- configure or inject later
            double minRequiredRise = operatingRange * MinResponseFraction;

            if (deltaPressure < minRequiredRise)
            {
                Fail("Pressure response too small — extend tuning time");
                return;
            }

            // --- Build time/value arrays ---
            var times = _samples.Select(s => (s.t - _startTime).TotalSeconds).ToArray();
            var pressures = _samples.Select(s => s.pressure).ToArray();

            // --- B. Clear slope peak detection ---
            var slopes = new List<double>();
            for (int i = 1; i < pressures.Length; i++)
            {
                double dp = pressures[i] - pressures[i - 1];
                double dt = times[i] - times[i - 1];
                if (dt > 0)
                    slopes.Add(dp / dt);
            }

            if (slopes.Count == 0 || slopes.Max() <= 0)
            {
                Fail("No meaningful pressure slope detected");
                return;
            }

            // --- C. Plateau detection (last N seconds) ---
            double plateauStartTime = times.Last() - PlateauWindowSeconds;
            var plateauSamples = _samples
                .Where(s => (s.t - _startTime).TotalSeconds >= plateauStartTime)
                .ToList();

            if (plateauSamples.Count < 10)
            {
                Fail("Not enough data to detect plateau");
                return;
            }

            double avgSlope = 0;
            for (int i = 1; i < plateauSamples.Count; i++)
            {
                double dp = plateauSamples[i].pressure - plateauSamples[i - 1].pressure;
                double dt = (plateauSamples[i].t - plateauSamples[i - 1].t).TotalSeconds;
                if (dt > 0)
                    avgSlope += dp / dt;
            }
            avgSlope /= (plateauSamples.Count - 1);

            if (Math.Abs(avgSlope) > PlateauSlopeThreshold)
            {
                Fail("Pressure still changing — no steady trend yet");
                return;
            }

            // --- Standard PI computation ---
            double K = deltaPressure / _totalInjectedEnergyMJ;

            double target28 = _baselinePressure + 0.28 * deltaPressure;
            double target63 = _baselinePressure + 0.63 * deltaPressure;

            double t28 = FindTimeAtPressure(times, pressures, target28);
            double t63 = FindTimeAtPressure(times, pressures, target63);

            double L = t28;
            double tau = t63 - t28;

            if (L <= 0 || tau <= 0)
            {
                Fail("Invalid process model detected");
                return;
            }

            double Kp = 0.9 * tau / (K * L);
            double Ki = Kp / (3.0 * L);

            Result = (Kp, Ki);
            TuneCompleted?.Invoke(this, Result);
            State = TuneState.Completed;
        }

        private static double FindTimeAtPressure(double[] times, double[] values, double target)
        {
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] >= target)
                {
                    return times[i];
                }
            }
            return -1;
        }

        private void Fail(string reason)
        {
            State = TuneState.Failed;
            TuneFailed?.Invoke(this, reason);
        }
    }


}
