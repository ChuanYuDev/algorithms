namespace Leetcode.LowestCommonAncestorOfABinaryTree;

//  The running time is similar to Solution 2
//  But the solution provided by others is claimed to run much faster??
public class Solution3
{
    private int _pVal;
    private int _qVal;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        _pVal = p.val;
        _qVal = q.val;

        return Dfs(root)!;
    }

    private TreeNode? Dfs(TreeNode? node)
    {
        if (node == null) return null;
        if (node.val == _pVal || node.val == _qVal) return node;
        var left = Dfs(node.left);
        var right = Dfs(node.right);

        if (left is not null && right is not null) return node;
        
        if (left is not null) return left;
        return right;
    }
}