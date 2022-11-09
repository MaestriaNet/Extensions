using System;
using System.Text;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ComputeHash(this string value, HashAlgorithm algorithm)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Null value to encrypt not suported.");

        using var hasher = algorithm.CreateHasher();
        return value.ComputeHash(hasher);
    }

    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ComputeHash(this string value, System.Security.Cryptography.HashAlgorithm algorithm)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Null value to encrypt not suported.");

        var inputBytes = Encoding.UTF8.GetBytes(value);
        var hashBytes = algorithm.ComputeHash(inputBytes);
        var hash = new StringBuilder();
        foreach (var b in hashBytes)
            hash.Append($"{b:x2}");
        return hash.ToString();
    }
}