using DesignPatterns.Builder;
using DesignPatterns.Entities;
using DesignPatterns.Proxy;
using Microsoft.AspNetCore.Mvc;

namespace Patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesingPatternController : ControllerBase
    {
        private readonly ILogger<DesingPatternController> _logger;
        private readonly IVideoDownloader videoDownloader;
        private readonly IUserProfileBuilder userProfileBuilder;
        private readonly IUserProfileChainOfResponsibilityBuilder userProfileChainOfResponsibilityBuilder;

        public DesingPatternController(
            ILogger<DesingPatternController> logger,
            IVideoDownloader videoDownloader,
            IUserProfileBuilder userProfileBuilder, 
            IUserProfileChainOfResponsibilityBuilder userProfileChainOfResponsibilityBuilder)
        {
            _logger = logger;
            this.videoDownloader = videoDownloader;
            this.userProfileBuilder = userProfileBuilder;
            this.userProfileChainOfResponsibilityBuilder = userProfileChainOfResponsibilityBuilder;
        }

        [HttpGet]
        [Route("ProxyPattern")]
        public FileStream ProxyPattern()
        {
            return videoDownloader.Download("");
        }

        [HttpGet]
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
        [HttpGet]
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
        [HttpGet]
        public void Get()
        {
        }
    }
}