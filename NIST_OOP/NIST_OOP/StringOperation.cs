using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIST_OOP
{
    static class StringOperation
    {
        public const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ .,;-'";
        public static string FilterText(string text)
        {
            StringBuilder sbuild = new StringBuilder();
            sbuild.Append(text);
            for (int i = 0; i < sbuild.Length; i++)
            {
                if (sbuild[i] != '\n')
                {
                    if (!alphabet.Contains(sbuild[i]))
                    {
                        sbuild.Remove(i, 1);
                        i -= 1;
                    }
                }
            }
            text = sbuild.ToString();
            return text;
        }
        public static List<int> FormDigitString(String str)
        {
            List<int> digit = new List<int>();
            foreach (char ch in str)
            {
                if (alphabet.IndexOf(ch) != -1)
                    digit.Add(alphabet.IndexOf(ch));
            }
            return digit;
        }
        public static string FormBinaryString(List<int> list)
        {
            StringBuilder str = new StringBuilder();
            foreach (var num in list)
            {
                String reserve = Convert.ToString(num, 2);
                for (int i = 0; i < (5 - reserve.Length); i++)
                {
                    str.Append("0");
                }
                str.Append(reserve);
                //str.Append(" ");
            }
            return str.ToString();
        }
        public static StringBuilder ToStringBuilder(this string str)
        {
            StringBuilder stb = new StringBuilder();
            stb.Append(str);
            return stb;
        }
    }
}
