using DesignPatterns.Builder;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Entities;
using DesignPatterns.Proxy;
using DesignPatterns.Singleton;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesignPatternController(
        ILogger<DesignPatternController> logger,
        IVideoDownloader videoDownloader,
        IUserProfileBuilder userProfileBuilder,
        IUserProfileChainOfResponsibilityBuilder userProfileChainOfResponsibilityBuilder) : ControllerBase
    {
        [HttpGet]
        [Route("ProxyPattern")]
        public FileStream ProxyPattern()
        {
            return videoDownloader.Download("");
        }

        [HttpPost]
        [Route("BuilderPattern")]
        public UserProfile BuilderPattern()
        {
            userProfileBuilder.IsPrivate();
            userProfileBuilder.Locked();
            userProfileBuilder.Active();
            userProfileBuilder.NotifyByEmail();
            var userProfile = userProfileBuilder.Build();
            return userProfile;
        }
        [HttpPost]
        [Route("BuilderPatternChainOfResponsibility")]
        public UserProfile BuilderPatternChainOfResponsibility()
        {
            var userProfile = 
                userProfileChainOfResponsibilityBuilder.IsPrivate()
                .Locked()
                .Active()
                .NotifyByEmail()
                .Build();

            return userProfile;
        }

        [HttpPost]
        [Route("ChainOfResponsibilityPattrn")]
        public void ChainOfResponsibilityPattern(LogLevel logLevel)
        {
            string logMessage = System.Text.Json.JsonSerializer.Serialize(HttpContext.Request.Path);
            AbstractLogHandler fileLogHandler = new FileLogHandler();
            AbstractLogHandler mailLogHandler = new EmailLogHandler();
            AbstractLogHandler consoleLogHandler = new ConsoleLogHandler();

            // Set up the chain
            fileLogHandler
                .SetNextHandler(mailLogHandler)
                .SetNextHandler(consoleLogHandler);

            fileLogHandler.Handle(logMessage, logLevel);
        }

        [HttpPost]
        [Route("SingletonPattrn")]
        public async Task<JsonResult> SingletonPattrn([FromHeader]string key, [FromHeader]string value)
        {
            var cache = CacheManager.GetCache();
            await cache.Set(key, value);
            var cachedValue = await cache.Get(key);
            return new JsonResult(cachedValue);
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}