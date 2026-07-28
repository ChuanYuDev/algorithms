using Helper;

namespace Leetcode.NQueens;
/*
N-Queens
Hard
   
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return all distinct solutions to the n-queens puzzle.
    You may return the answer in any order.

Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.

Example 1:
Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above

Example 2:
Input: n = 1
Output: [["Q"]]

Constraints:
    1 <= n <= 9
*/

/*
Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]

.Q..
...Q
Q...
..Q.

*/

/* Complexity
Time complexity: O(n!)
Space complexity: O(n)
*/

public class NQueens
{
    private readonly int _n;
    private int _col, _diagonal, _antiDiagonal;
    private readonly List<int> _board = [];

    private readonly char[] _rowCharArray;
    private readonly List<IList<string>> _result = [];
    public IList<IList<string>> Result
    {
        get => _result;
    }

    public NQueens(int n)
    {
        _n = n;
        
        _rowCharArray = new char[_n];
        for (var i = 0; i <= _n - 1; i++) _rowCharArray[i] = '.';
        
        BackTracking(0, 0, 0, 0);
    }
    
    private void BackTracking(int rowIdx, int cols, int diagonals, int antiDiagonals)
    {

        if (rowIdx >= _n)
        {
            _result.Add(_board.Select(GetRowString).ToList());
            return;
        }

        for (var colIdx = 0; colIdx <= _n - 1; colIdx++)
        {
            if (!IsSafe(rowIdx, colIdx, cols, diagonals, antiDiagonals)) continue;
            
            _board.Add(colIdx);
                
            BackTracking(rowIdx + 1, cols | _col, diagonals | _diagonal, antiDiagonals | _antiDiagonal);
                
            _board.RemoveAt(_board.Count - 1);
        }
    }
    
    private bool IsSafe(int rowIdx, int colIdx, int cols, int diagonals, int antiDiagonals)
    {
        _col = 1 << colIdx;
        _diagonal = 1 << (rowIdx - colIdx + _n - 1);
        _antiDiagonal = 1 << (rowIdx + colIdx);

        return ((cols & _col) == 0) && ((diagonals & _diagonal) == 0) && ((antiDiagonals & _antiDiagonal) == 0);
    }

    private string GetRowString(int colIdx)
    {
        _rowCharArray[colIdx] = 'Q';
        var rowString = new string(_rowCharArray);
        _rowCharArray[colIdx] = '.';

        return rowString;
    }
}

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var nQueens = new NQueens(n);
        return nQueens.Result;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        var n = 4;
        PrintHelper.Print2DList(sol.SolveNQueens(n));
        // Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]

        n = 1;
        PrintHelper.Print2DList(sol.SolveNQueens(n));
        // Output: [["Q"]]
    }
}