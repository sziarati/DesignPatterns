namespace Patterns.Proxy
{
    public class VideoDownloader : IVideoDownloader
    {
        public FileStream Download(string url)
        {
            return new FileStream(url, FileMode.Open);
        }
    }
}
