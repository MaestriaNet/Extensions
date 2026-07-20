using System;
using Xunit;
using Maestria.Extensions;
using Maestria.Extensions.Test.CSharp.TestEntities;

namespace Maestria.Extensions.Test.CSharp;

public class ResultTest
{
    private const string ErrorMessage = "Test";
    private readonly PersonEntity _person = new PersonEntity(1, "Fábio");
    private readonly PersonEntity _nullPerson = null;

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
        Result destinationWithoutValue = sourceValue;

        Assert.True(destinationLostingValue.Success);
        Assert.True(destinationWithoutValue.Success);
        Assert.Equal("Test", destinationLostingValue.Message);
        Assert.Equal("Test", destinationWithoutValue.Message);
        Assert.Equal(0, destinationLostingValue.Value);
    }

    [Fact]
    public void TValueFailConstructorTest()
    {
        var result = new Result<PersonEntity>();
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);

        result = new Result<PersonEntity>(new Exception(ErrorMessage));
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void TValueSuccessConstructorTest()
    {
        var result = new Result<PersonEntity>(_person);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Equal(_person, result.Value);
        Assert.True(result.HasValue);
        Assert.True(result.SuccessAndHasValue);

        result = new Result<PersonEntity>(true, _person);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Equal(_person, result.Value);
        Assert.True(result.HasValue);
        Assert.True(result.SuccessAndHasValue);
    }

    [Fact]
    public void TValueImplicitConversionBoolRetrunsSuccessAndHasValue()
    {
        Result<PersonEntity> result = new Result<PersonEntity>(true, null);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);
    }

    [Fact]
    public void DeconstructTest()
    {
        var result = Result.Ok("All good");
        var (success, message) = result;
        Assert.True(success);
        Assert.Equal("All good", message);

        var resultVal = Result<int>.Ok(42, "Done");
        var (successVal, value, messageVal) = resultVal;
        Assert.True(successVal);
        Assert.Equal(42, value);
        Assert.Equal("Done", messageVal);
    }
}
