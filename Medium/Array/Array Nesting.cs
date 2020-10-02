using System;
namespace Medium.Array
{
    public class Array_Nesting
    {
        public int ArrayNesting(int[] nums)
        {
            var max = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var count = 1;
                //keep looping and staying at i
                //until nums[i] = i
                //for all the visited path we mark its index = value, so that we dont need to visisted again
                //all paths starting from the index i are 'cut short' and value get stored in the first index visited
                while (nums[i] != i)
                {
                    var c = nums[nums[i]]; //store the next value
                    nums[nums[i]] = nums[i];  //set the new value to its index, we dont need to visit from this path anymore
                    nums[i] = c; //store the current path value under the current index to continue visit, until they form a loop
                    count++;
                }

                max = Math.Max(count, max);
            }

            return max;
        }
    }
}
