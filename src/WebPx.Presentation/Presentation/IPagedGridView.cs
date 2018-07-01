using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPx.Data;

namespace WebPx.Presentation
{
    public interface IPagedGridView<T> : IView<T>
    {
        event DataPageEventHandler LoadItems;
        DataPagedItems<T> Items { get; set; }
        event EventHandler ItemSelected;
        //T SelectedItem { get; }
    }
    public interface IPagedGridView<TEntity, TKey> : IPagedGridView<TEntity>, IGridViewKey<TKey>
    {
    }
    public interface IGridViewKey<TKey>
    {
        TKey SelectedKey { get; }
    }
}
