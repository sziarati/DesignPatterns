namespace Common
{
    public interface IEmailSender
    {
        public Task<bool> SendEmail(Message message);
    }
}