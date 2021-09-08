namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Calculates the SHA-384 hash for the given string.
        /// </summary>
        /// <returns>A 96 char long hash.</returns>
        public static string GetHashSha384(this string value) => ComputeHash(value, HashAlgorithm.Sha384);
    }
}