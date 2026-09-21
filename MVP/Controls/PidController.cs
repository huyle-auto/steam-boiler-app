using SteamBoilerApp.Configs;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Controls
{
    public sealed class PidController : IPidController
    {
        public double Kp { get; set; }
        public double Ki { get; set; }
        public double Kd { get; set; }

        public double OutputMin { get; set; } = double.MinValue;
        public double OutputMax { get; set; } = double.MaxValue;
        public double Deadband { get; set; } = 0.0;

        private double _integral;

        private readonly int _maxCorrectionEnergyMJ;

        public PidController(ControlConfig config)
        {
            _maxCorrectionEnergyMJ = config.MaxCorrectionEnergyMJ;
        }

        public void Configure(PidControllerConfig config)
        {
            Kp = config.Kp;
            Ki = config.Ki;
            Kd = config.Kd;
            OutputMin = config.OutputMin;
            OutputMax = config.OutputMax;
            Deadband = config.Deadband;

            Reset();
        }

        public double ComputePI(double setpoint, double averagePV, double deltaTimeSeconds)
        {
            double error = setpoint - averagePV;

            // Deadband
            if (Math.Abs(error) <= Deadband)
            {
                _integral *= 0.9961;
                return 0;
            }

            double tentativeIntegral = _integral + error * deltaTimeSeconds;

            double unclampedOutput =
                Kp * error +
                Ki * tentativeIntegral;

            bool wouldSaturateHigh = unclampedOutput > _maxCorrectionEnergyMJ;
            bool wouldSaturateLow = unclampedOutput < 0;

            if (!(wouldSaturateHigh && error > 0) &&
                !(wouldSaturateLow && error < 0))
            {
                _integral = tentativeIntegral;
            }

            double energyMJ = Kp * error + Ki * _integral;

            // Set output to (0.0 - 1.0)
            energyMJ = Math.Clamp(energyMJ, 0, _maxCorrectionEnergyMJ);

            Debug.WriteLine("Integral is: " + _integral);

            return energyMJ;
        }

        public double ComputeP(double setpoint, double averagePV, double deltaTimeSeconds)
        {
            double error = setpoint - averagePV;

            // Deadband
            if (Math.Abs(error) <= Deadband)
            {
                return 0;
            }

            double energyMJ = Kp * error;

            energyMJ = Math.Clamp(energyMJ, 0, _maxCorrectionEnergyMJ);

            return energyMJ;
        }

        public void InjectEnergy(double energyMJ)
        {
            if (Ki == 0)
            {
                return;
            }

            _integral -= energyMJ / Ki;
        }

        public void Reset()
        {
            _integral = 0;
        }
    }

}
