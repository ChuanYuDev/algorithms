namespace Leetcode.JumpGameIV;

//  Bidirectional BFS
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
//  0 1 2 
//    4 3 9 8
//      5 6
//        7
//
//  Layer   0 1 2
//
//          0 1 2
//            4 3
//
//          9 8
//            3
//
//  0
//  1 4
//  4 2
//
//  9
//  8 3
//
//  length = arr.Length
//  if (length == 1) return 0
//
//  Dictionary<int, List<int>> map
//  for i from 0 to length - 1
//      if (map.Contains(arr[i])) map[arr[i]].Add(i)
//      map[arr[i]]=new List<int>{i}
//  
//  visitedFromStart bool[length]
//  visitedFromEnd bool[length]
//  layer int[length]

//  visitedFromStart[0] = true
//  visitedFromEnd[length-1] = true
//  queueFromStart.Enqueue(0)
//  queueFromEnd.Enqueue(length - 1)
//  layer[0] = 0
//  layer[length - 1] = 0
//
//  while (queueFromStart.Count > 0)
//      compare = queueFromStart.Count > queueFromEnd.Count
//      if (compare)
//          queue = queueFromEnd
//          visited = visitedFromEnd
//          otherVisited = visitedFromStart
//      else
//          queue = queueFromStart
//          visited = visitedFromStart
//          otherVisited = visitedFromEnd
//      
//      nextQueue
//      for each i in queue
//          j = i+1
//
//          if (j < length && !visited[j])  
//              if (otherVisited[j]) return layer[j] + layer[i] + 1
//              visited[j]=true
//              layer[j] = layer[i]+1
//              nextQueue.Enqueue(j)
//          j = i-1
//          if (j >= 0 && !visited[j])     
//              if (otherVisited[j]) return layer[j] + layer[i] + 1
//              visited[j]=true
//              layer[j] = layer[i]+1
//              nextQueue.Enqueue(j)
//  
//          for each j in map[arr[i]]
//              if (!visited[j])
//                  if (otherVisited[j]) return layer[j] + layer[i] + 1
//                  visited[j] = true
//                  layer[j] = layer[i]+1
//                  nextQueue.Enqueue(j)
//
//          map[arr[i]].clear()      

//      if (compare)
//          queueFromEnd = nextQueue
//      else
//          queueFromStart = nextQueue
//
//  return -1
// I0  1  2  3  4  5  6  7  8  9  10
//  6, 1, 2, 3, 4, 1, 2, 3, 4, 7, 11
//
// L0 1 2 3 4
//  0 1 2 3 7 
//      5 6 
//        4 8 9 10
//
//  0 1 2 3
//      5 6
//        4
//
// 10 9 8 7
//        4
public class Solution2
{
    public int MinJumps(int[] arr)
    {
        var length = arr.Length;
        if (length == 1) return 0;
        
        var map = new Dictionary<int, List<int>>();
        
        for (var i = 0; i <= length - 1; i++)
        {
            if (map.ContainsKey(arr[i])) map[arr[i]].Add(i);
            else map[arr[i]] = new List<int> { i };
        }
        
        bool[] visitedFromStart = new bool[length];
        bool[] visitedFromEnd = new bool[length];
        int[] layer = new int[length];
        Queue<int> queueFromStart = new Queue<int>();
        Queue<int> queueFromEnd = new Queue<int>();

        visitedFromStart[0] = true;
        visitedFromEnd[length - 1] = true;
        queueFromStart.Enqueue(0);
        queueFromEnd.Enqueue(length - 1);
        layer[0] = 0;
        layer[length - 1] = 0;

        while (queueFromStart.Count > 0)
        {
            var compare = queueFromStart.Count > queueFromEnd.Count;
            bool[] visited;
            bool[] otherVisited;
            Queue<int> queue;

            if (compare)
            {
                visited = visitedFromEnd;
                otherVisited = visitedFromStart;
                queue = queueFromEnd;
            }
            else
            {
                visited = visitedFromStart;
                otherVisited = visitedFromEnd;
                queue = queueFromStart;
            }

            Queue<int> nextQueue = new Queue<int>();

            foreach (int i in queue)
            {
                var j = i + 1;

                if (j < length && !visited[j])
                {
                    if (otherVisited[j]) return layer[j] + layer[i] + 1;
                    visited[j] = true;
                    layer[j] = layer[i] + 1;
                    nextQueue.Enqueue(j);
                }

                j = i - 1;
                if (j > 0 && !visited[j])
                {
                    if (otherVisited[j]) return layer[j] + layer[i] + 1;
                    visited[j] = true;
                    layer[j] = layer[i] + 1;
                    nextQueue.Enqueue(j);
                }
            
                foreach(var k in map[arr[i]])
                {
                    if (!visited[k])
                    {
                        if (otherVisited[k]) return layer[k] + layer[i] + 1;
                        visited[k] = true;
                        layer[k] = layer[i] + 1;
                        nextQueue.Enqueue(k);
                    }
                }
            
                map[arr[i]].Clear();
            }

            if (compare) queueFromEnd = nextQueue;
            else queueFromStart = nextQueue;
        }

        return -1;
    }
}
