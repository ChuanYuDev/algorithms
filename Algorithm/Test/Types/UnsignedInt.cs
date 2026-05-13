namespace Test.Types;

public class UnsignedInt
{
    static void Main()
    {
        int target = 1769097904;
        int a = 758043978;
        
        Console.WriteLine(target + a);
        Console.WriteLine(target + a > target);

        uint t = (uint)target;
        Console.WriteLine(t + a > t);
    }
}