using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IDataAcquisitionService
    {
        Task SaveSensorDataAsync(IEnumerable<SensorDatum> data);
        Task<List<SensorDatum>> GetSensorDataAsync(int sensorId, DateTime fromDate, DateTime ToDate);
        Task<SensorDatum?> GetSensorLatestValueAsync(int sensorId, DateTime afterTimestamp);
    }
}
