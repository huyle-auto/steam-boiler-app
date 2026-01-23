using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.ViewModels
{
    public class FuelFeedSummary
    {
        public int FuelFeedLogId { get; set; }
        public string FuelName { get; set; } = String.Empty;
        public int FuelMass { get; set; }
        public string Unit { get; set; } = String.Empty;
        public DateTime Timestamp { get; set; }
    }
}
