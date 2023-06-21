using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

class Program
{
    static void Main()
    {
        string fila = "FILA_TEXTO";
        string exchange = "EXCHANGE_TEXTO";

        ConnectionFactory factory = new ConnectionFactory
        {
            HostName = "localhost",
            // Uri = new Uri("")
        };

        using (IConnection connection = factory.CreateConnection())
        {
            IModel channel = SetupQueue(connection, fila, exchange);
            while (true)
            {
                Thread.Sleep(1000);
                SendMessage(channel, fila, "Mensagem de texto");
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
            routingKey: ""
        );

        return channel;
    }

    static void SendMessage(IModel channel, string fila, string mensagem)
    {
        byte[] body = Encoding.UTF8.GetBytes(mensagem);

        channel.BasicPublish(
            exchange: "",
            routingKey: fila,
            basicProperties: null,
            body: body
        );

        Console.WriteLine("Mensagem enviada: " + mensagem);
    }
}