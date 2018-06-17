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
    [ToolboxData("<{0}:ModuleParts runat=server></{0}:ModuleParts>")]
    public class ModuleParts : WebControl
    {

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            var manager = PageModuleManager.Instance;
            var pageInfo = PageModuleManager.Get(this);
            if (manager != null && manager.HasControls)
            {
                if (!pageInfo._controlsAdded)
                {
                    foreach (var controlInfo in manager.Controls)
                        if (controlInfo.Type == ModuleControlType.Footer)
                        {
                            //if (source == null)
                            //    continue;
                            if (!string.IsNullOrEmpty(controlInfo.Path))
                            {
                                var control = this.Page.LoadControl(controlInfo.Path);
                                this.Controls.Add(control);
                            }
                            else if (!string.IsNullOrEmpty(controlInfo.ClassType))
                            {
                                var type = controlInfo.ClassType;
                                var oType = Type.GetType(type);
                                if (!typeof(Control).IsAssignableFrom(oType))
                                    throw new System.Exception("The type {0} is not derived from System.Web.UI.Control");
                                var control = (Control)Activator.CreateInstance(oType);
                                this.Controls.Add(control);
                            }
                        }
                    pageInfo._controlsAdded = true;
                }
                if (!pageInfo._stylesAdded)
                {
                    foreach (var style in manager.Styles)
                    {
                        var linkTag = new System.Web.UI.HtmlControls.HtmlGenericControl("link");
                        linkTag.Attributes.Add("href", Page.ResolveClientUrl(style.Path));
                        linkTag.Attributes.Add("rel", "stylesheet");
                        linkTag.Attributes.Add("type", "text/css");
                        this.Page.Header.Controls.Add(linkTag);
                    }
                    pageInfo._stylesAdded = true;
                }
            }
        }
    }
}
