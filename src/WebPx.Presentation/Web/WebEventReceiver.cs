using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPx.Web
{
    public class WebEventReceiver : IDisposable
    {
        private WebEventReceiver()
        {
            WebEventRouter.Broadcast += Receive;
        }

        private const string receiverKey = "VerbReceiver";

        public static bool HasInstance
        {
            get
            {
                return HttpContext.Current?.Items[receiverKey] != null;
            }
        }

        public static WebEventReceiver Instance
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var receiver = HttpContext.Current.Items[receiverKey];
                //if (receiver == null)
                //    receiver = new WebEventReceiver();
                WebEventReceiver verbReceiver = null;
                if (!(receiver is WebEventReceiver))
                {
                    verbReceiver = new WebEventReceiver();
                    HttpContext.Current.Items[receiverKey] = verbReceiver;
                }
                else
                    verbReceiver = (WebEventReceiver)receiver;
                return verbReceiver;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            if (disposed)
                return;
            Event = null;
            WebEventRouter.Broadcast -= Receive;
            var current = HttpContext.Current?.Items[receiverKey];
            if (current != null && current == this)
                HttpContext.Current.Items.Remove(receiverKey);
            disposed = true;
        }

        private void Receive(object sender, WebEventArgs e)
        {
            Event?.Invoke(sender, e);
        }

        public event VerbEventHandler Event;
    }
}
