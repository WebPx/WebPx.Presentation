using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [View]
    public interface IDeleteView : IItemView
    {
        event CancelEventHandler Delete;
    }

    [View]
    public interface IDeleteView<TEntity> : IDeleteView, IItemView<TEntity>
    {

    }
}
