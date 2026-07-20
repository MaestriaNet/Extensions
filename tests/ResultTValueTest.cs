#pragma warning disable CS0618
using System;
using Maestria.Extensions.Test.CSharp.TestEntities;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class ResultTValueTest
{
    const string ErrorMessage = "Test";

    private readonly PersonEntity _person = new PersonEntity(1, "Fábio");
    private readonly PersonEntity _nullPerson = null;

    [Fact]
    public void FailConstructorTest()
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
    public void SuccessConstructorTest()
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
    public void SuccessImplicitTest()
    {
        Result<PersonEntity> result = true;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);

        result = _person;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Equal(_person, result.Value);
        Assert.True(result.HasValue);
        Assert.True(result.SuccessAndHasValue);
    }

    [Fact]
    public void SuccessImpliciWithNullValueTest()
    {
        Result<PersonEntity> result = _nullPerson;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);

        result = _person;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Equal(_person, result.Value);
        Assert.True(result.HasValue);
        Assert.True(result.SuccessAndHasValue);
    }

    [Fact]
    public void FailImplicitTest()
    {
        Result<PersonEntity> result = false;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);

        Result<PersonEntity> result2 = ErrorMessage;
        Assert.False(result2.Success);
        Assert.False(result2);
        Assert.Equal(ErrorMessage, result2.Message);
        Assert.Null(result2.Value);
        Assert.False(result2.HasValue);
        Assert.False(result2.SuccessAndHasValue);

        Result<PersonEntity> result3 = new Exception(ErrorMessage);
        Assert.False(result3.Success);
        Assert.False(result3);
        Assert.Equal(ErrorMessage, result3.Message);
        Assert.Null(result3.Value);
        Assert.False(result3.HasValue);
        Assert.False(result3.SuccessAndHasValue);
    }

    [Fact]
    public void SuccessImplicitTValueToSimpleTest()
    {
        Result<PersonEntity> result1 = _person;
        Result result2 = result1;
        Assert.Equal(result1.Success, result2.Success);
        Assert.Equal(result1.Message, result2.Message);
        Assert.Equal(result1.Exception, result2.Exception);

        Assert.Equal(true, result2.Success);
        Assert.Null(result2.Message);
        Assert.Null(result2.Exception);
    }

    [Fact]
    public void FailImplicitTValueToSimpleTest()
    {
        Result<PersonEntity> result1 = new Exception(ErrorMessage);
        Result result2 = result1;
        Assert.Equal(result1.Success, result2.Success);
        Assert.Equal(result1.Message, result2.Message);
        Assert.Equal(result1.Exception, result2.Exception);

        Assert.Equal(false, result2.Success);
        Assert.Equal(ErrorMessage, result2.Message);
        Assert.NotNull(result2.Exception);
    }
}

#pragma warning restore CS0618
