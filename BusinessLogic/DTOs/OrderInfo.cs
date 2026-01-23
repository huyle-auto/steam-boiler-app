using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.BusinessLogic.DTOs
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string FluteCode { get; set; } = string.Empty;
        public List<LayerInfo> Layers { get; set; } = new();
        public List<MeasurementInfo> Measurements { get; set; } = new();
    }

    public class LayerInfo
    {
        public int LayerPosition { get; set; }
        public float Grammage { get; set; }
    }

    public class MeasurementInfo
    {
        public int MachineId { get; set; }
        public int MeasurementTypeId { get; set; }
        public decimal Value { get; set; }
    }

    public class SingleFacerParams
    {
        public int LinerGsm { get; set; }
        public int MediumGsm { get; set; }
        public float MediumRatio { get; set; }
        public float PaperWidth { get; set; }
        public float SteamTemp { get; set; }
        public int ManufactureSpeed { get; set; }
    }

    public class GluerParams
    {
        public int GlueGsm { get; set; }
        public float PaperWidth { get; set; }
        public int ManufactureSpeed { get; set; }
        public float SteamTempZone1 { get; set; }
        public float SteamTempZone2 { get; set; }

        public float FeedWaterTemp { get; set; }
    }

    public class DryerParams
    {
        public float PaperLength { get; set; }
        public float PaperWidth { get; set; }
        public int TotalPaperGsm {  get; set; }
        public int GlueSolidGsm { get; set; }
        public int MachineSpeed { get; set; }
    }
}
