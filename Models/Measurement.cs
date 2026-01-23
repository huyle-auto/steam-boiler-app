using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class Measurement
{
    public int MeasurementId { get; set; }

    public int OrderId { get; set; }

    public int? MachineId { get; set; }

    public int MeasurementTypeId { get; set; }

    public decimal MeasuredValue { get; set; }

    public int UnitId { get; set; }

    public virtual Machine? Machine { get; set; }

    public virtual MeasurementType MeasurementType { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
