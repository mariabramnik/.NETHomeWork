using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue23HomeWork
{
    class ProtectionCompare : IComparer<Customer>
    {
   
            public int Compare(Customer c1, Customer c2)
            {
                
                if (c1.Protection > c2.Protection)
                {
                    return -1;
                }
                else if (c1.Protection < c2.Protection)
                {
                    return 1;
                }
                else
                    return 0;
                  
                //return c1.Protection.CompareTo(c2.Protection);
            }
        }
}
