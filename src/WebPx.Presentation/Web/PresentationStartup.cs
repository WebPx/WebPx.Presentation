using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using WebPx.Presentation.Blades;

[assembly: PreApplicationStartMethod(typeof(WebPx.Web.PresentationStartup), "AppInitialize")]
namespace WebPx.Web
{
    public static class PresentationStartup
    {
        public static void AppInitialize()
        {
            bool enabled = true;
            var value = ConfigurationManager.AppSettings["blades:ClearTemplate"];
            if (!string.IsNullOrEmpty(value))
            {
#if BLADES
                DynamicPageApp.ClearTemplate = value;
                HttpApplication.RegisterModule(typeof(DynamicPageApp));
#endif
                HttpApplication.RegisterModule(typeof(StatusModule));
            }
        }
    }
}
