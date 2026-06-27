using Helper;

namespace Algorithm.Algorithm.CoordinateCompression;

//  Given an array `A[]` of size `N` where `0 <= A[i] < R`
//  For each element `A[i]`, count the number of elements to the left that are smaller than `A[i]`

//  Example: `A[] = {1, 5, 3, 7, 2}`, `N = 5`
//  The answer here would be `[0, 1, 1, 3, 1]`

public class Fenwick
{
    private readonly int _length;
    private readonly int[] _f;

    public Fenwick(int length)
    {
        _length = length;
        //  Fenwick tree index is 1 to length
        //  Initially, all the elements of f arrays are 0
        _f = new int[_length + 1];
    }

    public int Query(int i)
    {
        var result = 0;
        while (i > 0)
        {
            result += _f[i];
            i -= Lsb(i);
        }

        return result;
    }
    
    // Increment _f[i] by 1 each time
    public void Update(int i)
    {
        while (i <= _length)
        {
            _f[i]++;
            i += Lsb(i);
        }
    }

    private int Lsb(int i) => i & -i;
}

public class CoordinateCompression
{
    public static int[] Compress(int[] nums)
    {
        var ss = new SortedSet<int>();

        foreach (var num in nums) ss.Add(num);

        var idx = 1;
        var map = new Dictionary<int, int>();
        foreach (var val in ss)
        {
            map.Add(val, idx);
            idx++;
        }

        var length = nums.Length;
        var compressedNums = new int[length];

        for (var i = 0; i <= length - 1; i++)
        {
            compressedNums[i] = map[nums[i]];
        }

        return compressedNums;
    }
}

public class Solution
{
    public int[] LeftLessThan(int[] nums)
    {
        var length = nums.Length;
        var compressedNums = CoordinateCompression.Compress(nums);

        var fenwick = new Fenwick(length);

        var result = new int[length];
        for (var i = 0; i <= length - 1; i++)
        {
            result[i] = fenwick.Query(compressedNums[i] - 1);
            fenwick.Update(compressedNums[i]);
        }

        return result;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[] nums = [1, 5, 3, 7, 2];
        PrintHelper.PrintEnumerable(sol.LeftLessThan(nums));
        //  Output: [0, 1, 1, 3, 1]
        
        nums = [1, 5, 2, 3, 7, 2];
        PrintHelper.PrintEnumerable(sol.LeftLessThan(nums));
        //  Output: [0, 1, 1, 2, 4, 1]
    }
}