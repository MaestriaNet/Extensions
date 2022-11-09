using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp;

public class SyntaxExtensionsTest
{
    [Test]
    public void OutVar()
    {
        var executionPipelineResult = "abc123def"
            .OnlyNumbers()
            .OutVar(out var onlyNumbers)
            .Substring(0, 1);

        Assert.AreEqual("123", onlyNumbers);
        Assert.AreEqual("1", executionPipelineResult);
    }

    [Test]
    public void LimitMaxAtTest()
    {
        Assert.AreEqual(10, 10.LimitMaxAt(15));
        Assert.AreEqual(15, 15.LimitMaxAt(15));
        Assert.AreEqual(15, 20.LimitMaxAt(15));
    }

    [Test]
    public void LimitMinAtTest()
    {
        Assert.AreEqual(15, 10.LimitMinAt(15));
        Assert.AreEqual(15, 15.LimitMinAt(15));
        Assert.AreEqual(20, 20.LimitMinAt(15));
    }
}