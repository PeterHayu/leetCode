using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Sliding_Window
{
    class Sliding_Window_Template
    {
        void SlidingWindow(string s, string t)
        {
            Dictionary<char, int> need = new Dictionary<char, int>(), window;
            foreach (char c in t) need[c]++;

            int left = 0, right = 0;
            int valid = 0;
            while (right < s.Length)
            {
                // c 是将移入窗口的字符
                char c = s[right];
                // 右移窗口
                right++;
                // 进行窗口内数据的一系列更新
                //...

                /*** debug 输出的位置 ***/
                Console.WriteLine("window: [%d, %d)\n", left, right);
                /********************/

                // 判断左侧窗口是否要收缩, windowNeedsShrinkCondition just to make template compile
                bool windowNeedsShrinkCondition = false;
                while (windowNeedsShrinkCondition)
                {
                    // d 是将移出窗口的字符
                    char d = s[left];
                    // 左移窗口
                    left++;
                    // 进行窗口内数据的一系列更新
                    //...
                }
            }
        }
    }
}
