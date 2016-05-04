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
            public Test(StringBuilder sbl)
            {
                this.sBuilder=sbl;
            }
            abstract public void PerformTest();
        }

        public class Test1:Test
        {
            private double Sobs,PValue;
            private int count;

            public Test1(StringBuilder sbl):base(sbl){}
            public override void PerformTest()
            {
                this.count = Function.CountNotZero(this.sBuilder);
                this.Sobs = Math.Abs(this.count) / Math.Sqrt(this.sBuilder.Length);
                this.PValue = SpecialFunction.erfc(this.Sobs / Math.Sqrt(2));
            }
            public double PVALUE
            {
                get { return this.PValue; }
            }
        }
        
    }
}
