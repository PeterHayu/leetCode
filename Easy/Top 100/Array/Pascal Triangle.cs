using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Array
{
    class Pascal_Triangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();
            var r = new List<int>();
            for (int i = 0; i < numRows; i++)
            {
                //insert one at the beginning and increase row size
                r.Insert(0, 1);
                //update the middle elements by adding the current and the next element
                for (int j = 1; j < r.Count - 1; j++)
                {
                    r[j] = r[j] + r[j + 1];
                }
                //record the result
                result.Add(new List<int>(r));
            }

            return result;
        }

    }
}
