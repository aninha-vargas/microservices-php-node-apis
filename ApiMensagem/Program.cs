using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;

namespace envio_mensagem_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            string fila = "FILA";
            string exchange = "EXCHANGE";

            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = SetupQueue(connection, fila, exchange))
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    SendMessage(channel, fila, "Mensagem 1");
                }
            }
        }

        static IModel SetupQueue(IConnection connection, string fila, string exchange)
        {
            IModel channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: fila,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            channel.ExchangeDeclare(
                exchange: exchange,
                type: ExchangeType.Direct
            );

            channel.QueueBind(
                queue: fila,
                exchange: exchange,
                routingKey: string.Empty
            );

            return channel;
        }

        static void SendMessage(IModel channel, string fila, string mensagem)
        {
            byte[] body = Encoding.UTF8.GetBytes(mensagem);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: fila,
                basicProperties: null,
                body: body
            );

            Console.WriteLine($"Mensagem enviada: {mensagem}");
        }
    }
}