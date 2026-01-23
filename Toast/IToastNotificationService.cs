using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Toast
{
    public interface IToastNotificationService
    {
        void ShowInfo(string title, string message, string tag = "info");
        void ShowWarning(string title, string message, string tag = "warn");
        void ShowWithActions(string title, string message, string imagePath, string tag, Action<string> onAction);
        void UpdateToast(string tag, string newMessage);
    }
}
