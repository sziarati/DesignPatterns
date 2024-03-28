using Microsoft.AspNetCore.Mvc;
using Patterns.Proxy;

namespace Patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IVideoDownloader videoDownloader;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IVideoDownloader videoDownloader)
        {
            _logger = logger;
            this.videoDownloader = videoDownloader;
        }

        [HttpGet]
        public FileStream Get()
        {
            return videoDownloader.Download("");
        }
    }
}