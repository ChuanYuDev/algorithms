using System.Numerics;

namespace Test.MathTest;

public class ModTest
{
    private const int Mod = 1_000_000_007;
    static void Main()
    {
        int a = Mod * 2 + 1, b = Mod * 2 + 2;
        Console.WriteLine($"a: {a}, b: {b}");

        int c = a + b;
        Console.WriteLine(c);

        var d = new BigInteger(a) + b;
        Console.WriteLine(d);
        
        Console.WriteLine(c % Mod);
        Console.WriteLine((a + b) % Mod);
        Console.WriteLine(d % Mod);

    }
}