using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.HWConfig
{
    public class ModbusDeviceConfig
    {
        public string DeviceName { get; set; } = "";
        public byte SlaveId { get; set; }
        public int Resolution { get; set; }
        public int MinADC { get; set; } 
        public int MaxADC { get; set; }
        public Dictionary<string, ModbusRegister> Registers { get; set; } = new();
    }

    public class ModbusRegister
    {
        public int Id { get; set; }
        public ushort StartAddress { get; set; }
        public ushort Length { get; set; }
        public double MinMeasure { get; set; }
        public double MaxMeasure { get; set; }
        public string Description { get; set; } = "";
    }
}
