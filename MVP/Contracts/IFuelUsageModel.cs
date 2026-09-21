using SteamBoilerApp.Models;
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
        Task<Dictionary<string, float>> GetTotalFuelForOrder(int orderId);
        Task<Dictionary<string, int>> GetFuelFeedLogByDayAndTypeAsync(DateTime date);
        Task<List<FuelFeedLog>> GetFuelFeedByDayAsync(DateTime date);
        Task<DateTime> GetLatestFeedLogTimeAsync();
    }
}
