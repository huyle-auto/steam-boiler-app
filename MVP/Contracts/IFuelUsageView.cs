using SteamBoilerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IFuelUsageView
    {
        public DateTime FuelUseDay { get; }
        public DateTime FuelFeedLogDate { get; }

        public event EventHandler OnViewLoad;
        public event EventHandler OnFuelUseDayChanged;
        public event EventHandler OnFuelFeedDayChanged;
        public event EventHandler OnAddNewLogClicked;

        public void ShowFuelUsageByType(Dictionary<string, int> data);
        public void ShowFuelFeedLog(List<FuelFeedSummary> data);
    }
}
