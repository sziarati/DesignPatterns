using Common;
using DesignPatterns.Decorator;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Patterns.Controllers.Decorator
{
    [ApiController]
    [Route("[controller]")]
    public class DecoratorController : ControllerBase
    {
        //private readonly IEmailSender _emailSender;
        private readonly INotification _notification;
        public DecoratorController(/*IEmailSender emailSender,*/ INotification notification)
        {
            //_emailSender = emailSender;
            _notification = notification;
        }

        [HttpGet]
        [Route("DecoratorPattern")]
        public async Task<ActionResult<bool>> DecoratorPattern(string address)
        {
            return await _notification.Send(address);
            //var addressList = new List<string>() { address };
            //var message = new Message(addressList, "subject", "content");

            //return await _emailSender.SendEmail(message);
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}
