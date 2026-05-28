namespace Leetcode.FindTheLengthofTheLongestCommonPrefix;

//  The Solution is actually very similar to Trie data structure, but needs to be optimized based on Trie as follows
//
//  1. When we calculate the number of digits in a number, we can convert it to string and return the length of the string
//      Actually when we convert the int to string, it is similar to get each digit
//      But we can simplify the code
//
//  2. When we store the children of node, because the digits are limited from 0 to 9, we can store the digit based on the index of the children
//      The finding children process can be largely simplified
//
//  3. Separate Solution class into TrieNode, Trie and Solution 3 classes

//  TrieNode
//
//  Trie
//      root  
//  Trie.Insert
//  void Insert(int num)
//      node = root
//      num -> numStr
//      for each c in numStr
//          cIdx = c - '0'
//          if (node.Children[cIdx] is null)
//              node.Children[cIdx] = new Node()
//          node = node.Children[cIdx]
//
//  Trie.FindLongestPrefix
//  int FindLongestPrefix(int num)
//      node = root
//      num -> numStr
//      len = 0
//      for each c in numStr
//          cIdx = c - '0'
//          if (node.Children[cIdx] is null) break;
//
//          len++    
//          node = node.Children[cIdx]
//      return len
//  
//  Solution - LongestCommonPrefix
//  int LongestCommonPrefix(int[] arr1, int[] arr2)
//      trie = new Trie() 
//      maxLen = 0
//      for each num in arr1
//          trie.Insert(num)
//      
//      for each num in arr2
//          len = trie.FindLongestPrefix(num)
//          maxLen = len > maxLen? len: maxLen
//
//      return maxLen

public class Node
{
    public Node?[] Children { get; set; } = new Node?[10];
}

public class Trie
{
    private readonly Node _root = new Node();

    public void Insert(int num)
    {
        Node node = _root;
        var numStr = num.ToString();

        foreach (var c in numStr)
        {
            var cIdx = c - '0';

            if (node.Children[cIdx] is null) node.Children[cIdx] = new Node();

            node = node.Children[cIdx]!;
        }
    }

    public int FindLongestPrefix(int num)
    {
        Node node = _root;
        var numStr = num.ToString();
        var len = 0;

        foreach (var c in numStr)
        {
            var cIdx = c - '0';

            if (node.Children[cIdx] is null) break;

            len++;
            node = node.Children[cIdx]!;
        }

        return len;
    }
}

public class Solution3
{

    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var trie = new Trie();
        var maxLen = 0;
        
        foreach(var num in arr1) trie.Insert(num);

        foreach (var num in arr2)
        {
            var len = trie.FindLongestPrefix(num);
            maxLen = len > maxLen ? len : maxLen;
        }

        return maxLen;
    }
    
}