namespace Leetcode.BlockPlacementQueries;

//  Segment tree

//  Segment tree only stores the intervals between blocks
//      We have the intervals array
//      Indices are all possible block position (0~mx)
//      The value is the interval between the block at this position and its left block 
//
//  SortedSet stores the block position
//
//  1 <= x <= 50000
//  mx = 50001 to make sure that there are values on the left and right of every block
//  queries = [[1, 7], [1, 2], [2, 8, 5];

//  Initial state:
//  Intervals
//  index	0 1 2 ... mx-1 mx
//  value	0 0 0 ...    0  0
//  Because every block gap is non-negative, therefore we initialize all the values to 0 otherwise int.MinValue

//  Before queries:
//  SortedSet
//  0 mx
//
//  Intervals
//  index	0 1 2 ... mx-1 mx
//  value	0 0 0 ...    0 mx

//  Query 0: [1, 7] 
//  x: 7, r: mx, l: 0
//  SortedSet
//  0 7 mx
//
//  Intervals
//  index	0 1 2 ... 7 ... mx-1   mx
//  value	0 0 0 ... 7 ...    0 mx-7

//  Query 1: [1, 2] 
//  x: 2, r: 7, l: 0
//  SortedSet
//  0 2 7 mx
//
//  Intervals
//  index	0 1 2 ... 7 ... mx-1   mx
//  value	0 0 2 ... 5 ...    0 mx-7

//  Query 2: [2, 8, 5]
//  x: 8, sz: 5
//  pre: 7, max_space: 5, ans: true
//  SortedSet
//  0 2 7 mx
//
//  Intervals
//  index	0 1 2 ... 7 ... mx-1   mx
//  value	0 0 2 ... 5 ...    0 mx-7

//  Intervals
//      length = xMax + 2 (0 to xMax + 1)
//
//  private void Update(int idx, int val, int nodeIdx, int left, int right)
//  public void Update(int idx, int val)
//      Update(idx, val, 1, 0, length - 1)
//
//  private int Query(int queryLeft, int queryRight, int nodeIdx, int left, int right)
//  public int Query(int queryLeft, int queryRight)
//      Query(queryLeft, queryRight, 1, 0, length - 1)

//  Blocks
//      SortedSet sortedSet
//      Intervals intervals
//      xMax
//
//  Blocks(xMax)
//      sortedSet.Add(0)
//      sortedSet.Add(xMax + 1)
//      intervals = new Intervals(xMax) 
//      intervals.Update(xMax + 1, xMax + 1)
//
//  Insert(x)
//      // O(logq + logM)
//      _sortedSet.Add(x)
//      pre = sortedSet.GetViewBetween(0, x-1)      
//      next = sortedSet.GetViewBetween(x+1, xMax + 1)      
//      Update(x, x - pre)
//      Update(next, next - x)
//
//  GetLargestGap(x)
//      // O(logq + logM)
//      pre = sortedSet.GetViewBetween(0, x)
//      return Math.Max(Query(0, pre), x - pre)

//  Solution
//  IList<bool> GetResults(int[][] queries)
//      xMax = 50000
//      for each query in queries
//          if (query[0] == 1) blocks.Insert(query[1])
//          if (query[1] == 2)
//              largestGap = blocks.GetLargestGap(query[1])
//              results.Add(largestGap >= query[2])

//  Time complexity
//      q: # of queries
//      M: xMax
//      q(logq + logM)

//  Space complexity
//      O(M + q)

public class Intervals
{
    private readonly int _length;
    private readonly int[] _segmentTree;

    public Intervals(int xMax)
    {
        _length = xMax + 2;
        _segmentTree = new int[_length << 2];
    }

    private void Update(int idx, int val, int nodeIdx, int left, int right)
    {
        if (idx < left || idx > right) return;
        
        if (left == right)
        {
            _segmentTree[nodeIdx] = val;
            return;
        }

        int mid = (left + right) >> 1;

        var leftNodeIdx = nodeIdx << 1;
        var rightNodeIdx = nodeIdx << 1 | 1;
        if (idx <= mid) Update(idx, val, leftNodeIdx, left, mid);
        else Update(idx, val, rightNodeIdx, mid + 1, right);

        _segmentTree[nodeIdx] = Math.Max(_segmentTree[leftNodeIdx], _segmentTree[rightNodeIdx]);
    }

    public void Update(int idx, int val)
    {
        Update(idx, val, 1, 0, _length - 1);
    }

    private int Query(int queryLeft, int queryRight, int nodeIdx, int left, int right)
    {
        if (queryLeft > right || queryRight < left) return 0;

        if (queryLeft <= left && queryRight >= right) return _segmentTree[nodeIdx];

        var mid = (left + right) >> 1;
        var leftNodeIdx = nodeIdx << 1;
        var rightNodeIdx = nodeIdx << 1 | 1;

        return Math.Max(
            Query(queryLeft, queryRight, leftNodeIdx, left, mid),
            Query(queryLeft, queryRight, rightNodeIdx, mid + 1, right)
        );
    }

    public int Query(int queryLeft, int queryRight)
    {
        return Query(queryLeft, queryRight, 1, 0, _length - 1);
    }
}

public class Blocks2
{
    private readonly SortedSet<int> _sortedSet = new SortedSet<int>();
    private readonly Intervals _intervals;
    private readonly int _xMax;

    public Blocks2(int xMax)
    {
        _xMax = xMax;
        _sortedSet.Add(0);
        _sortedSet.Add(_xMax + 1);
        _intervals = new Intervals(_xMax);
        _intervals.Update(_xMax + 1, _xMax + 1);
    }

    public void Insert(int x)
    {
        _sortedSet.Add(x);
        var pre = _sortedSet.GetViewBetween(0, x - 1).Max;
        var next = _sortedSet.GetViewBetween(x + 1, _xMax + 1).Min;
        _intervals.Update(x, x - pre);
        _intervals.Update(next, next - x);
    }

    public int GetLargestGap(int x)
    {
        var pre = _sortedSet.GetViewBetween(0, x).Max;
        return Math.Max(_intervals.Query(0, pre), x - pre);
    }
}

public class Solution2
{
    public IList<bool> GetResults(int[][] queries)
    {
        var xMax = 50000;
        Blocks2 blocks = new Blocks2(xMax);
        var results = new List<bool>();

        foreach (var query in queries)
        {
            if (query[0] == 1)
            {
                blocks.Insert(query[1]);
                continue;
            }

            var largestGap = blocks.GetLargestGap(query[1]);
            results.Add(largestGap >= query[2]);
        }

        return results;
    }
}