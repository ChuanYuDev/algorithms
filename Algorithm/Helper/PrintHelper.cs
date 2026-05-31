namespace Helper;

public static class PrintHelper
{
    public static void PrintEnumerable<T>(IEnumerable<T> enumerable)
    {
        Console.WriteLine("Enumerable:");
        foreach (var element in enumerable)
        {
            Console.Write(element);
            Console.Write(" ");
        }
        
        Console.WriteLine();
    }

    public static void PrintJaggedArray<T>(T[][] array)
    {
        Console.WriteLine("Jagged array:");
        foreach (var innerArray in array)
        {
            foreach (var element in innerArray)
            {
                Console.Write(element);
                Console.Write(" ");
            }
            
            Console.WriteLine();
        }
    }
}