using SteamBoilerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.ChildMVP.Contracts
{
    public interface IAddFuelLogView
    {
        public event EventHandler OnSaveClicked;
        public event EventHandler OnCancelClicked;
        public event EventHandler? OnFormLoad;
        public FuelFeedLog GetFuelFeedLog();
        public void LoadLookups(List<FuelType> fuelTypes);
        public void Close();
        void CloseOnSuccess();
    }
}
