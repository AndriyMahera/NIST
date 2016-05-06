using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIST_OOP
{
    public class Function
    {
        //Порахувати баланс одиниць/нулів
        public static int CountNotZero(string sbl)
        {
            int count = 0;
            foreach (var s in sbl)
            {
                if (s == '1')
                    count += 1;
                else
                    count -= 1;
            }
            return count;
        }
        //Нарізати на блоки
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
        //Порахувати к-ть одиниць в кожному блоці
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
        //Знайти аргумент для 2-го тесту
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
        //Перевірка умови для 3-го тесту
        public static  bool CheckCondition(String str, ref double P)
        {
            int amount1 = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '1')
                    amount1 += 1;
            }
            P = (double)amount1 / (double)str.Length;
            bool AllRight = false;
            AllRight = (Math.Abs(P - 0.5) < 2 / Math.Sqrt(str.Length));
            return AllRight;
        }
        //Кількість знакозмін
        public static int CountChange(String str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
                    count += 1;
            }
            return count + 1;
        }
        //аргумент для 3-го тесту (V  - к-ть знакозмін ,len - довжина строки ,pi  -частка одиниць в загальній масі )
        public static double FindArgumentForTest3(int V, int len, double pi)
        {
            double arg = 0;
            double ar1 = Math.Abs(V - 2 * len * pi * (1 - pi));
            double ar2 = 2 * Math.Sqrt(2 * len) * pi * (1 - pi);
            arg = ar1 / ar2;
            return arg;
        }

    }
}
