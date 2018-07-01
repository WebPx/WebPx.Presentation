using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [View]
    public interface IEditView : IItemView
    {
        event CancelEventHandler Update;
    }

    [View]
    public interface IEditView<TEntity> : IEditView, IItemView<TEntity>
    {

    }
}
