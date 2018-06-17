using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class PresentationResolverException : Exception
    {
        public PresentationResolverException(string message)
            : base(message)
        {

        }

        public PresentationResolverException(string message, params object[] values)
            : base(string.Format(message, values))
        {

        }
    }
}
