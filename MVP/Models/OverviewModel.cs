using Microsoft.EntityFrameworkCore;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Models
{
    internal class OverviewModel : IOverviewModel
    {
        private readonly IModbusTCPService _modbus;
        public OverviewModel(IModbusTCPService modbus)
        {
            this._modbus = modbus;
        }

        public double ReadSteamPressure()
        {
            return _modbus.ReadAnalogInput("SteamPressure");
        }

        public async Task<Dictionary<string, int>> GetFuelDist(DateTime from, DateTime to)
        {
            var db = new ProductionDbContext();
            var list = await db.FuelFeedLogs
                .Where(f => f.Timestamp >= from && f.Timestamp <= to)
                .GroupBy(f => f.FuelType.FuelName)
                .Select(g => new
                {
                    FuelName = g.Key,
                    TotalMass = g.Sum(x => x.FuelMass)
                })
                .ToListAsync();
            return list.ToDictionary(x => x.FuelName, x => x.TotalMass);
        }
    }
}
