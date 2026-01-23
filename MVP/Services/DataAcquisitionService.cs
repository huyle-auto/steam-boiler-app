using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAPICodePack.Sensors;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Services
{
    public class DataAcquisitionService : IDataAcquisitionService
    {
        public async Task SaveSensorDataAsync(IEnumerable<SensorDatum> data)
        {
            var list = data.ToList();
            if (list.Count == 0)
            {
                return;
            }

            try
            {
                using var db = new ProductionDbContext();

                await db.SensorData.AddRangeAsync(list);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot save sensor data to DB: " + ex.InnerException?.Message ?? ex.Message);
            }
        }
        public async Task<List<SensorDatum>> GetSensorDataAsync(int sensorId, DateTime from, DateTime to)
        {
            try
            {
                using var db = new ProductionDbContext();

                return await db.SensorData
                    .AsNoTracking()
                    .Where(x => x.SensorId == sensorId && x.Timestamp >= from && x.Timestamp < to)
                    .OrderBy(x => x.Timestamp) // re-order for chart
                    .Select(d => new SensorDatum
                    {
                        SensorId = d.SensorId,
                        RawValue = d.RawValue,
                        EngineeringValue = d.EngineeringValue,
                        QualityStatus = d.QualityStatus,
                        Timestamp = d.Timestamp,
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot retrieve sensor data: " + ex.ToString());
                throw new Exception("Cannot retrieve sensor data: " + ex.ToString());
            }
        }
        public async Task<SensorDatum?> GetSensorLatestValueAsync(int sensorId, DateTime after)
        {
            try
            {
                using var db = new ProductionDbContext();
                return await db.SensorData
                    .AsNoTracking()
                    .Where(x =>
                        x.SensorId == sensorId &&
                        x.Timestamp > after)
                    .OrderBy(x => x.Timestamp)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot retrieve last sensor data: " + ex.Message.ToString());
                throw new Exception("Cannot retrieve last sensor data: " + ex.Message.ToString());
            }
        }

    }
}
