using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IDatabaseHealthService
    {
        bool IsConnected { get; }

        public event EventHandler DatabaseConnected;
        public event EventHandler DatabaseDisconnected;
    }
}
