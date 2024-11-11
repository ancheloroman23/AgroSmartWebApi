using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using AgroSmart.Core.Application.Dtos.Email;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Domain.Settings;

namespace AgroSmart.Infraestructure.Shared.Services
{
    public class EmailService : IEmailService
    {
        public EmailSettings EmailSettings { get; }

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public async Task SendAsync(EmailRequest emailRequest)
        {
            try
            {
                MimeMessage message = new()
                {
                    Sender = MailboxAddress.Parse(emailRequest.From ?? EmailSettings.EmailFrom)
                };

                message.To.Add(MailboxAddress.Parse(emailRequest.To));
                message.Subject = emailRequest.Subject;

                BodyBuilder bodyBuilder = new()
                {
                    HtmlBody = emailRequest.Body
                };

                message.Body = bodyBuilder.ToMessageBody();

                using SmtpClient smtpClient = new();
                smtpClient.Connect(EmailSettings.SmtpHost, EmailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(EmailSettings.SmtpUser, EmailSettings.SmtpPass);
                await smtpClient.SendAsync(message);
                smtpClient.Disconnect(true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
