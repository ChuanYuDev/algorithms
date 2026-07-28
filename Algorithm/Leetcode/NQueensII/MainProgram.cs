namespace Leetcode.NQueensII;
/*
N-Queens II

The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
   
Given an integer n, return the number of distinct solutions to the n-queens puzzle.

Example 1:
Input: n = 4
Output: 2
Explanation: There are two distinct solutions to the 4-queens puzzle as shown.

Example 2:
Input: n = 1
Output: 1

Constraints:
    1 <= n <= 9
*/
public class NQueens
{
    private readonly int _n;
    private int _col, _diagonal, _antiDiagonal;

    public NQueens(int n)
    {
        _n = n;
    }

    public int TotalNQueens()
    {
        return BackTracking(0, 0, 0, 0);
    }
    
    private int BackTracking(int rowIdx, int cols, int diagonals, int antiDiagonals)
    {

        if (rowIdx >= _n)
        {
            return 1;
        }

        var result = 0;

        for (var colIdx = 0; colIdx <= _n - 1; colIdx++)
        {
            if (!IsSafe(rowIdx, colIdx, cols, diagonals, antiDiagonals)) continue;
            
            result += BackTracking(rowIdx + 1, cols | _col, diagonals | _diagonal, antiDiagonals | _antiDiagonal);
        }

        return result;
    }
    
    private bool IsSafe(int rowIdx, int colIdx, int cols, int diagonals, int antiDiagonals)
    {
        _col = 1 << colIdx;
        _diagonal = 1 << (rowIdx - colIdx + _n - 1);
        _antiDiagonal = 1 << (rowIdx + colIdx);

        return ((cols & _col) == 0) && ((diagonals & _diagonal) == 0) && ((antiDiagonals & _antiDiagonal) == 0);
    }
}

public class Solution
{
    public int TotalNQueens(int n)
    {
        var nQueens = new NQueens(n);

        return nQueens.TotalNQueens();
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        var n = 4;
        Console.WriteLine(sol.TotalNQueens(n));
        // Output: 2

        n = 1;
        Console.WriteLine(sol.TotalNQueens(n));
        // Output: 1
    }
}