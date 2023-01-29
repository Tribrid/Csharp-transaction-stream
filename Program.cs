using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Stream
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        dynamic stream = await client.GetStreamAsync("https://api.whale-alert.io/v1/transactions?api_key=your-api-key");
        
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var transactions = reader.ReadLine();
                dynamic json = JsonConvert.DeserializeObject(transactions);
                Console.WriteLine(json);

            }
        }
        Console.ReadLine();
    }
}