using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28Part2SQLLite
{
    interface IEmployeeDAO
    {
        List<Employee> GetEmployees();
        void InsertEmployee(Employee e);
    }
}
