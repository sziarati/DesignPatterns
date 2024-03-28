namespace Patterns.Proxy
{
    public interface IVideoDownloader
    {
        public FileStream Download(string url);
    }
}
