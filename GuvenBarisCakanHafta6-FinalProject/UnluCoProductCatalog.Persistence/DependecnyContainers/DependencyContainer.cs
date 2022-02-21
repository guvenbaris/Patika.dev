using Microsoft.Extensions.DependencyInjection;
using UnluCoProductCatalog.Application.Interfaces.Mail;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;
using UnluCoProductCatalog.Persistence.Services.Mail;
using UnluCoProductCatalog.Persistence.Services.RabbitMQ;


namespace UnluCoProductCatalog.Persistence.DependecnyContainers
{
    public static class DependencyContainer 
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ISmtpServer, SmtpServer>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();
        }
    }
}
