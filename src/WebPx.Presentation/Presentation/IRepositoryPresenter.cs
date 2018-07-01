namespace WebPx.Presentation
{
    public interface IRepositoryPresenter<TRepository>
    {
        TRepository Repository { get; set; }
    }
}
