using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class EditPresenter<TView, TEntity> : Presenter<TView>
        where TView : IEditView<TEntity>
    {
        public EditPresenter(TView view) : base(view)
        {

        }

        protected override void AttachView(TView view)
        {
            view.Update += Update;
        }

        protected virtual void Update(object sender, EventArgs e)
        {

        }
    }

    public class EditPresenter<TEntity> : EditPresenter<IEditView<TEntity>, TEntity>
    {
        public EditPresenter(IEditView<TEntity> view) : base(view)
        {

        }
    }
}
