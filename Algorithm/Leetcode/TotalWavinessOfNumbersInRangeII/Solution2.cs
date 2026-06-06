namespace Leetcode.TotalWavinessOfNumbersInRangeII;
//
//  Construct
//  000 - 999 isWaviness
//      value: 0 1
//      brute force
//  
//  GetIsWaviness()
//      isWaviness = new bool[1000]
//      for i from 0 to 999
//          i -> iStr with leading zeros to length of 3
//          if ((iStr[1] > iStr[0] && iStr[1] > iStr[2]) || (iStr[1] < iStr[0] && iStr[1] < iStr[2])) isWaviness[i] = true
//  
//  long TotalWaviness(long num)
//      GetOccurrence(num)
//      waviness = 0
//      for i from 0 to 999
//          waviness += (isWaviness[i])? occurrence[i]: 0
//  
//      return waviness
//
//  long TotalWaviness(long num1, long num2)
//      return TotalWaviness(num2) - TotalWaviness(num1 - 1)

//  21 waviness = 0
//  1021 waviness = 2

//  Get 1000 - 9999, length = 4
//  i from 1 to length - 2
//  i=1
//  100 - 999: 10
//  i=2
//  000 - 999: 9
//
//  Get 10000 - 99999, length = 5
//  i from 1 to length - 2
//  i=1
//  100 - 999: 10^2
//  i=2
//  000 - 999: 9 * 10
//  i=3
//  000 - 999: 99 - 10 + 1 = 90
//  99...9: length 0~i-2: i-1
//  10...0: i-1
//  90...0: i-1
//  9 * 10^(i-2)
//
//  GetFixedLengthOccurence(int length)
//      i from 1 to length - 2
//      i == 1
//      100 - 999: 10^(length-i-2) = 10^(length-3)
//      i >= 2
//      000 - 999: 9 *10^(i-2) * 10^(length-i-2) = 9*10^(length-4)

//  Get 10...0 - num occurrence
//  1000 ~ 5234
//  i=1
//  100 - 522 10  
//  523 5
//  i=2
//  000 - 999 4
//  000 - 234 1

//  10000 ~52345
//  01234
//
//  i=1
//  100 - 522 10^2
//  523 45+1
//  i=2
//  000 - 999 4 * 10
//  000 - 233 10
//  234 5+1
//  i=3
//  000 - 999: (10 - 51): 42
//  000 - 345 1
//
//  Generalize
//  10...0 ~ num
//
//  GetRemainingOccurrence(num)
//      numStr = num.ToString()
//      length = numStr.Length
//      i from 1 to length - 2
//      // i-1 i i+1
//      // s[i-1: i+1] occurrence: 
//      i = 1
//      100 - (s[i-1:i+1] - 1): 10^(length-i-2)
//      s[i-1:i+1]: s[i+2:] + 1
//      
//      i >=2
//      // 10...0 ~ s[0:i-2]-1
//      // 10^(i-2) ~ s[0:i-2]-1
//      000 - 999: (s[0:i-2] - 1 - 10^(i-2) + 1) * 10^(length-i-2)
//      000 - (s[i-1:i+1]-1): 10^(length-i-2)
//      if (i == length-2)
//          s[i-1:i+1]: 1
//      else
//          s[i-1:i+1]: s[i+2:] + 1

//  GetOccurrence(num)
//      length = numStr.Length
//      for (len = 3; len <= length-1; len++)
//          GetFixedLengthOccurence(len)
//      GetRemainingOccurence(num)

//  Time complexity
//      d: maximum digit number
//      O(d^2)
//  Space complexity
//      O(1)

//  This solution is too error-prone

public class Solution2
{
    private bool[] _isWaviness;
    private long[] _occurrence;

    public Solution2()
    {
        GetIsWaviness();
    }
    
    private void GetIsWaviness()
    {
        _isWaviness = new bool[1000];
        
        for (var i = 0; i <= 999; i++)
        {
            string iStr = $"{i:D3}";

            if ((iStr[1] > iStr[0] && iStr[1] > iStr[2]) || (iStr[1] < iStr[0] && iStr[1] < iStr[2]))
            {
                _isWaviness[i] = true;
            }
        }
    }

    private void GetOccurrence(long num)
    {
        _occurrence = new long[1000];
        var numStr = num.ToString();
        var length = numStr.Length;

        for (var len = 3; len <= length - 1; len++)
        {
            GetFixedLengthOccurrence(len);
        }

        GetRemainingOccurrence(num);
    }

    private void GetFixedLengthOccurrence(int length)
    {
        for (var i = 1; i <= length - 2; i++)
        {
            if (i == 1)
            {
                for (int j = 100; j <= 999; j++)
                {
                    _occurrence[j] += (long)Math.Pow(10, length - 3);
                }
            }
            else
            {
                for (int j = 0; j <= 999; j++)
                {
                    _occurrence[j] += 9* (long)Math.Pow(10, length - 4);
                }
            }
        }
    }
    
    private void GetRemainingOccurrence(long num)
    {
        var numStr = num.ToString();
        var length = numStr.Length;

        for (var i = 1; i <= length - 2; i++)
        {
            var multiplier = (long)Math.Pow(10, length - i - 2);
            var value = int.Parse(numStr.Substring(i - 1, 3));
            
            var afterValue = (i < length - 2)? long.Parse(numStr.Substring(i + 2)): 0;

            if (i == 1)
            {
                for (var j = 100; j <= value - 1; j++)
                {
                    _occurrence[j] += multiplier;
                }

                _occurrence[value] += afterValue + 1;
            }
            else
            {
                for (var j = 0; j <= 999; j++)
                {
                    _occurrence[j] +=
                    (
                        long.Parse(numStr.Substring(0, i - 1)) -
                        (long)Math.Pow(10, i - 2)
                    ) * multiplier;
                }

                for (var j = 0; j <= value - 1; j++)
                {
                    _occurrence[j] += multiplier;
                }

                if (i == length - 2) _occurrence[value] += 1;
                else _occurrence[value] += afterValue + 1;
            }
        }
    }
    
    private long TotalWaviness(long num)
    {
        GetOccurrence(num);

        long waviness = 0;

        for (var i = 0; i <= 999; i++)
        {
            waviness += (_isWaviness[i]) ? _occurrence[i] : 0;
        }

        return waviness;
    }
    
    public long TotalWaviness(long num1, long num2)
    {
        return TotalWaviness(num2) - TotalWaviness(num1 - 1);
    }
}