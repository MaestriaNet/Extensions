using System;
using System.Security.Cryptography;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static System.Security.Cryptography.HashAlgorithm CreateHasher(this HashAlgorithm value) => value switch
    {
        HashAlgorithm.Md5 => new MD5CryptoServiceProvider(),
        HashAlgorithm.Sha1 => new SHA1Managed(),
        HashAlgorithm.Sha256 => new SHA256Managed(),
        HashAlgorithm.Sha384 => new SHA384Managed(),
        HashAlgorithm.Sha512 => new SHA512Managed(),
        _ => throw new ArgumentOutOfRangeException(nameof(value)),
    };
}