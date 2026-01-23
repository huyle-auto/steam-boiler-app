using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Toast
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [Guid("EFD8CED0-0B8C-4604-8CF7-D49045754745")]   // <-- MUST BE UNIQUE
    [ComVisible(true)]
    public class AppNotificationActivator : NotificationActivator
    {
        public override void OnActivated(string arguments, NotificationUserInput userInput, string appId)
        {
            ToastActivationRouter.HandleActivation(arguments);
        }
    }
}
