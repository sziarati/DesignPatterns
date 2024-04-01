using Microsoft.Extensions.Logging;

namespace DesignPatterns.ChainOfResponsibility;
public class EmailLogHandler : AbstractLogHandler
{
    protected override LogLevel logLevel => LogLevel.Critical;

    public async override Task Handle(string logRequest, LogLevel level)
    {
        if (logLevel == level)
        {
            //todo: must implement 
        }
        else if (_nextHandler is not null)
        {
            await _nextHandler.Handle(logRequest, level);
        }
    }
}