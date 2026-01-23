using SteamBoilerApp.Configs;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
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
                return 0;
            }

            _integral += error * deltaTimeSeconds;

            double energyMJ = Kp * error + Ki * _integral;

            energyMJ = Math.Clamp(energyMJ, 0, _maxCorrectionEnergyMJ);

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
            _integral -= energyMJ / Ki;
        }

        public void Reset()
        {
            _integral = 0;
        }
    }

}
