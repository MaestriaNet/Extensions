namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the SHA-256 hash for the given string.
    /// </summary>
    /// <returns>A 64 char long hash.</returns>
    public static string ToHashSha256(this string value) => value.ComputeHash(HashAlgorithm.Sha256);

    /// <summary>
    /// Calculates the SHA-256 hash for the given string.
    /// </summary>
    /// <returns>A 64 char long hash.</returns>
    [System.Obsolete("Use ToHashSha256 instead.")]
    public static string GetHashSha256(this string value) => value.ToHashSha256();
}