namespace Leetcode.NumberOfZigZagArraysI;

// Time Limit Exceeded 518 / 921 testcases passed

//  dp + dfs

//  dp
//      0 1 2 3
//      1,3,X
//      2,3,X
//  
//      1,3,2,X
//      2,4,2,X
//      2 X options are the same
//      Use dp[int i, int prev, bool prevInc]
//          i = 0 or 1, prevInc doesn't matter, we simply assign them as false
//      
//      prev1 != -1 and prev2 != -1 record dp

//  dfs
//      l = 1, r = 4
//      1 3 2 X
//      i   val     cnt
//      3   3,4     2
//      2   1       3
//          2       2
//      r - l + 1 -> 4 idx: 0 - 3
//      idx + l


//  range
//      dfs: int 2 * 10^9
//      lr range: 2* 10^3
//      cnt: 4 * 10^12

//  Mod = 1_000_000_007
//  dfs(0, -1, null) 
//  prevInc, prev, i
//  dfs(i, prev, prevInc)
//      if (i == n) return 1
//
//      long cnt = 0
//      if (i == 0)
//          //  1
//          for valI from l to r
//              cnt += dfs(i+1, valI, false)
//      else if (i == 1)
//          //  1 2
//          for valI from l to r
//              if (valI == prev) continue
//              cnt += dfs(i+1, valI, prev1 < valI)
//      else
//          if (dp[i, prev, prevInc] != -1)
//              return dp[i, prev, prevInc]
//
//          maxI = prevInc? prev - 1: r
//          minI = prevInc? l: prev + 1
//
//          for valI from minI to maxI
//              cnt += dfs(i+1, valI, !prevInc)
//  
//          dp[i, prev1, prev2] = cnt
//      
//      return (int)(cnt % Mod)

//  Time complexity:
//      D: r - l + 1
//      Node num: 2 * D * n
//      Edge num: 2 * D^2 * n
//      Total: O(D^2 * n)

//  Space complexity:
//      dp: O(D * n)

public class Solution
{
    private int _n;
    private int _l;
    private int _r;
    private int[,,] _dp = null!;
    private const int Mod = 1_000_000_007;
    
    public int ZigZagArrays(int n, int l, int r)
    {
        _n = n;
        _l = l;
        _r = r;
        _dp = new int[_n, _r - _l + 1, 2];

        for (var i = 0; i <= _dp.GetLength(0) - 1; i++)
        {
            for (var j = 0; j <= _dp.GetLength(1) - 1; j++)
            {
                for (var k = 0; k <= _dp.GetLength(2) - 1; k++)
                    _dp[i, j, k] = -1;
            }
        }

        return Dfs(0, -1, false);
    }

    private int Dfs(int i, int prev, bool prevInc)
    {
        if (i == _n) return 1;

        long cnt = 0;

        if (i == 0)
        {
            for (var valI = _l; valI <= _r; valI++) cnt += Dfs(i + 1, valI, false);
        }
        else if (i == 1)
        {
            for (var valI = _l; valI <= _r; valI++)
            {
                if (valI == prev) continue;
                cnt += Dfs(i + 1, valI, prev < valI);
            }
        }
        else
        {
            var dpVal = _dp[i, prev - _l, prevInc ? 1 : 0];
            if (dpVal != -1) return dpVal;

            var maxI = prevInc ? prev - 1 : _r;
            var minI = prevInc ? _l : prev + 1;

            for (var valI = minI; valI <= maxI; valI++) cnt += Dfs(i + 1, valI, !prevInc);
        }

        int cntMod = (int)(cnt % Mod);

        if (i >= 2) _dp[i, prev - _l, prevInc ? 1 : 0] = cntMod;

        return cntMod;
    }
}

