
namespace Easy.Top_100
{
    public static class MajorityElement
    {
        public static int majorityElement(int[] nums)
        {
            System.Array.Sort(nums);
            return nums[(nums.Length) / 2];
        }

        public static int majorityElementBoyerMoore(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }

            return candidate;
        }
    }
}
