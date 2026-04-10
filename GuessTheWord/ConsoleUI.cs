using System;
using System.Linq;

namespace GuessTheWord
{
    public class ConsoleUI
    {
        public char InputLetter()
        {
            do
            {
                Console.WriteLine("Введите букву (A-Z):");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ввод не может быть пустым!");
                    continue;
                }

                if (input.Length != 1)
                {
                    Console.WriteLine("Введите только одну букву!");
                    continue;
                }

                bool IsLetter = char.IsLetter(input[0]);
                if (IsLetter)
                    return char.ToUpper(input[0]);
                else
                    Console.WriteLine("Введите букву, а не символ!");

            } while (true);
        }

        public DifficultyType ChooseDifficulty()
        {
            Console.WriteLine("Выберите сложность:\n" +
                              "1 - Легко (10 попыток, слова 3-5 букв)\n" +
                              "2 - Нормально (8 попыток, слова 4-6 букв)\n" +
                              "3 - Сложно (6 попыток, слова 5-7 букв)");

            string result = Console.ReadLine();

            if (result != "1" && result != "2" && result != "3")
            {
                Console.WriteLine("Неверный ввод! Установлена сложность: Легко");
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
            Console.WriteLine("Использованные буквы:");

            foreach (char letter in letters)
            {
                Console.Write($"{letter} ");
            }

            Console.WriteLine();
        }

        public void ShowWord(string word)
        {
            Console.WriteLine($"Слово: {word}");
        }

        public void ShowLeftAttempts(int leftAttempts)
        {
            Console.WriteLine($"Осталось попыток: {leftAttempts}");
        }

        public void ShowGameResult(bool isWin)
        {
            Console.WriteLine(isWin ? "ПОБЕДА! 🎉 Вы угадали слово!" : "ПОРАЖЕНИЕ! 😢 Слово не угадано!");
        }

        public void ShowWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать в игру 'Угадай слово'!");
            Console.WriteLine("Правила: нужно угадать слово по буквам.");
            Console.WriteLine("Каждая неверная буква отнимает одну попытку.");
            Console.WriteLine();
        }

        public bool AskForNewGame()
        {
            Console.WriteLine("\nХотите сыграть еще? (Y/N):");
            string input = Console.ReadLine()?.ToUpper();
            return input == "Y" || input == "YES";
        }
    }
}