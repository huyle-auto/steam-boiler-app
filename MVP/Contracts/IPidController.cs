using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IPidController
    {
        void Configure(PidControllerConfig pidConfig);
        double ComputePI(double setpoint, double processValue, double deltaTimeSeconds);
        double ComputeP(double setpoint, double processValue, double deltaTimeSeconds);

        void InjectEnergy(double energyMJ);
    }
}
