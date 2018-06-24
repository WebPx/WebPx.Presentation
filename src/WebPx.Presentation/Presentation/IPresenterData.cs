namespace WebPx.Presentation
{
    public interface IPresenterData
    {
        object this[string key] { get; set; }
    }
}