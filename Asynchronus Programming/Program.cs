
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Main method started..");
        //Method1();
        Method2();
        Console.WriteLine("Main method ended.");
    }

    public static void Method1() //Without asynchronus programming
    {
        Console.WriteLine("Method1 started....");
        Thread.Sleep(5000);
        Console.WriteLine("Methid1 ended.");
    }

    public async static void Method2() //Asynchronus programming
    {
        Console.WriteLine("Method1 started....");
        //await Thread.Sleep(10000);
        await Task.Delay(5000);
        Console.WriteLine("Methid1 ended.");
    }
}