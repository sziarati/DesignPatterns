using DesignPatterns.Proxy;

namespace Patterns.Proxy
{
    public class VideoDownloaderProxy : IVideoDownloader
    {
        private readonly VideoDownloader _videoDownloader;
        Dictionary<string, FileStream> Videos = new();
        public VideoDownloaderProxy(VideoDownloader videoDownloader)
        {
            _videoDownloader = videoDownloader;
        }
        public FileStream Download(string url)
        {
            Videos.TryGetValue(url, out FileStream video);
            if (video?.Length > 0)
                return video;

            var downloadedVideo = _videoDownloader.Download(url);
            Videos.Add(url, downloadedVideo);
            return downloadedVideo;
        }
    }
}
