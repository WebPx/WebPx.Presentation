using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public interface IModuleController : IView
    {
        ApplicationController Owner { get; set; }
    }
}
