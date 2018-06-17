using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Web.Modules
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleControlCaptionAttribute : Attribute
    {
        public ModuleControlCaptionAttribute(string caption)
        {
            this.Caption = caption;
        }

        public string Caption { get; private set; }
    }
}
