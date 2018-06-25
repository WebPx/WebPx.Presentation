using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace WebPx.Presentation.Web
{
    class PresenterDataModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var control = new PresentationData();
            var data = new PresenterData(control);
            context.Items["PageData"] = data;
        }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            if (context.CurrentHandler is Page page)
                page.Init += Page_Init;
        }

        private void Page_Init(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            if (context.Items["PageData"] is PresenterData data)
                ((Page)context.Handler).Form.Controls.Add(data.Control);
        }
    }
}
