using Common;

namespace DesignPatterns.Decorator;

public class EmailNotification(IEmailSender emailSender) : NotificationAbstract
{
    public override async Task<bool> Send(string address)
    {
        var addressList = new List<string>() { address };
        var message = new Message(addressList, Subject, Content);
        return await emailSender.SendEmail(message);
    }
}
