using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Configs
{
    public class ControlConfig
    {
        public double AdvisoryWindowSeconds { get; set; }
        public double CommitWindowSeconds { get; set; } 
        public int MaxCorrectionEnergyMJ { get; set; } 

        public double PressureHighHighLimit { get; set; }
        public double PressureHighLimit { get; set; }
        public double PressureLowLimit { get; set; }
        public double PressureLowLowLimit { get; set; }
        public double MinProductionPressure { get; set; }

    }
}
