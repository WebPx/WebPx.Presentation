using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPx.Web.Modules
{
    //[DefaultProperty("Text")]
    [ToolboxData("<{0}:ModuleScripts runat=server></{0}:ModuleScripts>")]
    public class ModuleScripts : WebControl
    {
        //[Bindable(true)]
        //[Category("Appearance")]
        //[DefaultValue("")]
        //[Localizable(true)]
        //public string Text
        //{
        //    get
        //    {
        //        String s = (String)ViewState["Text"];
        //        return ((s == null) ? String.Empty : s);
        //    }

        //    set
        //    {
        //        ViewState["Text"] = value;
        //    }
        //}

        protected override void RenderContents(HtmlTextWriter output)
        {
            var manager = PageModuleManager.Instance;
            var pageInfo = PageModuleManager.Get(this);
            if (manager != null && manager.HasScripts)
                if (!pageInfo._scriptsRendered)
                {
                    foreach (var script in manager.Scripts)
                    {
                        output.AddAttribute(HtmlTextWriterAttribute.Src, Page.ResolveClientUrl(script.Path));
                        output.RenderBeginTag(HtmlTextWriterTag.Script);
                        output.RenderEndTag();
                    }
                    pageInfo._scriptsRendered = true;
                }
        }
    }
}
