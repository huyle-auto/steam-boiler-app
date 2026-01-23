using SteamBoilerApp.Models;
using SteamBoilerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MachineSetting.Contracts
{
    public interface IMachineSettingView
    {
        void InvokeUI(Action action);
        public void ShowOrder(List<OrderSummary> table);
        public void ShowStatus(string status);
        public Order GetNewOrderData();
        public void SetCustomers(List<Customer> customers);
        public void SetFluteTypes(List<FluteType> fluteTypes);
        public void SetPaperTypes(List<PaperType> paperTypes);
        public void SetPaperGrammages(List<PaperGrammage> paperGrammages);

        public DateTime FromDate { get; }
        public DateTime ToDate { get; }

        public string ExportFullPath { get; }
        public bool Append { get; }

        public event EventHandler OnViewLoad;
        public event EventHandler RefreshClicked;
        public event EventHandler SaveClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler RunOrderClicked;
        public event EventHandler PauseOrderClicked;
        public event EventHandler FinishOrderClicked;
        public event EventHandler ExportClicked;
        public int SelectedOrderId { get; }
    }
}
