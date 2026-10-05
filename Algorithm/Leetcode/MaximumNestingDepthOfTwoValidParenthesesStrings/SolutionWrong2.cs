namespace Leetcode.MaximumNestingDepthOfTwoValidParenthesesStrings;
/* Wrong Answer
21 / 31 testcases passed

Expected
(((()))((())))
00110010010011
A: (())(()) 2
B: (()()) 2

My
(((()))((())))
01010010000001
A: (())((())) 3
B: (()) 2
*/

/* Fix
Should not put ( into A and B alternately
    Instead should track the depth of A and B
    If depth(A) > depth(B), put into B
    else put into A
*/

/*
Input: seq = "()(())()"
Output: [0,0,0,1,1,0,1,1]

stackA, stackB char
maxDepthA, maxDepthB = 0
depthA, depthB

if left
    if (maxDepthA > maxDepthB)
        stackB push left
        depthB++
        maxDepthB = max(maxDepthB, depthB)
        result[i] = 1
    
    else
        stackA push left
        depthA++
        maxDepthA = max(maxDepthA, depthA)
        result[i] = 0

else
    if (stackA.Count != 0)
        stackA.pop()
        result[i] = 0
        depthA--
    
    else
        stackB.pop()
        result[i] = 1
        depthB--

return result
    
*/

public class SolutionWrong2
{
    public int[] MaxDepthAfterSplit(string seq)
    {
        var stackA = new Stack<char>();
        var stackB = new Stack<char>();
        int maxDepthA = 0, maxDepthB = 0;
        int depthA = 0, depthB = 0;

        var length = seq.Length;
        var result = new int[length];

        for (var i = 0; i <= length - 1; i++)
        {
            var c = seq[i];

            if (c == '(')
            {
                if (maxDepthA > maxDepthB)
                {
                    stackB.Push(c);
                    depthB++;
                    maxDepthB = Math.Max(maxDepthB, depthB);
                    result[i] = 1;
                }
                else
                {
                    stackA.Push(c);
                    depthA++;
                    maxDepthA = Math.Max(maxDepthA, depthA);
                    result[i] = 0;
                }
            }
            else
            {
                if (stackA.Count != 0)
                {
                    stackA.Pop();
                    result[i] = 0;
                    depthA--;
                }
                else
                {
                    stackB.Pop();
                    result[i] = 1;
                    depthB--;
                }
            }
        }

        return result;
    }
}