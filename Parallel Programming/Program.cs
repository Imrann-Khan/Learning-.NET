using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Program
{
    // 1. Data Parallelism

    // class Program
    // {
    //     public static void Main(String[] args)
    //     {
    //         var options = new ParallelOptions()
    //         {
    //             MaxDegreeOfParallelism = 3 // Set no. of threads manually for multithreaded
    //         };
    //         // Basic for loop
    //         Console.WriteLine("The app is running");
    //         for(int i = 0; i < 10; i++)
    //         {
    //             Console.WriteLine($"{i}  thread = {Thread.CurrentThread.ManagedThreadId}");
    //         }

    //         Console.WriteLine();

    //         // Parallel for loop
    //         Parallel.For(0, 10, options, num =>{
    //             Console.WriteLine($"{num}  thread = {Thread.CurrentThread.ManagedThreadId}");
    //         });

    //         // Single threaded programming
    //         // DateTime StartDateTime = DateTime.Now;
    //         // Stopwatch stopWatch = new Stopwatch();

    //         // Console.WriteLine("For Loop Execution start");
    //         // stopWatch.Start();
    //         // for (int i = 0; i < 10; i++)
    //         // {
    //         //     long total = DoSomeIndependentTask();
    //         //     Console.WriteLine("{0} - {1}", i, total);
    //         // }
    //         // DateTime EndDateTime = DateTime.Now;
    //         // Console.WriteLine("For Loop Execution end ");
    //         // stopWatch.Stop();
    //         // Console.WriteLine($"Time Taken to Execute the For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

    //         // // Parallel programming (use multiple threads)
    //         // DateTime StartDateTime = DateTime.Now;
    //         // Stopwatch stopWatch = new Stopwatch();
    //         // Console.WriteLine("Parallel For Loop Execution start");
    //         // stopWatch.Start();

    //         // Parallel.For(0, 10, i => {
    //         //     long total = DoSomeIndependentTask();
    //         //     Console.WriteLine("{0} - {1}", i, total);
    //         // });
    //         // DateTime EndDateTime = DateTime.Now;
    //         // Console.WriteLine("Parallel For Loop Execution end ");
    //         // stopWatch.Stop();
    //         // Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

    //         // // Parallel programming (use multiple threads)
    //         // DateTime StartDateTime = DateTime.Now;
    //         // Stopwatch stopWatch = new Stopwatch();
    //         // Console.WriteLine("Parallel For Loop Execution start");
    //         // stopWatch.Start();

    //         // Parallel.For(0, 10, i => {
    //         //     long total = DoSomeIndependentTask();
    //         //     Console.WriteLine("{0} - {1}", i, total);
    //         // });
    //         // DateTime EndDateTime = DateTime.Now;
    //         // Console.WriteLine("Parallel For Loop Execution end ");
    //         // stopWatch.Stop();
    //         // Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

    //     }

    //     static long DoSomeIndependentTask()
    //     {
    //         long total = 0;
    //         for (int i = 1; i < 100000000; i++)
    //         {
    //             total += i;
    //         }
    //         return total;
    //     }
    // }

    // 2. Task Parallelism
    class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            // Sequential manner in same thread
            // Method1();
            // Method2();
            // Method3();
            // Parallel manner in different thread
            int x = 0, y = 0, z = 0;
            Parallel.Invoke(
                () => x = Method1(),
                () => y = Method2(),
                () => z = Method3()
                );
            stopwatch.Stop();

            Console.WriteLine($"Methods ran on thread IDs: {x}, {y}, and {z}. Highest ID: {Math.Max(Math.Max(x, y), z)}");
            Console.WriteLine($"Parallel execution took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
        static int Method1()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return Thread.CurrentThread.ManagedThreadId;
        }
        static int Method2()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return Thread.CurrentThread.ManagedThreadId;
        }
        static int Method3()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
