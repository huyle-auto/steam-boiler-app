using System.Data;
using Newtonsoft.Json.Linq;

namespace SteamBoilerApp.Utils
{
    public sealed class JsonHandler
    {
        private readonly JObject _root;

        private JsonHandler(JObject root)
        {
            _root = root;
        }

        public static JsonHandler Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("JSON is empty");

            return new JsonHandler(JObject.Parse(json));
        }

        public DateTime? Timestamp =>
            _root["timestamp"]?.ToObject<DateTime>();

        // ---------- TABLE ----------
        public DataTable GetTable(string name)
        {
            var rows = _root[name]?["rows"] as JArray;
            return rows == null ? new DataTable() : RowsToTable(rows);
        }

        // ---------- RUNTIME / KV ----------
        public Dictionary<string, string> GetRuntime()
        {
            var dict = new Dictionary<string, string>();
            var obj = _root["runtime"] as JObject;

            if (obj == null)
                return dict;

            foreach (var prop in obj.Properties())
                dict[prop.Name] = prop.Value?.ToString() ?? "";

            return dict;
        }

        // ---------- GENERIC FIELD ----------
        public string GetValue(string section, string key)
        {
            return _root[section]?[key]?.ToString();
        }

        // ---------- INTERNAL ----------
        private static DataTable RowsToTable(JArray rows)
        {
            var table = new DataTable();

            if (rows.Count == 0)
                return table;

            // Build columns
            foreach (var prop in ((JObject)rows[0]).Properties())
                table.Columns.Add(prop.Name, typeof(string));

            // Fill rows
            foreach (JObject rowObj in rows)
            {
                DataRow row = table.NewRow();

                foreach (DataColumn col in table.Columns)
                    row[col.ColumnName] =
                        rowObj[col.ColumnName]?.ToString() ?? "";

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
