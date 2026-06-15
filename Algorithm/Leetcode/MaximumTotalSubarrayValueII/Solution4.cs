namespace Leetcode.MaximumTotalSubarrayValueII;

//  Because the heap operation is O(log n), the O(1) query by sparse table is not necessary
//  We can use segment tree to save space

//  For segment tree, we only need Build and Query operation
//  We will save _stMin and _stMax to calculate value = max - min
//  1
//  2 3
//  4 5 6 7

//  Heap part is the same as Solution3

//  SegmentTree
//  Constructor
//      _nums
//      _length
//      _stMin = new int[_length << 2]
//      _stMax = new int[_length << 2]
//
//  private void Build(nodeIdx, left, right)
//      if (left == right)
//          _stMin[nodeIdx] = _nums[left]
//          _stMax[nodeIdx] = _nums[left]
//      
//      mid = (left+right)>>1
//      leftNodeIdx = nodeIdx << 1
//      rightNodeIdx = nodeIdx << 1 | 1
//      Build(leftNodeIdx, left, mid)
//      Build(rightNodeIdx, mid+1, right)
//      _stMin[nodeIdx] = Math.Min(_stMin[leftNodeIdx], _stMin[rightNodeIdx])
//      _stMax[nodeIdx] = Math.Max(_stMax[leftNodeIdx], _stMax[rightNodeIdx])
//      
//  public void Build()
//      Build(1, 0, _length - 1)
//
//  private int QueryMin(queryLeft, queryRight, nodeIdx, left, right)
//      if (queryLeft > right || queryRight < left) return int.MaxValue
//      if (queryLeft <= left && queryRight >= right) return _stMin[nodeIdx]
//      
//      mid = (left+right) >> 1
//      return Math.Min(
//          QueryMin(queryLeft, queryRight, leftNodeIdx, left, mid),
//          QueryMin(queryLeft, queryRight, rightNodeIdx, mid+1, right)
//      )
//
//  private int QueryMin(queryLeft, queryRight, nodeIdx, left, right)
//      if (queryLeft > right || queryRight < left) return int.MinValue
//      // Same as min
//
//  public int Query(queryLeft, queryRight)
//      return QueryMax(queryLeft, queryRight, 1, 0, _length-1) - QueryMin(queryLeft, queryRight, 1, 0, _length-1)

//  Time complexity
//      segment tree build: O(n)
//      Heap contains n elements at most
//      Heap extract-max: O(log n)
//      Heap insert: O(log n)
//      Sparse table query: O(log n)
//      Total: O(k * log n)

//  Space complexity
//      segment tree: O(n)
//      Heap: O(n)
//      Total: O(n)

public class SegmentTree
{
    private readonly int[] _nums;
    private readonly int _length;
    private readonly int[] _stMin;
    private readonly int[] _stMax;
    
    public SegmentTree(int[] nums)
    {
        _nums = nums;
        _length = _nums.Length;
        _stMin = new int[_length << 2];
        _stMax = new int[_length << 2];
    }

    public void Build()
    {
        Build(1, 0, _length - 1);
    }

    public int Query(int ql, int qr)
    {
        return QueryMax(ql, qr, 1, 0, _length - 1) - 
            QueryMin(ql, qr, 1, 0, _length - 1);
    }

    private void Build(int nodeIdx, int left, int right)
    {
        if (left == right)
        {
            _stMin[nodeIdx] = _nums[left];
            _stMax[nodeIdx] = _nums[left];
            return;
        }

        var mid = (left + right) >> 1;
        var leftNodeIdx = nodeIdx << 1;
        var rightNodeIdx = nodeIdx << 1 | 1;
        Build(leftNodeIdx, left, mid);
        Build(rightNodeIdx, mid + 1, right);
        _stMin[nodeIdx] = Math.Min(_stMin[leftNodeIdx], _stMin[rightNodeIdx]);
        _stMax[nodeIdx] = Math.Max(_stMax[leftNodeIdx], _stMax[rightNodeIdx]);
    }

    private int QueryMin(int queryLeft, int queryRight, int nodeIdx, int left, int right)
    {
        if (queryLeft > right || queryRight < left) return int.MaxValue;

        if (queryLeft <= left && queryRight >= right) return _stMin[nodeIdx];

        var mid = (left + right) >> 1;
        return Math.Min(
            QueryMin(queryLeft, queryRight, nodeIdx << 1, left, mid),
            QueryMin(queryLeft, queryRight, nodeIdx << 1 | 1, mid + 1, right)
        );
    }
    
    private int QueryMax(int queryLeft, int queryRight, int nodeIdx, int left, int right)
    {
        if (queryLeft > right || queryRight < left) return int.MinValue;

        if (queryLeft <= left && queryRight >= right) return _stMax[nodeIdx];

        var mid = (left + right) >> 1;
        return Math.Max(
            QueryMax(queryLeft, queryRight, nodeIdx << 1, left, mid),
            QueryMax(queryLeft, queryRight, nodeIdx << 1 | 1, mid + 1, right)
        );
    }
}

public class CustomComparer4 : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return -x.CompareTo(y);
    }
}

public class Solution4
{
    public long MaxTotalValue(int[] nums, int k)
    {
        var st = new SegmentTree(nums);
        st.Build();
        
        var length = nums.Length;
        int l = 0, r = 0;
        
        var value = st.Query(l, length - 1 - r);
        
        var pq = new PriorityQueue<(int, int), int>(new CustomComparer4());
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