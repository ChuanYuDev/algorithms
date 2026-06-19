namespace Leetcode.LowestCommonAncestorOfABinaryTree;

//  Lowest Common Ancestor of a Binary Tree
//  Medium
//  Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
//
//  According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”
//
//  Example 1:
//  Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
//  Output: 3
//
//  Example 2:
//  Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
//  Output: 5
//
//  Example 3:
//  Input: root = [1,2], p = 1, q = 2
//  Output: 1
//
//  Constraints:
//      The number of nodes in the tree is in the range [2, 10^5].
//      -10^9 <= Node.val <= 10^9
//      All Node.val are unique.
//      p != q
//      p and q will exist in the tree.
    
// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int x) { val = x; }
}

public static class BinaryTreeHelper
{
    public static (TreeNode, TreeNode, TreeNode) ConstructBinaryTree(int?[] nums, int p, int q)
    {
        var numIdx = 0;
        
        var rootVal = nums[0];
        if (rootVal is null) throw new ArgumentException("First element of nums is not null");
        var root = new TreeNode(rootVal.Value);
        
        TreeNode pNode = null!, qNode = null!;
        if (rootVal.Value == p) pNode = root;
        else if (rootVal.Value == q) qNode = root;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        var length = nums.Length;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            for (var i = 0; i <= 1; i++)
            {
                if (++numIdx >= length) break;
                var childVal = nums[numIdx];
                if (childVal is not null)
                {
                    
                    var child = new TreeNode(childVal.Value);
                    if (childVal.Value == p) pNode = child;
                    else if (childVal.Value == q) qNode = child;

                    if (i == 0) node.left = child;
                    else node.right = child;
                    queue.Enqueue(child);
                } 
            }
        }

        return (root, pNode, qNode);
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();
        int?[] nums = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4];
        int p = 5, q = 1;
        var (root, pNode, qNode) = BinaryTreeHelper.ConstructBinaryTree(nums, p, q);
        Console.WriteLine(sol.LowestCommonAncestor(root, pNode, qNode).val);
        //  Output: 3

        nums = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4];
        p = 5;
        q = 4;
        (root, pNode, qNode) = BinaryTreeHelper.ConstructBinaryTree(nums, p, q);
        Console.WriteLine(sol.LowestCommonAncestor(root, pNode, qNode).val);
        //  Output: 5

        nums = [1, 2];
        p = 1;
        q = 2;
        (root, pNode, qNode) = BinaryTreeHelper.ConstructBinaryTree(nums, p, q);
        Console.WriteLine(sol.LowestCommonAncestor(root, pNode, qNode).val);
        //  Output: 1
    }
}