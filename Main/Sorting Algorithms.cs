using System;
namespace Main
{
    public class Sorting_Algorithms
    {
        public void bubbleSort(int[] arr, int n)
        {
            int i, j;
            bool isSwap = false;
            for (i = 0; i < n - 1; i++)
            { 
                // Last i elements are already in place  
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, arr[j], arr[j + 1]);
                        isSwap = true;
                    }
                }
                if (!isSwap)
                    break;
            }
        }


        void swap(int[] array, int from, int to)
        {
            int temp = array[from]; array[from] = array[to]; array[to] = temp;
        }

    }
}
