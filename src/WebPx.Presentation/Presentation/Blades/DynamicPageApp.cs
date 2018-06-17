using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPx.Presentation.Blades
{
#if BLADES
    class DynamicPageApp : System.Web.IHttpModule
    {
        public static string ClearTemplate { get; internal set; }

        public DynamicPageApp()
        {

        }

        void IHttpModule.Dispose()
        {

        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += HandlePageRequest;
        }

        private void HandlePageRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.CurrentHandler;
            if (request!=null && request is System.Web.UI.Page )
            {
                var page = (System.Web.UI.Page)request;
                var path = HttpContext.Current.Request["__blade"];
                    //var path = HttpUtility.UrlDecode(page.Request["__blade"]);
                    switch (path)
                    {
                        case "*":
                            if (!string.IsNullOrEmpty(ClearTemplate))
                            {
                                page.PreInit += new EventHandler((source, args) => {
                                    page.MasterPageFile = ClearTemplate; // "~/__layout/Clean.master";
                                });

                            }
                            break;
                        default:
                var r = page.GetType();
                var a = r.GetCustomAttributes(typeof(DynamicPageAttribute), true);
                if (a != null && a.Length > 0)
                {
                            if (!string.IsNullOrEmpty(path) && page.IsPostBack)
                            {
                                var uriBuilder = new UriBuilder(path);
                                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                                query["__blade"] = "*";
                                uriBuilder.Query = query.ToString();
                                path = uriBuilder.ToString();
                                page.Server.Transfer(path, true);
                            }
                }
                            break;
                    }
            }
        }
    }
#endif
}
