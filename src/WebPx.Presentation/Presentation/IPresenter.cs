namespace WebPx.Presentation
{
    public interface IPresenter<TView>
    {
        TView View { get; }
    }
}