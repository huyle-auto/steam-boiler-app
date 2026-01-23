using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class FuelType
{
    public int FuelTypeId { get; set; }

    public string FuelName { get; set; } = null!;

    public decimal? FuelLhv { get; set; }

    public int UnitId { get; set; }

    public virtual ICollection<FuelFeedLog> FuelFeedLogs { get; set; } = new List<FuelFeedLog>();

    public virtual Unit Unit { get; set; } = null!;
}
