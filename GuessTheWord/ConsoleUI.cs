using System;

namespace GuessTheWord
{
    public class ConsoleUI
    {
        public char InputLetter()
        {
            string result = Console.ReadLine();
            return result[0];
        }
        public DifficultyType ChooseDifficulty()
        {
            // вывести сообщение пользователю чтобы он выбрал сложность
            // прочитать его выбор 
            // опционально добавить проверку ввода
            // преобразовать его ввод в тип enum и вернуть значения
        }
    }
}