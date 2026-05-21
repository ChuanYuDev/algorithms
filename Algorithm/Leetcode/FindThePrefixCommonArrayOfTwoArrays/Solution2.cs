namespace Leetcode.FindThePrefixCommonArrayOfTwoArrays;

// Because we just check the presence of the element in aMap and bMap
// So we can change the data structure from Dictionary to HashSet with preset capacity

// But the HashSet is slower than Dictionary implementation in Leetcode (10ms vs. 5ms), why??
public class Solution2
{
    public int[] FindThePrefixCommonArray(int[] a, int[] b)
    {
        var length = a.Length;
        
        var aSet = new HashSet<int>(length - 1);
        var bSet = new HashSet<int>(length - 1);


        int[] c = new int[length];

        c[0] = a[0] == b[0] ? 1 : 0;

        for (var i = 1; i < length; i++)
        {
            aSet.Add(a[i - 1]);
            bSet.Add(b[i - 1]);
            
            c[i] = c[i - 1];

            if (a[i] == b[i])
                c[i] += 1;
            else
            {
                if (bSet.Contains(a[i]))
                    c[i] += 1;

                if (aSet.Contains(b[i]))
                    c[i] += 1;
            }
        }

        return c;
    }
}
