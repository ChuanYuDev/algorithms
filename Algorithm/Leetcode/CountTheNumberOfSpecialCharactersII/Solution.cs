namespace Leetcode.CountTheNumberOfSpecialCharactersII;

//  bool?[] isSpecial = new bool?[26]
//  set

//  for each c in word
//      cIdx = c.ToLower() - 'a'
//      if (isSpecial[cIdx] == false) continue
//      
//      if (c.IsLower() && set.Contains(c.ToUpper())
//          isSpecial[cIdx] = false
//          continue

//      if (c.IsUpper() && set.Contains(c.ToLower()) 
//          isSpecial[cIdx] = true
//          
//      set.Add(c)  // if there is no complement or c.IsUpper && set.Contains(c.ToLower())
//  
//  numberOfSpecial = 0
//  for each b in isSpecial
//      if (b == true) numberOfSpecial++
//  return numberOfSpecial

public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        bool?[] isSpecial = new bool?[26];
        HashSet<char> set = new HashSet<char>();

        foreach (var c in word)
        {
            var cIdx = char.ToLower(c) - 'a';

            if (isSpecial[cIdx] == false) continue;

            if (char.IsLower(c) && set.Contains(char.ToUpper(c)))
            {
                isSpecial[cIdx] = false;
                continue;
            }

            if (char.IsUpper(c) && set.Contains(char.ToLower(c))) isSpecial[cIdx] = true;

            set.Add(c);
        }

        int numberOfSpecial = 0;
        foreach (var b in isSpecial)
        {
            if (b == true) numberOfSpecial++;
        }
        
        return numberOfSpecial;
    }
}
