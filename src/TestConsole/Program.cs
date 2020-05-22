using System;
using System.Threading.Tasks;
using TelegramBot.Core.Models;
using TelegramBot.Core.Services;

namespace TestConsole
{
    class Program
    {
        static async Task Main()
        {
            var synonyms = string.Empty;
            var handler = new HttpHandler();
            Console.Write("Вводим слово: ");
            string word = Console.ReadLine();

            try
            {
                //var httpClient = new HttpClient();
                //var response = await httpClient.GetAsync("");
                //var content = await response.Content.ReadAsStringAsync();
                //response.EnsureSuccessStatusCode();
                //var searchObjects = JsonConvert.DeserializeObject<RootObject>(content);
                //{
                //}

                var wordModel = await handler.GetWordModelAsync(word);

                foreach (Word synonym in wordModel.Words)
                {
                    synonyms += synonym.word + " ";
                }

                Console.WriteLine(synonyms);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error,message - {ex.Message}, and track {ex.StackTrace}");
            }

            Console.ReadLine();
        }
    }
}
