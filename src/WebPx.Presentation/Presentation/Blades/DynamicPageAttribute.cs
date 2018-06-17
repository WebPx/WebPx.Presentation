using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation.Blades
{
#if BLADES
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class DynamicPageAttribute : Attribute
    {
        public DynamicPageAttribute()
        {

        }

        private bool _fullPostback = true;

        public bool FullPostback
        {
            get { return _fullPostback; }
            set { _fullPostback = value; }
        }

    }
#endif
}
