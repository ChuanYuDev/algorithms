using Helper;

namespace Algorithm.DataStructure.SparseTable;

//  Range Minimum Query Using Sparse Table

//  Build
//  _maxJ = (int)Math.Log2(n)
//  _lookup = new int[_length, _maxJ + 1];

//  for i from 0 to n-1
//      lookup[i][0] = nums[i]
//
//  for j from 1 to _maxJ
//      //  2^j to n - 1, n-1-x+1 = 2^j, x = n-2^j
//      for i from 0 to n - (1 << j)
//          lookup[i][j] = Math.Min(lookup[i][j–1], lookup[i + (1 << (j - 1))][j-1])

//  Query
//  k = (int) log2(r – l + 1)
//  //  2^k to r, r-x+1=2^k, x = r+1-2^k
//  return Math.Min(lookup[l][k], lookup[r – 2^k + 1][k])

// idx     0   1   2   3   4   5   6   7   8
// nums    7   2   3   0   5  10   3  12  18 

// lookup
// i j 0   1   2   3
// 0   7   2   0   0
// 1   2   2   0   0
// 2   3   0   0   -
// 3   0   0   0   -
// 4   5   5   3   -
// 5  10   3   3   -
// 6   3   3   -   -
// 7  12  12   -   -
// 8  18   -   -   -

public class SparseTable
{
    private readonly int[] _nums;
    private readonly int _length;
    private readonly int _maxJ;
    private readonly int[,] _lookup;

    public SparseTable(int[] nums)
    {
        _nums = nums;
        _length = _nums.Length;
        _maxJ = (int)Math.Log2(_length);
        _lookup = new int[_length, _maxJ + 1];
    }

    // Fills lookup array lookup[][] in bottom up manner
    public void Build()
    {
        // Initialize for the intervals with length 1
        for (int i = 0; i <= _length - 1; i++) _lookup[i, 0] = _nums[i];

        // Compute values from smaller to bigger intervals
        for (int j = 1; j <= _maxJ; j++)
        {
            for (int i = 0; i <= _length - (1 << j); i++) _lookup[i, j] = Math.Min(_lookup[i, j - 1], _lookup[i + (1 << (j - 1)), j - 1]);
        }
    }

    public int Query(int l, int r)
    {
        int k = (int)(Math.Log2(r - l + 1));

        return Math.Min(_lookup[l, k], _lookup[r - (1 << k) + 1, k]);
    }
}

public class Solution
{
    public int[] SolveQueries(int[] nums, int[][] queries)
    {
        var st = new SparseTable(nums);
        int queryLength = queries.Length;
        int[] result = new int[queryLength];
        
        st.Build();
        
        for (int i = 0; i <= queryLength - 1; i++)
        {
            result[i] = st.Query(queries[i][0], queries[i][1]);
        }
        
        return result;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        
        int[] nums = [7, 2, 3, 0, 5, 10, 3, 12, 18];
        int[][] queries = [[0, 4], [4, 7], [7, 8]];
        PrintHelper.PrintEnumerable(sol.SolveQueries(nums, queries));
        //  Output: 0 3 12
    }
}