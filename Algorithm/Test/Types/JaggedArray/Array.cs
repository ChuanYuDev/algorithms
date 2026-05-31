namespace Test.Types.JaggedArray;

public class Array
{
    static void Main()
    {
        // Jagged array
        int[][] array = [[1, 3], [4, 10], [2, 5]];
       
        // Console.WriteLine($"{array.GetLength(0)}, {array.GetLength(1)}");
        Console.WriteLine($"{array.GetLength(0)}");
        Console.WriteLine(array.Length);
    }
}