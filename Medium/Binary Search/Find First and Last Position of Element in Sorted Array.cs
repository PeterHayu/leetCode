using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Binary_Search
{
    class Find_First_and_Last_Position_of_Element_in_Sorted_Array { 

    //O(N) solution
     public int[] SearchRange(int[] nums, int target)
    {
        bool isFirst = true;
        int first = -1, last = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                if (isFirst)
                {
                    first = i;
                    isFirst = false;
                }
                last = i;
            }
        }
        return new int[] { first, last };
    }
}
}
