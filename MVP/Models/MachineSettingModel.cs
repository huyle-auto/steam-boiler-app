using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SteamBoilerApp.MachineSetting.Contract;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using SteamBoilerApp.Models;
using SteamBoilerApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SteamBoilerApp.MachineSetting.Models
{
    public class MachineSettingModel : IMachineSettingModel
    {
        public async Task<List<Customer>> GetCustomers()
        {
            using var db = new ProductionDbContext();
            return await db.Customers.OrderBy(c => c.CustomerId).ToListAsync();
        }
        public async Task<List<FluteType>> GetFluteTypes()
        {
            using var db = new ProductionDbContext();
            return await db.FluteTypes.OrderBy(f => f.FluteCode).ToListAsync();
        }
        public async Task<List<PaperType>> GetPaperTypes()
        {
            var db = new ProductionDbContext();
            return await db.PaperTypes.OrderBy(p => p.PaperCode).ToListAsync();
        }
        public async Task<List<PaperGrammage>> GetPaperGrammages()
        {
            var db = new ProductionDbContext();
            return await db.PaperGrammages.OrderBy(g => g.GrammageValue).ToListAsync();
        }
        public async Task<List<OrderSummary>> GetAllOrders(DateTime fromDate, DateTime toDate)
        {
            using var db = new ProductionDbContext();

            var result = await db.Orders
                .Where(o => o.RunDate >= fromDate && o.RunDate <= toDate)
                .Select(o => new
                {
                    o.OrderId,
                    CustomerName = o.Customer.CustomerName,
                    FluteType = o.FluteType.FluteCode,
                    o.RunDate,

                    // Concatenate layers into one string
                    LayersString = string.Join("/",
                        o.Layers
                            .OrderBy(l => l.LayerPosition)   // Ensure correct order
                            .Select(l =>
                                l.PaperType.PaperCode +
                                l.PaperGrammage.GrammageValue.ToString()
                            )
                    ),

                    // Get Paper Length (your MeasurementTypeId for Length)
                    PaperLength = o.Measurements
                        .Where(m => m.MeasurementTypeId == 3) // your type ID for Length
                        .Select(m => m.MeasuredValue)
                        .FirstOrDefault(),

                    // Get Paper Width
                    PaperWidth = o.Measurements
                        .Where(m => m.MeasurementTypeId == 4) // your type ID for Width
                        .Select(m => m.MeasuredValue)
                        .FirstOrDefault(),

                    // Get Unit
                    Unit = o.Measurements
                        .Select(m => m.Unit.Symbol)
                        .FirstOrDefault() ?? "",
                    LastStatus = o.OrderStatuses
                        .OrderByDescending(s => s.Timestamp)
                        .Select(s => s.Status)
                        .FirstOrDefault() ?? ""
                })
                .ToListAsync();
            return result
                .Select(r => new OrderSummary
                 {
                     OrderId = r.OrderId,
                     CustomerName = r.CustomerName,
                     FluteType = r.FluteType,
                     RunDate = r.RunDate,
                     Layers = r.LayersString,
                     PaperLength = r.PaperLength,
                     PaperWidth = r.PaperWidth,
                     Unit = r.Unit,
                     Status = r.LastStatus
                 })
                .ToList();
        }
        public async Task SaveOrder(Order order)
        {
            using var db = new ProductionDbContext();
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }
        public async Task DeleteOrder(int orderId)
        {
            if (orderId == 0)   // No order selected
            {
                throw new Exception("No order selected.");
            }

            using var db = new ProductionDbContext();
            var order = await db.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new Exception("Order not found.");
            }
            else
            {
                var status = await db.OrderStatuses
                    .Where(s => s.OrderId == orderId)
                    .OrderByDescending(s => s.Timestamp)
                    .FirstOrDefaultAsync();
                if (status != null)
                {
                    if (status.Status == "RUN" || status.Status == "PAUSE" || status.Status == "FINISH")
                    {
                        //MessageBox.Show("Order with Id: " + orderId + " Status is: " + status.Status);
                        throw new Exception("Cannot delete a started order.");
                    }
                }
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();
        }

        public async Task CheckUnfinishedOrder(int selectedOrderId)
        {
            using var db = new ProductionDbContext();
            var last = await db.OrderStatuses
                .OrderByDescending(s => s.Timestamp)
                .FirstOrDefaultAsync();

            // Only allow if last unfinished order is the selected one
            if (last != null && last.Status != "FINISH")
            {
                int orderId = last.OrderId;

                if (orderId == selectedOrderId)
                {
                    return; // Selected order is the unfinished one -> ALLOW RUN
                }

                var firstRun = await db.OrderStatuses
                    .Where(s => s.OrderId == orderId && s.Status == "RUN")
                    .OrderBy(s => s.Timestamp)
                    .Select(s => s.Timestamp)
                    .FirstOrDefaultAsync();  // Retrieve first run for user to find

                throw new Exception($"An order at {firstRun:MM-dd-yyyy HH:mm:ss} is not FINISH.");
            }
        }
        public async Task UpdateOrderStatus(int orderId, string newStatus)
        {
            using var db = new ProductionDbContext();
            var order = await db.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new Exception("Order not found.");
            }

            var last = await db.OrderStatuses.
                Where(os => os.OrderId == orderId)
                .OrderByDescending(os => os.Timestamp)
                .FirstOrDefaultAsync();

            // No status recorded
            if (last == null) 
            {
                if (newStatus != "RUN")
                {
                    throw new Exception("Cannot PAUSE or FINISH before RUN.");
                }

                await AddStatus(db, orderId, newStatus);
            }

            // Last = RUN
            else if (last.Status == "RUN") 
            {
                if (newStatus == "RUN")
                {
                    throw new Exception("Order is already running.");
                }

                await AddStatus(db, orderId, newStatus);
            }

            // Last = PAUSE
            else if (last.Status == "PAUSE")
            {
                if (newStatus == "PAUSE")
                {
                    throw new Exception("Order is already paused.");
                }
                await AddStatus(db, orderId, newStatus);
            }

            // Last = FINISH
            else if (last.Status == "FINISH")
            {
                throw new Exception("Order is finished. Please create a new order.");
            }
        }

        private async Task AddStatus(ProductionDbContext db, int orderId, string status)
        {
            db.OrderStatuses.Add(new OrderStatus
            {
                OrderId = orderId,
                Status = status,
                Timestamp = DateTime.Now // DATETIME2(0) → seconds precision
            });

            await db.SaveChangesAsync();
        }
    }
}
