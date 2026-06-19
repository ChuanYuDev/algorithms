namespace Leetcode.LowestCommonAncestorOfABinaryTree;

public class Solution2
{
    private TreeNode? _anc;
    private int _pVal;
    private int _qVal;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        _anc = null;
        _pVal = p.val;
        _qVal = q.val;

        Dfs(root);
        
        return _anc!;
    }

    private int Dfs(TreeNode? node)
    {
        if (node == null) return 0;
        if (_anc is not null) return 0;
        
        int count = 0;
        if (node.val == _pVal || node.val == _qVal) count++;
        count += Dfs(node.left);
        count += Dfs(node.right);
        if (_anc is null && count == 2) _anc = node;
        return count;
    }
}
