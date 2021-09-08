namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Calculates the SHA-1 hash for the given string.
        /// </summary>
        /// <returns>A 40 char long hash.</returns>
        public static string GetHashSha1(this string input) => ComputeHash(input, HashAlgorithm.Sha1);
    }
}