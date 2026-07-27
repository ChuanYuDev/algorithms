namespace Test.TypesTest.TupleTest;

public class BasicTest
{
    static void Main()
    {
        (double, int) t1 = (4.5, 3);
        Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

        t1.Item1 = 10;
        Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");
        
        int a = 5, b = 10;
        Console.WriteLine($"a: {a}, b: {b}");

        (a, b) = (b, a);
        Console.WriteLine($"a: {a}, b: {b}");
    }
}