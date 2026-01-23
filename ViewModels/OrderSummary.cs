using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.ViewModels
{
    public class OrderSummary
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = "";
        public string FluteType { get; set; } = "";
        public DateTime RunDate { get; set; }
        public string Layers { get; set; } = "";
        public decimal PaperLength { get; set; }
        public decimal PaperWidth { get; set; }
        public string Unit { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
