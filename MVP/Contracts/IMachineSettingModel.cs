using SteamBoilerApp.MachineSetting.Models;
using SteamBoilerApp.Models;
using SteamBoilerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MachineSetting.Contract
{
    public interface IMachineSettingModel
    {
        Task<List<OrderSummary>> GetAllOrders(DateTime fromDate, DateTime toDate);
        Task SaveOrder(Order order);
        Task DeleteOrder(int orderId);
        Task CheckUnfinishedOrder(int selectedOrderId);
        Task UpdateOrderStatus(int orderId, string newStatus);

        Task<List<Customer>> GetCustomers();
        Task<List<FluteType>> GetFluteTypes();
        Task<List<PaperType>> GetPaperTypes();
        Task<List<PaperGrammage>> GetPaperGrammages();
    }
}
