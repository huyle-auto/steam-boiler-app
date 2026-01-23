using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Models
{
    public class AppSettingModel : IAppSettingModel
    {
        private readonly IModbusTCPService _modbusService;
        public AppSettingModel(IModbusTCPService modbusService)
        {
            this._modbusService = modbusService;
        }
        
        public async Task<bool> ConnectAsync(string ipAddress, int port)
        {
            return await _modbusService.ConnectAsync(ipAddress, port);
        }

        public async Task<bool> DisconnectAsync()
        {
            return await _modbusService.DisconnectAsync();
        }
    }
}
