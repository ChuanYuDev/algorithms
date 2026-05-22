namespace Leetcode.FindTheLengthofTheLongestCommonPrefix;

//  Node
//      data
//      level   0       1    2    3   
//              null -> 1 -> 0 -> 0
//                        -> 2
//                   -> 2 -> 4 
//                   -> 3
//      children: List<Node>()
//      Node Add(data, level)
//          
//  Node Add(data, level)
//      node = new Node(data, level)
//      children.Add(node)
//      return node

//  Node GetLongestCommonPrefixNode(int[] nums)
//      commonPrefixNode = startNode

//      foreach(var num in nums)
//          Node? node = null

//          foreach(childNode in commonPrefixNode.children)
//              if childNode.data == num
//                  node = childNode
//                  break;
//          
//          if node is null
//              break;
//
//          commonPrefixNode = node
//      
//      return commonPrefixNode
//          
//  AddRemainingNodes(Node node, int [] nums)
//      for(i = node.level; i < nums.length; i++)
//          node = node.Add(nums[i], i+1)

//  Build tree based on arr1
//      The first node value is null
//      100 -> nums = [1, 0, 0]
//      node = GetLongestCommonPrefixNode(nums)
//      if node.level == nums.Length continue
//      AddRemainingNodes(nums)

//  Search tree using arr2
//      1000 -> nums = [1, 0, 0, 0]
//      node = GetLongestCommonPrefixNode(nums)
//      if (node.level > longestLength) longestLength = node.level

//  Complexity:
//      arr1.length n
//      arr2.length m
//      element with most digits l
//      tree: (n + m)log(l)
//      brute-force: (nm)log(l)

public class Solution
{
    class Node
    {
        public int Data { get; set; }
        public int Level { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();

        public Node Add(int data, int level)
        {
            var node = new Node { Data = data, Level = level };
            Children.Add(node);
            return node;
        }
    }

    private Node _startNode = null!;

    Node GetLongestCommonPrefixNode(int[] nums)
    {
        var commonPrefixNode = _startNode;

        foreach (var num in nums)
        {
            Node? node = null;

            foreach (var childNode in commonPrefixNode.Children)
            {
                if (childNode.Data == num)
                {
                    node = childNode;
                    break;
                }
            }
          
            if (node is null) break;

            commonPrefixNode = node;
        }

        return commonPrefixNode;
    }

    void AddRemainingNodes(Node node, int[] nums)
    {
        for (var i = node.Level; i < nums.Length; i++)
        {
            node = node.Add(nums[i], i + 1);
        }
    }
    
    int[] GetDigits(int value)
    {
        List<int> reverseDigits = new List<int>();

        while (value > 0)
        {
            reverseDigits.Add(value % 10);
            value /= 10;
        }

        reverseDigits.Reverse();

        return reverseDigits.ToArray();
    }

    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        _startNode = new Node { Data = -1, Level = 0 };
        
        int longestLength = 0;
        
        foreach (var num in arr1)
        {
            var digits = GetDigits(num);
            var node = GetLongestCommonPrefixNode(digits);
            
            if (node.Level == digits.Length) continue;
            
            AddRemainingNodes(node, digits);
        }

        foreach (var num in arr2)
        {
            var digits = GetDigits(num);
            var node = GetLongestCommonPrefixNode(digits);

            if (node.Level > longestLength) longestLength = node.Level;
        }

        return longestLength;
    }
}
