using System;

namespace WebPx.Presentation
{
    public interface IItemView : IView
    {

    }

    public interface IItemView<T> : IItemView, IView<T>
    {
        T Item { get; set; }
        event EventHandler LoadItem;
    }
}
