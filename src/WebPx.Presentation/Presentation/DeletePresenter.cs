using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class DeletePresenter<TView, TEntity> : Presenter<TView>
        where TView : IDeleteView<TEntity>
    {
        public DeletePresenter(TView view) : base(view)
        {
            
        }

        protected override void AttachView(TView view)
        {
            view.Delete += Delete;
        }

        protected virtual void Delete(object sender, EventArgs e)
        {

        }
    }

    public class DeletePresenter<TEntity> : DeletePresenter<IDeleteView<TEntity>, TEntity>
    {
        public DeletePresenter(IDeleteView<TEntity> view) : base(view)
        {

        }
    }
}
