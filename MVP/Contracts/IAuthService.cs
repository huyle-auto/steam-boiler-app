using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IAuthService
    {
        Task<bool> ValidateUserAsync(string username, string password);
        Task<bool> CreateUserAsync(string username, string password);
    }
}
