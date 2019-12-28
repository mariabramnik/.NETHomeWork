using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class AccountAlreadyExistException : Exception
    {
        public AccountAlreadyExistException() : base("this account already exists")
        {
            
            
        }
    }
}
