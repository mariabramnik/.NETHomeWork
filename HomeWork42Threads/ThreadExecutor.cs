using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork42Threads
{
    class ThreadExecutor
    {
        object key = new object();
        private bool disposed = false;
        private Thread t;
        //queue of threads
        public static Queue<Thread> threadsQueue = new Queue<Thread>();
        //create the thread for function Execute()
        public ThreadExecutor()
        {
            t = new Thread(new ThreadStart(this.ThreadFunction));
            t.Start();

        }
        ~ThreadExecutor()
        {
            Dispose();
        }

        public void Add(Thread thread)
        {

            lock(key)
            {
                threadsQueue.Enqueue(thread);
            }
        }
        //check if anyone is in the threadsQueue
        //if someone is there,makes start to firstes thread in threadsQueue
        //and move the threadsQueue forward 
        public void Execute()
        {
            lock (key)
            {
                if (threadsQueue.Count > 0)
                {
                    while (threadsQueue.Count > 0)
                    {
                        Thread thread = threadsQueue.Dequeue();
                        thread.Start();
                        thread.Join();
                    }
                }
            }
        }
        // runs while the object exists
        public void ThreadFunction()
        {
            while (!disposed)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    break;
                }
                Execute();
            }
        }
        public void Dispose()
        {
            disposed = true;
            t.Interrupt();
            t.Join();

        }

    }
}
