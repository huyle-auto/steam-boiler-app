using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class FluteType
{
    public int FluteTypeId { get; set; }

    public string FluteCode { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? FluteRatio { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
