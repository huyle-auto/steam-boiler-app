using SteamBoilerApp.Models;
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
        DateTime FuelUseDay { get; }
        DateTime FuelFeedLogDate { get; }

        event EventHandler OnViewLoad;
        event EventHandler OnFuelUseDayChanged;
        event EventHandler OnFuelFeedDayChanged;
        event EventHandler OnRefreshAllLogClicked;

        void ShowFuelUsageByType(Dictionary<string, int> data);
        void LoadFuelFeedLog(List<FuelFeedLog> data);
        void RefreshAllFuelLog(List<FuelFeedLog> data);
        void RefreshFuelLogKeepFilter(List<FuelFeedLog> data);
    }
}
