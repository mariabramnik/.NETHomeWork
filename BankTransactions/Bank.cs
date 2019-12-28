using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace BankTransactions
{
    [DataContract]
    class Bank : IBank
    {
        public readonly string name;
        public readonly string address;
        public int customerCount = 0;
        private List<Customer> listCustomers;
        private List<Account> listAccounts;
        private Dictionary<int, Customer> dict_CustId_Cust;
        private Dictionary<int, Customer> dict_CustNum_Cust;
        private Dictionary<int, Account> dict_AccountNum_Acc;
        private Dictionary<Customer, List<Account>> dict_Cust_AccList;
        private int TotalMoneyInBank = 0;
        private int profits;

        //collections for serialization
        [DataMember]
        public List<CustomerSerialize> listCustomers_ser;
        [DataMember]
        public List<AccountSerialize> listAccounts_ser;
        [DataMember]
        public Dictionary<int, CustomerSerialize> dict_CustId_Cust_ser;
        [DataMember]
        public Dictionary<int, CustomerSerialize> dict_CustNum_Cust_ser;
        [DataMember]
        public Dictionary<int, AccountSerialize> dict_AccountNum_Acc_ser;
        [DataMember]
        public Dictionary<CustomerSerialize, List<AccountSerialize>>
            dict_Cust_AccList_ser = new Dictionary<CustomerSerialize, List<AccountSerialize>>();

        //collections for deserializing from a file. 
        //In the end, we compare whether we got from the files the same collections that we had before serialization
        private List<Customer> listCustomers_AfterSer;
        private List<Account> listAccounts_AfterSer;
        private Dictionary<int, Customer> dict_CustId_Cust_AfterSer;
        private Dictionary<int, Customer> dict_CustNum_Cust_AfterSer;
        private Dictionary<int, Account> dict_AccountNum_Acc_AfterSer;
        private Dictionary<Customer, List<Account>> dict_Cust_AccList_AfterSer;

        public string Name
        {
            get { return name; }
        }
        public string Address
        {
            get { return address; }
        }
        public int CustomerCount
        {
            get { return customerCount; }
        }


        public Bank(string name, string address)
        {
            listCustomers = new List<Customer>();
            listAccounts = new List<Account>();
            dict_CustId_Cust = new Dictionary<int, Customer>();
            dict_CustNum_Cust = new Dictionary<int, Customer>();
            dict_AccountNum_Acc = new Dictionary<int, Account>();
            dict_Cust_AccList = new Dictionary<Customer, List<Account>>();
            this.name = name;
            this.address = address;
        }
        //Return Customer by Id
        internal Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            try
            {
                customer = listCustomers.First(c => c.CustomerId == id);
                return customer;
            }
            catch(Exception ex)
            {
                throw new CustomerNotFoundException();
            }
      
        }
         //Return Customer by CustomerNumber
        internal Customer GetCustomerByNumber(int customerNumber)
        {
            try
            {
                Customer customer = new Customer();
                customer = listCustomers.First(c => c.CustomerNumber == customerNumber);
                return customer;
            }
            catch (Exception ex)
            {
                throw new CustomerNotFoundException();
                
            }
        }
        ////Return Account by AccountNumber
        internal Account GetAccountByNumber(int accountNumber)
        {
            try
            {
                Account account = new Account();
                account = listAccounts.First(a => a.AccountNumber == accountNumber);
                return account;
            }
            catch (Exception ex)
            {
                throw new AccountNotFoundException();
            }
        }
        // return a collection of accounts by customer
        internal List<Account> GetAccountsByCustomer(Customer cust)
        {
            try
            {
                List<Account> listAccCust = new List<Account>();
                listAccCust = dict_Cust_AccList[cust];
                return listAccCust;
            }
            catch (Exception ex)
            {
                throw new AccountNotFoundException();
            }

        }
        internal void AddNewCustomer(Customer cust)
        {
            try
            {
                listCustomers.Add(cust);
                dict_CustId_Cust.Add(cust.CustomerId, cust);
                dict_CustNum_Cust.Add(cust.CustomerNumber, cust);
                customerCount++;
            }
            catch (Exception ex)
            {
                throw new CustomerAlreadyExistException();
            }

        }
        internal void OpenNewAccount(Account a, Customer c)
        {     
            try
            {
                listAccounts.Add(a);
                dict_AccountNum_Acc.Add(a.AccountNumber, a);
                List<Account> listAcc = new List<Account>();
                if(!dict_Cust_AccList.ContainsKey(c))
                {
                    listAcc.Add(a);
                    dict_Cust_AccList.Add(c, listAcc);
                }
                else
                { 
                    listAcc = dict_Cust_AccList[c];
                    listAcc.Add(a);
                }
               
            }
            catch (AccountAlreadyExistException ex)
            {
                throw new AccountAlreadyExistException();
            }

        }
        //add deposit money
        internal bool Deposit(Account acc, int amount)
        {
            bool res = false;
            this.TotalMoneyInBank += amount;
            try
            {
               acc.Add(amount);
               res = true;
               Console.WriteLine("Transaction was successful");
            }
            catch(Exception ex)
            {
                throw new AddMoneyException();
                
            }
            return res;
        }
        //withdraw money from the account
        internal bool Withdraw(Account acc, int amount)
        {
            bool res = false;
            this.TotalMoneyInBank -= amount;
            bool result = acc.Substract(amount);
            if (result)
            {
                Console.WriteLine("Transaction was successful");
                return res;
            }
            return res;
        }
        //return account balance by customer
        internal int GetCustomerTotalBalance(Customer cust)
        {
            int sum = 0;
            List<Account> listAccCust = new List<Account>();
            listAccCust = GetAccountsByCustomer(cust);
            foreach(Account acc in listAccCust)
            {
                sum += acc.Balance;
            }
            return sum;
        }

        internal void CloseAccount(Account acc)
        {
            listAccounts.Remove(acc);
            dict_AccountNum_Acc.Remove(acc.AccountNumber);
            List<Account> listAcc = dict_Cust_AccList[acc.AccountOwner];
            listAcc.Remove(acc);
            TotalMoneyInBank -= acc.Balance;
        }
        //recalculation of the bank commission.
        internal void ChargeAnnualCommission(float percentage)
        {
            int sum = 0;
            foreach (Customer cust in listCustomers)
            {
                List<Account> listAccCust = new List<Account>();
                listAccCust = GetAccountsByCustomer(cust);
                foreach (Account a in listAccCust)
                {
                    int bank_profit = (int)(a.Balance / 100 * percentage + 0.5);
                    if (a.Balance < 0)
                    {
                        bank_profit *= 2;
                    }
                    a.Substract(bank_profit);
                    sum += bank_profit;
                }
             }
            this.profits = sum;
            TotalMoneyInBank = TotalMoneyInBank - sum;
        }
        //connection of two accounts into one, provided that they belong to the same user
        internal void JoinAccount(Account a1, Account a2)
        {
            
            Account a3 = new Account();
            try
            {
                a3 = a1 + a2;
                OpenNewAccount(a3, a3.AccountOwner);
            }
            catch(NotSameCustomerException ex)
            {
                throw new NotSameCustomerException();
            }
            CloseAccount(a1);
            CloseAccount(a2);

            //PrintDictionary(dict_AccountNum_Acc);
        }
        // write to the file a collection of all accounts :listAccounts_ser
        internal void AccountsFromListToFile(string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\n"
                };
                settings.Async = true;
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<AccountSerialize>));
                string path = @"C:\test\" + fileName;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {               
                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.WriteObject(writer, listAccounts_ser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException();
            }
        }
        // write to the file a collection of all customers :listCustomers_ser
        internal void CustomersFromListToFile(string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\n"
                };
                settings.Async = true;
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<CustomerSerialize>));
                string path = @"C:\test\" + fileName;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    //ser.Serialize(fs, listCustomers_ser);
                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.WriteObject(writer, listCustomers_ser);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new SerializationException();
            }
        }

        //create accounts with type AccountSerialize for serialization to a file
        internal AccountSerialize AccountToAccountSerialize(Account a)
        {
            AccountSerialize acs = new AccountSerialize();
            acs.accountNumber = a.AccountNumber;
            acs.accountOwner = CustomerToCustomerSerialize(a.AccountOwner);
            acs.Balance = a.Balance;
            acs.maxMinusAllowed = a.MaxMinusAllowed;

            return acs;
        }
        //create customers with type CustomerSerialize for serialization to a file
        internal CustomerSerialize CustomerToCustomerSerialize(Customer c)
        {
            CustomerSerialize cs = new CustomerSerialize();
            cs.customerId = c.CustomerId;
            cs.customerNumber = c.CustomerNumber;
            cs.name = c.Name;
            cs.phNumber = c.phNumber;
            return cs;
        }
        //filling collection dict_Cust_AccList_ser for serialization dict_Cust_AccList
        internal void DictionaryToDictionarySerialize(AccountSerialize a, CustomerSerialize c)
        {          
            List<AccountSerialize> listAcc_ser = new List<AccountSerialize>();
            if (!dict_Cust_AccList_ser.ContainsKey(c))
            {
                listAcc_ser.Add(a);
                dict_Cust_AccList_ser.Add(c, listAcc_ser);
            }
            else
            {
                listAcc_ser = dict_Cust_AccList_ser[c];
                listAcc_ser.Add(a);
            }
        }
         // write to the file a collection dict_CustId_Cust_ser 
        internal void FromDictionaryCustId_Cust_serToFile(string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\n"
                };
                settings.Async = true;
                string path = @"C:\test\" + fileName;
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int,CustomerSerialize>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.WriteObject(writer, dict_CustId_Cust_ser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException();
            }

        }
        // write to the file a collection dict_Cust_AccList_ser 
        internal void FromDictionaryCust_AccList_serToFile(string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\n"
                };
                settings.Async = true;
                string path = @"C:\test\" + fileName;
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<CustomerSerialize, List<AccountSerialize>>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.WriteObject(writer, dict_Cust_AccList_ser);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new SerializationException();
            }
 
        }
        // write to the file a collection dict_CustNum_Cust_ser 
        internal void FromDictionaryCustNum_Cust_serToFile(string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\n"
                };
                settings.Async = true;
                string path = @"C:\test\" + fileName;
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int, CustomerSerialize>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.WriteObject(writer, dict_CustNum_Cust_ser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException();
            }

        }
        // write to the file a collection dict_AccountNum_Acc_ser 
        internal void FromDictionaryAccNum_Acc_serToFile(string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\n"
                };
                settings.Async = true;
                string path = @"C:\test\" + fileName;
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int, AccountSerialize>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.WriteObject(writer, dict_AccountNum_Acc_ser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException();
            }

        }

        //filling out the collections that we write to files. before serialization
        internal void BeforeSerialization()
        {
            listAccounts_ser = new List<AccountSerialize>();
            listCustomers_ser = new List<CustomerSerialize>();
            dict_CustId_Cust_ser = new Dictionary<int, CustomerSerialize>();
            dict_CustNum_Cust_ser = new Dictionary<int, CustomerSerialize>();
            
            foreach (Customer c in listCustomers)
            {
                CustomerSerialize cs = CustomerToCustomerSerialize(c);
                if (!listCustomers_ser.Exists(x => x.customerId == c.CustomerId))
                {
                    listCustomers_ser.Add(cs);
                    dict_CustId_Cust_ser.Add(cs.customerId, cs);
                    dict_CustNum_Cust_ser.Add(cs.customerNumber, cs);
                }    
            }
            dict_AccountNum_Acc_ser = new Dictionary<int, AccountSerialize>();           
            foreach(Account a in listAccounts)
            {
                AccountSerialize acs = AccountToAccountSerialize(a);
                DictionaryToDictionarySerialize(acs, acs.accountOwner);
                listAccounts_ser.Add(acs);
                dict_AccountNum_Acc_ser.Add(acs.accountNumber, acs);
            }
            
        }
        //delete items from
        //collections that were used for serialization
        internal void AfterSerialization()
        {
            listCustomers_ser.Clear();
            listAccounts_ser.Clear();
            dict_CustId_Cust_ser.Clear();
            dict_CustNum_Cust_ser.Clear();
            dict_AccountNum_Acc_ser.Clear();
            dict_Cust_AccList_ser.Clear();

        }
        //load collection dict_CustNum_Cust_ser from file
        internal void LoadFromFile_CustNum_Cust(string fileName)
        {
            string path = @"C:\test\" + fileName;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int, CustomerSerialize>));
            using (var reader = new FileStream(path,FileMode.Open, FileAccess.Read))
            {
                dict_CustNum_Cust_ser = serializer.ReadObject(reader) as Dictionary<int, CustomerSerialize>;
            }
        }
        //load collection dict_CustId_Cust_ser from file
        internal void LoadFromFile_CustId_Cust(string fileName)
        {
            string path = @"C:\test\" + fileName;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int, CustomerSerialize>));
            using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                dict_CustId_Cust_ser = serializer.ReadObject(reader) as Dictionary<int, CustomerSerialize>;
            }
        }
        //load collection dict_AccountNum_Acc_ser from file
        internal void LoadFromFile_AccNum_Acc(string fileName)
        {
            string path = @"C:\test\" + fileName;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int, AccountSerialize>));
            using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                dict_AccountNum_Acc_ser = serializer.ReadObject(reader) as Dictionary<int, AccountSerialize>;
            }
        }
        ////load collection dict_Cust_AccList_ser from file
        internal void LoadFromFile_Cust_AccList(string fileName)
        {
 
            string path = @"C:\test\" + fileName;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<CustomerSerialize, List<AccountSerialize>>));
            using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                dict_Cust_AccList_ser = serializer.ReadObject(reader) as Dictionary<CustomerSerialize, List<AccountSerialize>>;
            }
        }
        ////load collection listCustomers_ser from file
        internal void LoadFromFile_Customers(string fileName)
        {
            string path = @"C:\test\" + fileName;
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<CustomerSerialize>));
            using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                listCustomers_ser = serializer.ReadObject(reader) as List<CustomerSerialize>;
            }
        }
        ////load collection listAccounts_ser from file
        internal void LoadFromFile_Accounts(string fileName)
        {
            string path = @"C:\test\" + fileName;
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<AccountSerialize>));
             using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
               listAccounts_ser = serializer.ReadObject(reader) as List<AccountSerialize>;
            }
        }
        //the type read from the file : AccountSerialize needs to be rewritten in the original type: Account
        internal Account AccountSerializeToAccount(AccountSerialize acs)
        {
            int accountNumber = acs.accountNumber;
            int maxMinusAllowed = acs.maxMinusAllowed;
            CustomerSerialize cust = acs.accountOwner;
            Customer accountOwner = CustomerSerializeToCustomer(cust);
            Account a = new Account(accountOwner,accountNumber,maxMinusAllowed);
            return a;

        }
        ////the type read from the file : CustomerSerialize needs to be rewritten in the original type:Customer
        internal Customer CustomerSerializeToCustomer(CustomerSerialize custSer)
        {
            int customerNumber = custSer.customerNumber;
            int customerId = custSer.customerId;
            int phNumber = custSer.phNumber;
            string name = custSer.name;
            Customer c = new Customer( name, phNumber, customerId, customerNumber);
            return c;
        }
        internal void AfterLoading()
        {
            listCustomers_AfterSer = new List<Customer>();
            listAccounts_AfterSer = new List<Account>();
            dict_CustId_Cust_AfterSer = new Dictionary<int, Customer>();
            dict_CustNum_Cust_AfterSer = new Dictionary<int, Customer>();
            dict_AccountNum_Acc_AfterSer = new Dictionary<int, Account>();
            dict_Cust_AccList_AfterSer = new Dictionary<Customer, List<Account>>();
            List<Account> listAccounts = new List<Account>();
            foreach (CustomerSerialize cust in listCustomers_ser)
            {
                Customer c = CustomerSerializeToCustomer(cust);
                listCustomers_AfterSer.Add(c);
                dict_CustId_Cust_AfterSer.Add(c.CustomerId, c);
                dict_CustNum_Cust_AfterSer.Add(c.CustomerNumber, c);

            }
            foreach (AccountSerialize acs in listAccounts_ser)
            {
                Account a = AccountSerializeToAccount(acs);
                listAccounts_AfterSer.Add(a);
                Customer currCust = a.AccountOwner;
                dict_AccountNum_Acc_AfterSer.Add(a.AccountNumber, a);
                if (!dict_Cust_AccList_AfterSer.ContainsKey(currCust))
                {
                    listAccounts.Add(a);
                    dict_Cust_AccList_AfterSer.Add(currCust, listAccounts);
                }
                else
                {
                    listAccounts = dict_Cust_AccList_AfterSer[currCust];
                    listAccounts.Add(a);
                }
            }
            bool res = SuccessfulDeserialization();
            if (res)
            {
                Console.WriteLine("Successful Deserialization");
            }
        }

        internal bool SuccessfulDeserialization()
        {
            bool res = false;
            bool res1 = listAccounts.SequenceEqual(listAccounts_AfterSer);
            bool res2 = listCustomers.SequenceEqual(listCustomers_AfterSer);
            bool res3 = dict_CustId_Cust.SequenceEqual(dict_CustId_Cust_AfterSer);
            bool res4 = dict_CustNum_Cust.SequenceEqual(dict_CustNum_Cust);
            bool res5 = dict_AccountNum_Acc.SequenceEqual(dict_AccountNum_Acc_AfterSer);
            bool res6 = dict_Cust_AccList.SequenceEqual(dict_Cust_AccList_AfterSer);
            if(res1 == true && res2 == true && res3 == true && res4 == true && res5 == true)
            {
                res = true;
            }

            return res;
        }
        public void PrintDictionary(Dictionary<int,Account> dict_AccountNum_Ac)
        {
            foreach(KeyValuePair<int,Account> kvp in dict_AccountNum_Ac)
            {
                Console.WriteLine("key = {0} , value = {1} ", kvp.Key, kvp.Value);
            }
        }




    }
}
