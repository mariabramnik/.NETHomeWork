using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork40Threads
{
    class Program
    {
        public static string myAnswer;
        public static void StopWatchFunc(object ob)
        {
            int res = (int)ob;
            myAnswer = Console.ReadLine();
             
        }

        static void Main(string[] args)
        {
            bool end = false;
            Random ran = new Random();
            int number1 = ran.Next(1, 9);
            int number2 = ran.Next(1, 9);
            int res = number1 * number2;

            while (end == false)
            {
                Console.WriteLine($"Enter your answer: {number1} * {number2}");
               // ParameterizedThreadStart methodThreadStart = StopWatchFunc;
                Thread t = new Thread(StopWatchFunc);
                t.Start(res);
                t.Join(5000);
                if (!(myAnswer is null) && Int32.Parse(myAnswer) == res)
                {
                    Console.WriteLine("You are great!");
                    end = true;
                }
                else
                {
                    Console.WriteLine("Error!!");

                }
            }
            Console.ReadLine();
        }
       
    }
}
