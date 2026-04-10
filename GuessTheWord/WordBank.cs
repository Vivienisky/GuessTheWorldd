using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheWord
{
    public class WordBank
    {
        private List<Word> _wordsList;

        public WordBank()
        {
            _wordsList = new List<Word>()
            {
                new Word("IDE"),
                new Word("CAT"),
                new Word("DOG"),
                new Word("HOME"),
                new Word("COLD"),
                new Word("UNITY"),
                new Word("LAPTOP"),
                new Word("FAMILY"),
                new Word("TEACHER"),
                new Word("COMPUTER"),
                new Word("PROGRAMMING"),
                new Word("DEVELOPER"),
                new Word("GAME"),
                new Word("CODE"),
                new Word("ALGORITHM"),
            };
        }

        public Word Generate(Difficulty difficulty)
        {
  
            var words = _wordsList.Where(word => word.Length >= difficulty.MinWordLenght &&
                                                 word.Length <= difficulty.MaxWordLenght).ToList();
            
     
            if (!words.Any())
            {
                words = _wordsList;
                Console.WriteLine($"Нет слов длиной от {difficulty.MinWordLenght} до {difficulty.MaxWordLenght}. Используются все слова.");
            }
            
            var random = new Random();
            var index = random.Next(words.Count);
            return words[index];
        }
    }
}