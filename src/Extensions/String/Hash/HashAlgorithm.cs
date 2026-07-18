using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Maestria.Extensions;

public enum HashAlgorithm
{
    Md5,
    Sha1,
    Sha256,
    Sha384,
    Sha512,

    /// <summary>SHA3-256 (128 hex chars). Requires .NET 8+ and OS platform support. Check <c>SHA3_256.IsSupported</c> before use.</summary>
    Sha3_256,

    /// <summary>SHA3-384 (96 hex chars). Requires .NET 8+ and OS platform support. Check <c>SHA3_384.IsSupported</c> before use.</summary>
    Sha3_384,

    /// <summary>SHA3-512 (128 hex chars). Requires .NET 8+ and OS platform support. Check <c>SHA3_512.IsSupported</c> before use.</summary>
    Sha3_512
}

public static partial class MaestriaExtensions
{
    private static readonly Dictionary<HashAlgorithm, System.Security.Cryptography.HashAlgorithm> Hashers = new();

    public static System.Security.Cryptography.HashAlgorithm CreateHasher(this HashAlgorithm value) => value switch
    {
        HashAlgorithm.Md5 => MD5.Create(),
        HashAlgorithm.Sha1 => SHA1.Create(),
        HashAlgorithm.Sha256 => SHA256.Create(),
        HashAlgorithm.Sha384 => SHA384.Create(),
        HashAlgorithm.Sha512 => SHA512.Create(),
#if NET8_0_OR_GREATER
        HashAlgorithm.Sha3_256 => SHA3_256.Create(),
        HashAlgorithm.Sha3_384 => SHA3_384.Create(),
        HashAlgorithm.Sha3_512 => SHA3_512.Create(),
#else
        HashAlgorithm.Sha3_256 or HashAlgorithm.Sha3_384 or HashAlgorithm.Sha3_512
            => throw new PlatformNotSupportedException("SHA3 algorithms require .NET 8 or later."),
#endif
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid hash algorithm specified.")
    };

    public static System.Security.Cryptography.HashAlgorithm GetHasher(this HashAlgorithm value)
    {
        if (!Hashers.ContainsKey(value))
            Hashers[value] = value.CreateHasher();
        return Hashers[value];
    }
}