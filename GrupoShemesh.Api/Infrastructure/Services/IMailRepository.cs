using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace GrupoShemesh.Infrastructure.Services
{
    public interface IMailRepository
    {
        void SendMail(string to, string subject, string body);
    }
    public class MailRepository : IMailRepository
    {
        private readonly IConfiguration _configuration;

        public MailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendMail(string to, string subject, string body)
        {
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(from));
            message.To.Add(new MailboxAddress(to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            client.Connect(smtp, int.Parse(port), false);
            client.Authenticate(from, password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
