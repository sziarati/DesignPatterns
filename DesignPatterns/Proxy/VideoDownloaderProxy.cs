using DesignPatterns.Proxy;

namespace Patterns.Proxy
{
    public class VideoDownloaderProxy(VideoDownloader videoDownloader) : IVideoDownloader
    {
        Dictionary<string, FileStream> Videos = new();

        public FileStream Download(string url)
        {
            Videos.TryGetValue(url, out FileStream video);
            if (video?.Length > 0)
                return video;

            var downloadedVideo = videoDownloader.Download(url);
            Videos.Add(url, downloadedVideo);
            return downloadedVideo;
        }
    }
}
