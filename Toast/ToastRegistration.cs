using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Toast
{
    public class ToastRegistration
    {
        public static readonly string AppId = "SteamBoilerApp.NotificationChannel";
        public static void Register()
        {
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<AppNotificationActivator>(AppId);
            DesktopNotificationManagerCompat.RegisterActivator<AppNotificationActivator>();

            // Ensure activation handler only registered once
            //ToastNotificationManagerCompat.OnActivated -= OnToastActivated;
            //ToastNotificationManagerCompat.OnActivated += OnToastActivated;
        }

        //private static void OnToastActivated(ToastNotificationActivatedEventArgsCompat args)
        //{
        //    // Forward activation arguments to your app-level handler
        //    ToastActivationRouter.HandleActivation(args.Argument);
        //}
    }
}
