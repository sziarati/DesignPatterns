using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Common
{
    public class EmailSender : IEmailSender
    {
        private EmailConfiguration config { get; set; }
        public IConfiguration _configuration { get; set; }        
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;

            var from = _configuration.GetSection("EmailConfiguration:From").Value;
            var smtpServer = _configuration.GetSection("EmailConfiguration:SmtpServer").Value;
            var port = _configuration.GetSection("EmailConfiguration:Port").Value;
            var userName = _configuration.GetSection("EmailConfiguration:Username").Value;
            var password = _configuration.GetSection("EmailConfiguration:Password").Value;

            config = new EmailConfiguration
            {
                From = from,
                SmtpServer = smtpServer,
                Port = int.Parse(port),
                UserName = userName,
                Password = password,
            };
        }

        public async Task<bool> SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            return await Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(config.UserName , config.SmtpServer));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }
        private Task<bool> Send(MimeMessage mailMessage)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(config.SmtpServer, config.Port, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    //since 2022 google no longer supports the use of third party apps or devices which ask to sign in to accounts
                    //client.Authenticate(config.UserName, config.Password);
                    //client.Send(mailMessage);
                }
            }
            catch(Exception ex) 
            { }
            return Task.FromResult(true);
        }
    }
}