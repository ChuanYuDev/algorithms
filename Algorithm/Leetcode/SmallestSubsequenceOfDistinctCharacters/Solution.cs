namespace Leetcode.SmallestSubsequenceOfDistinctCharacters;

/* Example
Input: s = "cbacdcbc"
Output: "acdb"

idx:    0 1 2 3 4 5 6 7
s:      c b a c d c b c

set:    a b c d
first   stack       next    
c       c           b
b       b           a
a       a c d       c
        a c d       b     
        a c d b     c
    
a c d: b?
    Only push b into stack, because there is not d after b
    
a c d : c?
*/

/* Variable
stack 

set: HashSet
    a

leftMap: dictionary
    d: 1
*/

/* Pseudocode
for c from s
    if (leftMap.Contains(c)) leftMap[c]++
    else leftMap[c] = 1
    
for c from s
    if (!set.Contains(c))
        while (stack.Count > 0 && c < stack.Peek())
            if (leftMap[stack.Peek()] == 0) break
            var rC = stack.Pop()
            set.Remove(rC)
            
        stack.Push(c)
        
        set.Add(c)
        
    leftMap[c]--
*/

/* Complexity
D: all the lowercase English letter
Time complexity:
    O(D * D + n)
Space complexity: O(D)

*/


public class Solution
{
    public string SmallestSubsequence(string s)
    {
        var stack = new Stack<char>();
        var set = new HashSet<char>();
        var leftMap = new Dictionary<char, int>();
        
        foreach (var c in s)
        {
            if (leftMap.ContainsKey(c)) leftMap[c]++;
            else leftMap[c] = 1;
        }

        foreach (var c in s)
        {
            if (!set.Contains(c))
            {
                while (stack.Count > 0 && c < stack.Peek())
                {
                    if (leftMap[stack.Peek()] == 0) break;
                    var removedChar = stack.Pop();
                    set.Remove(removedChar);
                }
                
                stack.Push(c);
                set.Add(c);
            }
            
            leftMap[c]--;
        }

        var charArray = stack.ToArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }
}

