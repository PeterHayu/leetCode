using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Array
{
    class Find_Duplicate_Number_in_Array
    {
        public int FindDuplicate(int[] nums)
        {
            //same logic as Linked_List_Cycle_Return_Loop_Position
            //here a fast and slow pointer
            //fast = nums[nums[fast]], slow = nums[slow]
            if (nums.Length < 1)
                return -1;
            var fast = nums[0];
            var slow = nums[0];
            //slow and fast begin to race
            do
            {
                fast = nums[nums[fast]];
                slow = nums[slow];
            } while (fast != slow);

            var result = nums[0];

            while (result != slow)
            {
                result = nums[result];
                slow = nums[slow];
            }

            return result;
        }
    }
}
