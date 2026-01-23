using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IDataExportService
    {
        Task ExportExcelAsync<T> (string path, List<T> data);
    }
}
