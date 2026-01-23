using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class Sensor
{
    public int SensorId { get; set; }

    public string SensorName { get; set; } = null!;

    public string? Description { get; set; }

    public int MeasurementTypeId { get; set; }

    public int UnitId { get; set; }

    public double MeasureMin { get; set; }

    public double MeasureMax { get; set; }

    public bool IsEnabled { get; set; }

    public virtual MeasurementType MeasurementType { get; set; } = null!;

    public virtual ICollection<PidControllerConfig> PidControllerConfigs { get; set; } = new List<PidControllerConfig>();

    public virtual ICollection<SensorDatum> SensorData { get; set; } = new List<SensorDatum>();

    public virtual Unit Unit { get; set; } = null!;
}
