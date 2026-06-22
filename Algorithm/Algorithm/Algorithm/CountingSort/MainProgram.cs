namespace Algorithm.Algorithm.CountingSort;

public static class Solution
{
    public static int[] CountingSort(int[] arr)
    {
        var n = arr.Length;
        if (n == 0)
        {
            return [];
        }
        
        // find maximum
        var maxVal = arr[0];
        foreach (var v in arr)
        {
            if (v > maxVal)
                maxVal = v;
        }
        
        // create and initialize cntArr
        var cntArr = new int[maxVal + 1];
        for (var i = 0; i <= maxVal; i++)
        {
            cntArr[i] = 0;
        }
        
        // count frequency
        foreach (var v in arr)
        {
            cntArr[v]++;
        }
        
        // prefix sums
        for (var i = 1; i <= maxVal; i++)
        {
            cntArr[i] += cntArr[i - 1];
        }
        
        // build output
        var ans = new int[n];
        for (var i = n - 1; i >= 0; i--)
        {
            var v = arr[i];
            ans[cntArr[v] - 1] = v;
            cntArr[v]--;
        }
        
        return ans;
    }
}

public class MainProgram
{
    static void Main(string[] args)
    {
        int[] arr = { 2, 5, 3, 0, 2, 3, 0, 3 };
        int[] ans = Solution.CountingSort(arr);
        Console.WriteLine(string.Join(", ", ans));
        // Output: 0, 0, 2, 2, 3, 3, 3, 5
    }
}