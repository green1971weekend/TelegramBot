using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using TelegramBot.Core.Models;
using TelegramBot.Core.Services;

namespace TelegramBot.Core.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class TranslateCommand : ITelegramCommand
    {
        private readonly API_Config _api;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="key">Key.</param>
        public TranslateCommand(API_Config api)
        {
            if (api == null)
                throw new ArgumentNullException(nameof(api));
            else
            _api = api;
        }

        /// <inheritdoc/>
        public string Name { get; } = "/translate";

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var handler = new HttpHandler();
            var chatId = message.Chat.Id;

            var hasError = false;
            var userInput = string.Empty;
            var translatedText = string.Empty;
            var picture = string.Empty;
            var synonyms = string.Empty; 

            try
            {
                string[] words = message.Text.Split(' ');
                if (words.Length != 2)
                {
                    hasError = true;
                }
                userInput = words[1];
                if (hasError)
                {
                    throw new ArgumentException("Неккоректный ввод.. После команды /translate может быть только одно слово. Пример использования: /translate [WORD]");
                }

                // Yandex
                var translateYandexResponse = await handler.GetYandexTranslateResponseAsync(userInput, _api.YandexAPI);

                foreach (var translatedWord in translateYandexResponse.Text)
                {
                    translatedText = string.Concat(translatedWord);
                }
                await client.SendTextMessageAsync(chatId, translatedText);

                //Word
                //var wordModel = await handler.GetWordModelAsync(word);
                //foreach(Word synonym in wordModel.Words)
                //{
                //    synonyms += synonym.word + " ";
                //}

                // Image
                var pictureModel = await handler.GetImageModelAsync(userInput, _api.UnsplashAPI);
                if (pictureModel != null)
                {
                    picture = pictureModel.urls.full;
                    await client.SendPhotoAsync(chatId, new InputOnlineFile(picture));
                    await client.SendTextMessageAsync(chatId, "Подобрал для тебя самое лучшее из интернета:)");
                }
                else
                {
                    throw new ArgumentException("К сожалению не могу найти для тебя подходящую иллюстрацию для этого слова... Попробуй что-нибудь еще.");
                }
            }
            catch (Exception ex)
            {
                translatedText = ex.Message;
                await client.SendTextMessageAsync(chatId, translatedText);
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
