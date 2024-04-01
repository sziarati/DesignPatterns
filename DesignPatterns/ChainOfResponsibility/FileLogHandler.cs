using Microsoft.Extensions.Logging;

namespace DesignPatterns.ChainOfResponsibility;
public class FileLogHandler : AbstractLogHandler
{
    private string FilePath = Environment.CurrentDirectory;
    protected override LogLevel logLevel => LogLevel.Warning;
    public async override Task Handle(string logRequest, LogLevel level)
    {
        if (_logLevel == level)
        {
            await File.AppendAllTextAsync(FilePath, logRequest);
        }

        else if (_nextHandler is not null)
        {
            await _nextHandler.Handle(logRequest, level);
        }
    }
}
