using System.Text;
using NUnit.Framework;
using Maestria.Extensions;

namespace Maestria.Extensions.Test.CSharp;

public class Base64ExtensionsTest
{
    // Test data
    private const string PlainText = "Text to encode as Base64";
    private static readonly byte[] PlainBytes = Encoding.UTF8.GetBytes(PlainText);

    private const string Base64EncodedText = "VGV4dCB0byBlbmNvZGUgYXMgQmFzZTY0";
    private static readonly byte[] Base64EncodedBytes = Encoding.UTF8.GetBytes(Base64EncodedText);

    [Test]
    public void EncodeString()
    {
        Assert.AreEqual(Base64EncodedText, PlainText.ToBase64());
    }

    [Test]
    public void EncodeBytes()
    {
        Assert.AreEqual(Base64EncodedBytes, PlainBytes.ToBase64());
    }

    [Test]
    public void DecodeString()
    {
        Assert.AreEqual(PlainText, Base64EncodedText.FromBase64());
    }

    [Test]
    public void DecodeBytes()
    {
        Assert.AreEqual(PlainBytes, Base64EncodedBytes.FromBase64());
    }
}
