using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebPx.Web;

namespace WebPx.Presentation
{
    public static class Status
    {
        private static StatusManager GetManager()
        {
            var context = HttpContext.Current;
            var module = context.ApplicationInstance.Modules["StatusModule"] as StatusModule;
            var manager = module.GetManager(context);
            return manager;
        }

        public static void AddMessage(string content, StatusType statusType = StatusType.Success, ContentType contentType = ContentType.Text)
        {
            var manager = GetManager();
            if (manager != null)
                manager.Add(new StatusMessage() { StatusType = statusType, ContentType = contentType, Content = content });
        }

        public static StatusMessage[] GetMessages()
        {
            var manager = GetManager();
            return manager != null ? manager.GetMessages() : null;
        }

        public static void Reset()
        {
            var manager = GetManager();
            if (manager != null)
                manager.Reset();
        }
    }
}
