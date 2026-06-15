namespace Algorithm.Algorithm.Sort;

public class SelectionSortProgram
{
    private static void SelectionSort<T>(List<T> list)
        where T: IComparable<T>
    {
        for (var i = 0; i < list.Count; i++)
        {
            var minIndex = i;

            for (var j = i; j < list.Count; j++)
            {
                if (list[j].CompareTo(list[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            if (minIndex == i) continue;
            
            (list[i], list[minIndex]) = (list[minIndex], list[i]);
        }
    }
    
    public static void Main()
    {
        List<double> list = [2.2, 0.9, 1, 5.1, 3.4];
        
        SelectionSort(list);

        foreach (var element in list)
        {
            Console.Write(element);
            Console.Write(" ");
        }
        
        Console.WriteLine();
        // Output: 0.9, 1, 2.2, 3.4, 5.1};
    }
}