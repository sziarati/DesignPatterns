namespace DesignPatterns.Decorator;

public class SmsNotification : INotification
{
    public async Task<bool> Send(string address)
    {
        throw new NotImplementedException();
    }
}

