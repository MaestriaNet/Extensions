namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the SHA-384 hash for the given string.
    /// </summary>
    /// <returns>A 96 char long hash.</returns>
    public static string ToHashSha384(this string value) => value.ToHash(HashAlgorithm.Sha384);

    /// <summary>
    /// Calculates the SHA-384 hash for the given string.
    /// </summary>
    /// <returns>A 96 char long hash.</returns>
    [System.Obsolete("Use ToHashSha384 instead.")]
    public static string GetHashSha384(this string value) => value.ToHashSha384();
}