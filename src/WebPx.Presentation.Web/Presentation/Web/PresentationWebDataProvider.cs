using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPx.Presentation.Web
{
    public sealed class PresentationWebDataProvider : PresentationDataProvider
    {
        public PresentationWebDataProvider()
        {

        }

        public override IPresenterData PresenterData
        {
            get
            {
                var context = HttpContext.Current;
                if (context.Items["PageData"] is PresenterData data)
                    return data;
                return base.PresenterData;
            }
        }
    }
}
