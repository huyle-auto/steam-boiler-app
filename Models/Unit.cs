using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public string? Symbol { get; set; }

    public virtual ICollection<FuelFeedLog> FuelFeedLogs { get; set; } = new List<FuelFeedLog>();

    public virtual ICollection<FuelType> FuelTypes { get; set; } = new List<FuelType>();

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public virtual ICollection<PaperGrammage> PaperGrammages { get; set; } = new List<PaperGrammage>();

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
