using Common;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Patterns.Controllers.Decorator
{
    [ApiController]
    [Route("[controller]")]
    public class DecoratorController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public DecoratorController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        [Route("DecoratorPattern")]
        public async Task<ActionResult<bool>> DecoratorPattern(string address)
        {
            var addressList = new List<string>() { address };
            var message = new Message(addressList, "subject", "content");

            return await _emailSender.SendEmail(message);
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}
