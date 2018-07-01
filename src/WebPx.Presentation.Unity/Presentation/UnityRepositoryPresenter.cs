using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;
using WebPx.Repositories;

namespace WebPx.Presentation
{
    public abstract class UnityRepositoryPresenter<TRepository, TView, TEntity> : RepositoryPresenter<TRepository, TView, TEntity>
        where TView : IView<TEntity>
        where TRepository : IRepository<TEntity>
    {
        public UnityRepositoryPresenter(IView<TEntity> view) : base(view)
        {

        }

        [Dependency]
        public override TRepository Repository { get => base.Repository; set => base.Repository = value; }
    }

    public abstract class UnityRepositoryPresenter<TView, TEntity> : RepositoryPresenter<TView, TEntity>
        where TView : IView<TEntity>
    {
        public UnityRepositoryPresenter(TView view) : base(view)
        {

        }

        [Dependency]
        public override IRepository<TEntity> Repository { get => base.Repository; set => base.Repository = value; }
    }

    public abstract class UnityRepositoryPresenter<TEntity> : RepositoryPresenter<TEntity>
    {
        public UnityRepositoryPresenter(IView<TEntity> view) : base(view)
        {

        }

        [Dependency]
        public override IRepository<TEntity> Repository { get => base.Repository; set => base.Repository = value; }
    }

    public abstract class UnityKeyedRepositoryPresenter<TRepository, TView, TEntity, TKey> : KeyedRepositoryPresenter<TRepository, TView, TEntity, TKey>
        where TView : IView<TEntity>
        where TRepository : IRepository<TEntity>
    {
        public UnityKeyedRepositoryPresenter(TView view) : base(view)
        {

        }

        [Dependency]
        public override TRepository Repository { get => base.Repository; set => base.Repository = value; }
    }

    public abstract class UnityKeyedRepositoryPresenter<TView, TEntity, TKey> : KeyedRepositoryPresenter<TView, TEntity, TKey>
        where TView : IView<TEntity>
    {
        public UnityKeyedRepositoryPresenter(TView view) : base(view)
        {

        }

        [Dependency]
        public override IRepository<TEntity> Repository { get => base.Repository; set => base.Repository = value; }
    }

    public abstract class UnityKeyedRepositoryPresenter<TEntity, TKey> : KeyedRepositoryPresenter<TEntity, TKey>
    {
        public UnityKeyedRepositoryPresenter(IView<TEntity> view) : base(view)
        {

        }

        [Dependency]
        public override IRepository<TEntity> Repository { get => base.Repository; set => base.Repository = value; }
    }

}
