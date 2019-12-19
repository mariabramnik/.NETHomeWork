using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue23HomeWork
{
    class TotalPurchasesCompare : IComparer<Customer>
    {
        public int Compare(Customer c1, Customer c2)
        {
            return c1.TotalPurchases.CompareTo(c2.TotalPurchases);
        }
    }
}
