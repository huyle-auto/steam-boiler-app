using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class FuelFeedLog
{
    public int FuelFeedLogId { get; set; }

    public int FuelTypeId { get; set; }

    public int FuelMass { get; set; }

    public int UnitId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual FuelType FuelType { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
