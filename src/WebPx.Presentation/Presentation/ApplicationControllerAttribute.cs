using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = true)]
    public class ApplicationControllerAttribute : Attribute
    {
        public ApplicationControllerAttribute(ApplicationControllerMode mode = ApplicationControllerMode.Shared)
        {
            this.Mode = mode;
        }

        public ApplicationControllerMode Mode { get; set; }
    }
}
