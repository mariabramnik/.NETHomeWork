using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
  public  class AccountSerialize
    {
        public static int numberOfAcc;
        public  int accountNumber;
        public CustomerSerialize accountOwner;
        public int maxMinusAllowed;
        public int Balance;



        public AccountSerialize(CustomerSerialize accountOwner, int monthlyIncome)
        {
            numberOfAcc++;
            accountNumber = numberOfAcc;
            this.accountOwner = accountOwner;
            maxMinusAllowed = 3 * monthlyIncome;
        }
        public AccountSerialize()
        {

        }
        public override string ToString()
        {
            return $"Account Owner : {accountOwner.name}, Account Number : {accountNumber} ," +
                $" MaxMinusAllowed : {maxMinusAllowed} , Balance : {Balance}";
        }
    }
}
