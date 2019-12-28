using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
   public class CustomerSerialize
    {
        public static int numberOfCast = 0;
        public int customerId;
        public int customerNumber;
        public string name;
        public int phNumber;


        public CustomerSerialize(string name, int phNumber, int customerId)
        {
            numberOfCast++;
            this.name = name;
            this.phNumber = phNumber;
            this.customerId = customerId;
            customerNumber = numberOfCast;
        }
        public CustomerSerialize()
        {

        }

        public override string ToString()
        {
            return $"Name: {name} , phoneNumber: {phNumber} , Id : {customerId} ,CustomersNumber : {customerNumber}";
        }
    }
}
