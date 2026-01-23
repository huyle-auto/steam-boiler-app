using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class SteamLatentHeat
{
    public int SteamLatentHeatId { get; set; }

    public decimal PressureBarg { get; set; }

    public decimal TemperatureC { get; set; }

    public decimal LatentHeatKJkg { get; set; }
}
