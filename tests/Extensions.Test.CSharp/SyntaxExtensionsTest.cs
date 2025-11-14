using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class SyntaxExtensionsTest
{
    [Fact]
    public void OutVar()
    {
        var executionPipelineResult = "abc123def"
            .OnlyNumbers()
            .OutVar(out var onlyNumbers)
            .Substring(0, 1);

        Assert.Equal("123", onlyNumbers);
        Assert.Equal("1", executionPipelineResult);
    }

    [Fact]
    public void LimitMaxAtTest()
    {
        Assert.Equal(10, 10.LimitMaxAt(15));
        Assert.Equal(15, 15.LimitMaxAt(15));
        Assert.Equal(15, 20.LimitMaxAt(15));
    }

    [Fact]
    public void LimitMinAtTest()
    {
        Assert.Equal(15, 10.LimitMinAt(15));
        Assert.Equal(15, 15.LimitMinAt(15));
        Assert.Equal(20, 20.LimitMinAt(15));
    }
}