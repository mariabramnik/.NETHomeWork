using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28Part2SQLLite
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyDAO comDao = new CompanyDAO();
            Employee emp = new Employee
            {
                id = 23,
                name = "Micha"
            };
            comDao.InsertEmployee(emp);
            List<Employee> listEmp = comDao.GetEmployees();
            listEmp.ForEach(e => Console.WriteLine(e));
            Console.ReadLine();
        }
    }
}
