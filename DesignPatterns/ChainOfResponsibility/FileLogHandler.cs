using Microsoft.Extensions.Logging;

namespace DesignPatterns.ChainOfResponsibility;
public class FileLogHandler : AbstractLogHandler
{
    private string _filePath = Environment.CurrentDirectory;
    protected override LogLevel logLevel => LogLevel.Warning;
    public async override Task Handle(string logRequest, LogLevel level)
    {
        if (logLevel == level)
        {
            await File.AppendAllTextAsync(_filePath, logRequest);
        }

        else if (_nextHandler is not null)
        {
            await _nextHandler.Handle(logRequest, level);
        }
    }
}
