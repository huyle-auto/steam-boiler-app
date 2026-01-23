using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IPressureControlModel
    {
        void ConfigurePid(PidControllerConfig pidConfig);

        Task<PidControllerConfig?> GetLatestPidConfigAsync();
        Task SavePidConfigAsync(PidControllerConfig config);
        Task SavePidRuntimeLogAsync(double sp, double pv, double output);

        Task<double> GetAveragePVAsync(DateTime from, DateTime to);
        double ComputePiOutput(double setpoint, double processValue, double deltaTimeSeconds);
        double ComputePOutput(double setpoint, double processValue, double deltaTimeSeconds);

        void InjectEnergy(double energyMJ);

        Task<FuelFeedLog?> GetLatestFeedLogAsync();

        // ENERGY -> KG FUEL CONVERSION
        Task<Dictionary<string, double>> CalculateEquivalentFuelKgAsync(double energyCorrectionMJ);
    }
}
