namespace Leetcode.LowestCommonAncestorOfABinaryTree;

//  DFS
//  [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
//  3
//  5		1
//  6 2		0 8
//    7 4

//  5
//  [1,]
//  [2,]

//  3 5 6 5 2
//  anc
//  Dfs(node)
//      count = 0
//      if (node.val == p.val) count++
//      if (node.left is not null) count+=Dfs(node.left)
//      if (node.right is not null) count+=Dfs(node.right)
//      if (count == 2 && anc is null) anc = node
//      return count

//  Time complexity: O(n)
//  Space complexity:
//      For each call, we use O(1) space
//      There are maximum O(height of tree) calls
//      Total: O(height of tree)

public class Solution
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

    private int Dfs(TreeNode node)
    {
        if (_anc is not null) return 0;
        
        int count = 0;
        if (node.val == _pVal || node.val == _qVal) count++;
        if (node.left is not null) count += Dfs(node.left);
        if (node.right is not null) count += Dfs(node.right);
        if (_anc is null && count == 2) _anc = node;
        return count;
    }
}
