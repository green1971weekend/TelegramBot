using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;
using TelegramBot.Core.Models;

namespace TelegramBot.Core.Services
{
    /// <summary>
    /// Requests handler.
    /// </summary>
    public class HttpHandler
    {
        /// <summary>
        /// Get JSON model from Yandex API.
        /// </summary>
        /// <param name="userInput">User text input.</param>
        /// <param name="api_key">Key.</param>
        /// <returns>JSON model.</returns>
        public async Task<YandexModel> GetYandexTranslateResponseAsync(string userInput, string api_key)
        {
            YandexModel response = await "https://translate.yandex.net/"
                .AppendPathSegments("api", "v1.5", "tr.json", "translate")
                .SetQueryParams(new { key = api_key, text = userInput, lang = "en-ru" })
                .GetAsync()
                .ReceiveJson<YandexModel>();
            return response;
        }
        /// <summary>
        /// Get JSON model from Unsplash API.
        /// </summary>
        /// <param name="userInput">User text input.</param>
        /// <param name="api_key">Key.</param>
        /// <returns>JSON model.</returns>
        public async Task<RootObject> GetImageModelAsync(string userInput, string api_key)
        {
            try
            {
                var response = await "https://api.unsplash.com/"
                    .AppendPathSegments("photos", "random")
                    .SetQueryParams(new { client_id = api_key, query = userInput })
                    .GetAsync()
                    .ReceiveJson<RootObject>();
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get JSON model from Datamuse API.
        /// </summary>
        /// <param name="userInput">User text input.</param>
        /// <returns>JSON model.</returns>
        public async Task<WordModel> GetWordModelAsync(string userInput)
        {
            var response = await "https://api.datamuse.com/"
                .AppendPathSegment("words")
                .SetQueryParams(new { ml = userInput, qe = "ml", max = "1", md = "d" })
                .GetAsync()
                .ReceiveJson<WordModel>();
            return response;
        }
    }
}
