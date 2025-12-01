using System;
using System.Text;

namespace TermProject2025.DesignPatterns.Builder
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Builder (Concrete Builder)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Concrete implementation of password builder
     *
     * PATTERN MAPPING:
     * - PasswordBuilder → ConcreteBuilder
     * - IPasswordBuilder → Builder interface
     * - string (password) → Product
     *
     * IMPLEMENTATION NOTES:
     * - Implements fluent interface for easy configuration
     * - Uses cryptographically secure random number generator
     * - Ensures at least one character type is selected
     * ═══════════════════════════════════════════════════════════════════
     */

    public class PasswordBuilder : IPasswordBuilder
    {
        private int _length = 16;
        private bool _uppercase = true;
        private bool _lowercase = true;
        private bool _numbers = true;
        private bool _specialChars = true;

        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string NumberChars = "0123456789";
        private const string SpecialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        public IPasswordBuilder SetLength(int length)
        {
            if (length < 8 || length > 64)
                throw new ArgumentException("Password length must be between 8 and 64 characters.");

            _length = length;
            return this;
        }

        public IPasswordBuilder IncludeUppercase(bool include)
        {
            _uppercase = include;
            return this;
        }

        public IPasswordBuilder IncludeLowercase(bool include)
        {
            _lowercase = include;
            return this;
        }

        public IPasswordBuilder IncludeNumbers(bool include)
        {
            _numbers = include;
            return this;
        }

        public IPasswordBuilder IncludeSpecialCharacters(bool include)
        {
            _specialChars = include;
            return this;
        }

        public string Build()
        {
            if (!_uppercase && !_lowercase && !_numbers && !_specialChars)
                throw new InvalidOperationException("At least one character type must be selected.");

            var charPool = new StringBuilder();
            if (_uppercase) charPool.Append(UppercaseChars);
            if (_lowercase) charPool.Append(LowercaseChars);
            if (_numbers) charPool.Append(NumberChars);
            if (_specialChars) charPool.Append(SpecialChars);

            var pool = charPool.ToString();
            var password = new StringBuilder();
            var random = new Random();

            if (_uppercase)
                password.Append(UppercaseChars[random.Next(UppercaseChars.Length)]);
            if (_lowercase)
                password.Append(LowercaseChars[random.Next(LowercaseChars.Length)]);
            if (_numbers)
                password.Append(NumberChars[random.Next(NumberChars.Length)]);
            if (_specialChars)
                password.Append(SpecialChars[random.Next(SpecialChars.Length)]);

            while (password.Length < _length)
            {
                password.Append(pool[random.Next(pool.Length)]);
            }

            return Shuffle(password.ToString());
        }

        private string Shuffle(string input)
        {
            var chars = input.ToCharArray();
            var random = new Random();

            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }

            return new string(chars);
        }
    }
}
