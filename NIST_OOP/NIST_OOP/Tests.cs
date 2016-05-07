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
                this.str=s;
            }
            abstract public void PerformTest();
        }

        public class Test1 : Test
        {
            private double Sobs;
            private int count;

            public Test1(string s):base(s){}
            public override void PerformTest()
            {
                this.count = Function.CountNotZero(this.str);
                this.Sobs = Math.Abs(this.count) / Math.Sqrt(this.str.Length);
                this.PValue = SpecialFunction.erfc(this.Sobs / Math.Sqrt(2));
            }
        }
        public class Test2 : Test
        {
            private double  Xi;
            private int[] arr;
            private const int N = 20;

            public Test2(string s) : base(s) { }

            public override void PerformTest()
            {
                this.arr = Function.CountAmountInBlock(this.str,N);
                this.Xi = Function.FindXi2(arr,str.Length,N);
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
                    this.Xi = Function.FindArgumentForTest3(this.countOfChange,this.str.Length,this.p);
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
                    this.arrOfMaxSeq = Function.CountMaxSequence(this.str.Substring(0,6272),Function.R);
                    this.arrOfNormalSeq=Function.CountAmountOfMaxSequence(this.arrOfMaxSeq);
                    this.Xi=Function.FindXi4(this.arrOfNormalSeq);
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
                this.listOfMatrices = Function.FormMatrices(this.str,AMOUNT);
                this.ranks = Function.FindRanks(this.listOfMatrices);
                this.countR = Function.CountRanks(this.ranks);
                this.Xi = Function.CalcXI5(this.countR,this.ranks.Length);
                this.PValue = SpecialFunction.igamc(1, this.Xi / 2.0);  
            }
        }
        public class Test6 : Test
        {
            private double T, N1, N0, d;
            private List<double> normalArr,amplArr;

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
            private double u, o, xi, p, result=0;
            private const int NUM_IN_FRAMES = 100;
            private const int TEMPLATE_LENGTH = 6;
            private List<string> frames;

            public Test7(string s) : base(s) { }

            public override void PerformTest()
            {
                this.frames = Function.CutOnFrames(this.str,NUM_IN_FRAMES);
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
                this.PValue=result / Math.Pow(2, TEMPLATE_LENGTH);
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
                this.PValue=result / Math.Pow(2, TEMPLATE_LENGTH);
            }
        }
        public class Test9 : Test
        {
            private int Q;
            private double sum, f, c, u;
            private List<string> frames,frame_test = new List<string>();
            private Dictionary<string, int> mayerDict;
            private const int TEMPLATE_LENGTH = 6;
            private const int NUM_IN_FRAMES = 6;
            //для 9 тесту константи
            private const double  EXPECTED_VALUE = 5.2177052,VARIANCE = 2.954;

            public Test9(string s) : base(s) { }

            public override void PerformTest()
            {
                this.Q = 10 * (int)Math.Pow(2, TEMPLATE_LENGTH);
                this.frames = Function.CutOnFrames(this.str,NUM_IN_FRAMES);               
                //розбивка на тестові та ініціалізаційні
                for (int i = 0; i < Q; i++)
                {
                    this.frame_test.Add(this.frames[i]);
                }
                this.frames.RemoveRange(0, this.Q);
                this.mayerDict = Function.UniquesDictForMayer(TEMPLATE_LENGTH,this.frames,this.frame_test);
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
                this.PValue = Math.Min(this.PValue1,this.PValue2);
            }
        }
        public class Test11 : Test
        {
            private string sequence1, sequence2;

            public Test11(string str) : base(s) { }

            public override void PerformTest()
            {
                sequence1 = Line; sequence2 = Line;
                Function.AddTail(ref sequence1, m11);
                AddTail(ref sequence2, m11 + 1);
                var list4 = Function.FormOverlapListFreq(sequence1, m11);
                var list5 = Function.FormOverlapListFreq(sequence2, m11 + 1);
                f1 = Function.CalculateF(list4);
                f2 = Function.CalculateF(list5);
                var gg = f1 - f2;
                XI11 = 2 * Line.Length * (Math.Log(2, Math.E) - (f1 - f2));
                PValue11 = SpecialFunction.igamc(Math.Pow(2, m11 - 1), XI11 / 2.0);
                RT11.Text = PValue11.ToString("F6");
            }
        }
       
    }
}
