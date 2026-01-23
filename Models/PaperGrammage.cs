using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class PaperGrammage
{
    public int PaperGrammageId { get; set; }

    public decimal GrammageValue { get; set; }

    public int UnitId { get; set; }

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();

    public virtual Unit Unit { get; set; } = null!;
}
