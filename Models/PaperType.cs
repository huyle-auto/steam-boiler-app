using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class PaperType
{
    public int PaperTypeId { get; set; }

    public string PaperCode { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();
}
