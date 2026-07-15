using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsumerTest;

class Program
{
    static async Task Main(string[] args)
    {
        var connectionFactory = new ConnectionFactory { HostName = "localhost" };
        await using var connection = await connectionFactory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: "message",
            durable: true,
            exclusive: false,
            autoDelete: false
        );
        
        Console.WriteLine("Waiting for messages...");

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (sender, eventArgs) =>
        {
            byte[] body = eventArgs.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            
            Console.WriteLine($"Received: {message}");

            await ((AsyncEventingBasicConsumer)sender).Channel.BasicAckAsync(eventArgs.DeliveryTag, multiple: false);
        };

        await channel.BasicConsumeAsync("message", autoAck: false, consumer:consumer);
        
        Console.ReadLine();
    }
}