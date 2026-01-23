using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int FluteTypeId { get; set; }

    public DateTime RunDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual FluteType FluteType { get; set; } = null!;

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public virtual ICollection<OrderStatus> OrderStatuses { get; set; } = new List<OrderStatus>();
}
