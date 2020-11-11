using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using EmailService.Smtp;
using EmailService.SendGrid;

namespace EmailService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSmtpEmailService(this IServiceCollection services,
                   Action<SmtpSettings> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SmtpEmailService>();
        }

        public static void AddSmtpEmailService(this IServiceCollection services,
                   SmtpSettings options)
        {
            services.ConfigureOptions(options);
            services.AddTransient<IEmailService, SmtpEmailService>();
        }
    }
}