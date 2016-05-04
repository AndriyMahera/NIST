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
    }
}
