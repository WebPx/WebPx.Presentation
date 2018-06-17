using System;
namespace WebPx.Presentation
{
    public interface IModuleController<TViewState> : IModuleController
     where TViewState : struct
    {
        void ChangeView(TViewState state);
        TView ChangeView<TView>(TViewState state);
        TView GetView<TView>();
        event ViewChangedEventHandler<TViewState> ViewChanged;
    }
}
