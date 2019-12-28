using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class CustomerAlreadyExistException :Exception
    {
        public CustomerAlreadyExistException() : base("this customer already exists")
        {

        }
    }
}
