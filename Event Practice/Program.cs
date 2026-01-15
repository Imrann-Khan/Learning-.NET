
public delegate void firstMethodHandler(string message);

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        firstMethodHandler del1 = new(firstMethod);
        del1("Delegate");
    }

    public static void firstMethod(string message)
    {
        Console.WriteLine("Method performed by Delegate");
        Console.WriteLine($"The string is ${message}.");
    }

}