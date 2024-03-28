namespace DesignPatterns.Proxy
{
    public interface IVideoDownloader
    {
        public FileStream Download(string url);
    }
}
