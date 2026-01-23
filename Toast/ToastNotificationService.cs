using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace SteamBoilerApp.Toast
{
    public class ToastNotificationService : IToastNotificationService
    {
        private const string GROUP = "APP_TOASTS";

        public ToastNotificationService()
        {
            // ToastRegistration.Register();
        }

        public void ShowInfo(string title, string message, string tag = "info")
        {
            var builder = BuildBasicToast(title, message);

            // Default sound
            builder.AddAudio(new ToastAudio());

            Show(builder.GetToastContent(), tag);
        }

        public void ShowWarning(string title, string message, string tag = "warn")
        {
            var builder = BuildBasicToast(title, message);

            // Loud alarm sound
            builder.AddAudio(new ToastAudio());

            Show(builder.GetToastContent(), tag);
        }

        public void ShowWithActions(string title, string message, string imagePath, string tag, Action<string> onAction)
        {
            if (!AreNotificationsEnabled())
            {
                if (MessageBox.Show(
                    "Notifications are disabled. Open Windows Settings to enable them?",
                    "Enable Notifications",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "ms-settings:notifications",
                        UseShellExecute = true
                    });
                }
            }

            // Register custom callback
            ToastActivationRouter.RegisterAction(tag, onAction);

            string imgSystemPath = ToastAssetManager.GetImage(imagePath);

            var builder = BuildBasicToast(title, message)
                .AddButton(new ToastButton()
                    .SetContent("Open details")
                    .AddArgument("action", "open")
                    .AddArgument("tag", tag)
                    .SetBackgroundActivation());

            if (imgSystemPath != string.Empty)
            {
                builder.AddInlineImage(new Uri(imgSystemPath));
            }
            
            Show(builder.GetToastContent(), tag);
        }
      
        public void UpdateToast(string tag, string newMessage)
        {
            var update = new NotificationData();
            update.Values["message"] = newMessage;

            ToastNotificationManagerCompat.CreateToastNotifier()
                .Update(update, tag, GROUP);
        }

        // --------------- INTERNAL HELPERS ---------------
        private static ToastContentBuilder BuildBasicToast(string title, string message)
        {
            return new ToastContentBuilder()
                .AddText(title)
                .AddText(message)
                .AddAttributionText("Production Monitoring System")
                .SetToastDuration(ToastDuration.Long)
                .AddToastActivationInfo("default", ToastActivationType.Foreground)
                .SetToastScenario(ToastScenario.Reminder);
        }

        private static void Show(ToastContent content, string tag)
        {
            var toast = new ToastNotification(content.GetXml())
            {
                Tag = tag,
                Group = GROUP
            };

            ToastNotificationManagerCompat.CreateToastNotifier().Show(toast);
        }

        private static bool AreNotificationsEnabled()
        {
            try
            {
                var notifier = ToastNotificationManagerCompat.CreateToastNotifier();
                return notifier.Setting == NotificationSetting.Enabled;
            }
            catch
            {
                // If something fails, assume disabled
                return false;
            }   // This method always return true if AUMID is not registered
        }
    }
}
