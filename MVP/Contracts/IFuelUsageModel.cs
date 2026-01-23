using SteamBoilerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IFuelUsageModel
    {
        public Task<Dictionary<string, float>> GetTotalFuelForOrder(int orderId);
        public Task<Dictionary<string, int>> GetFuelFeedLogByDayAsync(DateTime date);
        public Task<List<FuelFeedSummary>> GetFuelFeedLogAllAsync(DateTime date);
    }
}
