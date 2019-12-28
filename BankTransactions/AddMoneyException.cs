using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class AddMoneyException : Exception
    {
        public AddMoneyException() : base("an error occurred, could not add money to the account")
        {

        }
    }
}
