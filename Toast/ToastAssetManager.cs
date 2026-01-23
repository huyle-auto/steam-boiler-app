using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Toast
{
    public static class ToastAssetManager
    {
        private static readonly string BasePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SteamBoilerApp", "Images");

        static ToastAssetManager()
        {
            Directory.CreateDirectory(BasePath);
        }

        /// <summary>
        /// Ensures an image exists in the toast-safe folder.
        /// Copies it only once, never again.
        /// Returns the absolute path safe for Windows Toast APIs.
        /// </summary>
        public static string GetImage(string fileName)
        {
            string localPath = Path.Combine(BasePath, fileName);

            // Only copy once (fast check)
            if (!File.Exists(localPath))
            {
                string sourcePath = Path.Combine(Application.StartupPath, "Images", fileName);

                if (!File.Exists(sourcePath))
                {
                    return "";
                }

                File.Copy(sourcePath, localPath, overwrite: false);
            }

            return localPath;
        }
    }

}
