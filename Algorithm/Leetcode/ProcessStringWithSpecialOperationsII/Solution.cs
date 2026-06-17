namespace Leetcode.ProcessStringWithSpecialOperationsII;

//  s = "a#b%*", k = 1
//      i   result  length
//      0   a       1
//      1   aa      2
//      2   aab     3
//      3   baa     3
//      4   ba      2

//  s = "cd%#*#"
//      i   result  length  k   k
//      0	c       1       0
//      1	cd      2       0   1
//      2	dc      2       1   0
//      3	dcdc    4       1   0
//      4	dcd     3       1   0
//      5	dcddcd  6       4   3

//  s = "*"
//      i   result  length
//      0   ""      0

//  s = "jio#*g"
//      i   result  length  k
//      0   j
//      1   ji      2       1
//      2   jio     3       1
//      3   jiojio  6       1
//      4   jioji   5       1
//      5   jiojig  6       1

//  Special operation will always get k in the previous result

//  '*': Remove
//  nothing 

//  '#': Duplicate
//  0 1 2 3 4 5, k = 4
//  k % (length / 2)

//  '%': Reverse
//  0 1 2 3 4 5, k = 4
//  length-1-k

//  English letter
//  if (k <= length - 2) nothing
//  if (k == length - 1) return c

//  Time complexity
//      n = s.Length
//      O(n)

//  Space complexity
//      O(1)

//  Pseudocode
//  length = 0
//  for c in s
//      switch (c)
//          case '*':
//              if (length >= 1) length--
//              break
//          case '#':
//              length *= 2
//              break
//          case '%':
//              break
//          default:
//              length++
//              break
//  
//  if (k >= length) return '.'
//
//  for i from s.Length-1 to 0
//      switch (s[i])
//          case '*':
//              length++
//              break
//          case '#':
//              k %= length / 2
//              length /= 2
//              break
//          case '%':
//              k = length-1-k
//              break
//          default:
//              if (k == length - 1) return s[i]
//              length--
//              break


public class Solution
{
    public char ProcessStr(string s, long k)
    {
        long length = 0;
        foreach (var c in s)
        {
            switch (c)
            {
                case '*':
                    if (length >= 1) length--;
                    break;
                case '#':
                    length *= 2;
                    break;
                case '%':
                    break;
                default:
                    length++;
                    break;
            }
        }

        if (k >= length) return '.';

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var c = s[i];
            switch (c)
            {
                case '*':
                    length++;
                    break;
                case '#':
                    k %= length / 2;
                    length /= 2;
                    break;
                case '%':
                    k = length - 1 - k;
                    break;
                default:
                    if (k == length - 1) return c;
                    length--;
                    break;
            }
        }

        // Never executed
        return '-';
    }
}
