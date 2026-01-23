using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface ILoginView
    {
        public string Username { get; }
        public string Password { get; }

        public event EventHandler LoginClicked;
        public event EventHandler CreateUserClicked;
        public void ShowStatus(string message);
        public void ClearInfo();
        public void Close();
    }
}
