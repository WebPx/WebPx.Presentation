using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public sealed class ViewChangedEventArgs<TViewState> : EventArgs where TViewState : struct
    {
        internal ViewChangedEventArgs(TViewState viewState)
        {
            this.ViewState = viewState;
        }

        public TViewState ViewState { get; private set; }
    }
}
