using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public sealed class ControllerInjectedEventArgs : EventArgs
    {
        internal ControllerInjectedEventArgs(object controller)
        {
            this.Controller = controller;
        }

        public object Controller { get; }
    }
}
