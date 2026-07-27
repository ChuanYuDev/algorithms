using System.Numerics;

namespace Leetcode.NumberOfPathsWithMaxScore;
/*
Runtime: 138 ms, Beats: 26.81%
Memory: 49.31 MB, Beats: 71.49%
*/

/* Dynamic programming
Input: board = ["E12","1X1","21S"]
Output: [4,2]

E12
1X1
21S

Start from S, go left, and record max score and number of paths
E       1       2
4,2     4,1     3,1

1       X       1
4,1     0,0     1,1

2       1       S
3,1     1,1     0,1

*/

/*
Use tuple instead of int[]
    Because int[] is a reference type
    nextRes and res are pointing to the same array
    Modifying nextRes will unexpectedly modify res
*/

/* Pseudocode
Mod = 10^9 + 7

res = new (int MaxScore, int NumPaths)[length]
row = board[length-1]

for j from length - 1 to 0
    valueChar = row[j]
    
    if (valueChar == 'S')
       res[j] = (0, 1) 
       continue
       
    if (valueChar == 'X')
       res[j] = (0, 0) 
       continue
    
    numPaths = res[j+1].NumPaths

    if (numPaths == 0)
       res[j] = (0, 0)
       continue
       
    valueInt = (valueChar == 'E')? 0: valueChar - '0' 
    res[j] = (res[j+1].MaxScore + valueInt, res[j+1].NumPaths)
    
nextRes = new (int MaxScore, int NumPaths)[length]

for i from length - 2 to 0
    row = board[i]
    
    for j from length - 1 to 0
        valueChar = row[j]
        if (valueChar == 'X')
            nextRes[j] = (0, 0) 
            continue
        
        if (j == length - 1) sumNumPaths = res[j].NumPaths
        else sumNumPaths = res[j].NumPaths, res[j+1].NumPaths, nextRes[j+1].NumPaths
        
        if (sumNumPaths == 0)
            nextRes[j] = (0, 0)
            continue
            
        valueInt = (valueChar == 'E')? 0: valueChar - '0' 
            
        if (j == length - 1)
            nextRes[j] = (res[j].MaxScore + valueInt, res[j].NumPaths)
            continue
            
        maxScore = max(res[j].MaxScore, res[j+1].MaxScore, nextRes[j+1].MaxScore)
        
        var numPaths = new BigInteger(0) 
        if (res[j].MaxScore == maxScore) numPaths += res[j].NumPaths
        if (res[j+1].MaxScore == maxScore) numPaths += res[j+1].NumPaths
        if (nextRes[j+1].MaxScore == maxScore) numPaths += nextRes[j+1].NumPaths
        
        nextRes[j] = (maxScore + valueInt, (int)(numPaths % Mod))     
    
    res = nextRes    

return [res[0].MaxScore, res[0].NumPaths]
*/

/* Complexity
Time complexity: O(n^2)
Space complexity: O(n)
*/

public class Solution
{
    private const int Mod = 1_000_000_007;
    private IList<string> _board = [];
    private int _length = 0;
    private (int MaxScore, int NumPaths)[] _res = [], _nextRes = [];
    
    
    public int[] PathsWithMaxScore(IList<string> board)
    {
        _board = board;
        _length = board.Count;
        _res = new (int MaxScore, int NumPaths)[_length];
        
        GetResultForLastRow();

        _nextRes = new (int MaxScore, int NumPaths)[_length];

        GetResultForOtherRows();

        return [_res[0].MaxScore, _res[0].NumPaths];
    }

    private void GetResultForLastRow()
    {
        var row = _board[_length - 1];

        for (var j = _length - 1; j >= 0; j--)
        {
            var valueChar = row[j];

            if (valueChar == 'S')
            {
                _res[j] = (0, 1);
                continue;
            }

            if (valueChar == 'X')
            {
                _res[j] = (0, 0);
                continue;
            }

            var numPaths = _res[j + 1].NumPaths;

            if (numPaths == 0)
            {
                _res[j] = (0, 0);
                continue;
            }

            _res[j] = (_res[j + 1].MaxScore + valueChar - '0', _res[j + 1].NumPaths);
        }
    }

    private void GetResultForOtherRows()
    {
        for (var i = _length - 2; i >= 0; i--)
        {
            var row = _board[i];

            for (var j = _length - 1; j >= 0; j--)
            {
                var valueChar = row[j];

                if (valueChar == 'X')
                {
                    _nextRes[j] = (0, 0);
                    continue;
                }
                
                var sumNumPaths = (j == _length - 1) ? _res[j].NumPaths : _res[j].NumPaths + _res[j + 1].NumPaths + _nextRes[j + 1].NumPaths;

                if (sumNumPaths == 0)
                {
                    _nextRes[j] = (0, 0);
                    continue;
                }

                var valueInt = (valueChar == 'E') ? 0 : valueChar - '0';

                if (j == _length - 1)
                {
                    _nextRes[j] = (_res[j].MaxScore + valueInt, _res[j].NumPaths);
                    continue;
                }

                var maxScore = Math.Max(Math.Max(_res[j].MaxScore, _res[j + 1].MaxScore), _nextRes[j + 1].MaxScore);

                var numPaths = new BigInteger(0);
                if (_res[j].MaxScore == maxScore) numPaths += _res[j].NumPaths;
                if (_res[j + 1].MaxScore == maxScore) numPaths += _res[j + 1].NumPaths;
                if (_nextRes[j + 1].MaxScore == maxScore) numPaths += _nextRes[j + 1].NumPaths;

                _nextRes[j] = (maxScore + valueInt, (int)(numPaths % Mod));

            }
            
            _res = [.._nextRes];
        }
    }
}
