using System;
namespace Medium.BinarySearch
{

    //O(nlog(n)) time complexity
    public class Kth_Smallest_Element_in_Sorted_Matrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int l = matrix[0][0];
            int h = matrix[m - 1][n - 1];

            while (l < h)
            {
                int mid = (h - l) / 2 + l;
                //count the number of elements smaller than the number mid
                int count = GetCount(matrix, mid);
                //if we have less element smaller than the expected k
                //that means mid is too small, increase l
                if (count < k)
                    l = mid + 1;
                //usually we return when count = k
                //but its not guaranteed that mid is an actual element within the matrix
                //so we further narrow it down by setting h = mid
                else
                    h = mid;

            }
            //we return when l<h breaks, which is l=h
            //the reason why we guarteed l and h are always within the range of the matrix value
            //is that we repetively check the count of elements in the matrix
            //and use it to determine there is valid number elements smaller than k
            //while using l to increase 1 by 1 to approach an real element in the matrix
            return l;

        }

        //this method get the counts of smaller numbers in the matrix than a giving number
        public int GetCount(int[][] matrix, int mid)
        {
            int count = 0;
            int m = matrix.Length;
            int n = matrix[0].Length;
            int j = n - 1;

            for (int i = 0; i < m; i++)
            {
                //starting from the largest element from the first column
                //keep iterate to the smaller elements 
                while (j >= 0 && matrix[i][j] > mid)
                {
                    j--;
                }
                //accumulate how many elements are smaller than mid in the current column
                count += (j + 1);
            }
            return count;
        }
    }
}
