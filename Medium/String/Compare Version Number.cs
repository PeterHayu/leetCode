using System;
namespace Medium.String
{
    public class Compare_Version_Number
    {
        public int CompareVersion(string version1, string version2)
        {
            var lv1 = version1.Split('.');
            var lv2 = version2.Split('.');
            var length = Math.Max(lv1.Length, lv2.Length);
            for (int i = 0; i < length; i++)
            {
                //need to compare when one array exhausted, because 
                int v1 = i < lv1.Length ? Convert.ToInt32(lv1[i]) : 0;
                int v2 = i < lv2.Length ? Convert.ToInt32(lv2[i]) : 0;
                if (v1 > v2)
                    return 1;
                else if (v1 < v2)
                    return -1;
            }
            return 0;
        }
    }
}
