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
        private const long MAX_FILE_SIZE_BYTES = 5 * 1024 * 1024; // 5 MB

        public static void Log(string text, string fileName = "debug.txt")
        {
            try
            {
                // Force the path to be the application's base folder
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(baseDirectory, fileName);

                string targetPath = GetAvailableFilePath(fullPath);
                string logEntry = $"{DateTime.Now} | {text}{Environment.NewLine}";

                File.AppendAllText(targetPath, logEntry);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error logging file: " + ex.Message);
            }
        }

        private static string GetAvailableFilePath(string baseFileName)
        {
            if (!File.Exists(baseFileName)) return baseFileName;

            FileInfo fi = new FileInfo(baseFileName);

            // If current file is under the limit, keep using it
            if (fi.Length < MAX_FILE_SIZE_BYTES) return baseFileName;

            // If exceeded, find the next available suffix (_1, _2, etc.)
            string directory = Path.GetDirectoryName(baseFileName) ?? "";
            string fileNameOnly = Path.GetFileNameWithoutExtension(baseFileName);
            string extension = Path.GetExtension(baseFileName);
            int suffix = 1;

            while (true)
            {
                string newPath = Path.Combine(directory, $"{fileNameOnly}_{suffix}{extension}");

                if (!File.Exists(newPath) || new FileInfo(newPath).Length < MAX_FILE_SIZE_BYTES)
                {
                    return newPath;
                }
                suffix++;
            }
        }
    }
}
