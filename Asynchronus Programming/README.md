# Asynchronous vs Synchronous Programming (C#)

This mini project demonstrates the difference between synchronous (blocking) and asynchronous (non-blocking) execution in C# using `Thread.Sleep` vs `Task.Delay`.

## What’s Inside

- Synchronous example: `Method1()` uses `Thread.Sleep(5000)` and blocks the thread.
- Asynchronous example: `Method2()` uses `await Task.Delay(5000)` and does not block the calling thread.
- Entry point: see `Main()` in `Program.cs`.

## Code Overview

```csharp
public static void Main(string[] args)
{
    Console.WriteLine("Main method started..");
    //Method1();        // Sync (blocking)
    Method2();          // Async (non-blocking)
    Console.WriteLine("Main method ended.");
}

public static void Method1() // Synchronous
{
    Console.WriteLine("Method1 started....");
    Thread.Sleep(5000);              // Blocks the thread for ~5s
    Console.WriteLine("Methid1 ended.");
}

public async static void Method2() // Asynchronous
{
    Console.WriteLine("Method1 started....");
    await Task.Delay(5000);          // Yields without blocking the thread
    Console.WriteLine("Methid1 ended.");
}
```

Key differences:
- `Thread.Sleep(ms)` pauses the current thread, blocking any work on it until the sleep completes.
- `await Task.Delay(ms)` asynchronously waits without blocking the thread, allowing other work to run.

Note: In production, prefer `async Task` return types instead of `async void` (except for event handlers) to allow proper awaiting and error handling.

## How to Run

From the project folder:

```powershell
cd "D:\CP Solves\CP Solves\Course\Asynchronus Programming"
dotnet run
```

You should see output similar to:

```
Main method started..
Method1 started....
Methid1 ended.
Main method ended.
```

## Try Both Modes

- Run synchronous (blocking):
  - In `Main()`, uncomment `Method1();` and comment out `Method2();`.
  - Re-run `dotnet run`.
  - Observe that `Main method ended.` is printed only after the 5-second sleep completes.

- Run asynchronous (non-blocking):
  - In `Main()`, comment out `Method1();` and keep `Method2();`.
  - Re-run `dotnet run`.
  - `Main method ended.` can print immediately after `Method2()` is invoked (since `async void` returns without waiting), while the async body completes later.

## Takeaways

- **Synchronous (blocking):** Simple but stalls the thread, reducing responsiveness.
- **Asynchronous (non-blocking):** Improves responsiveness and throughput by not blocking threads during waits.
- **Best practice:** Use `async Task`/`async Task<T>` for methods and `await` them to control flow and handle errors.

## Project Files

- Source: Asynchronus Programming/Program.cs
- This README: Asynchronus Programming/README.md
