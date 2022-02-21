using RabbitMQ.Client;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;

namespace UnluCoProductCatalog.Persistence.Services.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        //private readonly IConfiguration _configuration;

        //public RabbitMqService(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new()
            {
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }

}
