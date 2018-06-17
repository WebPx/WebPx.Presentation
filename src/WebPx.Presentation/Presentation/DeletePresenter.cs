using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class DeletePresenter<TView> : Presenter<TView>
        where TView : IDeleteView
    {
        public DeletePresenter(TView view) : base(view)
        {

        }

        protected override void AttachView(TView view)
        {
            view.Cancel += Cancel;
            view.Save += Save;
        }

        protected virtual void Save(object sender, EventArgs e)
        {

        }

        protected virtual void Cancel(object sender, EventArgs e)
        {

        }
    }

    public class DeletePresenter : DeletePresenter<IDeleteView>
    {
        public DeletePresenter(IDeleteView view) : base(view)
        {

        }
    }
}
