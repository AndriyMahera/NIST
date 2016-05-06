using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIST_OOP
{
    public class Function
    {
        public static int CountNotZero(StringBuilder sbl)
        {
            int count = 0;
            foreach (var s in sbl.ToString())
            {
                if (s == '1')
                    count += 1;
                else
                    count -= 1;
            }
            return count;
        }
        public static List<String> CutOnFrames(String input, int M)
        {
            List<String> list = new List<string>();
            int index = 0;
            int lenght = input.Length / M;
            for (int i = 0; i < lenght; i++)
            {
                list.Add(input.Substring(index, M));
                index += M;
            }
            return list;
        }
        public static int[] CountAmountInBlock(String str, int N)
        {
            List<String> list = CutOnFrames(str,str.Length/N);
            int[] arr=new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = list[i].Replace("0","").Length;
            }
            return arr;
        }
        public static double FindXi2(int[] input, int length, int NumOfBlock)
        {
            double SUM = 0;
            int NumInBlock = length / NumOfBlock;
            for (int i = 0; i < NumOfBlock; i++)
            {
                double a1 = (input[i] / (double)NumInBlock - 0.5);
                double a2 = (Math.Pow(a1, 2));
                SUM += a2;
            }
            SUM *= (4 * NumInBlock);
            return SUM;
        }
    }
}
