namespace Leetcode.JumpGameIII;

// Because jumpTo only has two options, so we expand it and speed up the algorithm

public class Solution2
{
    private bool[] _visited = null!;
    private int[] _arr = null!;
    private bool _found;
    private int _length;
    
    public bool CanReach(int[] arr, int start)
    {
        _length = arr.Length;
        _visited = new bool[_length];
        _arr = arr;
        _found = false;
        
        Dfs(start);
        return _found;
    }

    private void Dfs(int i)
    {
        _visited[i] = true;
        if (_arr[i] == 0)
        {
            _found = true;
            return;
        }

        var j1 = i + _arr[i];
        if (j1 <= _length - 1 && !_visited[j1]) Dfs(j1);
        
        var j2 = i - _arr[i]; 
        if (j2 >= 0 && !_visited[j2]) Dfs(j2);
    }
}
