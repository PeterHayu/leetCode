using System;
namespace Medium.String
{
    public class Reverse_Words_in_a_String
    {
        public string ReverseWords(string s)
        {
            //1, trim extra spaces in begin and end and split the string into word array
            var wordAray = s.Trim().Split(' ');
            var result = "";
            //2, add space to each word except the first
            //add to result in reverse order
            for (int i = wordAray.Length - 1; i > 0; i--)
            {
                result += wordAray[i] == "" ? "" : wordAray[i] + " ";
            }
            //add the first word without space to result
            result += wordAray[0];
            return result;
        }
    }
}
