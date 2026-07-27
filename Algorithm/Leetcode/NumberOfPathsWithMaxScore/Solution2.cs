namespace Leetcode.NumberOfPathsWithMaxScore;

/*
Runtime: 129 ms, Beats: 54.25%
Memory: 48.80 MB, Beats: 81.91%
*/

/* Optimization
1. Use (x + y) % Mod directly, there is no need to use BigInteger
    Because x < Mod, y < Mod, (x + y) is still in the range of int32, (x + y) % Mod < Mod
*/

public class Solution2
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

                var numPaths = 0;
                if (_res[j].MaxScore == maxScore) numPaths = (numPaths + _res[j].NumPaths) % Mod;
                if (_res[j + 1].MaxScore == maxScore) numPaths = (numPaths + _res[j + 1].NumPaths) % Mod;
                if (_nextRes[j + 1].MaxScore == maxScore) numPaths = (numPaths + _nextRes[j + 1].NumPaths) % Mod;

                _nextRes[j] = (maxScore + valueInt, numPaths);

            }
            
            _res = [.._nextRes];
        }
    }
}
