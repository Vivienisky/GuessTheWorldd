using System;

namespace GuessTheWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(attemptsMax:10);
            game.AddLetter('a', isGuessed: true);
        }
    }
}