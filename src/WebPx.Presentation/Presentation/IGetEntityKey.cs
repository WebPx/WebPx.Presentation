namespace WebPx.Presentation
{
    interface IGetEntityKey<TEntity, TKey> : IPresenter<IView<TEntity>>
    {
        TKey GetKey(TEntity selectedItem);
    }
}
