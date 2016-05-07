using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using System.Numerics;

namespace NIST_OOP
{
    public class Function
    {
        private static double[] PCoef = { 0.1174, 0.2430, 0.2493, 0.1752, 0.1027, 0.1124 };
        public  static readonly int R = 49, K = 5;
        //Коефи при формулі для тесту рангів матриць
        private static double[] indices5 = { 0.2888, 0.5776, 0.1336 };
        

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
        //Знайти максимальну послідовність одиниць у кожному блоці


        public static int[] CountMaxSequence(string str, int numOfBlocks)
        {
            int[] arr = new int[numOfBlocks];
            int maxLenght;
            int numInBlock = str.Length / numOfBlocks;
            List<String> lstr = CutOnFrames(str,numInBlock);
            bool isContains;
            for (int i = 0; i < lstr.Count; i++)
            {
                maxLenght = 0;
                isContains = true;
                while (isContains)
                {
                    maxLenght += 1;
                    isContains = lstr[i].Contains(String.Concat(Enumerable.Range(0,maxLenght+1).Select(x=>"1")));
                }
                arr[i] = maxLenght;
            }
            return arr;
        }
        //Знайти нормалізовані максимуми послідовностей одиниць
        public static int[] CountAmountOfMaxSequence(int[] input)
        {
            int[] output = new int[6];
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 5: output[1] += 1; break;
                    case 6: output[2] += 1; break;
                    case 7: output[3] += 1; break;
                    case 8: output[4] += 1; break;
                    default: if (input[i] <= 4)
                            output[0] += 1;
                        if (input[i] >= 9)
                            output[5] += 1;
                        break;
                }
            }
            return output;
        }
        //Знайти параметр для 4-го тесту
        public static double FindXi4(int[] input)
        {
            double output = 0;                                                      
            for (int i = 0; i < K; i++)
            {
                output += (Math.Pow(input[i] - R * PCoef[i], 2) / (R * PCoef[i]));  
            }                                                                       
            return output;
        }


        //нарізати послідовність на матриці
        public static List<double[,]> FormMatrices(String input, int order)
        {
            List<double[,]> list = new List<double[,]>();
            int amount = input.Length / (int)Math.Pow(order, 2);
            int iterator = 0;
            for (int i = 0; i < amount; i++)
            {
                double[,] Matrix = new double[order, order];
                for (int j = 0; j < order; j++)
                {
                    for (int k = 0; k < order; k++)
                    {
                        double.TryParse(input[iterator].ToString(), out Matrix[j, k]);
                        iterator += 1;
                    }
                }
                list.Add(Matrix);
            }
            return list;
        }
        //сформувати масив рангів для усіх матриць
        public static double[] FindRanks(List<double[,]> input)
        {
            double[] output = new double[input.Count];
            int k = 0;
            foreach (double[,] mat in input)
            {
                double[,] m = input[k];
                var matrix = Matrix<double>.Build.Dense(32, 32, (i, j) => m[i, j]);
                output[k] = matrix.Rank();
                k++;
            }
            return output;
        }
        //знайти к-ть рангів певної величини (input -матриця рангів)
        public static int[] CountRanks(double[] input)
        {
            int Max = (int)FindMaxRank(input);
            int[] output = new int[3];
            foreach (int el in input)
                if (el == Max) output[0] += 1;
                else
                    if (el == Max - 1) output[1] += 1;
                    else output[2] += 1;
            return output;

        }
        private static double FindMaxRank(double[] input)
        {
            double Max = double.MinValue;
            foreach (double el in input)
                if (el > Max)
                    Max = el;
            return Max;
        }
        //знайти параметр для 5-го тесту
        public static double CalcXI5(int[] amount, int N)
        {
            return Math.Pow(amount[0] - indices5[0] * N, 2) / indices5[0] / N + Math.Pow(amount[1] - indices5[1] * N, 2) / indices5[1] / N + Math.Pow(amount[2] - indices5[2] * N, 2) / indices5[2] / N;

        }

        //сформувати рядки типу -1;1
        public static List<double> NormalizeArray(String input)
        {
            List<double> output = new List<double>();
            foreach (char ch in input)
            {
                if (ch == '1')
                    output.Add(1);
                else
                    output.Add(-1);
            }
            return output;
        }
        //сформувати масив амплітуд(за FFT - розкладом)
        public static List<double> FindAmplArray(List<double> input)
        {
            List<double> amplArr = new List<double>();
            Complex[] mc = new Complex[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                mc[i] = new Complex(input[i], 0);
            }

            //FFT
            Complex[] mc2 = Butterfly.DecimationInFrequency(mc, true);
            for (int i = 0; i < mc2.Length / 2; i++)
            {
                amplArr.Add(mc2[i].Magnitude);
            }
            return amplArr;
        }
        //порахувати к-ть піків,нижчих за Т
        public static int CountPeaks(double Coef, List<double> input)
        {
            int Amount = 0;
            foreach (double el in input)
            {
                if (el < Coef)
                    Amount += 1;
            }
            return Amount;
        }



        //бітову комбінацію
        public static string FormCombination(string result, int index, int degree)
        {
            string Template = Convert.ToString(index, 2);
            for (int j = 0; j < degree - Template.Length; j++)
            {
                result += "0";
            }
            result += Template;
            return result;
        }
        //порахувати к-ть ненакладних входжень темплейту
        public static int[] CountNonOverlaping(List<String> input, String temp)
        {
            int[] output = new int[input.Count];
            int i = 0;
            foreach (String str in input)
            {
                int index = 0;
                while (index < str.Length - temp.Length)
                {
                    if (temp == str.Substring(index, temp.Length))
                    {
                        output[i] += 1;
                        index += temp.Length;
                    }
                    else
                    {
                        index += 1;
                    }
                }
                i += 1;
            }
            return output;
        }
        public static double CalcXI7(int[] input, double a1, double a2)
        {
            double output = 0;
            foreach (int El in input)
            {
                output += (Math.Pow(El - a1, 2) / a2);
            }
            return output;
        }


        //накладні входження
        public static int[] CountOverlaping(List<String> input, String temp)
        {
            int[] interim = new int[input.Count];
            int[] output = new int[6];
            int i = 0;
            foreach (String str in input)
            {
                int index = 0;
                while (index < str.Length - temp.Length)
                {
                    if (temp == str.Substring(index, temp.Length))
                        interim[i] += 1;
                    index += 1;
                }
                i += 1;
            }
            foreach (int el in interim)
            {
                switch (el)
                {
                    case 0: output[0] += 1; break;
                    case 1: output[1] += 1; break;
                    case 2: output[2] += 1; break;
                    case 3: output[3] += 1; break;
                    case 4: output[4] += 1; break;
                    default: output[5] += 1; break;
                }
            }
            return output;
        }
        public static double CalcXI8(int[] input, int N, double[] input2)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += (Math.Pow(input[i] - N * input2[i], 2) / N / input2[i]);
            }
            return result;
        }
    }
}
