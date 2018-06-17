using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public delegate void ViewItemEventHandler<TEntity>(object sender, ViewItemEventArgs<TEntity> args);
}
