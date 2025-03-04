using Pastel;
using Newtonsoft.Json;

public class Program
{
    static async Task Main()
    {
        var result = await MethodC();
        Console.WriteLine("Result of MethodC : ".Pastel(ConsoleColor.Yellow) + result);

        Console.ReadKey();
    }

    static async Task<int> MethodA()
    {
        return await Task.Run(() =>
        {
            int result = 0;
            Console.WriteLine("\nMethodA => ".Pastel(ConsoleColor.Yellow)+"Calculating result of complex mathematical operation...");
            for (int i = 1; i <= 100; i++)
            {
                result += (i * i);
            }

            Task.Delay(1000);
            Console.WriteLine("Result of MethodA : ".Pastel(ConsoleColor.Yellow) + result);
            return result;
        });
    }

    static async Task<string> MethodB()
    {
        int result = await MethodA();

        using (HttpClient client = new HttpClient())
        {
            string url = $"https://jsonplaceholder.typicode.com/todos/{result % 10 + 1}";
            Console.WriteLine("\nMethodB => ".Pastel(ConsoleColor.Yellow) + $"Fetching data from {url}");

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string urlContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Result of MethodB : ".Pastel(ConsoleColor.Yellow));
            Console.WriteLine(urlContent);
            return urlContent;
        }
    }

    static async Task<int> MethodC()
    {
        string result = await MethodB();
        Console.WriteLine("\nMethodC => ".Pastel(ConsoleColor.Yellow) +"Calculating the number of Key-Value pairs from the URL Content...");
        var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
        return keyValuePairs.Count();
    }
}