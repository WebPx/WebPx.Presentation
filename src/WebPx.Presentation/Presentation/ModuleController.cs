using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class ModuleController : ApplicationController, IModuleController
    {
        public ModuleController()
        {

        }

        public ApplicationController Owner { get; set; }
    }
}
