namespace Leetcode.MaximumTotalSubarrayValueII;

//  Hint 1: For fixed l, the sequence v(l,r)=max(nums[l..r])−min(nums[l..r]) is non-increasing as r moves left.
//  Hint 2: Build RMQs (sparse tables) for range max/min so each v(l,r) is queryable in O(1).

//  Use sparse table to preprocess the array in O(n log n) and get max and min in O(1)

//  Range: [l, n - 1 - r]
//  Value(Range) = max(Range) - min(Range)
//  Value can be stored in Int32 data type

//  For fixed l, value will be non-increasing as r increases
//  For fixed r, value will be non-increasing as l increases

//  l r 0   1   2   3
//  0   1   2?   
//  1   2?
//  2

//  l r 0   1   2   3
//  0   1   2   3?   
//  1   3?
//  2

//  l r 0   1   2   3
//  0   1   2   4?   
//  1   3   4?
//  2   4?

//  l r 0   1   2   3
//  0   1   2   5?   
//  1   3   4
//  2   5?

//  l r 0   1   2   3
//  0   1   2   6?   
//  1   3   4
//  2   5   6?

//  l r 0   1   2   3
//  0   1   2   7   8?  
//  1   3   4   8?
//  2   5   6

//  l r 0   1   2   3
//  0   1   2   7   8
//  1   3   4   9  10?
//  2   5   6  10?

//  l r 0   1   2   3
//  0   1   2   7   8
//  1   3   4   9  11
//  2   5   6  10  12

//  nums = [11, 8];
//  k = 3;
//  
//  l r 0   1
//  0   1   2?   
//  1   2?  X
//
//  l <= n - 1 - r

//  nums = [28, 21, 50, 32];
//  k = 10;
//  l, n-1-r -> l, 3-r
//  l r 0   1   2   3
//  0  29  29   7   0
//  1  29  29   0   
//  2  18   0
//  3   0

//  Time complexity
//      Sparse table build: O(n log n)
//      Sparse table query: O(1)
//      Heap contains n elements at most
//      Heap extract-max: O(log n)
//      Heap insert: O(log n)
//      Heap total: k* O(log n)
//      Total: O((k + n) * log n)

//  Space complexity
//      Sparse table: O(n log n)
//      Heap: O(n)
//      Total: O(n log n)

//  Pseudocode
//  // Use sparse table to preprocess the array in O(n log n) and get max and min in O(1)
//  
//  SparseTable
//  Constructor
//      _length = _nums.Length
//      // 0 2^j, 2^j-1<=n-1
//      _maxJ = (int)Math.Log2(n)
//      // _lookup[i][j]: start from i and length is 2^j
//      _lookupMin = new int[_length, _maxJ + 1]
//      _lookupMax = new int[_length, _maxJ + 1]

//  void Build()
//      for i from 0 to _length
//          _lookupMin[i, 0] = _nums[i]
//          _lookupMax[i, 0] = _nums[i]
//      
//      for j from 1 to _maxJ
//          // i + 2^j - 1 <= n - 1
//          for i from 0 to n - 2^j
//              lookupMin[i,j] = Math.Min(lookupMin[i,j-1], lookupMin[i+2^(j-1), j-1])
//              lookupMax[i,j] = Math.Max(lookupMax[i,j-1], lookupMax[i+2^(j-1), j-1])

//  // return value = max - min
//  int Query(l,r)
//      k = (int)Math.Log2(r-l+1)
//      // 2^k to r, r-x+1 = 2^k, x = r+1-2^k
//      max = Math.Max(lookupMax[l, k], lookupMax[r+1-2^k, k])
//      min = Math.Min(lookupMin[l, k], lookupMin[r+1-2^k, k])
//      return max - min

//  CustomComparer: IComparer<int>
//  public int Compare(int x, int y)
//      return -x.CompareTo(y)

