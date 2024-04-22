using MimeKit;

namespace Common
{
    public class Message
    {
        public List<MailboxAddress> To { get; }
        public string Subject { get; }
        public string Content { get; }
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(subject, x )));
            Subject = subject;
            Content = content;
        }
    }

}