using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IAppSettingModel
    {
        Task<bool> ConnectAsync(string ipAddress, int port);
        Task<bool> DisconnectAsync();
    }
}
