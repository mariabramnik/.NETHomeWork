using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork40ThreadsPart2
{
    class Program
    {
        //create static arrays . each cell contains 0;
        public static int[] numbers = new int[1000];
        public static int[] numbersMax = new int[1000000];
        public static int[] numbersMax2 = new int[1000000];
        //change 0 to 1 in hundred cells of the array named numbers
        public static void Set100ItemsInArray(object ob)
        {
            int ind = (int)ob;
            for (int i = ind; i < ind + 100; i++)
            {
                numbers[i] = 1;
            }
        }
        //change 0 to 1 in 100000 cells of the array named numbersMax
        public static void Set100000ItemsInArray(object ob)
        {
            int ind = (int)ob;
            for (int i = ind; i < ind + 100000; i++)
            {
                numbersMax[i] = 1;
            }
        }
        //change 0 to 1 in 100000 cells of the array named numbersMax2
        public static void Set100000ItemsInArray2(object ob)
        {
            int ind = (int)ob;
            for (int i = ind; i < ind + 100000; i++)
            {
                numbersMax2[i] = 1;
            }
        }

        static void Main(string[] args)
        {
            // s1 for measuring time code execution
            var s1 = Stopwatch.StartNew();
            //create array of threads
            Thread[] t = new Thread[10];
            //each thread will fill to 1 its patr of the array ;
            for (int i = 0, j = 0; i < 10; i++, j += 100)
            {
                t[i] = new Thread(Set100ItemsInArray);
                t[i].Start(j);
            }
            foreach (Thread t11 in t)
            {
                t11.Join();
            }
            s1.Stop();
            // printing time code execution
            Console.WriteLine((double)s1.Elapsed.TotalMilliseconds);

            //fill the aaray without threads
            int[] numbers2 = new int[1000];
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = 1;
            }
            s2.Stop();
            // printing time code execution 
            Console.WriteLine((double)s2.Elapsed.TotalMilliseconds);

            // s3 for measuring time code execution
            var s3 = Stopwatch.StartNew();
            //create array of threads
            Thread[] t2 = new Thread[10];
            for (int i = 0, j = 0; i < 10; i++, j += 100000)
            {
                t2[i] = new Thread(Set100000ItemsInArray);
                t2[i].Start(j);
            }
            foreach (Thread t22 in t2)
            {
                t22.Join();
            }
            s3.Stop();
            //time1 - time code execution
            double time1 = (double)s3.Elapsed.TotalMilliseconds;
            Console.WriteLine(time1);

            //fill an array of a million cells without threads
            int[] numbers4 = new int[1000000];
            var s4 = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                numbers4[i] = 1;
            }
            s4.Stop();
            //time2 - time code execution
            double time2 = (double)s4.Elapsed.TotalMilliseconds;
            Console.WriteLine(time2);


            // s5 for measuring time code execution
            var s5 = Stopwatch.StartNew();
            //using the threadPool 
            for (int i = 0, j = 0; i < 10; i++, j += 100000)
            {
                ThreadPool.QueueUserWorkItem(Set100000ItemsInArray2,j);

            }
            s5.Stop();
            //time2 - time code execution
            double time3 = (double)s5.Elapsed.TotalMilliseconds;
            Console.WriteLine(time3);
            //let's see which option is faster
            if(time3 < time2 && time3 < time1)
            {
                Console.WriteLine("ThreadPool runs fastest");
            }


            Console.ReadLine();
        }
    }
}
