using System;
using System.Text;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Calculates the hash for the given string.
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ComputeHash(this string input, HashAlgorithm hashAlgorithm)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Null value to encrypt not suported.");

            using var hasher = hashAlgorithm.CreateHasher();
            return input.ComputeHash(hasher);
        }

        /// <summary>
        /// Calculates the hash for the given string.
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ComputeHash(this string input, System.Security.Cryptography.HashAlgorithm hashAlgorithm)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Null value to encrypt not suported.");

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = hashAlgorithm.ComputeHash(inputBytes);
            var hash = new StringBuilder();
            foreach (var b in hashBytes)
                hash.Append($"{b:x2}");
            return hash.ToString();
        }
    }
}