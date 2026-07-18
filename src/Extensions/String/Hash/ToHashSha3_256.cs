namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Calculates the SHA3-256 hash for the given string.
    /// <para>Requires .NET 8 or later. Also requires OS platform support (OpenSSL 1.1.1+ on Linux or Windows 11 Build 25324+).</para>
    /// </summary>
    /// <returns>A 64 char long hash.</returns>
    /// <exception cref="System.PlatformNotSupportedException">Thrown when the OS does not support SHA3-256.</exception>
    public static string ToHashSha3_256(this string value) => value.ToHash(HashAlgorithm.Sha3_256);
}