//  pq = new PriorityQueue<(int int),int>(CustomComparer)
//  // Range: [l, n - 1 - r]
//  l = 0, r = 0
//  value = st.Query(l, n-1-r)
//  pq.Enqueue((l,r), value)
//  pendingL = new HashSet<int>()
//  pendingR = new HashSet<int>()
//  pendingL.Add(l)
//  pendingR.Add(r)
//
//  result
//  while(pq.Count > 0)
//      pq.TryDequeue(out var (l,r), out var value)
//      result += value
//      if (--k == 0) break
//
//      pendingL.Remove(l)
//      pendingR.Remove(r)
//
//      candidate1 = l+1
//      candidate2 = r+1
//      // if (candidate1 <= n - 1 && candidate1 <= n-1-r && !pendingL.Contains(candidate1))
//      if (candidate1 <= n-1-r && !pendingL.Contains(candidate1))
//          pq.Enqueue((candidate1, r), st.Query(candidate1, n-1-r))
//          pendingL.Add(candidate1)
//          pendingR.Add(r)
//      // if (candidate2 <= n - 1 && l <= n - 1 - candidate2 && !pendingR.Contains(candidate2))
//      if (candidate2 <= n-1-l && !pendingR.Contains(candidate2))
//          pq.Enqueue((l, candidate2), st.Query(l, n-1-candidate2))
//          pendingL.Add(l)
//          pendingR.Add(candidate2)
//  
//  return result

public class SparseTable
{
    private readonly int[] _nums;
    private readonly int _length;
    private readonly int _maxJ;
    private readonly int[,] _lookupMin;
    private readonly int[,] _lookupMax;
    
    public SparseTable(int[] nums)
    {
        _nums = nums;
        _length = _nums.Length;
        _maxJ = (int)Math.Log2(_length);
        _lookupMin = new int[_length, _maxJ + 1];
        _lookupMax = new int[_length, _maxJ + 1];
    }

    public void Build()
    {
        for (var i = 0; i <= _length - 1; i++)
        {
            _lookupMin[i, 0] = _nums[i];
            _lookupMax[i, 0] = _nums[i];
        }

        for (var j = 1; j <= _maxJ; j++)
        {
            for (var i = 0; i <= _length - (1 << j); i++)
            {
                _lookupMin[i, j] = Math.Min(_lookupMin[i, j - 1], _lookupMin[i + (1 << (j - 1)), j - 1]);
                _lookupMax[i, j] = Math.Max(_lookupMax[i, j - 1], _lookupMax[i + (1 << (j - 1)), j - 1]);
            }
        }
    }

    public int Query(int l, int r)
    {
        var k = (int)Math.Log2(r - l + 1);
        var max = Math.Max(_lookupMax[l, k], _lookupMax[r + 1 - (1 << k), k]);
        var min = Math.Min(_lookupMin[l, k], _lookupMin[r + 1 - (1 << k), k]);
        return max - min;
    }
}

public class CustomComparer3 : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return -x.CompareTo(y);
    }
}

public class Solution3
{
    public long MaxTotalValue(int[] nums, int k)
    {
        var st = new SparseTable(nums);
        st.Build();
        
        var length = nums.Length;
        int l = 0, r = 0;
        
        var value = st.Query(l, length - 1 - r);
        
        var pq = new PriorityQueue<(int, int), int>(new CustomComparer3());
        pq.Enqueue((l, r), value);

        var pendingL = new HashSet<int>();
        var pendingR = new HashSet<int>();
        pendingL.Add(l);
        pendingR.Add(r);

        long result = 0;

        while (pq.Count > 0)
        {
            pq.TryDequeue(out var t, out value);
            result += value;
            if (--k == 0) break;
            
            l = t.Item1;
            r = t.Item2;
            pendingL.Remove(l);
            pendingR.Remove(r);

            int candidate1 = l + 1, candidate2 = r + 1;

            if (candidate1 <= length - 1 - r && !pendingL.Contains(candidate1))
            {
                pq.Enqueue((candidate1, r), st.Query(candidate1, length - 1 - r));
                pendingL.Add(candidate1);
                pendingR.Add(r);
            }

            if (candidate2 <= length - 1 - l && !pendingR.Contains(candidate2))
            {
                pq.Enqueue((l, candidate2), st.Query(l, length - 1 - candidate2));
                pendingL.Add(l);
                pendingR.Add(candidate2);
            }
        }

        return result;
    }
}