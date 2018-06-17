using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public abstract class WebViewModuleController<TViewState> : WebModuleController, IModuleController<TViewState> where TViewState : struct
    {
        public WebViewModuleController()
        {
            
        }

        public virtual void ChangeView(TViewState state)
        {
            var args = new ViewChangedEventArgs<TViewState>(state);
            if (ViewChanged != null)
                ViewChanged(this, args);
        }

        public virtual TView ChangeView<TView>(TViewState state)
        {
            var args = new ViewChangedEventArgs<TViewState>(state);
            if (ViewChanged != null)
                ViewChanged(this, args);
            return this.GetView<TView>();
        }
        
        public virtual TView GetView<TView>()
        {
            return default(TView);
        }

        public event ViewChangedEventHandler<TViewState> ViewChanged;
    }
}
