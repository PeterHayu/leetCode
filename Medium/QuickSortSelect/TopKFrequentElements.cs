using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medium.QuickSortSelect
{
    public static class TopKFrequentElements
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            if (nums.Length < 0)
                return nums;
            //use quick select algorithm
            //1, create dictionary of counts
            var dic = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (dic.ContainsKey(n))
                {
                    dic[n]++;
                }
                else
                {
                    dic[n] = 1;
                }
            }

            //2, get all unique keys as an int array to perform partition and quick select
            //var keys = new int[dic.Size()];
            var ordered = dic.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            var result = new int[k];
            int i = 0;
            foreach (var o in ordered.Keys)
            {
                if (i >= k)
                    break;
                result[i] = o;
                i++;
            }

            return result;
        }

        public static int[] TopKFrequent2(int[] nums, int k)
        {
            if (nums.Length < 0)
                return nums;
            //use quick select algorithm
            //1, create dictionary of counts
            var dic = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (dic.ContainsKey(n))
                {
                    dic[n]++;
                }
                else
                {
                    dic[n] = 1;
                }
            }

            //2, get all unique keys as an int array to perform partition and quick select
            var keys = new int[dic.Count];
            int i = 0;
            foreach (var d in dic.Keys)
            {
                keys[i] = d;
                i++;
            }

            //3, perform quick select
            QuickSort(keys, 0, keys.Length - 1, k, dic);

            return keys[(keys.Length - k)..^0];
        }


        private static void QuickSort(int[] nums, int low, int high, int k, Dictionary<int, int> dic)
        {
            if (low < high)
            {
                int pi = Partition(nums, low, high, dic);
                // Recursively sort elements before 
                // partition and after partition 
                if (pi > nums.Length - k)
                    QuickSort(nums, low, pi - 1, k, dic);
                else if (pi < nums.Length - k)
                    QuickSort(nums, pi + 1, high, k, dic);
                else
                    return;
            }
        }

        private static int Partition(int[] nums, int low, int high, Dictionary<int, int> dic)
        {
            //modification: comapre based on dic value
            int pivot = dic[nums[high]];
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (dic[nums[j]] <= pivot)
                {
                    //swap i and j
                    var temp2 = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp2;

                    i++;
                }
            }
            //swap pivot with i
            var temp = nums[i];
            nums[i] = nums[high];
            nums[high] = temp;

            return i;
        }
    }

}
