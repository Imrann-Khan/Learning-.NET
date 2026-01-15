using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Main method started..");
        //Method1();
        //Method2();
        double temp = await GetWeather();
        Console.WriteLine($"{temp} C");
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

    public async static Task<double> GetWeather()
    {
        double temp = 0.0;
        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast?latitude=23.7104&longitude=90.4074&hourly=temperature_2m,relative_humidity_2m");
            HttpResponseMessage response = await client.GetAsync("");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
            {
                temp = doc.RootElement.GetProperty("hourly").GetProperty("temperature_2m")[0].GetDouble();
            }
        }
        return temp;
    }
}