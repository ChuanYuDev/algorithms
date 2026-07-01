using System.Text;
using RabbitMQ.Client;

namespace Producer;

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

        for (var i = 0; i < 10; i++)
        {
            var message = $"{DateTime.UtcNow} - {Guid.NewGuid()}";
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: "message",
                mandatory: true,
                basicProperties: new BasicProperties{Persistent = true},
                body: body);
            
            Console.WriteLine($"Sent: {message}");

            await Task.Delay(TimeSpan.FromSeconds(1));
        }
        
    }
}