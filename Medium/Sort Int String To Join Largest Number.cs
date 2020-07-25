using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Sort_Int_String_To_Join_Largest_Number
    {
        public string LargestNumber(int[] nums)
        {
            System.Array.Sort(nums, (a, b) => (b + "" + a).CompareTo(a + "" + b));
            return (nums[0] == 0) ? "0" : String.Join("", nums);
        }
    }
}
