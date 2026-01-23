using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Services
{
    public sealed class ModbusSnapshot
    {
        public bool[] Coils { get; }  // 0xxxx
        public bool[] DiscreteInputs { get; } // 1xxxx
        public ushort[] InputRegisters { get; } // 3xxxx
        public ushort[] HoldingRegisters { get; }   // 4xxxx

        public ModbusSnapshot(
            bool[] coils,
            bool[] discreteInputs,
            ushort[] inputRegisters,
            ushort[] holdingRegisters
        )
        {
            Coils = coils;
            DiscreteInputs = discreteInputs;
            InputRegisters = inputRegisters;
            HoldingRegisters = holdingRegisters;
        }
    }
}
