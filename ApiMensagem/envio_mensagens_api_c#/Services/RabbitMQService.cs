using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace envio_mensagens_api_c_.Services
{
    public class RabbitMQService : BackgroundService
    {
        private readonly ILogger<RabbitMQService> _logger;
        private readonly ConnectionFactory _factory;
        private readonly string _queueName;

        public RabbitMQService(ILogger<RabbitMQService> logger)
        {
            _logger = logger;
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            _queueName = "FILA";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, message) =>
                {
                    var body = message.Body.ToArray();
                    var mensagem = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Received message: {mensagem}");
                };

                channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

                stoppingToken.ThrowIfCancellationRequested();
            }

            return Task.CompletedTask;
        }

        public void SendMessage(string id, string message)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes($"{id} - {message}");

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            }
        }
    }
}