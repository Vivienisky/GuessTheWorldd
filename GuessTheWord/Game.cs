using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GuessTheWord
{
    public class Game
    {
        private readonly int _attemptsMax;
        private int _attemptsLeft;
        private Word _currentWord;
        private List<char> _usedLetters = new List<char>();
        private HashSet<char> _guessedLetters = new HashSet<char>(); 
        private bool _isGameRunning;
        private bool _isWin;

        public Game(int attemptsMax)
        {
            _attemptsMax = attemptsMax;
            _attemptsLeft = attemptsMax;
            _isGameRunning = false;
            _isWin = false;
        }

 
        public int AttemptsLeft => _attemptsLeft;
        public int AttemptsMax => _attemptsMax;
        public bool IsGameRunning => _isGameRunning;
        public bool IsWin => _isWin;
        public ReadOnlyCollection<char> UsedLetters => _usedLetters.AsReadOnly();
        public HashSet<char> GuessedLetters => _guessedLetters;


        public void Initialize(Word word)
        {
            _currentWord = word;
            _attemptsLeft = _attemptsMax;
            _usedLetters.Clear();
            _guessedLetters.Clear();
            _isGameRunning = true;
            _isWin = false;
        }

 
        public bool TryAddLetter(char letter)
        {
            letter = char.ToUpper(letter);
            
  
            if (_usedLetters.Contains(letter))
            {
                Console.WriteLine($"Буква '{letter}' уже использовалась!");
                return false;
            }


            _usedLetters.Add(letter);
            bool isGuessed = _currentWord.Contains(letter);
            
            if (isGuessed)
            {
                _guessedLetters.Add(letter);
                Console.WriteLine($"✓ Буква '{letter}' есть в слове!");
            }
            else
            {
                _attemptsLeft--;
                Console.WriteLine($"✗ Буквы '{letter}' нет в слове! Осталось попыток: {_attemptsLeft}");
            }


            if (IsWordFullyGuessed())
            {
                _isWin = true;
                _isGameRunning = false;
                Console.WriteLine("Поздравляем! Вы угадали всё слово!");
            }
            

            if (_attemptsLeft <= 0)
            {
                _isGameRunning = false;
                Console.WriteLine("Попытки закончились!");
            }

            return true;
        }


        private bool IsWordFullyGuessed()
        {
            string mask = _currentWord.GetMask(_guessedLetters.ToArray());
            return !mask.Contains('*');
        }


        public string GetCurrentMask()
        {
            return _currentWord.GetMask(_guessedLetters.ToArray());
        }


        public char[] GetUsedLettersArray()
        {
            return _usedLetters.ToArray();
        }

 
        public void DisplayGameState()
        {
            Console.Clear();
            Console.WriteLine("=== УГАДАЙ СЛОВО ===");
            Console.WriteLine($"Попыток осталось: {_attemptsLeft}/{_attemptsMax}");
            Console.WriteLine($"Слово: {GetCurrentMask()}");
            
            if (_usedLetters.Any())
            {
                Console.Write("Использованные буквы: ");
                foreach (var letter in _usedLetters)
                {
                    if (_guessedLetters.Contains(letter))
                        Console.Write($"[{letter}] ");
                    else
                        Console.Write($"{letter} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 30));
        }

    
        public void RunGameLoop(ConsoleUI ui, Word word)
        {
            Initialize(word);
            

            while (_isGameRunning)
            {
                DisplayGameState();
                
  
                char letter = ui.InputLetter();
                
   
                TryAddLetter(letter);
                
   
                if (_isGameRunning)
                {
                    System.Threading.Thread.Sleep(1500);
                }
            }
            
            DisplayGameState();
            ui.ShowGameResult(_isWin);
            
            if (!_isWin)
            {
                Console.Write("Загаданное слово было: ");
                _currentWord.DebugValue();
            }
        }
    }

    public interface IReadOnlyList<T>
    {
        
    }
}