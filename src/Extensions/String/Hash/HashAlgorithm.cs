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
    Sha512
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
        _ => throw new ArgumentOutOfRangeException(nameof(value)),
    };

    public static System.Security.Cryptography.HashAlgorithm GetHasher(this HashAlgorithm value)
    {
        if (!Hashers.ContainsKey(value))
            Hashers[value] = value.CreateHasher();
        return Hashers[value];
    }
}