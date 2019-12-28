using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            //create users
            Customer c1 = new Customer("Bramnik", 054342543, 323728857);
            Customer c2 = new Customer("Tramnik", 055334678, 221109876);
            Customer c3 = new Customer("Aramnik", 054656566, 322989811);
            Customer c4 = new Customer("Yamnik",  057778888, 333121219);
            Customer c5 = new Customer("Jamnik",  054999666, 441199878);
            Customer c6 = new Customer("Kramnik", 055334599, 112987654);
            Customer c7 = new Customer("Framnik", 052299999, 2120909095);
            Customer c8 = new Customer("Udarnik", 054333111, 343987945);
            Customer c9 = new Customer("Piastro", 054342500, 333117687);
            Customer c10 = new Customer("Heifec", 050005656, 131676788);
            Customer c11 = new Customer("BenGurion",  025450565, 77776788);
            //create accounts
            Account a1 = new Account(c1, 5000);
            Account a2 = new Account(c2, 35000); 
            Account a3 = new Account(c3, 55000);
            Account a4 = new Account(c10, 10000);
            Account a5 = new Account(c5, 6000);
            Account a6 = new Account(c6, 76000);
            Account a7 = new Account(c7, 7000);
            Account a8 = new Account(c8, 8000);
            Account a11 = new Account(c9, 9000); 
            Account a9 = new Account(c10, 10000);
            Account a10 = new Account(c10, 10000);
            Account a12 = new Account(c1, 5000);
            Account a13 = new Account(c1, 5000);
            Account a14 = new Account(c4, 100000);
            //create bank
            Bank myBank = new Bank("MyBank","Smelyansky 34,Netania,Israel");
            //add new customer in bank
            myBank.AddNewCustomer(c1); myBank.AddNewCustomer(c2); myBank.AddNewCustomer(c3);
            myBank.AddNewCustomer(c4); myBank.AddNewCustomer(c5); myBank.AddNewCustomer(c6);
            myBank.AddNewCustomer(c7); myBank.AddNewCustomer(c8); myBank.AddNewCustomer(c9);
            myBank.AddNewCustomer(c10);
            // Open new account in bank
            myBank.OpenNewAccount(a1,c1); myBank.OpenNewAccount(a2, c2); myBank.OpenNewAccount(a3, c3);
            myBank.OpenNewAccount(a4, c4); myBank.OpenNewAccount(a5, c5); myBank.OpenNewAccount(a6, c6);
            myBank.OpenNewAccount(a7, c7); myBank.OpenNewAccount(a8, c8); myBank.OpenNewAccount(a9, c9);
            myBank.OpenNewAccount(a10, c10); myBank.OpenNewAccount(a11, c9);
            myBank.OpenNewAccount(a12, c1); myBank.OpenNewAccount(a13, c1);
            myBank.OpenNewAccount(a14, c4);
            try
            {
                // get customer by CustomerId
                Customer currCust = myBank.GetCustomerById(323728857);
                Console.WriteLine(currCust.ToString());
            }
            catch(CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                // get customer by CustomerNumber
                Customer currCust1 = myBank.GetCustomerByNumber(3);
                Console.WriteLine(currCust1.ToString());
            }
            catch(CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                // get account by accounts number
                Account currAcc = myBank.GetAccountByNumber(2);
                Console.WriteLine(currAcc.ToString());
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            List<Account> listAcc = new List<Account>();
            Console.Write("List of Accounts of Customer by Name  {0} : ", c1.Name);
            try
            {
                // get list of accounts by customer
               listAcc = myBank.GetAccountsByCustomer(c1);
                foreach (Account a in listAcc)
                {
                    Console.Write(a.AccountNumber.ToString() + " ,");
                }
                Console.WriteLine();
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // add money to deposit
            myBank.Deposit(a1, 3000); myBank.Deposit(a9, 3000);
            myBank.Deposit(a2, 3000); myBank.Deposit(a10, 3000);
            myBank.Deposit(a3, 3000); myBank.Deposit(a11, 3000);
            myBank.Deposit(a4, 3000); myBank.Deposit(a12, 3000);
            myBank.Deposit(a5, 3000); myBank.Deposit(a13, 3000);
            myBank.Deposit(a6, 3000); 
          //  myBank.Deposit(a7, 3000); 
            myBank.Deposit(a8, 3000);
           //recalculation of the bank commission.
            myBank.ChargeAnnualCommission(3);
            //connection of two accounts into one, provided that they belong to the same user
            myBank.JoinAccount(a1, a13);

            //see the account balance with the user before withdrawing money
            int balance = myBank.GetCustomerTotalBalance(c1);
            Console.WriteLine("Customer's {0 }  Balance = {1} ", c10.Name, balance);
            try
            {
                //withdrawing money,too large amount, 
                //a message appears about exceeding the allowed minus
                myBank.Withdraw(a1, 50000);
            }
            catch(BalanceException)
            {
                
            }
            //see the account balance with the user after withdrawing money
            int balance1 = myBank.GetCustomerTotalBalance(c1);
            Console.WriteLine("Customer's {0 }  Balance = {1} ", c10.Name, balance1);
            try
            {
                //withdrawing money
                myBank.Withdraw(a1, 500);
            }
            catch (BalanceException)
            {

            }
            //see the account balance with the user after withdrawing money
            int balance2 = myBank.GetCustomerTotalBalance(c1);
            Console.WriteLine("Customer's {0 }  Balance = {1} ", c10.Name, balance2);
            //save all data in files
            try
            {
                myBank.BeforeSerialization();
                myBank.AccountsFromListToFile("MyBankAccounts.xml");
                myBank.CustomersFromListToFile("MyBankCustomers.xml");
                myBank.AccountsFromListToFile("MyBankAccounts.xml");
                myBank.FromDictionaryCust_AccList_serToFile("MyBankDictCustAccList.xml");
                myBank.FromDictionaryCustNum_Cust_serToFile("MyBankDictCustNumCust.xml");
                myBank.FromDictionaryCustId_Cust_serToFile("MyBankDictCustIdCust.Xml");
                myBank.FromDictionaryAccNum_Acc_serToFile("MyBankDictAccNumAcc.xml");
                myBank.AfterSerialization();
                Console.WriteLine("Serialization Successful");
            }
            catch(SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // loading data from the files
            myBank.LoadFromFile_AccNum_Acc("MyBankDictAccNumAcc.xml");
            myBank.LoadFromFile_Accounts("MyBankAccounts.xml");
            myBank.LoadFromFile_Customers("MyBankCustomers.xml");
            myBank.LoadFromFile_CustId_Cust("MyBankDictCustIdCust.xml");
            myBank.LoadFromFile_CustNum_Cust("MyBankDictCustNumCust.xml");
            myBank.LoadFromFile_Cust_AccList("MyBankDictCustAccList.xml");
            //compare data before serialization and sending to files, 
            //with those we get from files.
            myBank.AfterLoading();
            Console.ReadLine();
        }
    }
}
