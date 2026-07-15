namespace Algorithm.Algorithm.ManacherAlgorithm;

public class Manacher
{
    private const char C = '#';
    
    private readonly string _s;
    private readonly int _length;
    private readonly int _lengthPrime;
    private string _sPrime = "";
    private readonly int[] _p;

    public Manacher(string s)
    {
        _s = s;
        _length = s.Length;
        _lengthPrime = 2 * _length + 1;
        _p = new int[_lengthPrime];
        PreProcessing();
        Processing();
    }

    public string LongestPalindrome()
    {
        var centerIdxInSPrime = 0;
        var longestLengthInS = int.MinValue;
        
        for (var i = 0; i <= _lengthPrime - 1; i++)
        {
            if (_p[i] <= longestLengthInS) continue;
            longestLengthInS = _p[i];
            centerIdxInSPrime = i;
        }

        var startIdxInS = (centerIdxInSPrime - longestLengthInS) / 2;

        return _s.Substring(startIdxInS, longestLengthInS);
    }
    
    private void PreProcessing()
    {
        var charArr = new char[_lengthPrime];

        for (var i = 0; i <= _lengthPrime - 1; i++)
        {
            if ((i & 1) == 0) charArr[i] = C;
            else charArr[i] = _s[(i - 1) / 2];
        }

        _sPrime = new string(charArr);
    }

    private void Processing()
    {
        var center = 0;
        var r = 0;

        for (var i = 1; i <= _lengthPrime - 1; i++)
        {
            if (i <= r)
            {
                var iMirror = (center << 1) - i;
                _p[i] = Math.Min(r - i, _p[iMirror]);
            }

            if (i + _p[i] < r) continue;

            while (true)
            {
                var lPrime = i - _p[i] - 1;
                var rPrime = i + _p[i] + 1;

                if ((lPrime >= 0) && (rPrime <= _lengthPrime - 1) && (_sPrime[lPrime] == _sPrime[rPrime]))
                {
                    _p[i]++;
                    continue;
                }

                break;
            }

            if (i + _p[i] == r) continue;
            center = i;
            r = i + _p[i];
        }
    }
}

public class Solution
{
    public string LongestPalindrome(string s)
    {
        var manacher = new Manacher(s);
        return manacher.LongestPalindrome();
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();

        var s = "babad";
        Console.WriteLine(sol.LongestPalindrome(s));
        //  Output: "bab"

        s = "cbbd";
        Console.WriteLine(sol.LongestPalindrome(s));
        //  Output: "bb"
        
        s = "nbnanbs";
        Console.WriteLine(sol.LongestPalindrome(s));
        //  Output: "bnanb"
        
        s = "nbnnb";
        Console.WriteLine(sol.LongestPalindrome(s));
        //  Output: "bnnb"
    }
}