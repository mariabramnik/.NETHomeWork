using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class BalanceException : Exception
    {
        public BalanceException() : base("this amount cannot be withdrawn from the account, since the allowed minus will be exceeded")
        {
            Console.WriteLine(Message);
        }
    }
}
