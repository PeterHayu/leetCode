using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public static class LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> window = new Dictionary<char, int>();
            //foreach (char c in s) need[c]++;

            int left = 0, right = 0;
            //if empty string this will be return
            int maxUnique = 0;
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

                /*** debug 输出的位置 ***/
                Console.WriteLine($"window: [{left},{right})\n", left, right);
                /********************/

                // 判断左侧窗口是否要收缩, windowNeedsShrinkCondition just to make template compile
                while (window[c] > 1)
                {
                    // d 是将移出窗口的字符
                    var d = s[left];
                    // 左移窗口
                    left++;
                    // 进行窗口内数据的一系列更新
                    window[d]--;

                }
                maxUnique = Math.Max(right - left, maxUnique);
            }

            return maxUnique;
        }
    }
}
