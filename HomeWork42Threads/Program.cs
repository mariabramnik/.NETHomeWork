using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork42Threads
{
    class Program
    {
        public static Random ran = new Random();
        public static void PrintHello()
        {
            Console.WriteLine("Hello");
        }
        public static void PrintSquare()
        {
            int length = ran.Next(5, 20);
            int width = ran.Next(5, 20);
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
        public static void MultyplicNumber()
        {
            int num1 = ran.Next(1, 10);
            int num2 = ran.Next(1, 10);
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        }
         public static  void PrintNumbers()
        {
            for(int i = 0; i < 20; i++)
            {
                Console.Write($" {i} ,");
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintHello);
            Thread t2 = new Thread(PrintSquare);
            Thread t3 = new Thread(MultyplicNumber);
            Thread t4 = new Thread(PrintNumbers);
            ThreadExecutor threadEx = new ThreadExecutor();
            threadEx.Add(t1);
            threadEx.Add(t2);
            threadEx.Add(t3);
            threadEx.Add(t4);
            threadEx.Execute();

            Console.ReadLine();
        }
    }
}
