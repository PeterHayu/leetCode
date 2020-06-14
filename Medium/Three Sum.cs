using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class Three_Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var list = new List<IList<int>>();
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i + 1 == nums.Length - 1)
                    return list;
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                //two sum in sorted array
                int left = i + 1, right = nums.Length - 1, target = -nums[i];
                while (left < right)
                {
                    if (nums[left] + nums[right] == target)
                    {
                        list.Add(new[] { nums[i], nums[left], nums[right] });
                        //skipping duplicate within the while loop
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        //proceed to the next element, to find all possible pairs
                        left++;
                        right--;
                    }
                    else if (nums[left] + nums[right] > target)
                        right--;
                    else if (nums[left] + nums[right] < target)
                        left++;
                }
            }
            return list;

        }
    }
}
