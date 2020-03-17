using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class ReverseString
    {
        public static string reverseString(String s)
        {
            Stack<char> charsStack = new Stack<char>();
            ArrayList list = new ArrayList();
            StringBuilder builder = new StringBuilder();
            int size;


            foreach (char c  in s.ToCharArray())
            {
                charsStack.Push(c);
            }
            size = charsStack.Count;
            for (int i = 0; i < size; i++)
            {
                list.Add(charsStack.Pop().ToString());
            }
            //System.out.println(list);
            String result = String.Join("", list);
            //System.out.println(result);
            return result;
        }
    }
}
