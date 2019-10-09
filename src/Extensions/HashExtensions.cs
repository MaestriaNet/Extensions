using System;
using System.Security.Cryptography;
using System.Text;

namespace Maestria.Extensions
{
    public enum HashAlgorithm
    {
        Md5,
        Sha1,
        Sha256,
        Sha384,
        Sha512
    }

    public static class HashExtensions
    {
        /// <summary>
        /// Calculates the MD5 hash for the given string.
        /// </summary>
        /// <returns>A 32 char long hash.</returns>
        public static string GetHashMd5(this string input) => ComputeHash(HashAlgorithm.Md5, input);

        /// <summary>
        /// Calculates the SHA-1 hash for the given string.
        /// </summary>
        /// <returns>A 40 char long hash.</returns>
        public static string GetHashSha1(this string input) => ComputeHash(HashAlgorithm.Sha1, input);

        /// <summary>
        /// Calculates the SHA-256 hash for the given string.
        /// </summary>
        /// <returns>A 64 char long hash.</returns>
        public static string GetHashSha256(this string input) => ComputeHash(HashAlgorithm.Sha256, input);

        /// <summary>
        /// Calculates the SHA-384 hash for the given string.
        /// </summary>
        /// <returns>A 96 char long hash.</returns>
        public static string GetHashSha384(this string input) => ComputeHash(HashAlgorithm.Sha384, input);

        /// <summary>
        /// Calculates the SHA-512 hash for the given string.
        /// </summary>
        /// <returns>A 128 char long hash.</returns>
        public static string GetHashSha512(this string input) => ComputeHash(HashAlgorithm.Sha512, input);

        public static string ComputeHash(HashAlgorithm hashAlgorithm, string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Null value to encrypt not suported.");


            using (var hasher = GetHasher(hashAlgorithm))
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);

                var hashBytes = hasher.ComputeHash(inputBytes);
                var hash = new StringBuilder();
                foreach (var b in hashBytes)
                    hash.Append($"{b:x2}");

                return hash.ToString();
            }
        }

        private static System.Security.Cryptography.HashAlgorithm GetHasher(HashAlgorithm hashAlgorithm)
        {
            switch (hashAlgorithm)
            {
                case HashAlgorithm.Md5:
                    return new MD5CryptoServiceProvider();
                case HashAlgorithm.Sha1:
                    return new SHA1Managed();
                case HashAlgorithm.Sha256:
                    return new SHA256Managed();
                case HashAlgorithm.Sha384:
                    return new SHA384Managed();
                case HashAlgorithm.Sha512:
                    return new SHA512Managed();
                default:
                    throw new ArgumentOutOfRangeException(nameof(hashAlgorithm));
            }
        }
    }
}