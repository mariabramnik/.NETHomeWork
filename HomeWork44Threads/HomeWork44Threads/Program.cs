using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork44Threads
{
    class Program
    {
        static AutoResetEvent are = new AutoResetEvent(false);
        public static void CreateStudent()
        {

            are.WaitOne();
            Console.WriteLine("Student created");
            are.Set();
        }
        public static void CreateCourse()
        {
           
            are.WaitOne();
            Console.WriteLine("Course created");
            are.Set();
        }
        public static void UpdateStudent()
        {
            are.WaitOne();
            Console.WriteLine("Student updated");
            are.Set();
        }
        public static void UpdateCourse()
        {
            Thread.Sleep(1000);
            are.WaitOne();
            Console.WriteLine("Course updated");  
            are.Set();
        }
        public static void RemoveStudent()
        {
            Thread.Sleep(1000);
            are.WaitOne();
            Console.WriteLine("Student removed");
            are.Set();
        }
        public static void RemoveCourse()
        {
            Thread.Sleep(1000);
            are.WaitOne();
            Console.WriteLine("Course removed");
            are.Set();
        }
        public static void GetAllStudents()
        {
            Thread.Sleep(1000);
            are.WaitOne();
            Console.WriteLine("Students: dudy,masha,inna,mark,daniel");
            are.Set();
        }
        public static void GetAllCourses()
        {
            Thread.Sleep(1000);
            are.WaitOne();
            Console.WriteLine("Courses: C#,C++,C,Java,PHP");
            are.Set();
        }
        //will be executed first, other waiting for  him
        public static void DBConnection()
        {
            Console.WriteLine("DB is connected");
            Thread.Sleep(4000);
            //opened the gate
            are.Set();
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(CreateStudent));
            Thread t2 = new Thread(new ThreadStart(CreateCourse));
            Thread t3 = new Thread(new ThreadStart(UpdateStudent));
            Thread t4 = new Thread(new ThreadStart(UpdateCourse));
            Thread t5 = new Thread(new ThreadStart(RemoveStudent));
            Thread t6 = new Thread(new ThreadStart(RemoveCourse));
            Thread t7 = new Thread(new ThreadStart(GetAllStudents));
            Thread t8 = new Thread(new ThreadStart(GetAllCourses));
            Thread t9 = new Thread(new ThreadStart(DBConnection));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
            t8.Start();
            // t9 will be executed first, other waiting for  him
            t9.Start();
            Console.ReadLine();

        }
    }
}
