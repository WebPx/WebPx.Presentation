using System;
using System.ComponentModel;
using WebPx.Events;
using WebPx.Repositories;

namespace WebPx.Presentation
{
    public abstract class KeyedRepositoryPresenter<TEntity, TKey> : RepositoryPresenter<TEntity>, IKeyedRepositoryPresenter<TEntity, TKey>
    {
        public KeyedRepositoryPresenter(IView<TEntity> view) : base(view)
        {

        }

        protected virtual void SetKey(TKey key)
        {
            this.Data["Key"] = key;
        }

        TKey IKeyedRepositoryPresenter<IRepository<TEntity>, TEntity, TKey>.GetKey()
        {
            return GetKey();
        }

        protected internal virtual TKey GetKey()
        {
            return (TKey)Convert.ChangeType(this.Data["Key"], typeof(TKey));
        }

        protected override void Delete(object sender, CancelEventArgs e)
        {
            if (Repository is IKeyedRepository<TEntity, TKey> keyed/* && this.View is IKeyedView<TKey> keyedView*/)
            {
                e.Cancel = !keyed.Delete(this.GetKey());
                MessageCenter.Assert<TEntity>(!e.Cancel, this, StandardMessages.Updated);
            }
            else
                base.Delete(sender, e);
        }

        protected override void LoadItem(object sender, EventArgs e)
        {
            if (Repository is IKeyedRepository<TEntity, TKey> keyed/* && this.View is IKeyedView<TKey> keyedView*/)
            {
                var itemView = (IItemView<TEntity>)View;
                itemView.Item = keyed.Find(this.GetKey());
                MessageCenter.Assert<TEntity>(itemView.Item == null, this, StandardMessages.ItemNotFound);
            }
            else
                throw new NotSupportedException($"The Repository does not support a recognized Find Pattern");
        }

        protected override void ItemSelected(object sender, EventArgs e)
        {
            if (View is IGridViewKey<TKey> gridViewKey)
                this.Data["Key"] = gridViewKey.SelectedKey;
            else
                throw new NotSupportedException($"The View does not support a recognized Grid Pattern");
        }

        protected override void LoadItems(object sender, EventArgs args)
        {
            base.LoadItems(sender, args);
        }
    }

    public abstract class KeyedRepositoryPresenter<TView, TEntity, TKey> : RepositoryPresenter<TView, TEntity>,
        IKeyedRepositoryPresenter<TEntity, TKey>
        where TView : IView<TEntity>
    {
        public KeyedRepositoryPresenter(TView view) : base(view)
        {
            
        }

        TKey IKeyedRepositoryPresenter<IRepository<TEntity>, TEntity, TKey>.GetKey()
        {
            return GetKey();
        }

        protected virtual void SetKey(TKey key)
        {
            this.Data["Key"] = key;
        }

        protected virtual TKey GetKey()
        {
            return (TKey)Convert.ChangeType(this.Data["Key"], typeof(TKey));
        }

        protected override void Delete(object sender, CancelEventArgs e)
        {
            if (Repository is IKeyedRepository<TEntity, TKey> keyed /*&& this.View is IKeyedView<TKey> keyedView*/)
                e.Cancel = !keyed.Delete(this.GetKey());
            else
                base.Delete(sender, e);
        }

        protected override void LoadItem(object sender, EventArgs e)
        {
            if (Repository is IKeyedRepository<TEntity, TKey> keyed /*&& this.View is IKeyedView<TKey> keyedView*/)
            {
                var itemView = (IItemView<TEntity>)View;
                itemView.Item = keyed.Find(this.GetKey());
                MessageCenter.Assert<TEntity>(itemView.Item == null, this, StandardMessages.ItemNotFound);
            }
            else
                throw new NotSupportedException($"The Repository does not support a recognized Find Pattern");
        }

        protected override void ItemSelected(object sender, EventArgs e)
        {
            if (View is IGridViewKey<TKey> gridViewKey)
                this.Data["Key"] = gridViewKey.SelectedKey;
            else
                throw new NotSupportedException($"The View does not support a recognized Grid Pattern");
        }

        protected override void LoadItems(object sender, EventArgs args)
        {
            base.LoadItems(sender, args);
        }
    }

    public abstract class KeyedRepositoryPresenter<TRepository, TView, TEntity, TKey> : RepositoryPresenter<TRepository, TView, TEntity>,
        IKeyedRepositoryPresenter<TRepository, TEntity, TKey>
        where TView : IView<TEntity>
        where TRepository : IRepository<TEntity>
    {
        public KeyedRepositoryPresenter(TView view) : base(view)
        {

        }

        TKey IKeyedRepositoryPresenter<TRepository, TEntity, TKey>.GetKey()
        {
            return GetKey();
        }

        protected virtual void SetKey(TKey key)
        {
            this.Data["Key"] = key;
        }

        protected virtual TKey GetKey()
        {
            return (TKey)Convert.ChangeType(this.Data["Key"], typeof(TKey));
        }

        protected override void Delete(object sender, CancelEventArgs e)
        {
            if (Repository is IKeyedRepository<TEntity, TKey> keyed /*&& this.View is IKeyedView<TKey> keyedView*/)
                e.Cancel = !keyed.Delete(GetKey());
            else
                base.Delete(sender, e);
        }

        protected override void LoadItem(object sender, EventArgs e)
        {
            if (Repository is IKeyedRepository<TEntity, TKey> keyed /*&& this.View is IKeyedView<TKey> keyedView*/)
            {
                var itemView = (IItemView<TEntity>)View;
                itemView.Item = keyed.Find(this.GetKey());
                MessageCenter.Assert<TEntity>(itemView.Item == null, this, StandardMessages.ItemNotFound);
            }
            else
                throw new NotSupportedException($"The Repository does not support a recognized Find Pattern");
        }

        protected override void ItemSelected(object sender, EventArgs e)
        {
            if (View is IGridViewKey<TKey> gridViewKey)
                this.Data["Key"] = gridViewKey.SelectedKey;
            else
                throw new NotSupportedException($"The View does not support a recognized Grid Pattern");
        }

        protected override void LoadItems(object sender, EventArgs args)
        {
            base.LoadItems(sender, args);
        }
    }
}
