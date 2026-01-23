using Microsoft.IdentityModel.Tokens.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.BusinessLogic
{
    internal class Estimation
    {
        public static readonly float _cashewShellsLHVMJ = 17.99f; // MJ/kg
        public static readonly float _cashewPelletsLHVMJ = 19.24f; // MJ/kg
        public static readonly float _sawdustLHVMJ = 18.10f; // MJ/kg

        private static float _boilerEfficiency = 0.62f; // Value only for testing fuel usage estimation

        // Single facer
        public static readonly float _sfThermalUtilEfficiency = 0.68f;
        public static readonly float _sfInitialMoisture = 0.09f;
        public static readonly float _sfSpecificHeat = 1.4f; // kJ/kg°C
        public static readonly float _sfInletPaperTemp = 33.0f; // °C
        public static readonly float _sfOutletLinerTemp = 75.0f; // °C
        public static double CalculateSingleFacerSteamPerMin(
            int linerGrammage, 
            int mediumGrammage, 
            float mediumTakeUpRatio, 
            float paperWidth, 
            float steamTemp, 
            int manufactureSpeed
        )
        {
            float linerMassFlow = linerGrammage * (paperWidth * manufactureSpeed) / (1 - _sfInitialMoisture);   // kg paper / min
            double linerSteamUsage = linerMassFlow * _sfSpecificHeat * (_sfOutletLinerTemp - _sfInletPaperTemp) / (steamTemp *_sfThermalUtilEfficiency);    // kg steam / min

            float mediumMassFlow = mediumTakeUpRatio * mediumGrammage * (paperWidth * manufactureSpeed) / (1 - _sfInitialMoisture); // kg paper / min
            double mediumSteamUsage = mediumMassFlow * _sfSpecificHeat * (0.6 * (steamTemp - _sfInletPaperTemp)) / (steamTemp * _sfThermalUtilEfficiency);    // kg steam / min

            // Assume steamTemp is corrugate roll temp (ignore thermal loss)
            return (linerSteamUsage + mediumSteamUsage);    // kg steam / min
        }

        // Gluer
        public static readonly float _glThermalUtilEfficiency = 0.65f;
        public static readonly float _glSpecificHeat = 1.4f;     // kJ/kg°C
        public static readonly float _glInletTemp = 25.0f;       // °C
        public static readonly float _glAppTemp = 60.0f;         // °C
        private static float _zone1Fraction = 0.4f;
        public static double CalculateGluerSteamPerMin(
            int glueGsm,            // g/m² glue add-on
            float paperWidth,         // m
            float machineSpeed,   // m/min
            float steamTempZone1,          // steam saturation temp or mapped temp
            float steamTempZone2,          // steam saturation temp or mapped temp
            float feedwaterTemp       // °C
        )
        {
            // Area processed per minute (m²/min)
            double areaPerMin = paperWidth * machineSpeed;

            // Glue mass flow (kg/min)
            double glueMassFlow = (glueGsm / 1000.0) * areaPerMin;

            // Total energy required to heat glue (kJ/min)
            double Q_glue_heat = glueMassFlow * _glSpecificHeat * (_glAppTemp - _glInletTemp);

            // Clip fraction
            if (_zone1Fraction < 0.0) _zone1Fraction = 0.0f;
            if (_zone1Fraction > 1.0) _zone1Fraction = 1.0f;

            // Useful enthalpy per kg steam for each zone (kJ/kg)
            double hSteam1 = 2501 + 1.8608 * steamTempZone1;
            double hSteam2 = 2501 + 1.8608 * steamTempZone2;
            double hFeed = 4.1868 * feedwaterTemp;

            double deltaH1 = hSteam1 - hFeed;
            double deltaH2 = hSteam2 - hFeed;
            if (deltaH1 <= 0) deltaH1 = 2250.0;
            if (deltaH2 <= 0) deltaH2 = 2250.0;

            // Steam for each zone (kg/min) using the energy split
            double Q_zone1 = Q_glue_heat * _zone1Fraction;
            double Q_zone2 = Q_glue_heat * (1.0 - _zone1Fraction);

            double steamZone1 = Q_zone1 / (deltaH1 * _glThermalUtilEfficiency);
            double steamZone2 = Q_zone2 / (deltaH2 * _glThermalUtilEfficiency);

            return steamZone1 + steamZone2; // kg steam / min

            // IMPORTANT:
            // Glue water evaporation is already counted inside _initialMoisture before dryer
            // So DO NOT add any evaporation steam here.
        }

        // Dryer
        public static readonly float _drThermalUtilEfficiency = 0.67f;
        public static readonly float _initialMoisture = 0.11f; // 11% after gluer - before dryer
        public static readonly float _finalMoisture = 0.08f; // 11% after dryer - final product
        public static double CalculateDryerSteamPerMin(
            float totalPaperLength, 
            float paperWidth, 
            int totalPaperGrammage, 
            int glueSolidGrammage, 
            int machineSpeed
        )
        {
            // Add glue grammage here (if any)
            // *totalPaperLength already accounted extra length from flute ratios
            float paperMassPerSquare = totalPaperGrammage * totalPaperLength * paperWidth / 1000;   // kg/m2

            // Fix moisture with glue add-on (if any)
            float evaporatedWaterMass = paperMassPerSquare * (_initialMoisture - _finalMoisture) / (1 - _initialMoisture); // kg
            
            float steamRequiredMass = evaporatedWaterMass / _drThermalUtilEfficiency ; // kg steam
            float manufactureTime = totalPaperLength / (1.0f * machineSpeed);

            return (steamRequiredMass / manufactureTime);    // kg steam/min
        }

        // Currently assume _boilerEfficiency a constant
        public static double CalculateBoilerEfficiency(double totalSteamUseInPeriod, double totalFuelUseInPeriod, int steamTemp, int feedwaterTemp, float fuelLHVMJ)
        {
            return totalSteamUseInPeriod * (2501 + 1.8608 * steamTemp - 4.1868 * feedwaterTemp) / (totalFuelUseInPeriod * fuelLHVMJ); // decimal (0 - 1)
        }

        public static double CalculateSteamEnthalpy(double steamUsePerMin, float steamTemp, float feedwaterTemp)
        {
            double h_steam = 2501 + 1.8608 * steamTemp; // kJ/kg
            double h_feedwater = 4.1868 * feedwaterTemp;    // kJ/kg

            return steamUsePerMin * (h_steam - h_feedwater);   // kJ/min
        }

        public static double CalculateFuelUsePerMin(double steamEnthalpy, float[] fuelLHVMJs)
        {
            return steamEnthalpy / (_cashewShellsLHVMJ * 1000 * _boilerEfficiency); // kg fuel/min
        }
    }
}
