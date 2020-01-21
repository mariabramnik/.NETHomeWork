using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HomeWork32MsSQL
{
    class Program
    {
        public static int CheckForInt(string str)
        {
            int num = 0;
            bool res = false;
            res = int.TryParse(str, out num);
            while (res == false && (num < 0 || num >10 || num == 4))
            {
                Console.WriteLine("Enter a number from list");
                str = Console.ReadLine();
                res = int.TryParse(str, out num);
            }
          return num;
        }
        static void Main(string[] args)
        {
           SqlConnection con = new SqlConnection(@"Data Source=BRAMNIK-PC;Initial Catalog=CustomersProducts;Integrated Security=True");
            con.Open();
           // string str = string.Format("SELECT * FROM Products ");
            string str1 = string.Format("SELECT top 1 Customer_Id as c ,Customer.Name,Customer.Age ,Customer.Address,Count(*) as MyCount FROM Orders JOIN Customer ON Orders.Customer_Id= Customer.Id Group By Customer_Id,Customer.Name,Customer.Age,Customer.Address Order By MyCount DESC");

            string str2 = string.Format("SELECT  top 1 B.Customer_Id, B.CustName ,B.CustAge,B.CustAddress,SUM(CAST(B.Price AS INT)) as priceSum FROM (SELECT Orders.Customer_Id, Orders.Product_id,Customer.Id as custid, Customer.Name as CustName, Customer.Age as CustAge,Customer.Address as CustAddress, Products.Id ,Products.Price FROM Orders JOIN Products ON  Orders.Product_id = Products.Id JOIN Customer ON Orders.Customer_Id = Customer.Id) B GROUP BY B.Customer_Id,B.CustName,B.CustAge,B.CustAddress order by priceSum desc");

            string str3 = string.Format("SELECT B.Id,B.Name,B.Address,B.Age, B.Product_id FROM (SELECT * FROM Customer LEFT OUTER JOIN Orders ON Customer.Id = Orders.Customer_Id )B WHERE B.Product_id IS NULL");

            string str5 = string.Format("SELECT B.Customer_Id,B.CustName,B.CustAge, B.CustAddress, SUM(CAST(B.Price AS INT)) as priceSum from" +
                "(SELECT Orders.Customer_Id, Orders.Product_id, Products.Price, Customer.Name as CustName, Customer.Age as CustAge, Customer.Address as CustAddress  FROM Orders JOIN Products ON  Orders.Product_id = Products.Id JOIN Customer ON Orders.Customer_Id = Customer.Id)B " +
                "GROUP BY B.Customer_Id, B.CustName, B.CustAge, B.CustAddress");

            string str6 = string.Format("SELECT B.Customer_Id,B.CustName,B.CustAge, B.CustAddress, AVG(CAST(B.Price AS INT)) as priceAVG from "+
                "(SELECT Orders.Customer_Id, Orders.Product_id, Products.Price, Customer.Name as CustName, Customer.Age as CustAge, Customer.Address as CustAddress  FROM Orders JOIN Products ON  Orders.Product_id = Products.Id JOIN Customer ON Orders.Customer_Id = Customer.Id)B "+
                "GROUP BY B.Customer_Id, B.CustName, B.CustAge, B.CustAddress");

            string str7A = string.Format("SELECT AVG(CAST(B.Price AS INT))FROM(SELECT Orders.Product_id, Products.Price AS Price FROM  Orders JOIN Products ON Orders.Product_id = Products.Id) B");

            string str7 = string.Format("SELECT G.CustName,G.CustAddress,G.CustAge, G.priceSum FROM(SELECT B.Customer_Id,B.CustName,B.CustAge, B.CustAddress, SUM(CAST(B.Price AS INT)) as priceSum from "+
                "(SELECT Orders.Customer_Id, Orders.Product_id, Products.Price, Customer.Name as CustName, Customer.Age as CustAge, Customer.Address as CustAddress  FROM Orders JOIN Products ON  Orders.Product_id = Products.Id JOIN Customer ON Orders.Customer_Id = Customer.Id)B "+
                "GROUP BY B.Customer_Id, B.CustName, B.CustAge, B.CustAddress)G WHERE G.priceSum > (SELECT AVG(CAST(L.Price AS INT))FROM(SELECT Orders.Product_id, Products.Price AS Price FROM  Orders JOIN Products ON Orders.Product_id = Products.Id) L)");

            string str8 = string.Format("SELECT SUM(CAST(L.Price AS INT)) as S FROM(SELECT Orders.Product_id,Products.Price AS Price FROM  Orders JOIN Products ON Orders.Product_id = Products.Id) L");

            string str9 = string.Format("SELECT top 1 B.Name , COUNT(B.Product_id) as CountProd FROM(SELECT Orders.Product_id, Products.Name FROM Orders JOIN Products ON Orders.Product_id = Products.Id)B GROUP BY B.Product_id,B.Name Order BY CountProd DESC");

            string str10 = string.Format("SELECT B.Id,B.Name,B.Category,B.Vendor, B.Price FROM(SELECT * FROM Products LEFT OUTER JOIN Orders ON Products.Id = Orders.Product_id)B WHERE B.Customer_Id IS NULL");

            Console.WriteLine("Enter operation Number from list : ");
            Console.WriteLine("1  - return the user who made the maximum orders");
            Console.WriteLine("2 - return the user who has made  orders for the maximum amount $");
            Console.WriteLine("3 - return users who did not make orders");
            
            Console.WriteLine("5 - return users, and for each user his orders amount $");
            Console.WriteLine("6 - return users, and for each user his average orders amount $");
            Console.WriteLine("7 - return users whose purchases exceeded the average amount");
            Console.WriteLine("8 - return the sum of all orders of all customers together");
            Console.WriteLine("9 - return  the most popular product.");
            Console.WriteLine("10 - return items that were not purchased .");
            string answer = Console.ReadLine();
            int num = CheckForInt(answer);
            string myStr = "";
            switch (num)
            {
                case 1:
                    myStr = str1;
                    break;
                case 2:
                    myStr = str2;
                    break;
                case 3:
                    myStr = str3;
                    break;
                case 5:
                    myStr = str5;
                    break;
                case 6:
                    myStr = str6;
                    break;
                case 7:
                    myStr = str7;
                    break;
                case 8:
                    myStr = str8;
                    break;
                case 9:
                    myStr = str9;
                    break;
                case 10:
                    myStr = str10;
                    break;

            }

            SqlCommand cmd = new SqlCommand(myStr, con);           
            SqlDataReader reader = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
            switch(num)
            {
                case 1:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("First Name = {0}", reader["Name"]);
                        Console.WriteLine("Age = {0}", reader["Age"]);
                        Console.WriteLine("Address = {0}", reader["Address"]);
                        Console.WriteLine("Number of purchases = {0}", reader["MyCount"]);
          
                    }
                    break;
                case 2:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("First Name = {0}", reader["CustName"]);
                        Console.WriteLine("Age = {0}", reader["CustAge"]);
                        Console.WriteLine("Address = {0}", reader["CustAddress"]);
                        Console.WriteLine("Sum of purchases $ = {0}", reader["priceSum"]);

                    }
                    break;
                case 3:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("First Name = {0}", reader["Name"]);
                        Console.WriteLine("Age = {0}", reader["Age"]);
                        Console.WriteLine("Address = {0}", reader["Address"]);
                    }
                    break;
                case 5:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("First Name = {0}", reader["CustName"]);
                        Console.WriteLine("Age = {0}", reader["CustAge"]);
                        Console.WriteLine("Address = {0}", reader["CustAddress"]);
                        Console.WriteLine("Price of all orders  = {0}", reader["PriceSum"]);
                    }
                    break;
                case 6:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("First Name = {0}", reader["CustName"]);
                        Console.WriteLine("Age = {0}", reader["CustAge"]);
                        Console.WriteLine("Address = {0}", reader["CustAddress"]);
                        Console.WriteLine("Price of all orders  = {0}", reader["priceAVG"]);
                    }
                    break;
                case 7:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("First Name = {0}", reader["CustName"]);
                        Console.WriteLine("Age = {0}", reader["CustAge"]);
                        Console.WriteLine("Address = {0}", reader["CustAddress"]);
                        Console.WriteLine("Price of all orders  = {0}", reader["priceSum"]);
                    }
                    break;
                case 8:
                    while (reader.Read())
                    {
                        Console.WriteLine("SUM = {0}", reader[0]);
                    }
                    break;
                case 9:
                    while (reader.Read())
                    {
                        Console.WriteLine("Name of product= {0}", reader["Name"]);
                        Console.WriteLine("Count of purchases = {0}", reader["Countprod"]);
                    }
                    break;
                case 10:
                    while (reader.Read())
                    {
                        Console.WriteLine("Id= {0}", reader[0]);
                        Console.WriteLine("Product Name = {0}", reader["Name"]);
                        Console.WriteLine("Price = {0}", reader["Price"]);
                        Console.WriteLine("Category = {0}", reader["Category"]);
                        Console.WriteLine("Vendor = {0}", reader["Vendor"]);
                        Console.WriteLine("Price of all orders  = {0}", reader["Price"]);
                    }
                    break;
            }

            con.Close();
            Console.ReadLine();
        }
    }
}
