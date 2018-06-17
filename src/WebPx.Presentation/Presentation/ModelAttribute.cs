using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class ModelAttribute : Attribute
    {
        public ModelAttribute()
        {

        }
    }
}
