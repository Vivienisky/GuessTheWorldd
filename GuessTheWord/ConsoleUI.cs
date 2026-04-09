using System;

namespace GuessTheWord
{
    public class ConsoleUI
    {
        public char InputLetter()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Input letter:");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                bool isTooBig = input.Length != 1;

                if (isTooBig)
                    continue;

                bool IsLetter = char.IsLetter(input[0]);
                if (IsLetter)
                    return input.ToUpper()[0];

            } while (true);
        }

        public DifficultyType ChooseDifficulty()
        {
            Console.WriteLine("Choose difficulty:\n" +
                              "1 - Easy\n" +
                              "2 - Normal\n" +
                              "3 - Hard");

            string result = Console.ReadLine();

            if (result != "1" && result != "2" && result != "3")
            {
                Console.WriteLine("Invalid input! Default = Easy");
                return DifficultyType.Easy;
            }

            switch (result)
            {
                case "1":
                    return DifficultyType.Easy;
                case "2":
                    return DifficultyType.Normal;
                case "3":
                    return DifficultyType.Hard;
            }

            return DifficultyType.Easy;
        }

        public void ShowUsedLetters(char[] letters)
        {
            Console.WriteLine("Used letters:");

            foreach (char letter in letters)
            {
                Console.Write($"{letter} ");
            }

            Console.WriteLine();
        }

        public void ShowWord(string word)
        {
            Console.WriteLine($"Word: {word}");
        }

        public void ShowLeftAttempts(int leftAttempts)
        {
            Console.WriteLine($"Left attempts: {leftAttempts}");
        }

        public void ShowGameResult(bool isWin)
        {
            Console.WriteLine(isWin ? "You won!" : "You lost!");
        }


    }
}