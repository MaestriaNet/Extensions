using System;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class SimpleResultTValueTest
{
    const string ErrorMessage = "Test";

    private readonly Person _person = new Person(1, "Fábio");
    private readonly Person _nullPerson = null;

    [Fact]
    public void FailConstructorTest()
    {
        var result = new SimpleResult<Person>();
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);

        result = new SimpleResult<Person>(new Exception(ErrorMessage));
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void SuccessConstructorTest()
    {
        var result = new SimpleResult<Person>(_person);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.Null(result.Message);
        Assert.Equal(_person, result.Value);
        Assert.True(result.HasValue);
        Assert.True(result.SuccessAndHasValue);

        result = new SimpleResult<Person>(true, _person);
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
        SimpleResult<Person> result = true;
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
        SimpleResult<Person> result = _nullPerson;
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
        SimpleResult<Person> result = false;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Null(result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);

        result = ErrorMessage;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);

        result = new Exception(ErrorMessage);
        Assert.False(result.Success);
        Assert.False(result);
        Assert.Equal(ErrorMessage, result.Message);
        Assert.Null(result.Value);
        Assert.False(result.HasValue);
        Assert.False(result.SuccessAndHasValue);
    }

    [Fact]
    public void SuccessImplicitTValueToSimpleTest()
    {
        SimpleResult<Person> result1 = _person;
        SimpleResult result2 = result1;
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
        SimpleResult<Person> result1 = new Exception(ErrorMessage);
        SimpleResult result2 = result1;
        Assert.Equal(result1.Success, result2.Success);
        Assert.Equal(result1.Message, result2.Message);
        Assert.Equal(result1.Exception, result2.Exception);

        Assert.Equal(false, result2.Success);
        Assert.Equal(ErrorMessage, result2.Message);
        Assert.NotNull(result2.Exception);
    }
}

class Person
{
    public Person()
    {
    }

    public Person(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    int Id { get; set; }
    string Nome { get; set; }
}
