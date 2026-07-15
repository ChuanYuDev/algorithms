namespace Test.Types.JaggedArray;

public class Array
{
    static void Main()
    {
        // Jagged array
        int[][] array = [[1, 3], [4, 10], [2, 5]];
       
        // Console.WriteLine($"{array.GetLength(0)}, {array.GetLength(1)}");
        Console.WriteLine($"Rank: {array.Rank}");
        Console.WriteLine($"Length: {array.Length}");
        Console.WriteLine($"Dimension 0 length: {array.GetLength(0)}");
    }
}