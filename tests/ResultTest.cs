#pragma warning disable CS0618
using System;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class ResultTest
{
    const string ErrorMessage = "Test";

    [Fact]
    public void FailConstructorTest()
    {
        var result = new Result();
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);

        result = new Result(new Exception(ErrorMessage));
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
    }

    [Fact]
    public void SuccessConstructorTest()
    {
        var result = new Result(true);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
    }

    [Fact]
    public void SuccessImplicitTest()
    {
        Result result = true;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
    }

    [Fact]
    public void FailImplicitTest()
    {
        Result result = false;
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
        var source = new Result(true, "Test");
        var sourceValue = new Result<int>(true, 15, "Test");

        Result<int> destinationLostingValue = source;
        Result destinationWhitoutValue = sourceValue;

        Assert.True(destinationLostingValue.Success);
        Assert.True(destinationWhitoutValue.Success);
        Assert.Equal("Test", destinationLostingValue.Message);
        Assert.Equal("Test", destinationWhitoutValue.Message);
        Assert.Equal(0, destinationLostingValue.Value);
    }
}
#pragma warning restore CS0618
