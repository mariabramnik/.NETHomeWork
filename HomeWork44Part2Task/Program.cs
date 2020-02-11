using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork44Part2Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();

            Task<int>t1 = new Task<int>(() =>
            {
                int time = ran.Next(1000, 2000);
                Thread.Sleep(time);
                Console.WriteLine($"I'm Task ,my id = {Thread.CurrentThread.ManagedThreadId}, my tasl id = {Task.CurrentId}");
                return time;
                
            });
            Task<int> t2 = new Task<int>(() =>
            {
                int time = ran.Next(1000, 2000);
                Thread.Sleep(time);
                Console.WriteLine($"I'm Task ,my id = {Thread.CurrentThread.ManagedThreadId}, my tasl id = {Task.CurrentId}");
                return time;

            });
            var tasks = new Task[2];
            tasks[0] = t1;
            tasks[1] = t2;

            //t1.Start();
            //t2.Start();
            // int res = t1.Result;
            // Console.WriteLine(res);
            //Task.WaitAll(t1, t2);
            // Console.WriteLine($"{t1.Result},{t2.Result}");

            foreach (Task t in tasks)
            {
                t.Start();
            }
  
            int index = Task.WaitAny(tasks);  
            // Can find out who was the first by tasks id or by index of task in array or by status.
           // Console.WriteLine($"index = {index}");
            foreach(Task t in tasks)
            {
                Console.WriteLine($"id = {t.Id} , status = {t.Status}");
            }
            int fastId = ((Task<int>)tasks[index]).Id;
            int fastResult = ((Task<int>)tasks[index]).Result;
            Console.WriteLine($"result of fastest task with id = {fastId} = {fastResult}");
           
         
            Console.ReadLine();
        }
    }
}
