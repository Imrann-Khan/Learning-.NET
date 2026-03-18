using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Program
{
    class Program
    {
        public static void Main(String[] args)
        {
            // Basic for loop
            // Console.WriteLine("The app is running");
            // for(int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine($"{i}  thread = {Thread.CurrentThread.ManagedThreadId}");
            // }

            // Console.WriteLine();

            // Parallel for loop
            // Parallel.For(0, 10,num =>{
            //     Console.WriteLine($"{num}  thread = {Thread.CurrentThread.ManagedThreadId}");
            // });

            // Single threaded programming
            DateTime StartDateTime = DateTime.Now;
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("For Loop Execution start");
            stopWatch.Start();
            for (int i = 0; i < 10; i++)
            {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", i, total);
            }
            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine("For Loop Execution end ");
            stopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute the For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

            // Parallel programming (use multiple threads)
            DateTime StartDateTime = DateTime.Now;
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Parallel For Loop Execution start");
            stopWatch.Start();
       
            Parallel.For(0, 10, i => {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", i, total);
            });
            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine("Parallel For Loop Execution end ");
            stopWatch.Stop();
            Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

        }

        static long DoSomeIndependentTask()
        {
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }
    }
}
