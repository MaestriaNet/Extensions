namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the MD5 hash for the given string.
    /// </summary>
    /// <returns>A 32 char long hash.</returns>
    public static string GetHashMd5(this string value) => ComputeHash(value, HashAlgorithm.Md5);
}