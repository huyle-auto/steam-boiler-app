using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class MeasurementType
{
    public int MeasurementTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
