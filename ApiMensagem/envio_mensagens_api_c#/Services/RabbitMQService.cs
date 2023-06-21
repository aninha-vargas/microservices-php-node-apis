using System.Text;
using RabbitMQ.Client;

namespace envio_mensagens_api_c_.Services
{
    public class RabbitMQSenderService
    {
        private readonly ConnectionFactory _factory;

        public RabbitMQSenderService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public void SendMessage(string message, string queueName)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
        }
    }
}