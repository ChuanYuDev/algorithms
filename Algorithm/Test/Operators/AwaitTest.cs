namespace Test.Operators;

public class AwaitTest
{
    static async Task Main()
    {
        // var result = await Math.Max(1, 2);
        var result = Math.Max(1, 2);
        Console.WriteLine(result);
    }
}