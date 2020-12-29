using System;
using System.Collections.Generic;

namespace Medium.SlidingWindow
{
    public class Longest_Substring_With_At_Least_K_Repeating_Charaters
    {
        public int LongestSubstring(string s, int k)
        {
            Dictionary<char, int> window = new Dictionary<char, int>();
            HashSet<char> count = new HashSet<char>(s);

            int maxUniqueLetterInS = count.Count;

            int left = 0, right = 0;
            //loop thorugh every posibility of unique letter combination
            //for example, if we allow only 1 unique letter, 2 unique letter...up to max unique letter exists in s 
            //what is the max length for each of those situation?
            int result = 0;
            for (int currentUnique = 1; currentUnique <= maxUniqueLetterInS; currentUnique++)
            {
                //refresh the dictionary
                window.Clear();
                left = 0;
                right = 0;
                //keep track of number of unique chars reach the required count k
                int numberOfCharsReachMaxCountK = 0;
                while (right < s.Length)
                {
                    // c 是将移入窗口的字符
                    char c = s[right];
                    // 右移窗口
                    right++;
                    // 进行窗口内数据的一系列更新
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window[c] = 1;
                    if (window[c] == k)
                        numberOfCharsReachMaxCountK++;

                    /*** debug 输出的位置 ***/
                    //Console.WriteLine($"window: [{left},{right})\n", left, right);
                    /********************/

                    // 判断左侧窗口是否要收缩, windowNeedsShrinkCondition just to make template compile
                    //如果current unique 超过了就要缩 window
                    while (window.Count > currentUnique)
                    {
                        // d 是将移出窗口的字符
                        char d = s[left];

                        if (window[d] == k)
                            numberOfCharsReachMaxCountK--;
                        // 左移窗口
                        left++;
                        // 进行窗口内数据的一系列更新
                        window[d]--;
                        if (window[d] == 0)
                            window.Remove(d);
                    }
                    //return result when
                    //1, the current window have the required unique numbers of chars
                    //2, all unique chars in the current window reach required max count K
                    if (window.Count == currentUnique && window.Count == numberOfCharsReachMaxCountK)
                        result = Math.Max(result, right - left);
                }
            }
            return result;
        }
    }
}
