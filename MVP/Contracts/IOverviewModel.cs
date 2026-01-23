using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IOverviewModel
    {
        double ReadSteamPressure();
        Task<Dictionary<string, int>> GetFuelDist(DateTime from, DateTime to);
    }
}
