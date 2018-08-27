using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPx.Data;
using WebPx.Events;
using WebPx.Repositories;

namespace WebPx.Presentation
{
    /// <summary>
    /// Base class for a repository presenter that allows common operations
    /// </summary>
    /// <typeparam name="TRepository">The type of the repository</typeparam>
    /// <typeparam name="TView">The type of the base view</typeparam>
    /// <typeparam name="TEntity">The type of the entity</typeparam>
    public abstract class RepositoryPresenter<TRepository, TView, TEntity> : EntityPresenter<TEntity>, IRepositoryPresenter<TRepository>
        where TView : IView<TEntity>
        where TRepository : IRepository<TEntity>
    {
        public RepositoryPresenter(IView<TEntity> view) : base(view)
        {

        }

        public virtual TRepository Repository { get; set; }

        protected override void Create(object sender, CancelEventArgs e)
        {
            var item = ((ICreateView<TEntity>)this.View).Item;

            var created = ItemCreating(item) && Repository.Create(item);
            if (created)
                ItemCreated(item);
            e.Cancel = !created;
            MessageCenter.Assert(!e.Cancel, this, StandardMessages.Created, item);
        }

        public virtual bool ItemCreating(TEntity item) => true;

        protected abstract void ItemCreated(TEntity item);

        protected override void Update(object sender, CancelEventArgs e)
        {
            var item = ((IItemView<TEntity>)this.View).Item;
            var updated = ItemUpdating(item) && Repository.Update(item);
            if (updated)
                ItemUpdated(item);
            e.Cancel = !updated;
            MessageCenter.Assert(!e.Cancel, this, StandardMessages.Updated, item);
        }

        public virtual bool ItemUpdating(TEntity item) => true;

        protected virtual void ItemUpdated(TEntity item) { }

        protected override void Delete(object sender, CancelEventArgs e)
        {
            if (Repository is IDeletableRepository<TEntity> deletable)
            {
                var item = ((IItemView<TEntity>)this.View).Item;
                var deleted = ItemDeleting(item) && deletable.Delete(item);
                e.Cancel = !deleted;
                MessageCenter.Assert<TEntity>(!e.Cancel, this, StandardMessages.Updated);
            }
            else
                throw new NotSupportedException($"The Repository does not support a recognized Delete Pattern");
        }

        public virtual bool ItemDeleting(TEntity item) => true;

        protected virtual void ItemDeleted(TEntity item) { }

        protected override void LoadItems(object sender, EventArgs args)
        {
            switch (View)
            {
                case IPagedGridView<TEntity> paged:
                    switch (Repository)
                    {
                        case IRepositoryPagedList<TEntity> repList:
                            if (args is DataPageEventArgs pageArgs)
                            {
                                var page = repList.List(pageArgs.StartRowIndex, pageArgs.MaximumRows, out int totalRowCount);
                                paged.Items = new DataPagedItems<TEntity>(page, totalRowCount);
                                break;
                            }
                            goto default;
                        default:
                            throw new NotSupportedException($"The Repository '{Repository?.GetType().FullName??"unknown"}' does not implement IRepositoryPagedList<{typeof(TEntity).Name}>");
                    }
                    break;
                case IGridView<TEntity> pagedList:
                    switch (Repository)
                    {
                        case IRepositoryList<TEntity> repList:
                            if (args is DataPageEventArgs pageArgs)
                            {
                                var list = repList.List(pageArgs.StartRowIndex, pageArgs.MaximumRows);
                                pagedList.Items = list;
                                break;
                            }
                            goto default;
                        default:
                            throw new NotSupportedException($"The Repository does not implement IRepositoryList<{typeof(TEntity).Name}>");
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Base class for a repository presenter that allows common operations with a default view interface
    /// </summary>
    /// <typeparam name="TView">The type of the base view</typeparam>
    /// <typeparam name="TEntity">The type of the entity</typeparam>
    public abstract class RepositoryPresenter<TView, TEntity> : RepositoryPresenter<IRepository<TEntity>, TView, TEntity>
        where TView : IView<TEntity>
    {
        public RepositoryPresenter(TView view) : base(view)
        {

        }
    }

    /// <summary>
    /// Base class for a repository presenter that allows common operations with a default view interface and default repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity</typeparam>
    public abstract class RepositoryPresenter<TEntity> : RepositoryPresenter<IView<TEntity>, TEntity>
    {
        public RepositoryPresenter(IView<TEntity> view) : base(view)
        {

        }
    }
}
