namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the MD5 hash for the given string.
    /// </summary>
    /// <returns>A 32 char long hash.</returns>
    public static string ToHashMd5(this string value) => value.ComputeHash(HashAlgorithm.Md5);

    /// <summary>
    /// Calculates the MD5 hash for the given string.
    /// </summary>
    /// <returns>A 32 char long hash.</returns>
    [System.Obsolete("Use ToHashMd5 instead.")]
    public static string GetHashMd5(this string value) => value.ToHashMd5();
}