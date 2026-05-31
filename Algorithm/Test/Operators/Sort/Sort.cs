using System.Collections;
using Helper;

namespace Test.Operators.Sort;

public class CustomComparer : IComparer<int[]>
{
    public int Compare(int[]? x, int[]? y)
    {
        if (x is null || y is null)
        {
            return 0;
        }

        if (x.Length != 2 || y.Length != 2)
        {
            throw new ArgumentException("Array's length must be 2");
        }

        return (x[1] - x[0]).CompareTo(y[1] - y[0]);
    }
}

public class Sort
{
    
    public static void Main()
    {
        int[][] array1 = [[1, 3], [4, 10], [2, 5]];
        Array.Sort(array1, new CustomComparer());
        PrintHelper.PrintJaggedArray(array1);
        
        int[][] array2 = [[1, 3], [4, 10], [2, 5]];
        Array.Sort(array2, (array, otherArray) =>
            -(array[1] - array[0]).CompareTo(otherArray[1] - otherArray[0])
        );
        PrintHelper.PrintJaggedArray(array2);

        int[] array3 = [32, 200, 3];
        Array.Sort(array3);
        
        PrintHelper.PrintEnumerable(array3);
    }
}