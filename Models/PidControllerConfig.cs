using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class PidControllerConfig
{
    public int PidConfigId { get; set; }

    public string ControllerName { get; set; } = null!;

    public string ConfigName { get; set; } = null!;

    public int SensorId { get; set; }

    public double Kp { get; set; }

    public double Ki { get; set; }

    public double Kd { get; set; }

    public double OutputMin { get; set; }

    public double OutputMax { get; set; }

    public double Deadband { get; set; }

    public bool IsEnabled { get; set; }

    public string ControlMode { get; set; } = null!;

    public DateTime LastUpdated { get; set; }

    public virtual ICollection<PidRuntimeLog> PidRuntimeLogs { get; set; } = new List<PidRuntimeLog>();

    public virtual Sensor Sensor { get; set; } = null!;
}
