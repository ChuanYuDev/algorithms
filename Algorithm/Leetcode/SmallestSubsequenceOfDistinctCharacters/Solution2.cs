using System.Text;

namespace Leetcode.SmallestSubsequenceOfDistinctCharacters;

/* Optimization
1. HashSet and Dictionary can be replaced by simple arrays because s only consists of lowercase English letters 

2. Stack<T> can be replaced by the StringBuilder type because we don't need to do ToArray() and Reverse() operations
    Stack<T>.Push() -> StringBuilder.Append()
    Stack<T>.Pop() -> StringBuilder.Length--
    Stack<T>.Peek() -> StringBuilder[length - 1]
    
3. Set the initial capacity of StringBuilder to 26
    Because the maximum number of characters stored in StringBuilder is 26
    Indexer operation of StringBuilder may take O(n) time if there are many chunks, setting the initial capacity makes it not chunky
*/

public class Solution2
{
    private const int MaxCharNum = 26;
    
    public string SmallestSubsequence(string s)
    {
        var left = new int[MaxCharNum];

        foreach (var c in s) left[c - 'a']++;

        var stringBuilder = new StringBuilder(MaxCharNum);
        var visited = new bool[MaxCharNum];
        
        foreach (var c in s)
        {
            if (!visited[c - 'a'])
            {
                while (stringBuilder.Length > 0)
                {
                    var lastChar = stringBuilder[^1];

                    if (c >= lastChar) break;
                    if (left[lastChar - 'a'] == 0) break;

                    stringBuilder.Length--;
                    visited[lastChar - 'a'] = false;
                }

                stringBuilder.Append(c);
                visited[c - 'a'] = true;
            }
            
            left[c - 'a']--;
        }

        return stringBuilder.ToString();
    }
}
