using DesignPatterns.Proxy;

namespace Patterns.Proxy
{
    public class VideoDownloaderProxy : IVideoDownloader
    {
        private readonly VideoDownloader VideoDownloader;
        Dictionary<string, FileStream> Videos = new();
        public VideoDownloaderProxy(VideoDownloader videoDownloader)
        {
            VideoDownloader = videoDownloader;
        }
        public FileStream Download(string url)
        {
            Videos.TryGetValue(url, out FileStream video);
            if (video?.Length > 0)
                return video;

            var downloadedVideo = VideoDownloader.Download(url);
            Videos.Add(url, downloadedVideo);
            return downloadedVideo;
        }
    }
}
