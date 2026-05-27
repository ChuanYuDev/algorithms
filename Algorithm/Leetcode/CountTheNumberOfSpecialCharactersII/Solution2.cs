namespace Leetcode.CountTheNumberOfSpecialCharactersII;
//  Test use dictionary instead of HashSet
//  Time didn't improve
public class Solution2
{
    public int NumberOfSpecialChars(string word)
    {
        bool?[] isSpecial = new bool?[26];
        // HashSet<char> set = new HashSet<char>();
        Dictionary<char, int> set = new Dictionary<char, int>();

        foreach (var c in word)
        {
            var cIdx = char.ToLower(c) - 'a';

            if (isSpecial[cIdx] == false) continue;

            if (char.IsLower(c) && set.ContainsKey(char.ToUpper(c)))
            {
                isSpecial[cIdx] = false;
                continue;
            }

            if (char.IsUpper(c) && set.ContainsKey(char.ToLower(c))) isSpecial[cIdx] = true;

            set[c] = 1;
        }

        int numberOfSpecial = 0;
        foreach (var b in isSpecial)
        {
            if (b == true) numberOfSpecial++;
        }
        
        return numberOfSpecial;
    }
}
