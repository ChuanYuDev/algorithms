namespace Leetcode.BlockPlacementQueries;

//  [[1,7],[2,7,6],[1,2],[2,7,5],[2,7,6]]
//  Brute force
//      For every query 1, insert them into a sorted list blocks based on x (O(n))
//          all the query 1 x are different
//      For every query 2, get the nearest block which is xb < x (O(logn))
//          Get the maximal gap between blocks before xb (O(n))
//          Time complexity: O(n^2)
//
//  if x <= sorted[0] insert 0
//  if x > sorted[n-1] insert n
//  1 <= xi <= n-1
//  index   0 1 2 3
//  sorted  1 2 3 5 insert 4
//  first   last    mid
//  0       3       1
//  2       3       2
//  3       3       3       3

//  sorted  1 2 3 5 insert 3
//  first   last    mid
//  0       3       1
//  2       3       2

//  index   0 1 2 3
//  nums    1 2 3 5 insert 2.5
//  first   last    mid
//  0       3       1
//  2       3       2 
//  2       2   
//  if (last - first == 1)
//  if (value<=sorted[first]) valueIdx = first
//  else valueIdx = first+1

//  index   0 1 2
//  nums    1 2 3 insert 2.5
//  first   last    mid
//  0       2       1
//  2       2       2       2

//  index   0 1 2
//  nums    1 2 3 insert 1.5
//  first   last    mid
//  0       2       1
//  0       0       0       
//  if (first == last)
//      if (sorted[first] >= value) valueIdx=first
//      else valueIdx=first+1

//  index   0 1 2
//  nums    1 2 3 insert 3
//  first   last    mid
//  0       2       1
//  2       2       0       

//  index   0 1  2  3
//  nums    1 9 11 14 find 11
//  first   last    mid
//  0       3       1
//  2       3       2

//  SortedBlocks
//  List<T> sorted = new List<T>();
//  
//  int FindIdx(x)
//      // O(logn)
//      // For x from query 1, x != sorted[i]
//      // For x from query 2, x may equal to sorted[i]
//      if x <= sorted[0] valueIdx = 0
//      if x > sorted[n-1] valueIdx = n
//
//      first = 0, last = n-1
//      if (first == last)
//          if (sorted[first] >= value) valueIdx=first
//          else valueIdx=first+1

//      mid = (first + last) / 2
//      if (value > mid) first = mid + 1
//      if (value == mid) return mid
//      // when value is less than mid, valueIdx can still be mid
//      if (value < mid) last = mid
//
//  Insert(x)
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
//  int GetLargestGap(int x)
//      // O(logn)
//      idx = FindIdx(x)
//      if (idx == 0) return x
//      return Max(max[idx - 1], x - sorted[idx - 1])
//
//  Solution
//  IList<bool> GetResults(int[][] queries)
//      // O(n^2)
//      List<bool> results
//      for i from 0 to queries.Length
//          if (queries[i][0] == 1) sortedBlocks.Insert(queries[i][1])
//          if (queries[i][0] == 2) 
//              largestGap = sortedBlocks.GetLargestGap(queries[i][1])
//              result = largestGap >= queries[i][2]? true: false
//              results.Add(result)
//      return results
//  
//  Maximum gap before ith block
//  Insert other block which may split the maximum gap
//  Find the nearest block to the query

//  Because of Time Limit Exceeded, optimations are applied
//  1. When x is inserted into Blocks, we save the largest gap before x (inclusive)
//      sorted  10 14 25 26
//      max     10 10 11 11
//
//      sorted  10 14 23 25 26
//      max     10 10 10 10 10
//
//  2. When query 1 is applied, we delay the sorted procedure until query 2 is applied

public class Blocks
{
    private readonly List<int> _sorted = new List<int>();
    private readonly List<int> _max = new List<int>();

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

    public void Insert(int x)
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

    public int GetLargestGap(int x)
    {
        var idx = FindIdx(x);

        if (idx == 0) return x;
        return Math.Max(_max[idx - 1], x - _sorted[idx - 1]);
    }
}
public class Solution
{
    public IList<bool> GetResults(int[][] queries)
    {
        List<bool> results = new List<bool>();
        Blocks blocks = new Blocks();

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