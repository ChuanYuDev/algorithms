namespace Leetcode.SequentialDigits;

//  Input: low = 100, high = 300
//  Output: [123,234]

//  int GenNum(char first, int length)
//  O(length)
//  charArr = new char[length]
//  for i from 0 to length - 1
//      charArr[i] = first + i
//  
//  return int.Parse(new String(charArr))
//  
//  last - first + 1 = length
//  last = first + length - 1 <= '9'
//  first <= '9' + 1 - length

//  lowLength, highLength
//  for length from lowLength to highLength
//      for first from '1' to '9' + 1 - length
//          num = GenNum(first, length)
//          if (num < low) continue
//          if (num > high) break
//          res.Add(num)

//  Time complexity
//      Max digits: d
//      GenNum: O(d)
//      Total: O(d * 9 * d)

//  Space complexity
//      O(d)

public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        int lowLength = GetLength(low);
        int highLength = GetLength(high);
        var res = new List<int>();

        for (var length = lowLength; length <= highLength; length++)
        {
            var maxI = '9' - '1' + 1 - length;
            for (var i = 0; i <= maxI; i++)
            {
                var first = '1' + i;
                var num = GenNum(first, length);
                if (num < low) continue;
                if (num > high) break;
                res.Add(num);
            }
        }

        return res;
    }
    
    private int GetLength(int num) => num.ToString().Length;
    
    private int GenNum(int first, int length)
    {
        var charArr = new char[length];

        for (var i = 0; i <= length - 1; i++) charArr[i] = (char)(first + i);

        return int.Parse(new string(charArr));
    }
}
