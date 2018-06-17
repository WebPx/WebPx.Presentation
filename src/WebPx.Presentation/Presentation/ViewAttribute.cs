using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    /// <summary>
    /// Identifies an interface that is usable by the Model View Presenter infrastructure
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public sealed class ViewAttribute : Attribute
    {
        public ViewAttribute()
        {

        }
    }
}
