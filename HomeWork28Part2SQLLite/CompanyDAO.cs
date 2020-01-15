using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace HomeWork28Part2SQLLite
{
     class CompanyDAO : IEmployeeDAO
    {
        Employee e = new Employee();
        public List<Employee> GetEmployees()
        {
            List<Employee> listEmp = new List<Employee>();
           // Employee em = new Employee(7,"Luiza");
            using (SQLiteConnection con = new SQLiteConnection("Data source = C:\\Users\\Bramnik\\MashaDBLite2.db;Version=3;"))
            {
                con.Open();

                using (SQLiteCommand com = new SQLiteCommand("SELECT * FROM Employee", con))
                {
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee()
                            {
                                id = reader.GetInt32(0),
                                // id = (int)reader["id"],
                                name = (string)reader["name"],

                            };
                            listEmp.Add(emp);

                        }
                    }

                }
            }
            
            return listEmp;
        }

        public void InsertEmployee(Employee e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data source = C:\\Users\\Bramnik\\MashaDBLite2.db;Version=3;"))
            {
                con.Open();
                using (SQLiteCommand com1 = new SQLiteCommand($"INSERT INTO Employee VALUES({e.id},'{e.name}')", con))
                {
                    com1.ExecuteNonQuery();

                }
            }
        }
    }
}
