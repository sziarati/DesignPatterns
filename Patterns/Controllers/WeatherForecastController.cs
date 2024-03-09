using Microsoft.AspNetCore.Mvc;
using Patterns.Proxy;

namespace Patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IVideoDownloader videoDownloader;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IVideoDownloader videoDownloader)
        {
            _logger = logger;
            this.videoDownloader = videoDownloader;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            videoDownloader.Download("");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}