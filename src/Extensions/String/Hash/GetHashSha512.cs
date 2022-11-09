namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the SHA-512 hash for the given string.
    /// </summary>
    /// <returns>A 128 char long hash.</returns>
    public static string GetHashSha512(this string value) => ComputeHash(value, HashAlgorithm.Sha512);
}