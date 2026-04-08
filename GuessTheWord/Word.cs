using System;
using System.Linq;

namespace GuessTheWord
{
    public class Word
    {
        private readonly string _value;

        public Word(string value)
        {
            _value = value;
        }

        public int Length => _value.Length;

        public bool Contains(char character)
        {
            return _value.Contains(character.ToString());
        }

        public string GetMask(char[] guessedLetters)
        {
            string result = string.Empty;

            foreach (char character in _value)
            {
                if (guessedLetters.Contains(character))
                    result += character;
                else
                    result += "*";
            }

            return result;
            
        }

        public void DebugValue()
        {
            Console.WriteLine(_value);
        }
    }
}