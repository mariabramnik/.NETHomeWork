﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue23HomeWork
{
    class MyQueue
    {
        private List<Customer> customers = new List<Customer>();
        public int Count
            {
                get
                {
                    return customers.Count();
                }
            }
        public void Enqueue(Customer c)
        {
            customers.Add(c);
        }
        public Customer Dequeue()
        {
            Customer c = customers[0];
            customers.RemoveAt(0);
            return c;
        }
        //replaces the queue with a new gueue
        public void Init(List<Customer>customersNew)
        {
            customers = customersNew;
        }
        public void Clear()
        {
            customers.Clear();
        }
        public Customer WholsNext()
        {
            Customer c = customers[0];
            return c;
        }
        public void SortByProtection()
        {
            customers.Sort(new ProtectionCompare());
        }

        public void SortByTotalPurchases()
        {
            customers.Sort(new TotalPurchasesCompare());
        }

        public void SortByBirthDay()
        {
            customers.Sort(new BirthDayCompare()); 
        }
        //returned list lenght= num, from the beginning of the queue
        public List<Customer> DequeueCustomers(int num)
        {
            List<Customer> customersNum = new List<Customer>();
            if(customers.Count > 0)
            {
                if(customers.Count >= num)
                {
                    for(int i = 0; i < num; i++)
                    {
                        customersNum.Add(customers[i]);
                    }            
                }
                else
                {
                    Console.WriteLine("the list is too short, the returned list is smaller than num");
                    for (int i = 0; i < customers.Count; i++)
                    {
                        customersNum.Add(customers[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("the list is empty");
            }
            return customersNum;
        }
        public void AnyRakSheila(Customer c)
        {
            customers.Insert(0, c);
        }
        //returns customer with the highest protection with the lowest index
        public Customer DequeueProtectiza()
        {
            int res = 0;
            //remember the queue before sorting
            List<Customer>customersOld = new List<Customer>(customers);
            SortByProtection();
            int protect = customers[0].Protection;
            int max = customersOld.Count;
            foreach(Customer c in customersOld)
            {
                if(c.Protection == protect)
                {
                    res = customersOld.IndexOf(c);
                    break;
                }
            }           
            Customer prot = customersOld[res];
            customersOld.Insert(0, prot);
            customersOld.RemoveAt(res);
            return prot;
        }
        public void PrintMyQueue()
        {
            foreach(Customer c in customers)
            {
                Console.WriteLine(c.ToString() + "  Number in queue" + customers.IndexOf(c));
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
