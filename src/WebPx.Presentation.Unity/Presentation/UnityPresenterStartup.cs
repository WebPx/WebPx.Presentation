using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(WebPx.Presentation.UnityPresenterStartup), "AppInitialize")]
namespace WebPx.Presentation
{
    public class UnityPresenterStartup
    {
        public static void AppInitialize()
        {
            Presenters.AddResolver(new UnityBuilder());
        }
    }
}
