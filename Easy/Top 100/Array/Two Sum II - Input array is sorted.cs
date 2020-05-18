using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Array
{
    class Two_Sum_II___Input_array_is_sorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    return new int[] { left + 1, right + 1 };
                    /* dedup not necessary
                    while(left < right && numbers[left+1] == numbers[left]) left++;
                    while(left < right && numbers[right-1] == numbers[right]) right--;
                        left++;
                        right--;
                        */
                }
                else if (numbers[left] + numbers[right] > target)
                    right--;
                else if (numbers[left] + numbers[right] < target)
                    left++;
            }
            return new int[] { };
        }

    }
}
