using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IPidAutoTuner
    {
        public void Start(double currentPressure);
        public void RegisterFuelInput(double fuelMassKg, double calorificValueMJPerKg);
        public void Update(double pressure);

        public void Reset();

        public event EventHandler<(double Kp, double Ki)?>? TuneCompleted;
        public event EventHandler<string>? TuneFailed;
    }
}
