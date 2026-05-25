namespace Leetcode.JumpGameIII;

//  arr = [4,2,3,0,3,1,2], start = 5
//
//  All elements in visited are false
//  bool[] _visited = new bool[length];
//  bool _found;
//  DFS
//  Dfs(i)
//      _visited[i] = true;
//      if (arr[i] == 0)
//          _found = true;
//          return
//      int[] jumpTo = [i + arr[i], i - arr[i]]
//      foreach (j in jumpTo)
//          if (j <= length - 1 && j >=0 && !_visited[j]) Dfs(j)
//  
//  CanReach
//      Dfs(start)
//      return _found

public class Solution
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

        int[] jumpTo = [i + _arr[i], i - _arr[i]];

        foreach (var j in jumpTo)
        {
            if (j <= _length - 1 && j >= 0 && !_visited[j])
                Dfs(j);
        }
    }
}
