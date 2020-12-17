using System;
namespace Medium.Array
{
    public class Shuffle_An_Array
    {
        private Random ran;
        private int l;
        private int[] originalA;

        public Shuffle_An_Array(int[] nums)
        {
            ran = new Random();
            l = nums.Length;
            originalA = (int[])nums.Clone();
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return originalA;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            var ans = new int[l];
            //randomly pick a number from the rest of the array
            //then swap value 
            for (int i = 0; i < originalA.Length; i++)
            {
                int r = ran.Next(i + 1);
                //this step pick a previous value from the array
                //and randomly swap with it
                ans[i] = ans[r];
                ans[r] = originalA[i];
            }
            return ans;
        }
    }




}

