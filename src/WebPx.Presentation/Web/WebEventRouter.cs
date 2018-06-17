using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace WebPx.Web
{
    public static class WebEventRouter
    {

        public static void Send(object sender, string verb, object message = null, object args = null)
        {
            WebEventArgs eventArgs = new WebEventArgs(verb, message, args);
            Broadcast?.Invoke(sender, eventArgs);
        }

        internal static event VerbEventHandler Broadcast;

        //public static void SendVerb(this Page page, string verb, object message = null)
        //{
        //    VerbRouter.SendVerb(page, verb, message);
        //}
    }
}
