using Microsoft.Extensions.Logging;

namespace DesignPatterns.ChainOfResponsibility;

public class ConsoleLogHandler : AbstractLogHandler
{
    protected override LogLevel logLevel => LogLevel.Debug;

    public async override Task Handle(string logRequest, LogLevel level)
    {
        if (logLevel == level)
        {
            Console.WriteLine(logRequest);
        }
        else if (_nextHandler is not null)
        {
            await _nextHandler.Handle(logRequest, level);
        }
    }
}