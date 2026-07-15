namespace Test.TypesTest.SortedSetTest;

public class CustomComparer : IComparer<KeyValuePair<int, int>>
{
    public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
    {
        return -x.Key.CompareTo(y.Key);
    }
}

public class CustomComparer2 : IComparer<KeyValuePair<int, int>>
{
    public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
    {
        return -x.Value.CompareTo(y.Value);
    }
}

public class CustomComparer3 : IComparer<KeyValuePair<int, int>>
{
    public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
    {
        var keyCompare = x.Key.CompareTo(y.Key);

        if (keyCompare != 0) return -keyCompare;
        
        return x.Value.CompareTo(y.Value);
    }
}

public class KeyValuePairAsElementTest
{
    static void Main()
    {
        Console.WriteLine("Sorted set:");
        var ss = new SortedSet<KeyValuePair<int, int>>(new CustomComparer());
        ss.Add(new KeyValuePair<int, int>(9, 1));
        ss.Add(new KeyValuePair<int, int>(9, 2));
        ss.Add(new KeyValuePair<int, int>(7, 10));
        
        foreach (var pair in ss) Console.WriteLine($"{pair.Key}, {pair.Value}");
        
        Console.WriteLine("Sorted set 2:");
        var ss2 = new SortedSet<KeyValuePair<int, int>>(new CustomComparer2());
        ss2.Add(new KeyValuePair<int, int>(1, 9));
        ss2.Add(new KeyValuePair<int, int>(2, 9));
        ss2.Add(new KeyValuePair<int, int>(10, 7));
        
        foreach (var pair in ss2) Console.WriteLine($"{pair.Key}, {pair.Value}");
        
        Console.WriteLine("Sorted set 3:");
        var ss3 = new SortedSet<KeyValuePair<int, int>>(new CustomComparer3());
        ss3.Add(new KeyValuePair<int, int>(9, 1));
        ss3.Add(new KeyValuePair<int, int>(9, 2));
        ss3.Add(new KeyValuePair<int, int>(9, 2));
        ss3.Add(new KeyValuePair<int, int>(7, 10));
        
        foreach (var pair in ss3) Console.WriteLine($"{pair.Key}, {pair.Value}");
    }
}