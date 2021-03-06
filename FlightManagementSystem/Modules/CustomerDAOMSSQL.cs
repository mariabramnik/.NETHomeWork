﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Modules
{
    class CustomerDAOMSSQL : ICustomerDAO
    {
        static SqlConnection con = new SqlConnection(@"Data Source=BRAMNIK-PC;Initial Catalog=FlightManagementSystem;Integrated Security=True");
        public void SQLConnectionOpen()
        {
            con.Open();
        }
        public void SQLConnectionClose()
        {
            con.Close();
        }
        public void Add(Customer ob)
        {
            int id = ob.id;
            Customer customer = Get(id);
            if (customer is null)
            {
                throw new CustomerNotExistException("This customer is already exist");
            }
            string str = string.Format($"INSERT INTO Customer VALUES({id},'{ob.firstName}','{ob.lastName}','{ob.userName}','{ob.password}','{ob.address}','{ob.phoneNo}','{ob.creditCardNumber}')");
            
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.ExecuteNonQuery();
            }

            SQLConnectionClose();
        }

        public Customer Get(int id)
        {    
            Customer customer = null;
            string str = $"SELECT * FROM Customers WHERE ID = {id}";
            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        customer = new Customer
                        {
                            id = (int)reader["ID"],
                            firstName = (string)reader["FIRST_NAME"],
                            lastName = (string)reader["LAST_NAME"],
                            userName = (string)reader["USER_NAME"],
                            password = (string)reader["PASSWORD"],
                            address = (string)reader["ADDRESS"],
                            phoneNo = (string)reader["PHONE_NO"],
                            creditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]

                        };
                    }
                }
            }
            return customer;
        }

        public List<Customer> GetAll()
        {
           
            List<Customer> customersList = new List<Customer>();
            string str = $"SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        id = (int)reader["ID"],
                        firstName = (string)reader["FIRST_NAME"],
                        lastName = (string)reader["LAST_NAME"],
                        userName = (string)reader["USER_NAME"],
                        password = (string)reader["PASSWORD"],
                        address = (string)reader["ADDRESS"],
                        phoneNo = (string)reader["PHONE_NO"],
                        creditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]
                    };
                    customersList.Add(customer);
                }

            }
            
            return customersList;
        }

        public Customer GetCustomerByUserName(string userName)
        {
           
            Customer customer = null;
            string str = $"SELECT * FROM Customers WHERE USER_NAME = '{userName}'";
            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        customer = new Customer
                        {
                            id = (int)reader["ID"],
                            firstName = (string)reader["FIRST_NAME"],
                            lastName = (string)reader["LAST_NAME"],
                            userName = (string)reader["USER_NAME"],
                            password = (string)reader["PASSWORD"],
                            address = (string)reader["ADDRESS"],
                            phoneNo = (string)reader["PHONE_NO"],
                            creditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]

                        };
                    }

                }
            }
 
            return customer;
           
        }

        public void Remove(Customer ob)
        {
            int id = ob.id;
            Customer customer = Get(id);
            if (customer is null)
            {
                throw new CustomerNotExistException("This customer is not exist");
            }
            string str = string.Format($"DELETE FROM Customers WHERE ID = {id})");
           
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.ExecuteNonQuery();
            }
         
        }

        public void Update(Customer ob)
        {
            int id = ob.id;
            Customer customer = Get(id);
            if (customer is null)
            {
                throw new CustomerAlreadyExistException("This customer is already exist");
            }
            string str = string.Format($"UPDATE Customers SET FIRST_NAME = '{ob.firstName}',LAST_NAME = '{ob.lastName}',USER_NAME = '{ob.userName}', PASSWORD = '{ob.password}',Address = '{ob.address}',PHONE_NO = '{ob.phoneNo}',CREDIT_CARD_NUMBER = '{ob.creditCardNumber}' WHERE ID = {id}");
           
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                cmd.ExecuteNonQuery();
            }

        }
    }
}
