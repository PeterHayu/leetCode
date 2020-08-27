using System;
using System.Collections.Generic;

namespace Interview
{
    public class Amazon
    {
        public int CountElememt(int[] NumAray, int el)
        {
            if (NumAray.Length <= 0)
                return 0;
            int count = 0;
            for (int i = 0; i < NumAray.Length; i++)
            {
                if (NumAray[i] == el)
                    count++;
            }
            return count;
        }

        public int[] MoveAllElementToEnd(int[] number)
        {
            if (number == null)
                return null;
            int size = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != 0)
                {
                    number[size] = number[i];
                    size++;
                }
            }

            for (int j = size; j < number.Length; j++)
            {
                number[j] = 0;
            }

            return number;
        }

        public int[] MergeTwoSortedList(int[] longA, int[] shortA)
        {
            int endOfLong = longA.Length - 1;
            int endOfShort = shortA.Length - 1;
            int endOfContent = endOfLong - endOfShort + 1;

            while (endOfShort >= 0 && endOfLong >= 0)
            {
                if (longA[endOfContent] <= shortA[endOfShort])
                {
                    longA[endOfLong] = shortA[endOfShort];
                    endOfShort--;
                }
                else
                {
                    longA[endOfLong] = longA[endOfContent];
                    endOfContent--;
                }
                endOfLong--;
            }
            /*
                        for (int j = 0; j <= endOfShort; j++)
                        {
                            longA[j] = shortA[j];
                        }
                        */
            while (endOfShort >= 0)
            {
                longA[endOfLong--] = shortA[endOfShort--];
            }

            return longA;
        }

        //this is to reverse every k elements
        //for example: [1,2,3,4,5] k =2
        //[2,1] [4,3] [5]
        public int[] ReverseSortedArrayInSizeK(int[] arr, int n, int k)
        {
            for (int i = 0; i < n; i += k)
            {
                int left = i;
                int right = Math.Min(i + k - 1, n - 1);
                int temp;
                //reverse template
                while (left < right)
                {
                    temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    right--;
                    left++;
                }


            }
            return arr;
        }

        public string FrequencyOfChar(string s)
        {
            if (s == "" || s == null)
                return s;

            var dic = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c] += 1;
                else
                    dic[c] = 1;
            }
            var str = "";
            foreach (var p in dic)
            {
                str += p.Key;
                str += p.Value;
                str += " ";
            }
            return str;
        }

        public int[] FirstAndFinalOccuranceInSortedArray(int[] Ary, int target)
        {
            int size = Ary.Length;
            int first = -1;
            int last = -1;
            for (int i = 0; i < size; i++)
            {
                if (Ary[i] != target)
                    continue;
                if (first == -1)
                    first = i;
                last = i;
            }

            return new int[] { first, last };
        }

        public char FirstNonRepeatingChar(string s) {
            var dic = new Dictionary<char, int>();
            foreach (var c in s) {
                if (dic.ContainsKey(c))
                    dic[c] += 1;
                else
                    dic[c] = 1;
            }

            foreach (var e in dic) {
                if (e.Value == 1)
                    return e.Key;
            }
            return ' ';
        }
    }
}
