using System;
using System.Collections.Generic;

namespace GuessTheWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(attemptsMax:10);
            game.AddLetter('a', isGuessed: true);
            
            
            var usedLetters = new HashSet<char>();
            usedLetters.Add('a');
            usedLetters.Add('b');
            
            char newLetter = 'a';
            
            if (!usedLetters.Contains(newLetter))
                usedLetters.Add('a');
            
            var dictionary =  new Dictionary<DifficultyType, int>();
            dictionary[DifficultyType.Easy] = 4;
            dictionary[DifficultyType.Normal] = 2;
            dictionary[DifficultyType.Hard] = 0;

            if (dictionary.TryGetValue(DifficultyType.Easy, out int result))
            {
                
            }

        }

        private void InitCharactersArray(int maxAttempts)
        {
            var characters = new char[maxAttempts];
        }
    }
}