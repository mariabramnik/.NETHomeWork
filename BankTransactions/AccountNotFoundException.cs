using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() : base("Account is not found")
        {

        }
    }
}
