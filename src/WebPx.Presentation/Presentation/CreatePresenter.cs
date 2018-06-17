using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class CreatePresenter<TView> : Presenter<TView>
        where TView : ICreateView
    {
        public CreatePresenter(TView view) : base(view)
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

    public class CreatePresenter : CreatePresenter<ICreateView>
    {
        public CreatePresenter(ICreateView view) : base(view)
        {

        }
    }
}
