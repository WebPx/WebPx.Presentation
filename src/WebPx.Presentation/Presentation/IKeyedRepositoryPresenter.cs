using WebPx.Repositories;

namespace WebPx.Presentation
{
    public interface IKeyedRepositoryPresenter<TEntity, TKey> : IKeyedRepositoryPresenter<IRepository<TEntity>, TEntity, TKey>, IRepositoryPresenter<IRepository<TEntity>>
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRepositoy"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IKeyedRepositoryPresenter<TRepositoy, TEntity, TKey> : IRepositoryPresenter<TRepositoy>
    {
        TKey GetKey();
    }
}
