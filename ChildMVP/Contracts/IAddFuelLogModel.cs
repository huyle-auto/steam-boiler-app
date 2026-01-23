using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.ChildMVP.Contracts
{
    public interface IAddFuelLogModel
    {
        public Task<List<FuelType>> GetFuelTypesAsync();
        public Task SaveFuelFeedLog(FuelFeedLog log);
    }
}
