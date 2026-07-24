using Helper;

namespace Algorithm.Algorithm.NQueensProblem;

using System.Collections.Generic;

public class NQueens
{
    private readonly int _n;
    private int _col, _diagonal, _antiDiagonal;
    private readonly List<int> _board = [];

    private readonly List<IList<int>> _result = [];
    public IList<IList<int>> Result
    {
        get => _result;
    }

    public NQueens(int n)
    {
        _n = n;
        BackTracking(0, 0, 0, 0);
    }
    
    private void BackTracking(int rowIdx, int cols, int diagonals, int antiDiagonals)
    {

        if (rowIdx >= _n)
        {
            _result.Add(new List<int>(_board));
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
}

public class MainProgram
{
    static void Main()
    {
        var n = 4;
        var nQueens = new NQueens(n);
        PrintHelper.Print2DList(nQueens.Result);
        // Output: [[1, 3, 0, 2], [2, 0, 3, 1]]

        n = 3;
        nQueens = new NQueens(n);
        PrintHelper.Print2DList(nQueens.Result);
        // Output: []
    }
}