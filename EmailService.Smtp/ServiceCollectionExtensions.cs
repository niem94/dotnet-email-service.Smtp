using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace EmailService.Smtp
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSmtpEmailService(this IServiceCollection services,
                   Action<SmtpOptions> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SmtpEmailService>();
        }
    }
}