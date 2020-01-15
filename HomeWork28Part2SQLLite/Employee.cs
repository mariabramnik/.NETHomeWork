using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28Part2SQLLite
{
   public class Employee
    {
        public int id;
        public string name;

        public Employee(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Employee() { }
        public string Name{ get { return name; } private set { name = value; } }
        public int Id { get { return id; } private set { id = value; } }
        public override string ToString()
        {
            return $"id = {id} , name = {name}";
        }
    }
}
