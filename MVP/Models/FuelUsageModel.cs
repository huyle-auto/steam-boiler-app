using Microsoft.EntityFrameworkCore;
using SteamBoilerApp.BusinessLogic.DTOs;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using SteamBoilerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Models
{
    public class FuelUsageModel : IFuelUsageModel
    {
        const int ID_MEASUREMENT_SET_PRESSURE = 1;
        const int ID_MEASUREMENT_MACHINE_SPEED = 2;
        const int ID_MEASUREMENT_PAPER_LENGTH = 3;
        const int ID_MEASUREMENT_PAPER_WIDTH = 4;

        const int ID_SINGLE_FACER_1 = 1;
        const int ID_SINGLE_FACER_2 = 2;
        const int ID_GLUER_ZONE_1 = 3;
        const int ID_GLUER_ZONE_2 = 4;

        const float BOILER_FEEDWATER_TEMP = 110; // °C
        const float BOILER_STEAM_TEMP = 176; // °C

        // Return a distributed set of fuel types with their respective masses
        public async Task<Dictionary<string, float>> GetTotalFuelForOrder(int orderId)
        {
            var orderInfo = await GetOrderData(orderId);
            var singleFacerParams = await GetSingleFacerParams(orderInfo);
            var gluerParams = await GetGluerParams(orderInfo);
            var dryerParams = await GetDryerParams(orderInfo);

            double singleFacerSteamPerMin = 0.0,
                   gluerSteamPerMin = 0.0,
                   dryerSteamPerMin = 0.0;

            foreach (SingleFacerParams set in singleFacerParams)
            {
                singleFacerSteamPerMin += BusinessLogic.Estimation.CalculateSingleFacerSteamPerMin(
                    set.LinerGsm,
                    set.MediumGsm,
                    set.MediumRatio,
                    set.PaperWidth,
                    set.SteamTemp,
                    set.ManufactureSpeed
                );
            }

            gluerSteamPerMin = BusinessLogic.Estimation.CalculateGluerSteamPerMin(
                gluerParams.GlueGsm,
                gluerParams.PaperWidth,
                gluerParams.ManufactureSpeed,
                gluerParams.SteamTempZone1,
                gluerParams.SteamTempZone2,
                gluerParams.FeedWaterTemp
            );

            dryerSteamPerMin = BusinessLogic.Estimation.CalculateDryerSteamPerMin(
                dryerParams.PaperLength,
                dryerParams.PaperWidth,
                dryerParams.TotalPaperGsm,
                dryerParams.GlueSolidGsm,
                dryerParams.MachineSpeed
            );

            var totalSteamEnthalpy = BusinessLogic.Estimation.CalculateSteamEnthalpy(singleFacerSteamPerMin + gluerSteamPerMin + dryerSteamPerMin, BOILER_STEAM_TEMP, BOILER_FEEDWATER_TEMP);
            return [];
        }

        public static async Task<OrderInfo> GetOrderData(int orderId)
        {
            using var db = new ProductionDbContext();

            var order = await db.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => new OrderInfo
                {
                    OrderId = o.OrderId,
                    FluteCode = o.FluteType.FluteCode,

                    Layers = o.Layers.Select(l => new LayerInfo
                    {
                        LayerPosition = l.LayerPosition.GetValueOrDefault(),
                        Grammage = (float)l.PaperGrammage.GrammageValue,
                    }).ToList(),

                    Measurements = o.Measurements.Select(m => new MeasurementInfo
                    {
                        MachineId = m.MachineId.GetValueOrDefault(),
                        MeasurementTypeId = m.MeasurementTypeId,
                        Value = m.MeasuredValue
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return order;
        }

        public static async Task<List<SingleFacerParams>> GetSingleFacerParams(OrderInfo orderInfo)
        {
            var paramsList = new List<SingleFacerParams>();

            int linerGsm = orderInfo.Layers
                    .Where(l => l.LayerPosition == 1 || l.LayerPosition == 3)
                    .Sum(l => (int)l.Grammage);
            
            int mediumGsm = orderInfo.Layers
                    .Where(l => l.LayerPosition == 2)
                    .Sum(l => (int)l.Grammage);
            
            List<float> mediumRatios = await GetMediumRatioAsync(orderInfo.FluteCode);

            float paperWidth = GetMeasurementValue(orderInfo, ID_MEASUREMENT_PAPER_WIDTH, null, 0f);

            float steamSetPressure = GetMeasurementValue(orderInfo, ID_MEASUREMENT_SET_PRESSURE, ID_SINGLE_FACER_1, 0f);
            float steamTemp = await GetSteamTempAsync(steamSetPressure);
            float machineSpeed = GetMeasurementValue(orderInfo, ID_MEASUREMENT_MACHINE_SPEED, null, 1f);
            float paperLength = GetMeasurementValue(orderInfo, ID_MEASUREMENT_PAPER_LENGTH, null, 1f);
            int manufactureSpeed = (int)(paperLength / (1.0f * machineSpeed));

            paramsList.Add(new SingleFacerParams
            {
                LinerGsm = linerGsm,
                MediumGsm = mediumGsm,
                MediumRatio = mediumRatios[0],
                PaperWidth = paperWidth,
                SteamTemp = steamTemp,
                ManufactureSpeed = manufactureSpeed
            });

            // Second params set here (if any)
            if (orderInfo.FluteCode.Length == 2)
            {
                int linerGsm2 = orderInfo.Layers
                        .Where(l => l.LayerPosition == 5)
                        .Sum(l => (int)l.Grammage);

                int mediumGsm2 = orderInfo.Layers
                        .Where(l => l.LayerPosition == 4)
                        .Sum(l => (int)l.Grammage);

                float steamSetPressure2 = GetMeasurementValue(orderInfo, ID_MEASUREMENT_SET_PRESSURE, ID_SINGLE_FACER_2, steamSetPressure);
                float steamTemp2 = await GetSteamTempAsync(steamSetPressure2);

                paramsList.Add(new SingleFacerParams
                {
                    LinerGsm = linerGsm2,
                    MediumGsm = mediumGsm2,
                    MediumRatio = mediumRatios.ElementAtOrDefault(1),
                    PaperWidth = paperWidth,
                    SteamTemp = steamTemp2,
                    ManufactureSpeed = manufactureSpeed
                });
            }

            return paramsList;
        }

        public static async Task<GluerParams> GetGluerParams(OrderInfo orderInfo)
        {
            float paperWidth = GetMeasurementValue(orderInfo, ID_MEASUREMENT_PAPER_WIDTH, null, 0f);
            float machineSpeed = GetMeasurementValue(orderInfo, ID_MEASUREMENT_MACHINE_SPEED, null, 1f);
            float paperLength = GetMeasurementValue(orderInfo, ID_MEASUREMENT_PAPER_LENGTH, null, 1f);
            int manufactureSpeed = (int)(paperLength / machineSpeed);

            float steamSetPressureZone1 = GetMeasurementValue(orderInfo, ID_MEASUREMENT_SET_PRESSURE, ID_GLUER_ZONE_1, 0f);
            float steamTempZone1 = await GetSteamTempAsync(steamSetPressureZone1);
            float steamSetPressureZone2 = GetMeasurementValue(orderInfo, ID_MEASUREMENT_SET_PRESSURE, ID_GLUER_ZONE_2, 0f);
            float steamTempZone2 = await GetSteamTempAsync(steamSetPressureZone2);

            return new GluerParams
            {
                GlueGsm = 0,
                PaperWidth = paperWidth,
                ManufactureSpeed = manufactureSpeed,
                SteamTempZone1 = steamTempZone1,
                SteamTempZone2 = steamTempZone2,
                FeedWaterTemp = BOILER_FEEDWATER_TEMP
            };
        }

        public static async Task<DryerParams> GetDryerParams(OrderInfo orderInfo)
        {
            float paperWidth = GetMeasurementValue(orderInfo, ID_MEASUREMENT_PAPER_WIDTH, null, 0f);
            float machineSpeed = GetMeasurementValue(orderInfo, ID_MEASUREMENT_MACHINE_SPEED, null, 1f);
            
            float paperLength = GetMeasurementValue(orderInfo, ID_MEASUREMENT_PAPER_LENGTH, null, 1f);
            List<float> mediumRatios = await GetMediumRatioAsync(orderInfo.FluteCode);

            float totalPaperLength = 0.0f;
            if (mediumRatios.Count == 1)
            {
                totalPaperLength = paperLength * (2 + mediumRatios[0]);
            }
            else if (mediumRatios.Count == 2)
            {
                totalPaperLength = paperLength * (2 + mediumRatios[0] + mediumRatios[1]);
            }

            int totalPaperGsm = orderInfo.Layers.Sum(l => (int)l.Grammage);

            return new DryerParams
                {
                    PaperWidth = paperWidth,
                    PaperLength = totalPaperLength,
                    TotalPaperGsm = totalPaperGsm,
                    GlueSolidGsm = 0,
                    MachineSpeed = (int)machineSpeed
                };
        }

        private static float GetMeasurementValue(OrderInfo order, int measurementTypeId, int? machineId = null, float fallback = 0f)
        {
            var q = order.Measurements
                .Where(m => m.MeasurementTypeId == measurementTypeId);

            if (machineId.HasValue)
                q = q.Where(m => m.MachineId == machineId.Value);

            var found = q.Select(m => (float?)m.Value).FirstOrDefault();

            return found ?? fallback;
        }

        private static async Task<List<float>> GetMediumRatioAsync(string fluteCode)
        {
            using var db = new ProductionDbContext();
            var result = new List<float>();

            foreach (char ch in fluteCode)
            {
                string letter = ch.ToString();

                decimal? ratio = await db.FluteTypes
                    .Where(f => f.FluteCode == letter)
                    .Select(f => f.FluteRatio)
                    .FirstOrDefaultAsync();

                result.Add((float)(ratio ?? 0m));
            }

            return result;
        }

        private static async Task<float> GetSteamTempAsync (float steamPressure)
        {
            using var db = new ProductionDbContext();

            // convert once to decimal to match PressureBarg type
            decimal target = (decimal)steamPressure;

            // try exact match first
            var exact = await db.SteamLatentHeats
                .Where(l => l.PressureBarg == target)
                .Select(l => (float?)l.TemperatureC)
                .FirstOrDefaultAsync();

            if (exact.HasValue)
                return exact.Value;

            // fallback: find nearest by ordering on squared difference (no Abs needed)
            var nearest = await db.SteamLatentHeats
                .OrderBy(l => (l.PressureBarg - target) * (l.PressureBarg - target))
                .Select(l => (float)l.TemperatureC)
                .FirstOrDefaultAsync();

            return nearest;
        }

        public async Task<Dictionary<string, int>> GetFuelFeedLogByDayAsync(DateTime date)
        {
            var query =
                await new ProductionDbContext().FuelFeedLogs
                .Where(f => f.Timestamp.Date == date.Date)       
                .GroupBy(f => new { f.FuelTypeId, f.FuelType.FuelName })
                .Select(g => new
                {
                    FuelName = g.Key.FuelName,
                    TotalMass = g.Sum(x => x.FuelMass)
                })
                .OrderBy(x => x.FuelName)  // optional
                .ToListAsync();

            return query.ToDictionary(x => x.FuelName, x => x.TotalMass);
        }

        public async Task<List<FuelFeedSummary>> GetFuelFeedLogAllAsync(DateTime date)
        {
            using var db = new ProductionDbContext();
            DateTime start = date.Date;
            DateTime end = date.AddDays(1);

            return await db.FuelFeedLogs
                .Include(l => l.FuelType)
                .Include(l => l.Unit)
                .Where(l => l.Timestamp >= start && l.Timestamp < end)
                .Select(l => new FuelFeedSummary
                {
                    FuelFeedLogId = l.FuelFeedLogId,
                    FuelName = l.FuelType.FuelName,
                    FuelMass = l.FuelMass,
                    Unit = l.Unit.Symbol,
                    Timestamp = l.Timestamp
                })
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }

    }
}
