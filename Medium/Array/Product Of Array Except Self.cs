using System;
namespace Medium.Array
{
    public class Product_Of_Array_Except_Self
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            System.Array.Fill(result, 1);
            int left = 1, right = 1;

            //result[i] represents product of all the elements to the left of element at index i.
            //for i =1,  L[i] = nums[i - 1] * L[i - 1];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] *= left;
                left *= nums[i];
            }

            //now, we multiply the  product of all the elements to the left of element at index i.
            //for i = length-2, R[i+1] = nums[i + 1] * R[i + 1];
            //this process save a loop to multiply them together result[i] = L[i] * R[i]
            for (int j = nums.Length - 1; j >= 0; j--)
            {
                result[j] *= right;
                right *= nums[j];
            }

            return result;
        }

    }
}
