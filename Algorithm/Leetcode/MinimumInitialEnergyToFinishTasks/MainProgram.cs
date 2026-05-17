namespace Leetcode.MinimumInitialEnergyToFinishTasks;

//  Minimum Initial Energy to Finish Tasks
//  Hard
//  You are given an array tasks where tasks[i] = [actuali, minimumi]:
//      actuali is the actual amount of energy you spend to finish the ith task.
//      minimumi is the minimum amount of energy you require to begin the ith task.
//      For example, if the task is [10, 12] and your current energy is 11, you cannot start this task. However, if your current energy is 13, you can complete this task, and your energy will be 3 after finishing it.
//
//  Constraints:
//      1 <= tasks.length <= 10^5
//      1 <= actuali <= minimumi <= 10^4

//  You can finish the tasks in any order you like.
//  Return the minimum initial amount of energy you will need to finish all the tasks.

//  Example 1
//  Input: tasks = [[1,2],[2,4],[4,8]]
//  Output: 8
//
//  8
//  [4,8]
//  [2,4] 
//  [1,2] -> 2

//  Example 2
//  Input: tasks = [[1,3],[2,4],[10,11],[10,12],[8,9]]
//  Output: 32
//
//  [10,12] -> 22
//  [10,11] -> 12
//  [8,9] -> 4
//  [2,4] -> 2
//  [1,3] -> X
// 
//  [1,3] -> 31
//  [2,4] -> 29
//  [8,9] -> 21
//  [10,11] -> 11
//  [10,12] -> X
//
//  [1,3] -> 31
//  [2,4] -> 29
//  [10,11] -> 19
//  [10,12] -> 9
//  [8,9] -> 1
//
//  3 + 2 + 10 + 9 + 8 = 32
//  [1,3]
//  [2,4]
//  [10,12]
//  [10,11]
//  [8,9]

//  Example 3
//  Input: tasks = [[1,7],[2,8],[3,9],[4,10],[5,11],[6,12]]
//  Output: 27
//
//  [6,12] -> 21
//  [5,11] -> 16
//  [4,10] -> 12
//  [3,9] -> 9
//  [2,8] -> 7
//  [1,7] -> 6
//
//  [1,7] -> 26
//  [2,8] -> 24
//  [3,9] -> 21
//  [4,10] -> 17
//  [5,11] -> 12
//  [6,12] -> 6
//
//  12 + 5 + 4 + 3 + 2 + 1 = 27
//  [6,12]
//  [5,11]
//  [4,10]
//  [3,9]
//  [2,8]
//  [1,7]

//  Minimum initial energy >= Total actuali

//  Total actuali <= Max minimumi -> j
//  Do task j

//  Total actuali > Max minimumi -> j
//  Do task with least actuali


public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        Array.Sort(tasks, (array1, array2) => 
            -(array1[1] - array1[0]).CompareTo(array2[1] - array2[0])
        );

        int minimumEffort = tasks[0][1];
        int energy = minimumEffort;

        foreach (var task in tasks)
        {
            if (energy < task[1])
            {
                minimumEffort += task[1] - energy;
                energy = task[1];
            }

            energy -= task[0];
        }

        return minimumEffort;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();

        int[][] tasks = [[1, 2], [2, 4], [4, 8]];
        Console.WriteLine(sol.MinimumEffort(tasks));
        //  Output: 8
        
        tasks = [[1, 3], [2, 4], [10, 11], [10, 12], [8, 9]];
        Console.WriteLine(sol.MinimumEffort(tasks));
        //  Output: 32

        tasks = [[1, 7], [2, 8], [3, 9], [4, 10], [5, 11], [6, 12]];
        Console.WriteLine(sol.MinimumEffort(tasks));
        //  Output: 27

    }
}