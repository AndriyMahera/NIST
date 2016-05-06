using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIST_OOP
{
    class Tests
    {
        abstract public class Test
        {
            protected StringBuilder sBuilder;
            protected double PValue;
            public double PVALUE
            {
                get { return this.PValue; }
            }
            public Test(StringBuilder sbl)
            {
                this.sBuilder=sbl;
            }
            abstract public void PerformTest();
        }

        public class Test1:Test
        {
            private double Sobs;
            private int count;

            public Test1(StringBuilder sbl):base(sbl){}
            public override void PerformTest()
            {
                this.count = Function.CountNotZero(this.sBuilder);
                this.Sobs = Math.Abs(this.count) / Math.Sqrt(this.sBuilder.Length);
                this.PValue = SpecialFunction.erfc(this.Sobs / Math.Sqrt(2));
            }
        }

        public class Test2 : Test
        {
            private double  Xi;
            private int[] arr;
            private const int N = 20;

            public Test2(StringBuilder sbl) : base(sbl) { }

            public override void PerformTest()
            {
                this.arr = Function.CountAmountInBlock(this.sBuilder.ToString(),N);
                this.Xi = Function.FindXi2(arr,sBuilder.Length,N);
                PValue = SpecialFunction.igamc(5, this.Xi / 2);
            }
        }
        
    }
}
