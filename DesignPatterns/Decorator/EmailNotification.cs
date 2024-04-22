using Common;

namespace DesignPatterns.Decorator;

public class EmailNotification : NotificationAbstract
{
    private readonly IEmailSender _emailSender;
    public EmailNotification(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public override async Task<bool> Send(string address)
    {
        var addressList = new List<string>() { address };
        var message = new Message(addressList, Subject, Content);
        return await _emailSender.SendEmail(message);
    }
}
