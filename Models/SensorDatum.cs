using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class SensorDatum
{
    public long SensorDataId { get; set; }

    public int SensorId { get; set; }

    public int RawValue { get; set; }

    public decimal? EngineeringValue { get; set; }

    public string QualityStatus { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Sensor Sensor { get; set; } = null!;
}
