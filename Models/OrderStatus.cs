using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public int OrderId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Order Order { get; set; } = null!;
}
