using Microsoft.Extensions.Options;
using Xunit;

namespace EmailService.Smtp.Tests
{
    public class SmtpEmailServiceTest
    {
        private readonly IOptions<SmtpOptions> options = Options.Create(new SmtpOptions());
        [Fact]
        public void SmtpEmailService_Can_Construct()
        {
            SmtpEmailService smtpEmailService = new(options);

            TestClientDefaultValues(smtpEmailService);
            TestOptionsDefaultValues(smtpEmailService);
        }

        private static void TestClientDefaultValues(SmtpEmailService smtpEmailService)
        {
            Assert.Equal(443, smtpEmailService.SmtpClient.Port);
            //TODO: Finish this test
        }

        private static void TestOptionsDefaultValues(SmtpEmailService smtpEmailService)
        {
            Assert.Equal("", smtpEmailService.Options.DisplayName);
            Assert.Equal("", smtpEmailService.Options.Email);
            Assert.Equal("", smtpEmailService.Options.Host);
            Assert.Equal("", smtpEmailService.Options.Password);
            Assert.Equal("", smtpEmailService.Options.Username);
            Assert.False(smtpEmailService.Options.EnableSsl);
            Assert.False(smtpEmailService.Options.UseDefaultCredentials);
            Assert.Equal(8000, smtpEmailService.Options.Port);
        }

        [Fact]
        public void SendEmailAsync_Sends_Email()
        {
            SmtpEmailService smtpEmailService = new(options);
            //TODO: Finish this test
        }
    }
}