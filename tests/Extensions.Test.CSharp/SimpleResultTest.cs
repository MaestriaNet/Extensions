using System;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class SimpleResultTest
{
    const string ErrorMessage = "Test";

    [Fact]
    public void FailConstructorTest()
    {
        var result = new SimpleResult();
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);

        result = new SimpleResult(new Exception(ErrorMessage));
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
    }

    [Fact]
    public void SuccessConstructorTest()
    {
        var result = new SimpleResult(true);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
    }

    [Fact]
    public void SuccessImplicitTest()
    {
        SimpleResult result = true;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
    }

    [Fact]
    public void FailImplicitTest()
    {
        SimpleResult result = false;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);

        result = ErrorMessage;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);

        result = new Exception(ErrorMessage);
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
    }

    [Fact]
    public void ImplicitConversionTest()
    {
        var source = new SimpleResult(true, "Test");
        var sourceValue = new SimpleResult<int>(true, 15, "Test");

        SimpleResult<int> destinationLostingValue = source;
        SimpleResult destinationWhitoutValue = sourceValue;

        Assert.True(destinationLostingValue.Success);
        Assert.True(destinationWhitoutValue.Success);
        Assert.Equal("Test", destinationLostingValue.Message);
        Assert.Equal("Test", destinationWhitoutValue.Message);
        Assert.Equal(0, destinationLostingValue.Value);
    }
}
