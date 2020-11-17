using System;
namespace Medium.DP
{
    public class Increasing_Triplet_Subsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {
            //because its sequence of 3 we just need to keep two variable for smaller value
            //when the third one that greater than both of them we know to return true
            var first = Int32.MaxValue;
            var second = Int32.MaxValue;
            foreach (var n in nums)
            {
                if (n <= first)
                    first = n;
                else if (n <= second)
                    second = n;
                else
                    return true;
            }
            return false;
        }
    }
}
