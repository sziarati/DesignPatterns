namespace DesignPatterns.Decorator
{
    public abstract class NotificationAbstract : INotification
    {
        public string Address { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }

        public abstract Task<bool> Send(string address);
    }
    public interface INotification
    {
        public Task<bool> Send(string address);
    }

}
