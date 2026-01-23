using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class Layer
{
    public int LayerId { get; set; }

    public int OrderId { get; set; }

    public int? LayerPosition { get; set; }

    public int PaperTypeId { get; set; }

    public int PaperGrammageId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PaperGrammage PaperGrammage { get; set; } = null!;

    public virtual PaperType PaperType { get; set; } = null!;
}
