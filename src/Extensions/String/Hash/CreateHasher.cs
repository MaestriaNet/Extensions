using System;
using System.Security.Cryptography;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static System.Security.Cryptography.HashAlgorithm CreateHasher(this HashAlgorithm value) => value switch
    {
        HashAlgorithm.Md5 => MD5.Create(),
        HashAlgorithm.Sha1 => SHA1.Create(),
        HashAlgorithm.Sha256 => SHA256.Create(),
        HashAlgorithm.Sha384 => SHA384.Create(),
        HashAlgorithm.Sha512 => SHA512.Create(),
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unsupported hash algorithm."),
    };
}