using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medium
{
    class SeachSuggestedProduct
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var result = new List<IList<string>>();
            if (products.Length < 1)
                return result;
            System.Array.Sort(products);
            for (int i = 1; i <= searchWord.Length; i++)
            {
                var str = searchWord.Substring(0, i);
                var match = products.Where(x => x.StartsWith(str)).Take(3).ToList();
                if (match.Any())
                {
                    result.Add(new List<string>(match));
                }
                else
                {
                    result.Add(new List<string>());
                }
            }

            return result;
        }
    }
}
