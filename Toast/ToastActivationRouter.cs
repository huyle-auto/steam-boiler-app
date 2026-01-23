using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.Toast
{
    public class ToastActivationRouter
    {
        private static readonly Dictionary<string, Action<string>> _actions =
        new Dictionary<string, Action<string>>();

        public static void RegisterAction(string tag, Action<string> callback)
        {
            if (!_actions.ContainsKey(tag))
                _actions.Add(tag, callback);
        }

        public static void HandleActivation(string argument)
        {
            // Example argument: "action=open&tag=warn"
            var args = System.Web.HttpUtility.ParseQueryString(argument);

            string action = args["action"];
            string tag = args["tag"];

            if (tag != null && _actions.ContainsKey(tag))
            {
                _actions[tag](action);
            }
        }
    }
}
