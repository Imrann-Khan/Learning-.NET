# Asynchronous vs Synchronous Programming (C#)

This mini project compares synchronous (`Thread.Sleep`) vs asynchronous (`await Task.Delay`) execution and adds a simple weather fetch using Open-Meteo (no API key needed).

## What’s Inside
- Synchronous example: `Method1()` uses `Thread.Sleep(5000)` and blocks the thread.
- Asynchronous example: `Method2()` uses `await Task.Delay(5000)` and yields without blocking.
- HTTP example: `GetWeather()` calls Open-Meteo and reads `temperature_2m` from the JSON response.
- Entry point: `Main()` currently calls `GetWeather()` and prints the temperature.

## Code Overview

```csharp
public static async Task Main(string[] args)
{
    Console.WriteLine("Main method started..");
    //Method1();        // Sync (blocking)
    //Method2();        // Async (non-blocking)
    double temp = await GetWeather();
    Console.WriteLine($"{temp} C");
    Console.WriteLine("Main method ended.");
}

public static void Method1() // Synchronous
{
    Thread.Sleep(5000); // Blocks the thread
}

public async static void Method2() // Asynchronous
{
    await Task.Delay(5000); // Yields without blocking the thread
}

public async static Task<double> GetWeather()
{
    using(var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast?latitude=23.7104&longitude=90.4074&hourly=temperature_2m,relative_humidity_2m");
        HttpResponseMessage response = await client.GetAsync("");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
        {
            return doc.RootElement.GetProperty("hourly").GetProperty("temperature_2m")[0].GetDouble();
        }
    }
}
```

## How to Run
```powershell
cd "D:\CP Solves\CP Solves\Course\Asynchronus Programming"
dotnet run
```
Sample output:
```
Main method started..
30.2 C
Main method ended.
```

## Try Both Modes
- Synchronous (blocking): uncomment `Method1();`, comment out others; observe the 5s pause blocks the thread.
- Asynchronous (non-blocking): uncomment `Method2();` instead; the call yields while waiting.
- Weather fetch: keep `GetWeather()` as-is to see JSON parsing of `temperature_2m`.

## Takeaways
- `Thread.Sleep` blocks; `await Task.Delay` does not.
- `await` is required before accessing async results or JSON models.
- Parsing JSON: either use `JsonDocument` (shown) or define POCOs for cleaner code.

