namespace Leetcode.TrappingRainWater;

/* Key idea
Considering the water trapped in each position
    i: current position
    lMax: the max bar on the left of the current position 
    rMax: the max bar on the right of the current position 
    the water trapped in the current position: max(min(lMax, rMax) - height[i], 0)
*/

/* Example
idx:    0 1 2 3 4 5
height: 4 2 0 3 2 5

Initial case: leftmost = 4, rightmost = 5
for idx = 1
    lMax = leftmost = 4, because the left side of 1 is only left most bar
    rMax >= rightmost = 5
    Therefore, the trapped water at 1 is max(4 - 2, 0) = 2

However for idx = 4
    We cannot determine lMax
*/

/* Dry run
idx:    0 1 2 3 4 5 6 7 8 9 0 1
height: 0 1 0 2 1 0 1 3 2 1 2 1
   
lMax    rMax    lIdx    rIdx    water   at idx
0       1       1       10      0       1
1       1       2       10      1       2
1       1       3       10      0       3
2       1       4       10      0       10
2       2       4       9       1       4
2       2       5       9       2       5
2       2       6       9       1       6
2       2       7       9       0       7
3       2       8       9       1       9
3       2       8       8       0       8       
total water = 6
*/

/* Pseudocode
length = height.Length
lMax = height[0]
rMax = height[length-1]

water = 0

i = 1, j = length - 2

while (i <= j)
    if (lMax <= rMax)
        currHeight = height[i]
        water += max(lMax - currHeight, 0)
        lMax = max(lMax, currHeight)
        i++
    else
        currHeight = height[j]
        water += max(rMax - currHeight, 0)
        rMax = max(rMax, currHeight)
        j--

return water
*/

/* Complexity
Time complexity: O(n)
Space complexity: O(1)
*/

public class Solution3
{
    public int Trap(int[] height)
    {
        var length = height.Length;
        var lMax = height[0];
        var rMax = height[length - 1];

        var water = 0;

        int i = 1, j = length - 2;

        while (i <= j)
        {
            if (lMax <= rMax)
            {
                var currHeight = height[i];
                water += Math.Max(lMax - currHeight, 0);
                lMax = Math.Max(lMax, currHeight);
                i++;
            }
            else
            {
                var currHeight = height[j];
                water += Math.Max(rMax - currHeight, 0);
                rMax = Math.Max(rMax, currHeight);
                j--;
            }
        }

        return water;
    }
}