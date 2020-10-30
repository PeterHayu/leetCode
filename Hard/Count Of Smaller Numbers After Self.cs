using System;
using System.Collections.Generic;

namespace Hard
{
    public static class Count_Of_Smaller_Numbers_After_Self
    {
        public class Item
        {
            public int index;
            public int val;

            public Item(int v, int i)
            {
                index = i;
                val = v;
            }

        }
        //major logic: add a step during Merge Sort to calculate the numbers smaller than the current number

        public static IList<int> CountSmaller(int[] nums)
        {
            //1, pre-processing. Create items array to store val-key pair
            int n = nums.Length;
            var items = new Item[n];
            for (int i = 0; i < n; i++)
            {
                items[i] = new Item(nums[i], i);
            }
            //this count stores the number of smaller elements to its right
            //in every recursive iteration
            var count = new int[n];

            MergeSort(0, n - 1, items, count);


            return new List<int>(count);

        }

        private static void MergeSort(int lo, int hi, Item[] items, int[] count)
        {
            if (lo >= hi)
                return;
            int mid = (lo + hi) / 2;  //hi-(hi-lo)/2
            MergeSort(lo, mid, items, count);
            MergeSort(mid + 1, hi, items, count);
            Merge(lo, mid, mid + 1, hi, items, count);
        }

        private static void Merge(int lo, int l1, int hiLo, int l2, Item[] items, int[] count)
        {
            int m = l2 - lo + 1;
            //sorted result stores here
            var sortedItems = new Item[m];
            int lessElementFromRightCounter = 0;
            //merge sort, pointers
            int i1 = lo;
            int i2 = hiLo;
            //merge sort index
            int i = 0;

            while (i1 <= l1 && i2 <= l2)
            {
                //comparing left array to right array
                if (items[i1].val <= items[i2].val)
                {
                
                    //do not increase lessElementFromRightCounter, use this to increase the count of all elements
                    count[items[i1].index] += lessElementFromRightCounter;
                    sortedItems[i++] = items[i1++];
                }
                else
                {
                    
                    lessElementFromRightCounter++;
                    sortedItems[i++] = items[i2++];
                }
            }


            while (i1 <= l1)
            {
                
                count[items[i1].index] += lessElementFromRightCounter;
                sortedItems[i++] = items[i1++];
            }

            while (i2 <= l2)
            {
                
                //lessElementFromRightCounter++;
                sortedItems[i++] = items[i2++];
            }

            //update item to sortedItem in current iteration
           Array.Copy(sortedItems,0,items,lo,m);
        }
    }
}
