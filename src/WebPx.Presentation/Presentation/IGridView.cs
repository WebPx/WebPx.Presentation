using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPx.Data;

namespace WebPx.Presentation
{
    public interface IGridView<T> : IView<T>
    {
        event EventHandler LoadItems;
        IEnumerable<T> Items { get; set; }
        event EventHandler ItemSelected;
        //T SelectedItem { get; }
    }

    public interface IGridView<TEntity, TKey> : IGridView<TEntity>, IGridViewKey<TKey>
    {
    }
}
