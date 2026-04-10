using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheWord
{
    public class WordBank
    {
        private Word[] _words;
        private List<Word> _wordsList;

        public WordBank()
        {
            _words = new[]
            {
                new Word("ide"),
                new Word("cat"),
                new Word("dog"),
                new Word("home"),
                new Word("cold"),
                new Word("unity"),
                new Word("laptop"),
                new Word("family"),
                new Word("teacher"),
                new Word("computer"),
                
                
            };
            
            _wordsList = new List<Word>()
            {
                new Word("ide"),
                new Word("cat"),
                new Word("dog"),
                new Word("home"),
                new Word("cold"),
                new Word("unity"),
                new Word("laptop"),
                new Word("family"),
                new Word("teacher"),
                new Word("computer"),
                
                
            };
        }

        public Word Generate(Difficulty difficulty)
        {
            var words = _words.Where(word => word.Length >= difficulty.MinWordLenght &&
                                             word.Length <= difficulty.MaxWordLenght).ToArray();
            var random = new Random();
            var index = random.Next(_words.Length);
            return _words[index];
        }

    }
}