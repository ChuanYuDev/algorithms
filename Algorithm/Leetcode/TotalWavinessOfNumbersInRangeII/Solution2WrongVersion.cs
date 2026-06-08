namespace Leetcode.TotalWavinessOfNumbersInRangeII;
//  Get 000 - num occurrence
//  000 ~ 123
//  000 - 122 1
//  123 1

//  0000 ~ 1234
//  i=1
//  000 - 122 10  
//  123 5
//  i=2
//  000 - 999 1
//  000 - 234 1
//
//  i=1 020 10
//  0200 0201 0202 ... 0209

//  00000 ~12345
//  i=1
//  000 - 122 10^2
//  123 45+1
//  i=2
//  000 - 999 10
//  000 - 233 10
//  234 5+1
//  i=3
//  000 - 999 12
//  000 - 345 1
//
//  // Generalize
//  GetOccurrence(num)
//      numStr = num.ToString()
//      length = numStr.Length
//      i from 1 to length - 2
//      // i-1 i i+1
//      // s[i-1: i+1] occurrence: 
//      if (i>=2)
//          000 - 999: long.Parse(s[0: i-2]) * 10^(length - i - 2)
//
//      000 - (int.Parse(s[i-1: i+1]) - 1): 10^(length - i - 2)
//  
//      if (i == length-2)
//          int.Parse(s[i-1: i+1]): 1
//      else
//          int.Parse(s[i-1: i+1]): int.Parse(s[i+2:]) + 1

public class Solution2WrongVersion
{
    private long[] GetOccurrence(long num)
    {
        var occurrence = new long[1000];
        var numStr = num.ToString();
        var length = numStr.Length;

        for (var i = 1; i <= length - 2; i++)
        {
            var multiplier = (long)Math.Pow(10, length - i - 2);
            var value = int.Parse(numStr.Substring(i - 1, 3));
            
            if (i >= 2)
            {
                for (var j = 0; j <= 999; j++)
                {
                    occurrence[j] += long.Parse(numStr.Substring(0, i - 1)) * multiplier;
                }
            }
            
            for (var j = 0; j <= value - 1; j++)
            {
                occurrence[j] += multiplier;
            }

            if (i == length - 2) occurrence[value] += 1;
            else occurrence[value] += int.Parse(numStr.Substring(i + 2)) + 1;
        }

        return occurrence;
    }
    
    private long TotalWaviness(long num)
    {
        var isWaviness = new bool[1000];
        for (var i = 0; i <= 999; i++)
        {
            if (i <= 99) continue;

            var iStr = i.ToString();

            if ((iStr[1] > iStr[0] && iStr[1] > iStr[2]) || (iStr[1] < iStr[0] && iStr[1] < iStr[2]))
            {
                isWaviness[i] = true;
            }
        }

        var occurrence = GetOccurrence(num);

        long waviness = 0;

        for (var i = 0; i <= 999; i++)
        {
            waviness += (isWaviness[i]) ? occurrence[i] : 0;
        }

        return waviness;
    }
    
    public long TotalWaviness(long num1, long num2)
    {
        return TotalWaviness(num2) - TotalWaviness(num1 - 1);
    }
}