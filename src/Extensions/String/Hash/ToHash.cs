using System;
using System.Text;

#if NET5_0_OR_GREATER
using System.Security.Cryptography;
#endif

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    private const string UnsupportedPlatformForHasher = "{0} is not supported on this platform. Requires OpenSSL 1.1.1+ on Linux or Windows 11 (Build 25324+).";
    
    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ToHash(this string value, HashAlgorithm algorithm, Encoding? encoding = null)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Null value to encrypt not supported.");

        encoding ??= GlobalSettings.Properties.DefaultEncoding;

#if NET8_0_OR_GREATER
        var hashBytes = algorithm switch
        {
            HashAlgorithm.Md5 => MD5.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha1 => SHA1.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha256 => SHA256.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha384 => SHA384.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha512 => SHA512.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha3_256 => SHA3_256.IsSupported
                ? SHA3_256.HashData(encoding.GetBytes(value))
                : throw new PlatformNotSupportedException(UnsupportedPlatformForHasher.Format("SHA3-256")),
            HashAlgorithm.Sha3_384 => SHA3_384.IsSupported
                ? SHA3_384.HashData(encoding.GetBytes(value))
                : throw new PlatformNotSupportedException(UnsupportedPlatformForHasher.Format( "SHA3-384")),
            HashAlgorithm.Sha3_512 => SHA3_512.IsSupported
                ? SHA3_512.HashData(encoding.GetBytes(value))
                : throw new PlatformNotSupportedException(UnsupportedPlatformForHasher.Format("SHA3-512")),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm)),
        };
        return hashBytes.HashBytesToString();
#elif NET5_0_OR_GREATER
        var hashBytes = algorithm switch
        {
            HashAlgorithm.Md5 => MD5.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha1 => SHA1.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha256 => SHA256.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha384 => SHA384.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha512 => SHA512.HashData(encoding.GetBytes(value)),
            HashAlgorithm.Sha3_256 or HashAlgorithm.Sha3_384 or HashAlgorithm.Sha3_512
                => throw new PlatformNotSupportedException("SHA3 algorithms require .NET 8 or later."),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm)),
        };
        return hashBytes.HashBytesToString();
#else
        return value.ToHash(algorithm.GetHasher(), encoding);
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
    [Obsolete("Use ToHash instead.")]
    public static string ComputeHash(this string value, HashAlgorithm algorithm, Encoding? encoding = null) =>
        value.ToHash(algorithm, encoding);

    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ToHash(this string value, System.Security.Cryptography.HashAlgorithm algorithm, Encoding? encoding = null)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Null value to encrypt not supported.");
        
        encoding ??= GlobalSettings.Properties.DefaultEncoding;
        var inputBytes = encoding.GetBytes(value);
        var hashBytes = algorithm.ComputeHash(inputBytes);
        return hashBytes.HashBytesToString();
    }

    /// <summary>
    /// Calculates the hash for the given string.
    /// </summary>
    /// <param name="algorithm"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [Obsolete("Use ToHash instead.")]
    public static string ComputeHash(this string value, System.Security.Cryptography.HashAlgorithm algorithm, Encoding? encoding = null) =>
        value.ToHash(algorithm, encoding);
    
    private static string HashBytesToString(this byte[] hashBytes)
    {
        var hash = new StringBuilder();
        foreach (var b in hashBytes)
            hash.Append($"{b:x2}");
        return hash.ToString();
    }
}