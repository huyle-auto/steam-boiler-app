using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class PidRuntimeLog
{
    public long PidLogId { get; set; }

    public int PidConfigId { get; set; }

    public double Setpoint { get; set; }

    public double ProcessValue { get; set; }

    public double OutputValue { get; set; }

    public double Error { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual PidControllerConfig PidConfig { get; set; } = null!;
}
