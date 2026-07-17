namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the SHA-1 hash for the given string.
    /// </summary>
    /// <returns>A 40 char long hash.</returns>
    public static string ToHashSha1(this string value) => value.ComputeHash(HashAlgorithm.Sha1);

    /// <summary>
    /// Calculates the SHA-1 hash for the given string.
    /// </summary>
    /// <returns>A 40 char long hash.</returns>
    [System.Obsolete("Use ToHashSha1 instead.")]
    public static string GetHashSha1(this string value) => value.ToHashSha1();
}