using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue23HomeWork
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public int Protection { get; set; }
        public int TotalPurchases { get; set; }
        public Customer(int id, string name, int birthYear, string address, int protection)
        {
            Id = id;
            Name = name;
            BirthYear = birthYear;
            Address = address;
            Protection = protection;
        }
        public Customer() { }

        public override string ToString()
        {
            return $"Id = {Id} , Name = {Name} , BirthYear = {BirthYear} , Address = {Address}," +
               $"Protection = {Protection} , TotalPurchases = {TotalPurchases}";
           
          
        }
    }
}
