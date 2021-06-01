using System;
using System.Net.Mail;
using System.Threading.Tasks;

using CSharpFunctionalExtensions;

using ServiceTemplate.Domain.Interfaces;

namespace ServiceTemplate.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public async Task<Result> SendEmail(string to, string text, string subject)
        {
            var client = new SmtpClient(_settings.Server, _settings.Port);

            try
            {
                await client.SendMailAsync(_settings.From, to, subject, text);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.ToString());
            }
        }
    }
}
