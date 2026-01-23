using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Configs
{
    public class ControlConfig
    {
        public int AdvisoryWindowMinutes { get; set; }
        public int CommitWindowMinutes { get; set; } 
        public int MaxCorrectionEnergyMJ { get; set; } 
    }
}
