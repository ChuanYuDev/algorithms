using System.Numerics;
using Helper;

namespace Leetcode.NumberOfPathsWithMaxScore;
/*
Number of Paths with Max Score
Hard

You are given a square board of characters.
    You can move on the board starting at the bottom right square marked with the character 'S'.

    You need to reach the top left square marked with the character 'E'.
    
    The rest of the squares are labeled either with a numeric character 1, 2, ..., 9 or with an obstacle 'X'.
    
    In one move you can go up, left or up-left (diagonally) only if there is no obstacle there.

Return a list of two integers: the first integer is the maximum sum of numeric characters you can collect, and the second is the number of such paths that you can take to get that maximum sum, taken modulo 10^9 + 7.

In case there is no path, return [0, 0].

Example 1:
Input: board = ["E23","2X2","12S"]
Output: [7,1]

Example 2:
Input: board = ["E12","1X1","21S"]
Output: [4,2]

Example 3:
Input: board = ["E11","XXX","11S"]
Output: [0,0]

Constraints:
    2 <= board.length == board[i].length <= 100
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
    
    
    public int[] PathsWithMaxScore(IList<string> board)
    {
        _length = board.Count;
        var res = new (int MaxScore, int NumPaths)[_length];
        var row = board[_length - 1];

        for (var j = _length - 1; j >= 0; j--)
        {
            var valueChar = row[j];

            if (valueChar == 'S')
            {
                res[j] = (0, 1);
                continue;
            }

            if (valueChar == 'X')
            {
                res[j] = (0, 0);
                continue;
            }

            var numPaths = res[j + 1].NumPaths;

            if (numPaths == 0)
            {
                res[j] = (0, 0);
                continue;
            }

            var valueInt = (valueChar == 'E') ? 0 : valueChar - '0';
            res[j] = (res[j + 1].MaxScore + valueInt, res[j + 1].NumPaths);
        }

        var nextRes = new (int MaxScore, int NumPaths)[_length];

        for (var i = _length - 2; i >= 0; i--)
        {
            row = board[i];

            for (var j = _length - 1; j >= 0; j--)
            {
                var valueChar = row[j];

                if (valueChar == 'X')
                {
                    nextRes[j] = (0, 0);
                    continue;
                }
                
                var sumNumPaths = (j == _length - 1) ? res[j].NumPaths : res[j].NumPaths + res[j + 1].NumPaths + nextRes[j + 1].NumPaths;

                if (sumNumPaths == 0)
                {
                    nextRes[j] = (0, 0);
                    continue;
                }

                var valueInt = (valueChar == 'E') ? 0 : valueChar - '0';

                if (j == _length - 1)
                {
                    nextRes[j] = (res[j].MaxScore + valueInt, res[j].NumPaths);
                    continue;
                }

                var maxScore = Math.Max(Math.Max(res[j].MaxScore, res[j + 1].MaxScore), nextRes[j + 1].MaxScore);

                var numPaths = new BigInteger(0);
                if (res[j].MaxScore == maxScore) numPaths += res[j].NumPaths;
                if (res[j + 1].MaxScore == maxScore) numPaths += res[j + 1].NumPaths;
                if (nextRes[j + 1].MaxScore == maxScore) numPaths += nextRes[j + 1].NumPaths;

                nextRes[j] = (maxScore + valueInt, (int)(numPaths % Mod));

            }
            res = nextRes;
        }

        return [res[0].MaxScore, res[0].NumPaths];
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        List<string> board = ["E23", "2X2", "12S"];
        PrintHelper.PrintEnumerable(sol.PathsWithMaxScore(board));
        // Output: [7,1]

        board = ["E12", "1X1", "21S"];
        PrintHelper.PrintEnumerable(sol.PathsWithMaxScore(board));
        // Output: [4,2]

        board = ["E11", "XXX", "11S"];
        PrintHelper.PrintEnumerable(sol.PathsWithMaxScore(board));
        // Output: [0,0]
    }
}