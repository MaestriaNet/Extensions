using System.Text;
using Xunit;
using Maestria.Extensions;

namespace Maestria.Extensions.Test.CSharp;

public class Base64ExtensionsTest
{
    // Test data
    private const string PlainText = "Text to encode as Base64";
    private static readonly byte[] PlainBytes = Encoding.UTF8.GetBytes(PlainText);

    private const string Base64EncodedText = "VGV4dCB0byBlbmNvZGUgYXMgQmFzZTY0";
    private static readonly byte[] Base64EncodedBytes = Encoding.UTF8.GetBytes(Base64EncodedText);

    [Fact]
    public void EncodeString()
    {
        Assert.Equal(Base64EncodedText, PlainText.ToBase64());
    }

    [Fact]
    public void EncodeBytes()
    {
        var result = PlainBytes.ToBase64();
        Assert.Equal(Base64EncodedBytes.Length, result.Length);
        for (var i = 0; i < Base64EncodedBytes.Length; i++) 
            Assert.Equal(Base64EncodedBytes[i], (byte)result[i]);
    }

    [Fact]
    public void DecodeString()
    {
        Assert.Equal(PlainText, Base64EncodedText.FromBase64());
    }

    [Fact]
    public void DecodeBytes()
    {
        var result = Base64EncodedBytes.FromBase64();
        Assert.Equal(PlainBytes.Length, result.Length);
        for (int i = 0; i < PlainBytes.Length; i++)
        {
            Assert.Equal(PlainBytes[i], result[i]);
        }
    }
}
