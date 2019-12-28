using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class Account
    {
        private static int numberOfAcc;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber { get { return accountNumber; } }
        public int Balance { get; private set; }
        public Customer AccountOwner{ get { return accountOwner; }}
        public int MaxMinusAllowed { get { return maxMinusAllowed; } }


        public Account(Customer accountOwner, int monthlyIncome)
        {
            numberOfAcc++;
            accountNumber = numberOfAcc;
            this.accountOwner = accountOwner;
            maxMinusAllowed = 3 * monthlyIncome;
        }
        public Account(Customer accountOwner,int accountNumber,int  maxMinusAllowed)
        {
            this.accountNumber = accountNumber;
            this.accountOwner = accountOwner;
            this.maxMinusAllowed = maxMinusAllowed;
        }
        public Account()
        {

        }
        public override string ToString()
        {
            return $"Account Owner : {AccountOwner.Name}, Account Number : {AccountNumber} ," +
                $" MaxMinusAllowed : {MaxMinusAllowed} , Balance : {Balance}";
        }

        public static bool operator == (Account a1, Account a2)
        {
            bool res = false;
            if(a1.AccountNumber == a2.AccountNumber)
            {
                res = true;
            }
            return res;
        }

        public static bool operator !=(Account a1, Account a2)
        {
            bool res = false;
            if (a1.AccountNumber != a2.AccountNumber)
            {
                res = true;
            }
            return res;
        }

        public override bool Equals(object obj)
        {
            bool res = false;
            Account a = (Account)obj;
            if(this.AccountNumber == a.AccountNumber)
            {
                res = true;
            }
            return res;

        }

        public override int GetHashCode()
        {
            return this.GetHashCode() + this.AccountNumber;
        }

        public static Account operator +(Account a1, Account a2)
        {
            if (a1.AccountOwner == a2.AccountOwner)
            {
                Account a3 = new Account(a1.AccountOwner, a1.maxMinusAllowed / 3);
                a3.Balance = a1.Balance + a2.Balance;
                a3.maxMinusAllowed = a1.maxMinusAllowed + a2.maxMinusAllowed;
                
                return a3;
            }
            return null;
        }
        public static int operator +(Account a, int amount)
        {
            a.Balance += amount;
            return a.Balance;
        }
        public static int operator -(Account a, int amount)
        {
            a.Balance -= amount;
            return a.Balance;
        }
        public void Add(int amount)
        {
           this.Balance += amount;
           
        }
        public bool Substract(int amount)
        {
            bool res = false;
            if (this.Balance - amount > -maxMinusAllowed)
            {
                this.Balance -= amount;
                res = true;
            }
            else
            {
                throw new BalanceException();

            }
            return res;
        }
    }
}
