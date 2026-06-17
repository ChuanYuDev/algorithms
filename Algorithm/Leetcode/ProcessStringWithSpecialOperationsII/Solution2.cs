namespace Leetcode.ProcessStringWithSpecialOperationsII;

//  Improve solution
//  1. Changing all *2 and /2 into bit shift
//  2. Use - instead of % 
//      '#': Duplicate
//      0 1 2 3 4 5, k = 4
//      // k % (length / 2)
//      if (k >= length/2) k-= length/2

public class Solution2
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
                    length <<= 1;
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
                    var halfLength = length >> 1;
                    if (k >= halfLength) k -= halfLength;
                    length = halfLength;
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
