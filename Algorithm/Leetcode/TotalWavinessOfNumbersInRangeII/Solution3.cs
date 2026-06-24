namespace Leetcode.TotalWavinessOfNumbersInRangeII;
//  Use DFS + dynamic programming to calculate TotalWaviness(num)

//  DFS
//  1
//  0 1 ... 9
//  
//  012 3
//  010 0-9
//  dfs(i, prev1, prev2, isLimit) return count, waviness
//      i=3 return 10, 9
//  
//  i=2, dfs(i+1) return subCount, subWaviness
//  waviness+=subCount
//  waviness+subWaviness
//  waviness: 19

//  prev2, prev1, valueI
//  if ((prev1 > prev2 && prev1 > valueI) || (prev1 < prev2 && prev1 < valueI)) -> waviness

//  Why do we need dynamic programming?
//      pos=3
//      curr=0
//      prev=1
//
//      index   0123
//              010
//
//      For pos=3, previous digits are 010, we get 10 counts and 9 waviness (except for 100)
//
//      index   0123
//              110
//      For pos=3, previous digits are 110, we still need to get the last digits count and waviness
//      This is the moment we use DP
//
//      i, prev1, prev2, isLimit form the dynamic programming

//  Why do we need to record prev2 value instead of recording prev2, prev1 relationship
//      Because we need to get the count value
//      The count value affects the waviness

//  Why do we need DP with !isLimit?
//      num = 5104
//      010: cnt 10, wav 9
//
//      When 510, isLimit = true, cnt only 5

//  Pseudocode
//
//  long TotalWaviness(long num)
//      int[,,] dpCount = new int[16, 10, 10]
//      int[,,] dpWaviness = new int[16, 10, 10]
//      initialize dpCount, dpWaviness
//      count, waviness = dfs(0, -1, -1, true)
//  
//  i: position i from 0 to length - 1
//  dfs(i, prev1, prev2, isLimit)
//      if (i == length) return 1, 0
//      
//      if (!isLimit && dpWaviness[i][prev1][prev2] != -1)
//          return dpCount[i][prev1][prev2], dpWaviness[i][prev1][prev2]
//
//      count, waviness = 0
//      maxI = isLimit? numStr[i] - '0': 9
//      for valueI from 0 to maxI
//          // prev2, prev1, valueI
//          valueIAfterCheck = (prev1 == -1 && valueI == 0)? -1: valueI
//          subCount, subWaviness = dfs(i+1, valueIAfterCheck, prev1, isLimit && (valueI == maxI))
//          if (prev1 != -1 && prev2 != -1)
//              if ((prev1 > prev2 && prev1 > valueI) || (prev1 < prev2 && prev1 < valueI))
//                  waviness += subCount
//
//          waviness += subWaviness
//          count+= subCount
//
//      if (!isLimit && prev1 != -1 && prev2 != -1)
//          dpCount[i][prev1][prev2] = count
//          dpWaviness[i][prev1][prev2] = waviness
//      
//      return count, waviness

//  Time complexity
//      D: 10
//      d: digits number
//      O(D^2 * d): vertices number
//      O(D^3 * d): edges number
//      O(D^3 * d): time complexity

//  Space complexity
//      O(D^2 * d): dp

public class Solution3
{
    private string _numStr = "";
    private int _length;
    private readonly long[,,] _dpCount = new long [16, 10, 10], _dpWaviness = new long [16, 10, 10];
    
    public long TotalWaviness(long num1, long num2)
    {
        return TotalWaviness(num2) - TotalWaviness(num1 - 1);
    }
    
    private long TotalWaviness(long num)
    {
        _numStr = num.ToString();
        _length = _numStr.Length;
        
        for (var i = 0; i <= 15; i++)
        {
            for (var j = 0; j <= 9; j++)
            {
                for (var k = 0; k <= 9; k++)
                {
                    _dpCount[i, j, k] = -1;
                    _dpWaviness[i, j, k] = -1;
                }
            }
        }

        var result = Dfs(0, -1, -1, true);
        return result.Waviness;
    }

    private (long Count, long Waviness) Dfs(int i, int prev1, int prev2, bool isLimit)
    {
        if (i == _length) return (1, 0);
        
        if (!isLimit && prev1 != -1 && prev2!= -1 &&_dpCount[i, prev1, prev2] != -1) return (_dpCount[i, prev1, prev2], _dpWaviness[i, prev1, prev2]);

        long count = 0, waviness = 0;
        int maxI = isLimit ? _numStr[i] - '0' : 9;

        for (var valueI = 0; valueI <= maxI; valueI++)
        {
            var valueIAfterCheck = (prev1 == -1 && valueI == 0) ? -1 : valueI;
            var result = Dfs(i + 1, valueIAfterCheck, prev1, isLimit && (valueI == maxI));

            if (prev1 != -1 && prev2 != -1 && ((prev1 > prev2 && prev1 > valueI) || (prev1 < prev2 && prev1 < valueI)))
            {
                waviness += result.Count;
            }

            count += result.Count;
            waviness += result.Waviness;
        }

        if (!isLimit && prev1 != -1 && prev2 != -1)
        {
            
            _dpCount[i, prev1, prev2] = count;
            _dpWaviness[i, prev1, prev2] = waviness;
        }

        return (count, waviness);
    }
}