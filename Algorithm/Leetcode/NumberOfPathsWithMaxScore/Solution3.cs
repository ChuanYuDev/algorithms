namespace Leetcode.NumberOfPathsWithMaxScore;

/* Optimization
1. Set MaxScore as -1 if valueChar is 'X'
    Because MaxScore is also 0 if valueChar is 'S'
    We can use MaxScore to differentiate 'X' and 'S' instead of using NumPaths
*/
   
public class Solution3
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

        var maxScore = _res[0].MaxScore;
        
        return [(maxScore == -1)? 0: maxScore, _res[0].NumPaths];
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
                _res[j] = (-1, 0);
                continue;
            }

            var maxScore = _res[j + 1].MaxScore;

            if (maxScore == -1)
            {
                _res[j] = (-1, 0);
                continue;
            }

            _res[j] = ( maxScore + valueChar - '0', _res[j + 1].NumPaths);
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
                    _nextRes[j] = (-1, 0);
                    continue;
                }

                var maxScore = (j == _length - 1)? _res[j].MaxScore: Math.Max(Math.Max(_res[j].MaxScore, _res[j + 1].MaxScore), _nextRes[j + 1].MaxScore);

                if (maxScore == -1)
                {
                    _nextRes[j] = (-1, 0);
                    continue;
                }
                
                if (j == _length - 1)
                {
                    _nextRes[j] = (maxScore + valueChar - '0', _res[j].NumPaths);
                    continue;
                }

                var numPaths = 0;
                if (_res[j].MaxScore == maxScore) numPaths = (numPaths + _res[j].NumPaths) % Mod;
                if (_res[j + 1].MaxScore == maxScore) numPaths = (numPaths + _res[j + 1].NumPaths) % Mod;
                if (_nextRes[j + 1].MaxScore == maxScore) numPaths = (numPaths + _nextRes[j + 1].NumPaths) % Mod;

                var valueInt = (valueChar == 'E') ? 0 : valueChar - '0';
                _nextRes[j] = (maxScore + valueInt, numPaths);

            }
            
            _res = [.._nextRes];
        }
    }
}

