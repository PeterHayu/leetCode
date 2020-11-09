using System;
namespace Medium
{
    public class Wiggle_Sort
    {
        //logic:
        //sort the array and find the medium, split the array in half
        //create new array by grabbing elements from each half of the ordered array, to create a wiggle effect
        //we can use default sort
        //or quick sort algorithm


        public void WiggleSort(int[] nums)
        {
            int mid = (nums.Length - 1) / 2;
            var numsBeforeSort = new int[nums.Length];
            FindKthSmallest(nums, mid);
            nums.CopyTo(numsBeforeSort, 0);

            /*
            foreach(var test in nums){
              Console.WriteLine(test);        
            }
            */
            //after this step we have nums sorted on the left half till median, and a median
            //now handle the case where multiple median exists
            //we have no better way then rearranging the whole array during partioning
            int i = 0;
            int j = 0;
            int k = numsBeforeSort.Length - 1;



            //smaller numbers insert to all even indices
            i = mid;
            j = 0;
            while (i >= 0)
            {
                nums[j] = numsBeforeSort[i];
                i -= 1;
                j += 2;
            }

            //greater numbers insert to all odd indices
            i = nums.Length - 1;
            j = 1;
            while (i > mid)
            {
                nums[j] = numsBeforeSort[i];
                i -= 1;
                j += 2;
            }
        }

        public int FindKthSmallest(int[] nums, int k)
        {
            QuickSort(nums, 0, nums.Length - 1, k);
            return nums[k];
        }

        private void QuickSort(int[] nums, int low, int high, int k)
        {
            if (low < high)
            {
                int pi = Partition(nums, low, high);
                // Recursively sort elements before 
                // partition and after partition 
                //usually would not change
                //if we want to find kth smallest
                //first condition will be (pi>k)
                if (pi > k)
                    QuickSort(nums, low, pi - 1, k);
                else if (pi < k)
                    QuickSort(nums, pi + 1, high, k);
                else
                    return;
            }
        }


        /* This function takes last element as pivot, places
           the pivot element at its correct position in sorted
            array, and places all smaller (smaller than pivot)
           to left of pivot and all greater elements to right
           of pivot */

        private int Partition(int[] nums, int low, int high)
        {
            //pivot decides the sorting logic
            //might change due to requirement
            int pivot = nums[high];
            int i = low;
            //to achieve three way partitioning, here need to be modify
            //new variable left, right pointer created to manipulate sorting 
            //left is the currently processing pointer
            //i is the final result which 
            int left = low;
            int right = high;

            /*
            logic: this partioning place all smaller to left of pivot, equals to the middle, and larger to the right
            a) arr[l..i] elements less than pivot.
            b) arr[i+1..j-1] elements equal to pivot.
            c) arr[j..r] elements greater than pivot.
            */

            while (left <= right)
            {
                if (nums[left] < pivot)
                {
                    //swap i and j
                    Swap(nums, i, left);
                    i++;
                    left++;
                }
                else if (nums[left] > pivot)
                {
                    Swap(nums, right, left);
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return i;
        }


        public void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
