
using Microsoft.Extensions.Logging;

namespace DesignPatterns.ChainOfResponsibility;

public abstract class AbstractLogHandler
{
    protected AbstractLogHandler? _nextHandler;
    protected LogLevel _logLevel;
    protected abstract LogLevel logLevel { get;}

    public AbstractLogHandler SetNextHandler(AbstractLogHandler nextHandler) 
    { 
        _nextHandler = nextHandler;
        return _nextHandler;
    }
    public abstract Task Handle(string logRequest, LogLevel level);
}
