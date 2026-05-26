namespace Leetcode.CountTheNumberOfSpecialCharactersI;

// Solution is okay but only beats 50% in runtime

// Store the characters of word in two sets, lowercases and uppercases (store lowercase instead)
// Then intersect these two sets and count the number
//
// The time doesn't improve at all... 
public class Solution2
{
    public int NumberOfSpecialChars(string word)
    {
        HashSet<char> lowercases = new HashSet<char>();
        HashSet<char> uppercases = new HashSet<char>();
        
        foreach (var c in word)
        {
            if (char.IsUpper(c)) uppercases.Add(char.ToLower(c));
            else lowercases.Add(c);
        }

        lowercases.IntersectWith(uppercases);
        return lowercases.Count;
    }
}