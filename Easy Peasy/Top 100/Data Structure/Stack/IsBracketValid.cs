using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class IsBracketValid
    {
        public static bool isBracketValid(string s) {
            if (s == null)
                return false;
            var al = s.ToCharArray();
            if (al.Length % 2 != 0)
                return false;

            var st = new Stack<char>();
            foreach (var c in al)
            {
                if (c == '(')
                    st.Push(')');
                else if (c == '{')
                    st.Push('}');
                else if (c == '[')
                    st.Push(']');
                else if (st.Count == 0 || st.Pop() != c )
                    return false;
            }
            return st.Count ==0;
        }
    }
}
