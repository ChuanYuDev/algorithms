using StackExchange.Redis;

namespace RedisWebApiTest;

public class RedisBackgroundJob(IConnectionMultiplexer connectionMultiplexer): BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var db = connectionMultiplexer.GetDatabase();

        var isSet = db.StringSet("foo", "bar");
        Console.WriteLine(isSet);
        
        var value = db.StringGet("foo");
        Console.WriteLine(value);
        
        isSet = await db.StringSetAsync("foo2", "bar2");
        Console.WriteLine(isSet);
        
        value = db.StringGet("foo2");
        Console.WriteLine(value);
        
        isSet = await db.StringSetAsync("foo3", "bar3", TimeSpan.FromSeconds(10));
        Console.WriteLine(isSet);
        
        value = db.StringGet("foo3");
        Console.WriteLine(value);

    }
}