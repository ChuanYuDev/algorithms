using Helper;

namespace Test.TypesTest.ListTest;

public class CollectionInitializerTest
{
    static void Main()
    {
        var list1 = new List<int> { 1, 2, 3 };

        var list2 = new List<int>(list1) { 100, 101, 102 };
        
        PrintHelper.PrintEnumerable(list2);
    }
}