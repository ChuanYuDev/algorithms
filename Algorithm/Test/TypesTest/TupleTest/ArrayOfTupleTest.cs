namespace Test.TypesTest.TupleTest;

public class ArrayOfTupleTest
{
    public static void Main()
    {
        ArrayOfTuple();
        ArrayOfArray();
    }
    
    private static void ArrayOfTuple()
    {
        var tuples = new (double Score, int Num)[2];
        PrintArrayOfTuple(nameof(tuples), tuples);

        (double Score, int Num)[] tuples2 = [..tuples];
        PrintArrayOfTuple(nameof(tuples2), tuples2);
        tuples[0].Score = 10;
        PrintArrayOfTuple(nameof(tuples2), tuples2);
    }
    
    private static void ArrayOfArray()
    {
        var arrays = new int[2][];

        for (var i = 0; i <= arrays.Length - 1; i++) arrays[i] = new int[2];
        PrintArrayOfArray(nameof(arrays), arrays);        

        int[][] arrays2 = [..arrays];
        PrintArrayOfArray(nameof(arrays2), arrays2);
        arrays[0][0] = 10;
        PrintArrayOfArray(nameof(arrays2), arrays2);
    }

    private static void PrintArrayOfTuple(string arrayOfTupleName, (double Score, int Num)[] tuples)
    {
        Console.WriteLine($"{arrayOfTupleName}: ");
        foreach (var tuple in tuples) Console.WriteLine($"{tuple.Score}, {tuple.Num} ");
    }
    
    private static void PrintArrayOfArray(string arrayOfArrayName, int[][] arrays)
    {
        Console.WriteLine($"{arrayOfArrayName}: ");
        for (var i = 0; i <= arrays.Length - 1; i++) Console.WriteLine($"{arrays[i][0]}, {arrays[i][1]}");
    }
}