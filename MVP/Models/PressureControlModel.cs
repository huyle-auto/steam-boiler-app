using Microsoft.EntityFrameworkCore;
using SteamBoilerApp.BusinessLogic;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.MVP.Controls;

namespace SteamBoilerApp.MVP.Models
{
    public class PressureControlModel : IPressureControlModel
    {
        private readonly IPidController _pidController;

        public PressureControlModel(IPidController pidController)
        {
            _pidController = pidController;
        }

        public void ConfigurePid(PidControllerConfig pidConfig)
        {
            _pidController.Configure(pidConfig);
        }

        public async Task<PidControllerConfig?> GetLatestPidConfigAsync()
        {
            using var db = new ProductionDbContext();
            return await db.PidControllerConfigs.Where(c => c.SensorId == 1).OrderByDescending(c => c.LastUpdated).FirstOrDefaultAsync();
        }

        public async Task SavePidConfigAsync(PidControllerConfig config)
        {
            using var db = new ProductionDbContext();

            //// 1. SAVE BY NAME
            //var existing = await db.PidControllerConfigs.Where(c => c.ConfigName == config.ConfigName).FirstOrDefaultAsync();

            //if (existing == null)   // Not found, add new config
            //{
            //    await db.PidControllerConfigs.AddAsync(config);

            //}
            //else   // Update existing config
            //{
            //    db.Entry(existing).CurrentValues.SetValues(new PidControllerConfig
            //    {
            //        PidConfigId = existing.PidConfigId,
            //        ControllerName = config.ControllerName,
            //        ConfigName = config.ConfigName,
            //        SensorId = config.SensorId,
            //        Kp = config.Kp,
            //        Ki = config.Ki,
            //        Kd = config.Kd,
            //        OutputMin = config.OutputMin,
            //        OutputMax = config.OutputMax,
            //        Deadband = config.Deadband,
            //        IsEnabled = config.IsEnabled,
            //        ControlMode = config.ControlMode,
            //        LastUpdated = DateTime.Now
            //    });
            //}

            // 2. SAVE ALL
            await db.PidControllerConfigs.AddAsync(config);

            await db.SaveChangesAsync();
        }

        public double ComputePiOutput(double setpoint, double processValue, double deltaTimeSeconds)
        {
            return _pidController.ComputePI(setpoint, processValue, deltaTimeSeconds);
        }

        public double ComputePOutput(double setpoint, double processValue, double deltaTimeSeconds)
        {
            return _pidController.ComputeP(setpoint, processValue, deltaTimeSeconds);
        }

        public async Task<FuelFeedLog?> GetLatestFeedLogAsync()
        {
            using var db = new ProductionDbContext();
            return await db.FuelFeedLogs
                .Include(l => l.FuelType)
                .OrderByDescending(f => f.Timestamp)
                .FirstOrDefaultAsync();
        }

        public async Task SavePidRuntimeLogAsync(double sp, double pv, double output)
        {
            using var db = new ProductionDbContext();
            var configId = (await GetLatestPidConfigAsync())?.PidConfigId ?? 0;

            await db.PidRuntimeLogs.AddAsync(new PidRuntimeLog
            {
                PidConfigId = configId,
                Setpoint = sp,
                ProcessValue = pv,
                OutputValue = output,
                Error = sp - pv,
                Timestamp = DateTime.Now,
            });

            await db.SaveChangesAsync();
        }

        public async Task<double> GetAveragePVAsync(DateTime from, DateTime to)
        {
            using var db = new ProductionDbContext();
            var samples = await db.SensorData
                .Where(x =>
                        x.SensorId == 1 &&
                        x.Timestamp >= from &&
                        x.Timestamp <= to)
                .OrderBy(x => x.Timestamp)
                .Select(x => new
                {
                    x.Timestamp,
                    x.EngineeringValue
                })
                .ToListAsync();

            return ComputeTimeWeightedAverage(
                samples.Select(s => (s.Timestamp, (double)s.EngineeringValue)).ToList(),
                from,
                to
            );
        }

        // TWMA
        private static double ComputeTimeWeightedAverage(   
            IReadOnlyList<(DateTime ts, double value)> samples,
            DateTime windowStart,
            DateTime windowEnd)
        {
            if (samples == null || samples.Count == 0)
                throw new InvalidOperationException("No pressure data in window");

            double weightedSum = 0.0;
            double totalSeconds = 0.0;

            for (int i = 0; i < samples.Count; i++)
            {
                DateTime t0 = samples[i].ts;
                DateTime t1 = (i + 1 < samples.Count)
                    ? samples[i + 1].ts
                    : windowEnd;

                // Clamp to window
                t0 = t0 < windowStart ? windowStart : t0;
                t1 = t1 > windowEnd ? windowEnd : t1;

                double seconds = (t1 - t0).TotalSeconds;
                if (seconds <= 0)
                    continue;

                weightedSum += samples[i].value * seconds;
                totalSeconds += seconds;
            }

            if (totalSeconds <= 0)
                throw new InvalidOperationException("Invalid averaging window");

            return weightedSum / totalSeconds;
        }

        public void InjectEnergy(double energyMJ)
        { 
            _pidController.InjectEnergy(energyMJ);
        }

        // Convert energy correction (MJ) into equivalent fuel mass (kg)
        public async Task<Dictionary<string, double>> CalculateEquivalentFuelKgAsync(double energyCorrectionMJ)
        {
            var result = new Dictionary<string, double>();

            using var db = new ProductionDbContext();
            var fuels = await db.FuelTypes
                .Where(f => f.FuelLhv > 0)
                .ToListAsync();

            foreach(var fuel in fuels)
            {
                double kg = energyCorrectionMJ / (double)fuel.FuelLhv;

                result[fuel.FuelName] = Math.Round(kg);
            }

            return result;
        }
    }
}
