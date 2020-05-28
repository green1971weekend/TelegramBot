using System;
using System.Collections.Generic;

namespace TelegramBot.Core.Models
{
    /// <summary>
    /// Root JSON object of context word.
    /// </summary>
    public class WordModel
    {
        public string Word { get; set; }
        public int Score { get; set; }
        public string[] Tags { get; set; }
        public string[] Defs { get; set; }
    }

}
