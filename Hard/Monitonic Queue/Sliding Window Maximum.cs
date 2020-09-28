using System;
using System.Collections.Generic;

namespace Hard.MonitonicQueue
{
    public class Sliding_Window_Maximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            //this is question requires the implementation of monitonic queue
            //we can achieve it by base data structure linked list
            //because we can remove element from linkedlist with O(1) complexity with known index

            //the data structure keeps the index of nums
            //when a new element is adding to the data structure
            //0, the ith value is the max index beginning for window size i
            //1, the first element of the queue is the potential result
            //2, all elements with value smaller than the added value will be deleted
            //3, all elements outside of the window of length k will be deleted
            //with every newly added element index i we stores nums[i] to result

            //more explaination on 2:
            //because the window increase monitonically
            //a newly added max will always be deleted later than previous max
            //so once a bigger number added, all previous smaller values will no longer be needed
            //as the new number get deleted the latest and its the max, which take priority

            //time complexity is O(n)
            //space is O(k)

            var n = nums.Length;
            if (n <= 0)
                return new int[0];
            var result = new int[n - k + 1];
            //monitonic queue: store the INDEX of the max value of the current window
            var mq = new LinkedList<int>();

            //iterate through nums
            for (int i = 0; i < n; i++)
            {
                //keep track of which index we should populate into result
                //we can see indexOfResult is k steps less than indexOfNums, i
                var indexOfResult = i - k + 1;

                //3,when window length is reached, remove the first element from queue
                //size of result indicates # of sub-windows nums can potentially be divided 
                //so if indexOfResult, which is the current window beginning position
                //is greated(outside) of the currentMaxIndex, which stored in mq
                //we remove it since its no longer valid, and the max will be the second value in mq
                if (mq.Count > 0 && indexOfResult > mq.First.Value)
                {
                    mq.RemoveFirst();
                }

                //2, before adding the new element, delete all smaller elements
                //from the end index of mq, up to an index where the value is strictly greater
                //note, even if tie in value, newly added value still take priority
                while (mq.Count > 0 && nums[i] >= nums[mq.Last.Value])
                {
                    mq.RemoveLast();
                }

                //now we can safely add the index of new max to the end of mq correctly
                mq.AddLast(i);

                if (indexOfResult >= 0)
                {
                    //1, note that we want to add the max value to result, not the index
                    result[indexOfResult] = nums[mq.First.Value];
                }

            }

            return result;
        }
    }
}
