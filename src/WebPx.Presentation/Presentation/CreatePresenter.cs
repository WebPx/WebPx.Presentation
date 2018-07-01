using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPx.Presentation
{
    public class CreatePresenter<TView, TEntity> : Presenter<TView>
        where TView : ICreateView<TEntity>
    {
        public CreatePresenter(TView view) : base(view)
        {

        }

        protected override void AttachView(TView view)
        {
            view.Create += Create;
        }

        protected virtual void Create(object sender, EventArgs e)
        {
            
        }
    }

    public class CreatePresenter<TEntity> : CreatePresenter<ICreateView<TEntity>, TEntity>
    {
        public CreatePresenter(ICreateView<TEntity> view) : base(view)
        {

        }
    }
}
