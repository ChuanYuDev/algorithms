namespace Leetcode.LongestCommonSuffixQueries;

//  Instead of storing index of wordsContainer in the node, we can store the index of node that has the smallest length

//  Because we traverse wordsContainer from front to back, ties are naturally resolved in favor of the earlies occurrence

//  ["abcd","bcd","xbcd"], wordsQuery = ["cd","bcd","xyz"]
//
//  wordsContainer
//  root (1) -> d (1) -> c (1) -> b (1) -> a (0)
//                                      -> x (2)

//  Node
//      Node?[] Children = new Node?[26]
//      int MinLen
//      int Idx 
//
//  Trie
//      root = new Node
//
//  void Insert(string s, idx)
//      node = root
//      len = s.Length
//      if (len < node.MinLen)
//          node.MinLen = len
//          node.Idx = idx
//      
//      for i from s.Length to 0
//          idx = s[i] - 'a'
//          if (node.Children[idx] is null) node.Children[idx] = new Node()
//          node = node.Children[idx]
//          if (len < node.MinLen)
//              node.MinLen = len
//              node.Idx = idx
//  
//  int FindLongestSuffix(string s)
//      node = root
//      for i from s.Length - 1 to 0
//          idx = s[i] - 'a'
//          if (node.Children[idx] is null) break;
//          node = node.Children[idx]
//      return node.Idx
//
//  Solution
//  int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
//      trie = new Trie()
//      stringIndices = []
//      for each s in wordsContainer
//          trie.Insert(s) 
//
//      for var i in wordsQuery
//          var s = wordsQuery[i]
//          stringIndices[i] = trie.FindLongestSuffix(s) 
//      return stringIndices
//
//  Time complexity
//      Digits d
//      Container m
//      Query n
//      O((m+n)d)
//  Space complexity
//      O(md)

public class Node2
{
    public Node2?[] Children { get; set; } = new Node2?[26];
    public int MinLen { get; set; } = int.MaxValue;
    public int Idx { get; set; } = int.MaxValue;
}

public class Trie2
{
    private readonly Node2 _root = new Node2();

    public void Insert(string s, int idx)
    {
        Node2 node = _root;
        var len = s.Length;

        if (len < node.MinLen)
        {
            node.MinLen = len;
            node.Idx = idx;
        }

        for (var i = len - 1; i >= 0; i--)
        {
            var cIdx = s[i] - 'a';

            if (node.Children[cIdx] is null) node.Children[cIdx] = new Node2();

            node = node.Children[cIdx]!;

            if (len < node.MinLen)
            {
                node.MinLen = len;
                node.Idx = idx;
            }
        }
    }

    public int FindLongestSuffix(string s)
    {
        Node2 node = _root;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var cIdx = s[i] - 'a';

            if (node.Children[cIdx] is null) break;

            node = node.Children[cIdx]!;
        }

        return node.Idx;
    }
}

public class Solution2
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        var trie2 = new Trie2();
        var queryLength = wordsQuery.Length;
        var stringIndices = new int[queryLength];

        for (var i = 0; i < wordsContainer.Length; i++)
            trie2.Insert(wordsContainer[i], i);

        for (var i = 0; i < queryLength; i++)
        {
            var s = wordsQuery[i];
            stringIndices[i] = trie2.FindLongestSuffix(wordsQuery[i]);
        }

        return stringIndices;
    }
}
