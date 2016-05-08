using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NIST_OOP
{
    class Tests
    {
        abstract public class Test
        {
            protected string str;
            protected double PValue;
            public double PVALUE
            {
                get { return this.PValue; }
            }
            public Test(string s)
            {
                this.str = s;
            }
            abstract public void PerformTest();
        }

        public class Test1 : Test
        {
            private double Sobs;
            private int count;

            public Test1(string s) : base(s) { }
            public override void PerformTest()
            {
                this.count = Function.CountNotZero(this.str);
                this.Sobs = Math.Abs(this.count) / Math.Sqrt(this.str.Length);
                this.PValue = SpecialFunction.erfc(this.Sobs / Math.Sqrt(2));
            }
        }
        public class Test2 : Test
        {
            private double Xi;
            private int[] arr;
            private const int N = 20;

            public Test2(string s) : base(s) { }

            public override void PerformTest()
            {
                this.arr = Function.CountAmountInBlock(this.str, N);
                this.Xi = Function.FindXi2(arr, str.Length, N);
                PValue = SpecialFunction.igamc(5, this.Xi / 2);
            }
        }
        public class Test3 : Test
        {
            private double Xi, p;
            private int countOfChange;

            public Test3(string s) : base(s) { }

            public override void PerformTest()
            {
                if (Function.CheckCondition(this.str, ref this.p))
                {
                    this.countOfChange = Function.CountChange(this.str);
                    this.Xi = Function.FindArgumentForTest3(this.countOfChange, this.str.Length, this.p);
                    this.PValue = SpecialFunction.erfc(this.Xi);
                }
            }
        }
        public class Test4 : Test
        {
            private double Xi;
            private int[] arrOfMaxSeq, arrOfNormalSeq;

            public Test4(string s) : base(s) { }

            public override void PerformTest()
            {
                try
                {
                    this.arrOfMaxSeq = Function.CountMaxSequence(this.str.Substring(0, 6272), Function.R);
                    this.arrOfNormalSeq = Function.CountAmountOfMaxSequence(this.arrOfMaxSeq);
                    this.Xi = Function.FindXi4(this.arrOfNormalSeq);
                    this.PValue = SpecialFunction.igamc((double)Function.K / 2, this.Xi / 2);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }
        public class Test5 : Test
        {
            private const int AMOUNT = 32;
            private List<double[,]> listOfMatrices;
            private double[] ranks;
            private int[] countR;
            private double Xi;

            public Test5(string s) : base(s) { }

            public override void PerformTest()
            {
                this.listOfMatrices = Function.FormMatrices(this.str, AMOUNT);
                this.ranks = Function.FindRanks(this.listOfMatrices);
                this.countR = Function.CountRanks(this.ranks);
                this.Xi = Function.CalcXI5(this.countR, this.ranks.Length);
                this.PValue = SpecialFunction.igamc(1, this.Xi / 2.0);
            }
        }
        public class Test6 : Test
        {
            private double T, N1, N0, d;
            private List<double> normalArr, amplArr;

            public Test6(string s) : base(s) { }

            public override void PerformTest()
            {
                this.normalArr = Function.NormalizeArray(this.str);
                this.amplArr = Function.FindAmplArray(this.normalArr);
                this.T = Math.Sqrt(Math.Log(20) * this.normalArr.Count);
                this.N0 = 0.95 * this.normalArr.Count / 2;
                this.N1 = Function.CountPeaks(this.T, this.amplArr);
                this.d = (this.N1 - this.N0) / Math.Sqrt(this.normalArr.Count * 0.95 * 0.05 / 4);
                this.PValue = SpecialFunction.erfc(Math.Abs(this.d) / Math.Sqrt(2));
            }
        }
        public class Test7 : Test
        {
            private string res;
            private int[] amountArr;
            private double u, o, xi, p, result = 0;
            private const int NUM_IN_FRAMES = 100;
            private const int TEMPLATE_LENGTH = 6;
            private List<string> frames;

            public Test7(string s) : base(s) { }

            public override void PerformTest()
            {
                this.frames = Function.CutOnFrames(this.str, NUM_IN_FRAMES);
                //64 -к-ть шаблонів для 2^6
                for (int i = 0; i < (int)Math.Pow(2, TEMPLATE_LENGTH); i++)
                {
                    this.res = "";
                    this.res = Function.FormCombination(this.res, i, TEMPLATE_LENGTH);
                    //масив к-ті входжень
                    this.amountArr = Function.CountNonOverlaping(this.frames, this.res);
                    //100 в блоці
                    this.u = (NUM_IN_FRAMES - this.res.Length + 1) / Math.Pow(2, this.res.Length);
                    this.o = NUM_IN_FRAMES * ((1 / Math.Pow(2, this.res.Length)) - (2 * this.res.Length - 1) / Math.Pow(2, 2 * this.res.Length));
                    this.xi = Function.CalcXI7(this.amountArr, this.u, this.o);
                    this.p = SpecialFunction.igamc(this.frames.Count / 2.0, this.xi / 2.0);
                    this.result += this.p;
                }
                this.PValue = result / Math.Pow(2, TEMPLATE_LENGTH);
            }
        }
        public class Test8 : Test
        {
            private double result = 0, y, n, Xi, p;
            private string res;
            private int[] amountArr;
            private List<string> frames;
            private const int NUM_IN_FRAMES = 100;
            private const int TEMPLATE_LENGTH = 6;
            //Константи для тесту 8
            private static double[] PI = { 0.364091, 0.185659, 0.139381, 0.100571, 0.070432, 0.139865 };

            public Test8(string s) : base(s) { }

            public override void PerformTest()
            {
                this.frames = Function.CutOnFrames(this.str, NUM_IN_FRAMES);
                //64 -к-ть шаблонів для 2^6
                for (int i = 0; i < (int)Math.Pow(2, TEMPLATE_LENGTH); i++)
                {
                    this.res = "";
                    this.res = Function.FormCombination(this.res, i, TEMPLATE_LENGTH);
                    //масив к-ті входжень
                    this.amountArr = Function.CountOverlaping(this.frames, this.res);
                    //100 в блоці
                    this.y = (NUM_IN_FRAMES - this.res.Length + 1) / Math.Pow(2, this.res.Length);
                    this.n = this.y / 2;
                    this.Xi = Function.CalcXI8(this.amountArr, frames.Count, PI);
                    this.p = SpecialFunction.igamc(2.5, this.Xi / 2.0);
                    this.result += this.p;
                }
                this.PValue = result / Math.Pow(2, TEMPLATE_LENGTH);
            }
        }
        public class Test9 : Test
        {
            private int Q;
            private double sum, f, c, u;
            private List<string> frames, frame_test = new List<string>();
            private Dictionary<string, int> mayerDict;
            private const int TEMPLATE_LENGTH = 6;
            private const int NUM_IN_FRAMES = 6;
            //для 9 тесту константи
            private const double EXPECTED_VALUE = 5.2177052, VARIANCE = 2.954;

            public Test9(string s) : base(s) { }

            public override void PerformTest()
            {
                this.Q = 10 * (int)Math.Pow(2, TEMPLATE_LENGTH);
                this.frames = Function.CutOnFrames(this.str, NUM_IN_FRAMES);
                //розбивка на тестові та ініціалізаційні
                for (int i = 0; i < Q; i++)
                {
                    this.frame_test.Add(this.frames[i]);
                }
                this.frames.RemoveRange(0, this.Q);
                this.mayerDict = Function.UniquesDictForMayer(TEMPLATE_LENGTH, this.frames, this.frame_test);
                this.sum = Function.FindLogSum(this.frames, mayerDict, Q);
                this.f = sum / (double)this.frames.Count;
                this.c = 0.7 - 0.8 / 6.0 + (4 + 32.0 / 6.0) * Math.Pow(this.frames.Count, -3.0 / 6.0) / 15.0;
                this.u = c * Math.Sqrt(VARIANCE / (double)this.frames.Count);
                this.PValue = SpecialFunction.erfc(Math.Abs((this.f - EXPECTED_VALUE) / this.u / Math.Sqrt(2)));
            }

        }
        public class Test10 : Test
        {
            private string sequence1, sequence2, sequence3;
            private const int M = 6;
            private double PValue1, PValue2, w1, w2, w3;
            private List<int> list1, list2, list3;

            public Test10(string s) : base(s) { }

            public override void PerformTest()
            {
                this.sequence1 = this.str; this.sequence2 = this.str; this.sequence3 = this.str;
                //додаємо хвости 
                Function.AddTail(ref this.sequence1, M);
                Function.AddTail(ref this.sequence2, M - 1);
                Function.AddTail(ref this.sequence3, M - 2);
                //лісти квадратних кількостей входжень
                this.list1 = Function.FormOverlapList(this.sequence1, M);
                this.list2 = Function.FormOverlapList(this.sequence2, M - 1);
                this.list3 = Function.FormOverlapList(this.sequence3, M - 2);
                this.w1 = Math.Pow(2, M) / this.sequence1.Length * this.list1.Sum() - this.sequence1.Length;
                this.w2 = Math.Pow(2, M - 1) / this.sequence2.Length * this.list2.Sum() - this.sequence2.Length;
                this.w3 = Math.Pow(2, M - 2) / this.sequence3.Length * this.list3.Sum() - this.sequence3.Length;

                this.PValue1 = SpecialFunction.igamc(Math.Pow(2, M - 2), (this.w1 - this.w2) / 2.0);
                this.PValue2 = SpecialFunction.igamc(Math.Pow(2, M - 3), (this.w1 - 2 * this.w2 + this.w3) / 2.0);
                this.PValue = Math.Min(this.PValue1, this.PValue2);
            }
        }
        public class Test11 : Test
        {
            private string sequence1, sequence2;
            private const int M = 6;
            private List<double> list1, list2;
            private double f1, f2, Xi;

            public Test11(string s) : base(s) { }

            public override void PerformTest()
            {
                this.sequence1 = this.str; this.sequence2 = this.str;
                Function.AddTail(ref this.sequence1, M);
                Function.AddTail(ref this.sequence2, M + 1);
                this.list1 = Function.FormOverlapListFreq(this.sequence1, M);
                this.list2 = Function.FormOverlapListFreq(this.sequence2, M + 1);
                this.f1 = Function.CalculateF(this.list1);
                this.f2 = Function.CalculateF(this.list2);
                var gg = this.f1 - this.f2;
                this.Xi = 2 * this.str.Length * (Math.Log(2, Math.E) - (this.f1 - this.f2));
                this.PValue = SpecialFunction.igamc(Math.Pow(2, M - 1), this.Xi / 2.0);
            }
        }
        public class Test12 : Test
        {
            private List<double> normalArr;
            private double maxSum, maxSum2, endK, endK2, Pvalue1, Pvalue2;

            public Test12(string s) : base(s) { }

            public override void PerformTest()
            {
                try
                {
                this.normalArr=Function.NormalizeArray(str.Substring(0, 1000));
                this.maxSum = Function.FindMaxSum(this.normalArr, 0, null);
                this.maxSum2 = Function.FindMaxSum(this.normalArr, 1, null);
                this.endK = (this.normalArr.Count / this.maxSum - 1) * 4;
                this.endK2 = (this.normalArr.Count / this.maxSum2 - 1) * 4;
                this.Pvalue1 = 1 - Function.FINDSum(this.maxSum, this.endK, this.normalArr) + Function.FINDSum2(this.maxSum, this.endK, this.normalArr);
                this.Pvalue2 = 1 - Function.FINDSum(this.maxSum2, this.endK2, this.normalArr) + Function.FINDSum2(this.maxSum2, this.endK2, this.normalArr);
                this.PValue = Math.Min(this.Pvalue1, this.Pvalue2);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
             }
        }
        public class Test13 : Test
        {
            private List<double> normalArr,listSum=new List<double>();
            private List<double[]> listCycles=new List<double[]>();
            private double[,] cycle_state,amount_state;
            private double[] xiMatrix, pvalueMatrix;
            private const int J_STANDARD=500;
            private double[,] P_Matrix = { {0.5,0.25,0.125,0.0625,0.0312,0.0312},{0.75,0.0625,0.0469,0.352,0.264,0.0791},
                                     {0.8333,0.0278,0.0231,0.0193,0.0161,0.0804},{0.875,0.0156,0.0137,0.012,0.0105,0.0733}};


            public Test13(string s) : base(s) { }

            public override void PerformTest()
            {

                this.normalArr=Function.NormalizeArray(this.str);
                this.listSum.Add(0);
                Function.FindMaxSum(this.normalArr, 0, this.listSum);
                this.listSum.Add(0);
                Function.DivideIntoCycles(this.listSum, this.listCycles);
                int J = this.listCycles.Count;
                if (J < J_STANDARD)
                {
                    this.cycle_state = new double[8, J];
                    Function.FillMatrixApp(ref this.cycle_state, this.listCycles, 4);
                    this.amount_state = new double[8, 6];
                    Function.FillMatrixAmount(this.cycle_state, ref this.amount_state);
                    this.xiMatrix = Function.FormXiMatrix(this.amount_state, P_Matrix, J);
                    this.pvalueMatrix = Function.FormPValueMatrix(this.xiMatrix);
                }
                else
                    this.PValue = 0;
                this.PValue = this.pvalueMatrix.Average();
            }
        }
        public class Test14 : Test
        {
            private List<double> normalArr, listSum = new List<double>();
            private List<double[]> listCycles = new List<double[]>();
            private const int J_STANDARD = 500;
            private double[,] matrix_count;
            private double[] matrix_C,pValueMatrix;


            public Test14(string s) : base(s) { }

            public override void PerformTest()
            {
                this.normalArr = Function.NormalizeArray(this.str);
                this.listSum.Add(0);
                Function.FindMaxSum(this.normalArr, 0, this.listSum);
                this.listSum.Add(0);
                Function.DivideIntoCycles(this.listSum, this.listCycles);
                int J = this.listCycles.Count;
                if (J < J_STANDARD)
                {
                    this.matrix_count = new double[18, J];
                    Function.FillMatrixApp(ref this.matrix_count, this.listCycles, 9);
                    this.matrix_C = new double[18];
                    Function.FindRowSum(ref this.matrix_C, this.matrix_count);
                    this.pValueMatrix = new double[18];
                    for (int i = 0; i < this.pValueMatrix.Length; i++)
                    {
                        this.pValueMatrix[i] = SpecialFunction.erfc(Function.ArgumentToTest14(i, this.matrix_C, 9, J));
                    }
                    this.PValue = this.pValueMatrix.Average();
                }
                else
                    this.PValue = 0;
            }
        }
    }
}
