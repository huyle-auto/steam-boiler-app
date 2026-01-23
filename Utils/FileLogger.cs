using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Utils
{
    public static class FileLogger
    {
        public static void Log(string text, string fileName = "debug.txt")
        {
            try
            {
                File.AppendAllText(fileName, DateTime.Now + " | " + text + Environment.NewLine);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error logging file: " + ex.Message);
            }
        }
    }
}
