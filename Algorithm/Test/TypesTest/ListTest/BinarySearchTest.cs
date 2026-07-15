namespace Test.TypesTest.ListTest;

public class BinarySearchTest
{
    static void Main()
    {
        // 1 2 3 4 10
        SortedSet<int> sortedSet = new SortedSet<int> { 3, 4, 2, 1, 10, 5};
        List<int> sortedList = new List<int> (sortedSet);

        int x = 5;
        
        Console.WriteLine("Get the largest element that is less than or equal to x");
        Console.WriteLine(sortedSet.GetViewBetween(0, x).Max);

        var idx = sortedList.BinarySearch(x);
        Console.WriteLine(idx);
        if (idx < 0) idx = ~idx - 1;
        Console.WriteLine(sortedList[idx]);
        
        Console.WriteLine("If the list contains zero elements");
        sortedList.Clear();
        Console.WriteLine(sortedList.BinarySearch(x));
        
    }
}