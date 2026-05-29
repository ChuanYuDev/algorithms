namespace Leetcode.JumpGameIV;

//  BFS
//    0  1    2   3   4  5  6  7 8   9     
//  100,-23,-23,404,100,23,23,23,3,404
//
//  arr[i] -> i
//  100: 0 4
//  -23: 1 2
//   23: 5 6 7
//  404: 3 9
//    3: 8
//
//  0 -> 100 -> 0 4
//  
//  0 1 2 
//    4 3 9 8
//      5 6
//        7
//  
//  length = arr.Length
//  visited bool[length]
//  layer int[length]
//
//  Dictionary<int, List<int>> map
//  for i from 0 to length - 1
//      if (map.Contains(arr[i])) map[arr[i]].Add(i)
//      map[arr[i]]=new List<int>{i}
//  
//  visited[0] = true
//  queue.Enqueue(0)
//
//  while (queue.Count > 0)
//      i = queue.Dequeue()
//      j = i+1
//
//      if (j < length && !visited[j])     
//          visited[j]=true
//          layer[j] = layer[i]+1
//          queue.Enqueue(j)
//      j = i-1
//      if (j >= 0 && !visited[j])     
//          visited[j]=true
//          layer[j] = layer[i]+1
//          queue.Enqueue(j)
//  
//      for each j in map[arr[i]]
//          if (!visited[j])
//              visited[j] = true
//              layer[j] = layer[i]+1
//              queue.Enqueue
//      map[arr[i]].clear()      
//
//  return layer[length-1]
//
//  Time complexity
//      O(n)
//  Space complexity
//      O(n)

//  0  1  2  3  4  5  6  7  8  9        
//  7, 7, 2, 1, 7, 7, 7, 3, 4, 1];
//  0 -> 4 -> 3 -> 9
//  Output: 3
//
//  7: 0 1 4 5 6
//  2: 2
//  1: 9
//  3: 7
//  4: 8
//
//  0 1 2
//    4 3 9
//    5 
//    6 7 8

public class Solution
{
    public int MinJumps(int[] arr)
    {
        var length = arr.Length;
        var map = new Dictionary<int, List<int>>();
        
        for (var i = 0; i <= length - 1; i++)
        {
            if (map.ContainsKey(arr[i])) map[arr[i]].Add(i);
            else map[arr[i]] = new List<int> { i };
        }
        
        bool[] visited = new bool[length];
        int[] layer = new int[length];
        Queue<int> queue = new Queue<int>();

        visited[0] = true;
        queue.Enqueue(0);

        while (queue.Count > 0)
        {
            var i = queue.Dequeue();
            var j = i + 1;

            if (j < length && !visited[j])
            {
                visited[j] = true;
                layer[j] = layer[i] + 1;
                queue.Enqueue(j);
            }

            j = i - 1;
            if (j > 0 && !visited[j])
            {
                visited[j] = true;
                layer[j] = layer[i] + 1;
                queue.Enqueue(j);
            }
            
            foreach(var k in map[arr[i]])
            {
                if (!visited[k])
                {
                    visited[k] = true;
                    layer[k] = layer[i] + 1;
                    queue.Enqueue(k);
                }
            }
            
            map[arr[i]].Clear();
        }

        return layer[length - 1];
    }
}
