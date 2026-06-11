namespace Leetcode.MaximumTotalSubarrayValueII;

//  Input: nums = [1,3,2], k = 2
//  l r max min value
//  0 0   1   1     0
//  0 1   3   1     2
//  0 2   3   1     2
//  1 1   3   3     0
//  1 2   3   2     1
//  2 2   2   2     0

//  Input: nums = [4,2,5,1], k = 3
//  Output: 12
//  l   r   max     min     value
//  0   0     4       4         0
//  0   1     4       2         2
//  0   2     5       2         3 
//  0   3     5       1         4
//  1   1     2       2         0
//  1   2     5       2         3
//  1   3     5       1         4
//  2   2     5       5         0
//  2   3     5       1         4
//  3   3     1       1         0

//  Find the first element that is greater than max
//  Hint 1: For fixed l, the sequence v(l,r)=max(nums[l..r])−min(nums[l..r]) is non-increasing as r moves left.

//  Hint 2: Build RMQs (sparse tables) for range max/min so each v(l,r) is queryable in O(1).


public class Solution3
{
    
}