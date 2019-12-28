using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class CustomerNotFoundException : Exception
    {

        public CustomerNotFoundException() : base("Customer is not found")
        {
            Console.Write(Message);
        }
    }
}
