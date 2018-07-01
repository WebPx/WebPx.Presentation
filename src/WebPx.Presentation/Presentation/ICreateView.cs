using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    [View]
    public interface ICreateView : IView
    {
        event CancelEventHandler Create;
    }

    [View]
    public interface ICreateView<TEntity> : ICreateView, IView<TEntity>
    {
        TEntity Item { get; }
    }
}
