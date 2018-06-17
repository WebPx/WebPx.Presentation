using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Web
{
    public sealed class WebEventArgs : EventArgs
    {
        internal WebEventArgs(string verb, object message, object arguments = null)
        {
            this.Verb = verb;
            this.Message = message;
            this.Arguments = arguments;
        }

        public string Verb { get; private set; }

        public object Message { get; private set; }

        public object Arguments { get; private set; }
    }
}
