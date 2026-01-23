using Microsoft.EntityFrameworkCore;
using SteamBoilerApp.ChildMVP.Contracts;
using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.ChildMVP.Models
{
    public class AddFuelLogModel : IAddFuelLogModel
    {
        public async Task<List<FuelType>> GetFuelTypesAsync()
        {
            using var db = new ProductionDbContext();
            return await db.FuelTypes.ToListAsync();
        }

        public async Task SaveFuelFeedLog(FuelFeedLog log)
        {
            using var db = new ProductionDbContext();
            db.FuelFeedLogs.Add(log);
            await db.SaveChangesAsync();
        }
    }
}
