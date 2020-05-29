using System;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.Core.Models;
using TelegramBot.Core.Services;

namespace TestConsole
{
    class Program
    {
        //static async Task Main()
        //{
            //var synonyms = string.Empty;
            //var handler = new HttpHandler();
            //Console.Write("Вводим слово: ");
            //string word = Console.ReadLine();

            //try
            //{
            //    var wordModel = await handler.GetWordModelAsync(word);
            //    var definition = wordModel[0].Defs[0].Remove(0, 2);
            //    synonyms += $"Определение к слову {wordModel[0].Word}: {definition}. Синонимы: " ;

            //    foreach (WordModel wordsss in wordModel.Skip(1))
            //    {
            //        wordsss.Word.Skip(1);
            //        synonyms += wordsss.Word + "; ";
            //    }
            //    Console.WriteLine(synonyms);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Some error,message - {ex.Message}, and track {ex.StackTrace}");
            //}

            //Console.ReadLine();
        //}
    }
}
