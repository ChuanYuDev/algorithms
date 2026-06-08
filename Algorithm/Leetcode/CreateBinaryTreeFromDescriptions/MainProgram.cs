namespace Leetcode.CreateBinaryTreeFromDescriptions;
//  Create Binary Tree From Descriptions
//  Medium
//  You are given a 2D integer array descriptions where descriptions[i] = [parenti, childi, isLefti] indicates that parenti is the parent of childi in a binary tree of unique values.
//  Furthermore,
//      If isLefti == 1, then childi is the left child of parenti.
//      If isLefti == 0, then childi is the right child of parenti.
//
//  Construct the binary tree described by descriptions and return its root.
//
//  The test cases will be generated such that the binary tree is valid.
//
//  Example 1:
//  Input: descriptions = [[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]
//  Output: [50,20,80,15,17,19]
//
//  Example 2:
//  Input: descriptions = [[1,2,1],[2,3,0],[3,4,1]]
//  Output: [1,2,null,null,3,4]
//
//  Constraints:
//      1 <= descriptions.length <= 10^4
//      descriptions[i].length == 3
//      1 <= parenti, childi <= 105
//      0 <= isLefti <= 1
//      The binary tree described by descriptions is valid.

//  Input: descriptions = [[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]
//  Dictionary<value, (TreeNode Node, bool HasParent)> map
//  foreach description in descriptions
//      childValue = description[1]
//      if (map.ContainsKey(childValue)
//          childNode = map[childValue].Node
//          map[childValue].HasParent = true
//      else
//          childNode = new TreeNode(childValue)
//          map[childValue] = (childNode, true)
//
//      parentValue = description[0]
//      if (map.ContainsKey(parentValue) parentNode = map[parentValue].Node
//      else
//          parentNode = new TreeNode(parentValue)
//          map[parentValue] = (parentNode, false)
//
//      if (description[2] == 1)
//          parentNode.left = childNode
//      else
//          parentNode.right = childNode
//
//  for (var nodeInfo in map.Values)
//      if (!nodeInfo.HasParent)
//          return nodeInfo.Node
//  // Never executed
//  return null!

//  // Traverse a tree
//  Tree
//
//  void PrintTree(TreeNode root)
//      Queue<TreeNode> queue
//      queue.Enqueue(root)
//      while(queue is not empty)
//          node = queue.Dequeue()
//          print node.val
//
//          if (node.left == null) print null
//          else queue.Enqueue(node.left)
//
//          if (node.right == null) print null
//          else queue.Enqueue(node.right)
//          

//  Time complexity
//      n: descriptions.Length
//      O(n)
//  Space complexity
//      O(n)

//  Definition for a binary tree node.
public class TreeNode
{ 
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
    {
        this.val = val; 
        this.left = left; 
        this.right = right;
    }
}

public class Tree
{
    private readonly TreeNode _root;

    public Tree(TreeNode root)
    {
        _root = root;
    }

    public void PrintTree()
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(_root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            
            if (node is null)
            {
                Console.Write("null ");
                continue;
            }
            Console.Write($"{node.val} ");
            
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
        
        Console.WriteLine();
    }
}

public class Solution 
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var nodeMap = new Dictionary<int, TreeNode>();
        var hasParentMap = new Dictionary<int, bool>();

        foreach (var description in descriptions)
        {
            var childValue = description[1];
            TreeNode parentNode, childNode;

            if (nodeMap.ContainsKey(childValue))
            {
                childNode = nodeMap[childValue];
            }
            else
            {
                childNode = new TreeNode(childValue);
                nodeMap[childValue] = childNode;
            }
            
            hasParentMap[childValue] = true;

            var parentValue = description[0];
            if (nodeMap.ContainsKey(parentValue)) parentNode = nodeMap[parentValue];
            else
            {
                parentNode = new TreeNode(parentValue);
                nodeMap[parentValue] = parentNode;
                hasParentMap[parentValue] = false;
            }

            if (description[2] == 1) parentNode.left = childNode;
            else parentNode.right = childNode;
        }

        foreach (KeyValuePair<int, bool> nodeInfo in hasParentMap)
        {
            if (!nodeInfo.Value) return nodeMap[nodeInfo.Key];
        }

        // Never executed
        return null!;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[][] descriptions = [[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]];
        var root = sol.CreateBinaryTree(descriptions);
        (new Tree(root)).PrintTree();
        //  Output: [50,20,80,15,17,19]

        descriptions = [[1, 2, 1], [2, 3, 0], [3, 4, 1]];
        root = sol.CreateBinaryTree(descriptions);
        (new Tree(root)).PrintTree();
        //  Output: [1,2,null,null,3,4]
    }
}