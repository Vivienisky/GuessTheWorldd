using System;
using System.Collections.Generic;

namespace GuessTheWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            var ui = new ConsoleUI();
            var wordBank = new WordBank();
            
            ui.ShowWelcomeMessage();
            
            bool playAgain = true;
            
            while (playAgain)
            {

                DifficultyType difficultyType = ui.ChooseDifficulty();
                var difficulty = new Difficulty(difficultyType);
                

                Word word = wordBank.Generate(difficulty);
                
  
                var game = new Game(difficulty.Attempts);
                

                game.RunGameLoop(ui, word);
                playAgain = ui.AskForNewGame();
                
                if (playAgain)
                {
                    Console.Clear();
                    ui.ShowWelcomeMessage();
                }
            }
            
            Console.WriteLine("Спасибо за игру! До свидания!");
            Console.ReadKey();
        }
    }
}