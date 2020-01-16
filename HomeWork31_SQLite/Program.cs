using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork31_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassDAO cd = new ClassDAO();
            cd.SQLiteConnectionOpen();
            //cd.UpdateClassNumberOfStudent();
            //cd.UpdateClassNumberOfVIP();
            //cd.UpdateClassAgeAverage();
            //cd.UpdateClassMostPopularCity();
            //cd.UpdateClassOldestVIP();
            //cd.UpdateClassYoungestVIP();
            
            Dictionary<Class,List<Student>> dictRes = cd.GetMapClassToStudentsDictionary();
            
            foreach(KeyValuePair<Class,List<Student>> keyValue in dictRes)
            {
                Console.WriteLine($"Class : {keyValue.Key} : ");
                List<Student> list = keyValue.Value;
                foreach (Student s in list)
                {
                    Console.WriteLine($"    { s}");
                }
            }
            
            List<Student> listRes = cd.GetStudentFromClass(2);
            Console.WriteLine("List Students from class Id = 2");
            foreach (Student s in listRes)
            {
                Console.WriteLine($"    { s}");
            }
            cd.SQLiteConnectionClose();
            Console.ReadLine();
            
        }
    }
}
