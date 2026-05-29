namespace Leetcode.LongestCommonSuffixQueries;

//  ["abcd","bcd","xbcd"], wordsQuery = ["cd","bcd","xyz"]
//
//  wordsContainer
//  root -> d -> c -> b (1) -> a (0)
//                          -> x (2)
//  Node
//      Node?[] Children = new Node?[26]
//      // Index in wordContainer
//      int? Value 
//
//  Trie
//      root = new Node
//
//  void Insert(string s, value)
//      node = root
//      for i in s.Length
//          idx = s[i] - 'a'
//          if (node.Children[idx] is null) node.Children[idx] = new Node()
//          node = node.Children[idx]
//      node.Value = value
//  
//  Node FindLongestSuffix(string s)
//      node = root
//      for i in s.Length
//          idx = s[i] - 'a'
//          if (node.Children[idx] is null) break;
//          node = node.Children[idx]
//      return node
//
//  int FindStringIndex(Node node)
//      // Smallest length
//      // BFS, no need to maintain a visited array because all the children nodes are not visited
//      queue.Enqueue(node)
//      while(queue.Count > 0)
//          // Pop all the nodes in queue to maintain the nodes in queue all belong to the same layer
//          nextLayerQueue = new Queue<Node>()
//          indices = []
//          while(queue.Count > 0)
//              node = queue.Dequeue()
//              if (node.Value is not null) indices.Add(node.Value)
//              for each child in node.Children
//                  if (child is not null) nextLayerQueue.Enqueue(child)
//          // Find Node with Value in next layer, return the smallest value
//          if (indices.Count > 0) return Min(indices)
//          // If no nodes has Value, we search next layer, until we find node with Value 
//          queue = nextLayerQueue
//      // Cannot execute this line
//      return -1
//
//  Solution
//  int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
//      trie = new Trie()
//      stringIndices = []
//      for each s in wordsContainer
//          trie.Insert(s) 
//      // Save wordsQuery[i] result, and check it first
//      Dictionary<string, int> stringIndicesMap
//      for var i in wordsQuery
//          var s = wordsQuery[i]
//          if (stringIndicesMap.ContainsKey(s))
//              stringIndices[i] = stringIndicesMap[s]
//              continue
//          node = trie.FindLongestSuffix(s) 
//          stringIndex = trie.FindStringIndex(node)
//          stringIndices[i] = stringIndex
//          stringIndicesMap[s] = stringIndex      
//      return stringIndices
//
//  Time complexity
//      Digits d
//      Container m
//      Query n
//      O((m+n)d)
//  Space complexity
//      O(md)

public class Node
{
    public Node?[] Children { get; set; } = new Node?[26];
    public int? Value { get; set; }
}

public class Trie
{
    private readonly Node _root = new Node();

    public void Insert(string s, int value)
    {
        Node node = _root;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var idx = s[i] - 'a';

            if (node.Children[idx] is null) node.Children[idx] = new Node();

            node = node.Children[idx]!;
        }

        if (node.Value is null) node.Value = value;
    }

    public Node FindLongestSuffix(string s)
    {
        Node node = _root;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var idx = s[i] - 'a';

            if (node.Children[idx] is null) break;

            node = node.Children[idx]!;
        }

        return node;
    }

    public int FindStringIndex(Node startNode)
    {
        var queue = new Queue<Node>();
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var nextLayer = new Queue<Node>();
            var indices = new List<int>();

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (node.Value is not null) indices.Add(node.Value.Value);

                foreach (var child in node.Children)
                {
                    if (child is not null) nextLayer.Enqueue(child);
                }
            }

            if (indices.Count > 0) return indices.Min();

            queue = nextLayer;
        }

        return -1;
    }
}

public class Solution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        var trie = new Trie();
        var queryLength = wordsQuery.Length;
        var stringIndices = new int[queryLength];

        for (var i = 0; i < wordsContainer.Length; i++)
            trie.Insert(wordsContainer[i], i);

        Dictionary<string, int> stringIndicesMap = new Dictionary<string, int>();

        for (var i = 0; i < queryLength; i++)
        {
            var s = wordsQuery[i];

            if (stringIndicesMap.ContainsKey(s))
            {
                stringIndices[i] = stringIndicesMap[s];
                continue;
            }
            var node = trie.FindLongestSuffix(wordsQuery[i]);
            var stringIndex = trie.FindStringIndex(node);
            stringIndices[i] = stringIndex;
            stringIndicesMap[s] = stringIndex;
        }

        return stringIndices;
    }
}
