using System;
using System.Text;

#if NET5_0_OR_GREATER
using System.Security.Cryptography;
#endif

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ComputeHash(this string value, HashAlgorithm algorithm, Encoding? encoding = null)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Null value to encrypt not supported.");

        encoding ??= GlobalSettings.Properties.DefaultEncoding;

#if NET5_0_OR_GREATER
        var hashBytes = algorithm switch
        {
            HashAlgorithm.Md5 => MD5.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha1 => SHA1.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha256 => SHA256.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha384 => SHA384.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha512 => SHA512.HashData(encoding.GetBytes(value)),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm)),
        };
        return hashBytes.HashBytesToString();
#else
        return value.ComputeHash(algorithm.GetHasher(), encoding);
#endif
    }

    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ComputeHash(this string value, System.Security.Cryptography.HashAlgorithm algorithm, Encoding? encoding = null)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Null value to encrypt not supported.");
        
        encoding ??= GlobalSettings.Properties.DefaultEncoding;
        var inputBytes = encoding.GetBytes(value);
        var hashBytes = algorithm.ComputeHash(inputBytes);
        return hashBytes.HashBytesToString();
    }
    
    private static string HashBytesToString(this byte[] hashBytes)
    {
        var hash = new StringBuilder();
        foreach (var b in hashBytes)
            hash.Append($"{b:x2}");
        return hash.ToString();
    }
}