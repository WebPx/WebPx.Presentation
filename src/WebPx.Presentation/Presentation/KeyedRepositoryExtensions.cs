using System;
using WebPx.Events;
using WebPx.Repositories;

namespace WebPx.Presentation
{
    public static class KeyedRepositoryExtensions
    {

        public static TEntity LoadItem<TEntity, TKey>(this IKeyedRepositoryPresenter<TEntity, TKey> presenter)
        {
            if (presenter.Repository is IKeyedRepository<TEntity, TKey> keyed/* && this.View is IKeyedView<TKey> keyedView*/)
            {
                var item = keyed.Find(presenter.GetKey());
                MessageCenter.Assert<TEntity>(item == null, presenter, StandardMessages.ItemNotFound);
                return item;
            }
            else
                throw new NotSupportedException($"The Repository does not support a recognized Find Pattern");
        }

        public static TEntity LoadItem<TRepository, TEntity, TKey>(this IKeyedRepositoryPresenter<TRepository, TEntity, TKey> presenter)
        {
            if (presenter.Repository is IKeyedRepository<TEntity, TKey> keyed/* && this.View is IKeyedView<TKey> keyedView*/)
            {
                var item = keyed.Find(presenter.GetKey());
                MessageCenter.Assert<TEntity>(item == null, presenter, StandardMessages.ItemNotFound);
                return item;
            }
            else
                throw new NotSupportedException($"The Repository does not support a recognized Find Pattern");
        }

    }
}
