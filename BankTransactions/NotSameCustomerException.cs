using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class NotSameCustomerException : Exception
    {
        public NotSameCustomerException() : base("it is impossible to unite accounts in this way, since they belong to different customers")
        {

        }
    }
}
