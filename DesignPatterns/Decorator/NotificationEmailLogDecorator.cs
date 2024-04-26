using Microsoft.Extensions.Logging;

namespace DesignPatterns.Decorator;

public class NotificationEmailLogDecorator(INotification notification, ILogger logger) : NotificationAbstract
{
    public async override Task<bool> Send(string address)
    {
        logger.Log(LogLevel.Information, $"NotificationSend to address {address}.");
        return await notification.Send(address);
    }
}

