using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class SerializationException : Exception
    {
        public SerializationException() : base("Serilization Exception,attempt failed")
        {

        }
    }
}
