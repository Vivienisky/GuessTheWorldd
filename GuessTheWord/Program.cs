using System;

namespace GuessTheWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char[] guessedLetters = new[] { 'h' , 'a' , 'e' , 'i' , 'o' , 'u'};
            
            var easyMode = new Difficulty(DifficultyType.Easy);
            var normalMode = new Difficulty(DifficultyType.Normal);
            var hardMode = new Difficulty(DifficultyType.Hard);
            
            var wordBank = new WordBank();
            var generatedWord = wordBank.Generate(normalMode);
            generatedWord.DebugValue();
            Console.WriteLine($"{generatedWord.GetMask(guessedLetters)}");

            

            
        }
    }
}