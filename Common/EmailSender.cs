using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Options;

namespace HomeTravelAPI.Common
{
    public class EmailSender : IMailService
    {
        private readonly EmailOption _emailOption;

        public EmailSender(IOptions<EmailOption> emailOption)
        {
            _emailOption = emailOption.Value;
        }

        public async Task<bool> SendMail(string toEmail,string message)
        {
            var msg = new SendGridMessage
            {
                From = new EmailAddress(_emailOption.FromEmail, _emailOption.FromName),
                Subject = "Notice from website HomeTravel",
                PlainTextContent = message
            };

            var apiKey = _emailOption.APIKey;
            var client = new SendGridClient(apiKey);
            msg.AddTo(toEmail);
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
    }
}
