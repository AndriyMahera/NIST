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
       
    }
}
