namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Calculates the SHA-256 hash for the given string.
        /// </summary>
        /// <returns>A 64 char long hash.</returns>
        public static string GetHashSha256(this string input) => ComputeHash(input, HashAlgorithm.Sha256);
    }
}