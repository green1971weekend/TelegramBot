using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Core.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class StartCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = "/start";

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var username = message.Chat.Username ?? message.Chat.Id.ToString();

            await client.SendTextMessageAsync(chatId, $"Привет @{username}! Я твой персональный бот помощник в изучении English:) Моя задача - перевести на Русский введенное тобой Английское слово, давая подходящие иллюстрации для твоего запоминания. Let's begin.. Введи команду /translate [Your word] чтобы заставить меня работать.                                                                                        .");
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
