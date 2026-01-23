using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class Machine
{
    public int MachineId { get; set; }

    public string MachineName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
}
