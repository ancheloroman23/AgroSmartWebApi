using AgroSmart.Core.Application.Dtos.Email;
using AgroSmart.Core.Domain.Settings;

namespace AgroSmart.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public EmailSettings EmailSettings { get; }
        Task SendAsync(EmailRequest emailRequest);
    }
}
