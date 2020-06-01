using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.DP
{
    public class NumArray
    {
        private int[] sum;
        public NumArray(int[] nums)
        {
            //framework
            sum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                //DP concept
                sum[i + 1] = sum[i] + nums[i];
            }
        }

        public int SumRange(int i, int j)
        {
            return sum[j + 1] - sum[i];
        }

    }
}
