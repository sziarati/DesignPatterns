using Microsoft.Extensions.Logging;

namespace DesignPatterns.Decorator;

public class NotificationEmailLogDecorator : NotificationAbstract
{ 
    private readonly INotification _notification;
    private readonly ILogger _logger;

    public NotificationEmailLogDecorator(INotification notification, ILogger logger)
    {
        _notification = notification;
        _logger = logger;
    }
    public async override Task<bool> Send(string address)
    {
        _logger.Log(LogLevel.Information, $"NotificationSend to address {address}.");
        return await _notification.Send(address);
    }
}

