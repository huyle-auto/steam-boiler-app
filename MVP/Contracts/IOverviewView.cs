using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IOverviewView
    {
        DateTime FuelDistFromDate { get; set; }
        DateTime FuelDistToDate { get; set; }

        void SetPressureGauge(double pressure);
        void ShowDistributionChart(Dictionary<string, int> data);

        event EventHandler CboFuelDistClicked;
    }
}
