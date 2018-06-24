using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPx.Presentation.Web
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:PresentationData runat=server></{0}:PresentationData>")]
    class PresentationData : WebControl, IStateBag
    {
        internal PresentationData()
        {

        }

        StateBag IStateBag.Data => this.ViewState;
    }
}
