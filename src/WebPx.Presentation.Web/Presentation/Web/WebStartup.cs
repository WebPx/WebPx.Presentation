using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(WebPx.Presentation.Web.WebStartup), "AppInitialize")]
namespace WebPx.Presentation.Web
{
    public static class WebStartup
    {
        public static void AppInitialize()
        {
            HttpApplication.RegisterModule(typeof(PresenterDataModule));
            Presenters.SetDataProvider(new PresentationWebDataProvider());
        }
    }
}

