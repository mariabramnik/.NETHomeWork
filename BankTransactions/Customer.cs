using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class Customer
    {
        public static int numberOfCast = 0;
        private readonly int customerId;
        private readonly int customerNumber;
        public string Name { get; private set; }
        public int phNumber { get; private set; }
        public int CustomerId { get { return customerId; } }
        public int CustomerNumber{ get { return customerNumber; } }

        public Customer(string name, int phNumber, int customerId)
        {
            numberOfCast++;
            Name = name;
            this.phNumber = phNumber;
            this.customerId = customerId;
            this.customerNumber = numberOfCast;
        }
        public Customer(string name, int phNumber, int customerId, int customerNumber)
        {
            Name = name;
            this.phNumber = phNumber;
            this.customerId = customerId;
            this.customerNumber = customerNumber;
        }

        public Customer()
        {

        }

        public override string ToString()
        {
            return $"Name: {Name} , phoneNumber: {phNumber} , Id : {CustomerId} ,CustomersNumber : {CustomerNumber}";
        }
        public static bool operator == (Customer c1,Customer c2)
        {
            bool res = false;
            if (c1.CustomerId == c2.CustomerId)
            {
                res = true; 
            }
            return res;
        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            bool res = false;
            if (c1.CustomerId != c2.CustomerId  )
            {
                res = true;
            }
            return res;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            Customer c = (Customer)obj;
            if(this.CustomerId == c.CustomerId && this.Name == c.Name)
            {
                res = true;
            }
            return res;
        }
        public override int GetHashCode()
        {

            return CustomerId;
        }


    }
}
