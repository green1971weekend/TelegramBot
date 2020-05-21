using TelegramBot.Core.Commands;
using TelegramBot.Core.Interfaces;
using System.Collections.Generic;
using TelegramBot.Core.Models;
using Microsoft.Extensions.Options;
using System;

namespace TelegramBot.Core.Services
{
    /// <inheritdoc cref="ICommandService"/>
    public class CommandService : ICommandService
    {
        private readonly IEnumerable<ITelegramCommand> _commands;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="options">Receive API key.</param>
        public CommandService(IOptions<API_Config> options)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));

            _commands = new List<ITelegramCommand>
            {
                new StartCommand(),
                new TranslateCommand(options.Value),
                new UnknownCommand()
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ITelegramCommand> Get() => _commands;
    }
}
