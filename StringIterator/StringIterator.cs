using System;

namespace Marinkas.Utils
{
	/// <summary>
	/// Provides a utility for iterating through strings.
	/// </summary>
	public class StringIterator : IDisposable
    {
        private string content;
        private int currentCharacterIndex = 0;
        private bool disposedValue;

        /// <summary>
        /// Initializes a new StringIterator class with the string to iterate through.
        /// </summary>
        /// <param name="text"></param>
        public StringIterator(string text)
        {
            content = text;
            currentCharacterIndex = 0;
        }

        /// <summary>
        /// Reads a string untill it reaches the specified target
        /// </summary>
        /// <param name="target"></param>
        /// <returns>String that was read</returns>
        public string ReadUntil(char target)
        {
            string text = string.Empty;
            while (Current() != target)
            {
                text += Current();
                Next();
            }
            return text;
        }
        /// <summary>
        /// Reads a string for as long the the condition is met
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>String that was read</returns>
        public string ReadWhile(Func<char, bool> condition)
        {
            string text = string.Empty;
            while (condition(Current()))
            {
                text += Current();
                Next();
            }
            return text;
        }
        /// <summary>
        /// Skips the string untill it reachest the specified target
        /// </summary>
        /// <param name="target"></param>
        public void SkipUntil(char target)
        {
            while (Current() != target)
            {
                Next();
            }
        }
        /// <summary>
        /// Skips while the condition is met
        /// </summary>
        /// <param name="condition"></param>
        public void SkipWhile(Func<char, bool> condition)
        {
            while (condition(Current()))
            {
                Next();
            }
        }
        /// <summary>
        /// </summary>
        /// <returns>The current character</returns>
        public char Current()
        {
            return Character(currentCharacterIndex);
        }
        /// <summary>
        /// </summary>
        /// <returns>The next character</returns>
        public char Peek()
        {
            return Character(currentCharacterIndex + 1);
        }
        /// <summary>
        /// Iterates to the next character
        /// </summary>
        /// <returns>The next character</returns>
        public char Next()
        {
            currentCharacterIndex++;
            return Character(currentCharacterIndex);
        }
        /// <summary>
        /// </summary>
        /// <returns>The current character index</returns>
        public int CurrentIndex()
        {
            return currentCharacterIndex;
        }
        /// <summary>
        /// </summary>
        /// <returns>The string's length</returns>
        public int Length()
        {
            return content.Length;
        }
        /// <summary>
        /// </summary>
        /// <param name="characterIndex"></param>
        /// <returns>The character at characterIndex</returns>
        private char Character(int characterIndex)
        {
            if (characterIndex < 0 | characterIndex >= content.Length)
            {
                return '\0';
            }
            return content[characterIndex];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    content = null;
                    currentCharacterIndex = 0;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
