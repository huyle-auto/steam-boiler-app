using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Contracts
{
    public interface IScheduleView
    {
        void SetRuntimeData(Dictionary<string, string> data);

        void SetScheduleData(DataTable table);

        event EventHandler ViewLoad;
    }
}
