using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebPx.Presentation;

namespace WebPx.Web
{
    public sealed class StatusModule : IHttpModule
    {
        private HttpApplication _context;

        public StatusModule()
        {

        }

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["StatusManager"] = new StatusManager();
        }

        internal StatusManager GetManager(HttpContext context)
        {
            return context.Items["StatusManager"] as StatusManager;
        }
    }
}
