namespace Leetcode.BlockPlacementQueries;

//  SortedBlocks
//  List<int> sorted = new List<int>();
//  List<int> max = new List<int>();
//  List<int> unsorted = new List<int>();
//  
//  void InsertIntoSorted(x)
//      // O(n)
//      idx = FindIdx(x)
//      sorted.Insert(idx, x)
//      if (idx == 0) max.Insert(idx, x)
//      else
//          xMax = Max(max[idx-1], x - sorted[idx-1])
//          max.Insert(idx, xMax)
//
//      for i from idx + 1 to max.Length - 1
//          maxI  = Max(max[i-1], sorted[i] - sorted[i-1])
//          if (maxI == max[i]) break
//          max[i] = maxI
// 
//  Sort()
//      sorted.AddRange(unsorted)
//      length = sorted.Length
//      if (length == 0)
//          return;
//
//      sorted.Sort()
//      max.Clear()
//      max.Add(sorted[0])
//
//      for i from 1 to sorted.Length - 1
//          max.Add(Max(max[i-1], sorted[i] - sorted[i-1]))
//
//  Insert(x)
//      unsorted.Add(x)
//
//  int GetLargestGap(int x)
//      if (unsorted.Count > sorted.Count)
//          Sort()
//      else
//          foreach element in unsorted
//              InsertIntoSorted(element)
//
//      idx = FindIdx(x)
//      if (idx == 0) return x
//      return Max(max[idx - 1], x - sorted[idx - 1])
//
//  Because of Time Limit Exceeded, optimations are applied
//  2. When query 1 is applied, we delay the sorted procedure until query 2 is applied

//  Unbelievable beats 100%

public class BlocksOptimization
{
    private readonly List<int> _sorted = new List<int>();
    private readonly List<int> _max = new List<int>();
    private readonly List<int> _unsorted = new List<int>();

    private int FindIdx(int x)
    {
        var length = _sorted.Count;

        if (length == 0) return 0;

        if (x <= _sorted[0]) return 0;
        if (x > _sorted[length - 1]) return length;

        int first = 0, last = length - 1;
        while (first <= last)
        {
            if (first == last)
            {
                if (_sorted[first] >= x) return first;
                return first + 1;
            }

            var mid = (first + last) / 2;

            if (x == _sorted[mid]) return mid;
            
            if (x > _sorted[mid]) first = mid + 1;
            else last = mid;
        }

        // Never executed
        return -1;
    }

    private void InsertIntoSorted(int x)
    {
        var idx = FindIdx(x);
        _sorted.Insert(idx, x);
        if (idx == 0) _max.Insert(idx, x);
        else
        {
            var xMax = Math.Max(_max[idx - 1], x - _sorted[idx - 1]);
            _max.Insert(idx, xMax);
        }

        for (var i = idx + 1; i <= _max.Count - 1; i++)
        {
            var iMax = Math.Max(_max[i - 1], _sorted[i] - _sorted[i - 1]);
            if (iMax == _max[i]) break;
            _max[i] = iMax;
        }
    }

    private void SortBlocks()
    {
        _sorted.AddRange(_unsorted);
        var length = _sorted.Count;
        if (length == 0) return;
        
        _sorted.Sort();
        _max.Clear();
        _max.EnsureCapacity(length);
        _max.Add(_sorted[0]);

        for (var i = 1; i <= _sorted.Count - 1; i++)
        {
            _max.Add(Math.Max(_max[i-1], _sorted[i] - _sorted[i - 1]));
        }
    }

    public void Insert(int x)
    {
        _unsorted.Add(x);
    }

    public int GetLargestGap(int x)
    {
        if (_unsorted.Count > _sorted.Count) SortBlocks();
        else
        {
            foreach (var element in _unsorted)
            {
                InsertIntoSorted(element);
            }
        }
        
        _unsorted.Clear();
        
        var idx = FindIdx(x);

        if (idx == 0) return x;
        return Math.Max(_max[idx - 1], x - _sorted[idx - 1]);
    }
}
public class SolutionOptimization
{
    public IList<bool> GetResults(int[][] queries)
    {
        List<bool> results = new List<bool>();
        BlocksOptimization blocks = new BlocksOptimization();

        foreach (var query in queries)
        {
            if (query[0] == 1)
            {
                blocks.Insert(query[1]);
                continue;
            }

            var largestGap = blocks.GetLargestGap(query[1]);
            var result = largestGap >= query[2];
            results.Add(result);
        }

        return results;
    }
}