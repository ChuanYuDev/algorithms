namespace Leetcode.CountTheNumberOfSpecialCharactersI;
//  set 
//  bool[] isSpecial = new bool[26]
//  foreach(var c in word)
//      cIdx = c.ToLower() - 'a'
//      if (isSpecial[cIdx]) continue;
//
//      var cComplement = c >= 'A'? c.ToLower(): c.ToUpper()
//      if (set.Contains(cComplement)) isSpecial[cIdx] = true
//      else set.Add(c)

public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        HashSet<char> set = new HashSet<char>();
        bool[] isSpecial = new bool[26];
        int numberOfSpecial = 0;

        foreach (var c in word)
        {
            var cIdex = char.ToLower(c) - 'a';
            if (isSpecial[cIdex]) continue;

            var cComplement = char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);

            if (set.Contains(cComplement))
            {
                isSpecial[cIdex] = true;
                numberOfSpecial++;
            }
            else set.Add(c);
        }
        return numberOfSpecial;
    }
}
