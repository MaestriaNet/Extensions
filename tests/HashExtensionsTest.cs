using System;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class HashExtensionsTest
{
    private const string InputValue = "Value to cryptography test";

    // Expected values
    private const string Md5Expected = "930fe80be1c6a5b5bfc49ab91727bb91";
    private const string Sha1Expected = "a9c1f880a83374094f4242c0b72e1bf888504983";
    private const string Sha256Expected = "0c3854f97ec73fbcafe048f78e2f2a88c06d335a67220e004f1e82e7bb8fee69";
    private const string Sha384Expected = "25c8c1a053eff04f331d43434fcffe022a2747ba3d61c2406468d9cdfd6e329115f814bf3d6e2d9ddeb2cf1964cd1f89";
    private const string Sha512Expected = "782be31c425eff35b3028fc0a2b3535392605821467c713370f16fa96c94eb07309dc19575d819b11fe42d387d211c2caf404d2b46ee9cfe0333dd96bb6a3029";

    [Fact]
    public void Md5HashTest()
    {
        Assert.Equal(Md5Expected, InputValue.ToHashMd5());
    }

    [Fact]
    public void Sha1HashTest()
    {
        Assert.Equal(Sha1Expected, InputValue.ToHashSha1());
    }

    [Fact]
    public void Sha256HashTest()
    {
        Assert.Equal(Sha256Expected, InputValue.ToHashSha256());
    }

    [Fact]
    public void Sha384HashTest()
    {
        Assert.Equal(Sha384Expected, InputValue.ToHashSha384());
    }

    [Fact]
    public void Sha512HashTest()
    {
        Assert.Equal(Sha512Expected, InputValue.ToHashSha512());
    }

#if NET8_0_OR_GREATER
    // ReSharper disable InconsistentNaming
    private const string Sha3_256Expected = "289dc351e3a3773692b53b19c9a090b71f347aa7ad369bf9bdde7ee495bed1bf";
    private const string Sha3_384Expected = "c30b4b09f5ddc812196b0cf2b303fcf115455cbf20d7e0ccdd937ba3a300cde2143b25eb6dad04934bf3027f46e96175";
    private const string Sha3_512Expected = "ecb8640471a5f3efc353a795de96240a8a9d2d4be40adfb261dcbc63a26f4ef122f60fac57b25bac7c7e9283bdb3225b48983622686c4e3456e7aeec6b3cdd0a";
    // ReSharper restore InconsistentNaming

    [Fact]
    public void Sha3_256HashTest()
    {
        if (!System.Security.Cryptography.SHA3_256.IsSupported)
            return; // Skip on unsupported platforms

        Assert.Equal(Sha3_256Expected, InputValue.ToHashSha3_256());
        Assert.Equal(Sha3_256Expected, InputValue.ToHash(HashAlgorithm.Sha3_256));
    }

    [Fact]
    public void Sha3_384HashTest()
    {
        if (!System.Security.Cryptography.SHA3_384.IsSupported)
            return; // Skip on unsupported platforms

        Assert.Equal(Sha3_384Expected, InputValue.ToHashSha3_384());
        Assert.Equal(Sha3_384Expected, InputValue.ToHash(HashAlgorithm.Sha3_384));
    }

    [Fact]
    public void Sha3_512HashTest()
    {
        if (!System.Security.Cryptography.SHA3_512.IsSupported)
            return; // Skip on unsupported platforms

        Assert.Equal(Sha3_512Expected, InputValue.ToHashSha3_512());
        Assert.Equal(Sha3_512Expected, InputValue.ToHash(HashAlgorithm.Sha3_512));
    }
#endif
    
    [Fact]
    public void NullNotSupportedException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            MaestriaExtensions.ToHash(null!, HashAlgorithm.Md5);
        });
    }
}
