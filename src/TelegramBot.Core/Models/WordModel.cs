using System;

namespace TelegramBot.Core.Models
{
    /// <summary>
    /// Root JSON object of context word.
    /// </summary>
    public class WordModel
    {
        public Word[] Words { get; set; }
    }

    /// <summary>
    /// Specific word.
    /// </summary>
    public class Word
    {
        public string word { get; set; }
        public int score { get; set; }
        public string[] tags { get; set; }
        public string[] defs { get; set; }
    }

}
