using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue23HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer(111, "masha", 1978, "address1", 1);c1.TotalPurchases = 100;
            Customer c2 = new Customer(222, "inna", 1969, "address2", 2);c2.TotalPurchases = 200;
            Customer c3 = new Customer(333, "mark", 1990, "address3", 3);c3.TotalPurchases = 300;
            Customer c4 = new Customer(444, "gena", 1938, "address4", 5);c4.TotalPurchases = 400;
            Customer c5 = new Customer(555, "avy", 1967, "address5", 7);c5.TotalPurchases = 500;
            Customer c6 = new Customer(666, "dany", 1999, "address6", 5);c6.TotalPurchases = 600;
            Customer c7 = new Customer(777, "rony", 1972, "address7", 7);c7.TotalPurchases = 700;
            Customer c8 = new Customer(888, "sasha", 1955, "address8", 3);c8.TotalPurchases = 800;
            Customer c9 = new Customer(999, "max", 2000, "address9", 7);c9.TotalPurchases = 900;
            Customer c10 = new Customer(1000, "lion", 1979, "address10", 2);c10.TotalPurchases = 910;
            Customer c11 = new Customer(8000, "tomas", 1993, "address11", 1);c11.TotalPurchases = 9;
            List<Customer> myCustomers = new List<Customer>{ c1,c2, c3, c4,c5,c6,c7,c8,c9,c10 };
 
            MyQueue my = new MyQueue();
            my.Enqueue(c1);
            my.PrintMyQueue();
            my.Init(myCustomers);
            my.PrintMyQueue();
            Customer custProtect = new Customer();
            custProtect = my.DequeueProtectiza();
            Console.WriteLine(custProtect);
            Console.WriteLine("********************************************************************");
            my.Dequeue();
            my.PrintMyQueue();
            my.Dequeue();
            my.PrintMyQueue();
            my.SortByBirthDay();
            my.PrintMyQueue();
            my.SortByProtection();
            my.PrintMyQueue();
            my.SortByTotalPurchases();
            my.PrintMyQueue();
            myCustomers = my.DequeueCustomers(10);
            foreach(Customer c in myCustomers)
            {
                Console.WriteLine(c.ToString());
            }
            Console.ReadLine();
        }
    }
}
