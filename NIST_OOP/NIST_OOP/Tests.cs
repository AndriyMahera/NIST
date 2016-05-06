﻿using System;
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

        public class Test1:Test
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
        
    }
}
