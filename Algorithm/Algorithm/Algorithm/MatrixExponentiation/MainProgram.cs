namespace Algorithm.Algorithm.MatrixExponentiation;

public class MainProgram
{
    public static void Main(string[] args)
    {
        var sol = new Solution();
        
        int n = 1;
        Console.WriteLine(sol.NthFibonacci(n));
        //  Output: 1
        
        n = 3;
        Console.WriteLine(sol.NthFibonacci(n));
        //  Output: 2

        n = 7;
        Console.WriteLine(sol.NthFibonacci(n));
        //  Output: 13

        n = 10;
        Console.WriteLine(sol.NthFibonacci(n));
        //  Output: 55
        
        n = 12;
        Console.WriteLine(sol.NthFibonacci(n));
        //  Output: 144
    }
}