using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.Smtp.Tests
{
    public class ServiceCollectionExtensionsTest
    {

        private readonly IServiceCollection services;

        public ServiceCollectionExtensionsTest()
        {
            services = new ServiceCollection();
        }

        [Fact]
        public void AddSmtpEmailService_Adds_EmailService_From_Delegate()
        {
            SmtpOptions smtpOptions = new SmtpOptions();
            services.AddSmtpEmailService(options => options = smtpOptions);
            var serviceProvider = services.BuildServiceProvider();
            Assert.NotNull(serviceProvider.GetService<IEmailService>());
        }
    }
}