using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SteamBoilerApp.MVP.Services
{
    public class DataExportService : IDataExportService
    {
        public async Task ExportExcelAsync<T>(string path, List<T> data)    // Overwrite all
        {
            await Task.Run(() =>
            {
                using var wb = new XLWorkbook();

                var ws = wb.Worksheets.Add("Sheet1");
                ws.Cell(1, 1).InsertTable(data, "Table1", true);

                var range = ws.RangeUsed();
                if (range != null)
                {
                    range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                }

                ws.Columns().AdjustToContents();
                ws.Rows().AdjustToContents();

                wb.SaveAs(path);
            });
        }
    }
}
