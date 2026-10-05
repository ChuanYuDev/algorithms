namespace Leetcode.MaximumNestingDepthOfTwoValidParenthesesStrings;
/* Fix
1. Based on SolutionWrong2, we should not use maxDepth to determine which bucket we should put into,
    We should use depth
    Because if depthA > depthB, we put ( into B, it will not increase max(depthA, depthB)

2. Because we use depth instead of maxDepth, we even don't maxDepth variable

3. We don't need stackA and stackB, we only need countA
*/

/*
Input: seq = "()(())()"
Output: [0,0,0,1,1,0,1,1]

countA = 0
depthA, depthB

if left
    if (depthA > depthB)
        depthB++
        result[i] = 1
    
    else
        countA++
        depthA++
        result[i] = 0

else
    if (countA != 0)
        countA--
        result[i] = 0
        depthA--
    
    else
        result[i] = 1
        depthB--

return result
    
*/

public class Solution
{
    public int[] MaxDepthAfterSplit(string seq)
    {
        var countA = 0;
        int depthA = 0, depthB = 0;

        var length = seq.Length;
        var result = new int[length];

        for (var i = 0; i <= length - 1; i++)
        {
            var c = seq[i];

            if (c == '(')
            {
                if (depthA > depthB)
                {
                    depthB++;
                    result[i] = 1;
                }
                else
                {
                    countA++;
                    depthA++;
                    result[i] = 0;
                }
            }
            else
            {
                if (countA != 0)
                {
                    countA--;
                    result[i] = 0;
                    depthA--;
                }
                else
                {
                    result[i] = 1;
                    depthB--;
                }
            }
        }

        return result;
    }
}
