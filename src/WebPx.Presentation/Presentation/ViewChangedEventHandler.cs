using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Presentation
{
    public delegate void ViewChangedEventHandler<TViewState>(object sender, ViewChangedEventArgs<TViewState> args) where TViewState : struct;
}
