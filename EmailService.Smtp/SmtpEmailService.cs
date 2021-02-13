using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace EmailService.Smtp
{
    public class SmtpEmailService : EmailService<SmtpOptions>
    {
        public SmtpClient SmtpClient { get; set; }

        public SmtpEmailService(IOptions<SmtpOptions> options) : base(options)
        {
            SmtpClient = new SmtpClient(Options.Host, Options.Port);
        }

        public override async Task SendEmailAsync(MailMessage message)
        {
            MailMessage mailMessage = new()
            {
                From = new MailAddress(message.From.Address, message.From.DisplayName),
                IsBodyHtml = message.IsBodyHtml,
                Subject = message.Subject,
                Body = message.Body
            };
            mailMessage.To.Add(new MailAddress(message.To[0].Address, message.To[0].DisplayName));
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = Options.UseDefaultCredentials;
            await SmtpClient.SendMailAsync(mailMessage).ConfigureAwait(false);
            SmtpClient.Dispose();
        }
    }
}
