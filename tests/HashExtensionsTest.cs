using System;
using Xunit;
using Maestria.Extensions;

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
    public void MD5HashTest()
    {
        Assert.Equal(Md5Expected, InputValue.GetHashMd5());
    }

    [Fact]
    public void SHA1HashTest()
    {
        Assert.Equal(Sha1Expected, InputValue.GetHashSha1());
    }

    [Fact]
    public void SHA256HashTest()
    {
        Assert.Equal(Sha256Expected, InputValue.GetHashSha256());
    }

    [Fact]
    public void SHA384HashTest()
    {
        Assert.Equal(Sha384Expected, InputValue.GetHashSha384());
    }

    [Fact]
    public void SHA512HashTest()
    {
        Assert.Equal(Sha512Expected, InputValue.GetHashSha512());
    }

    [Fact]
    public void NullNotSupportedException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            MaestriaExtensions.ComputeHash(null, HashAlgorithm.Md5);
        });
    }
}
