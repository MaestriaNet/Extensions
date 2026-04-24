using System;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp;

public class SimpleResultTValueTest
{
    const string ErrorMessage = "Test";

    private readonly PersonEntity _person = new PersonEntity(1, "Fábio");
    private readonly PersonEntity _nullPerson = null;

    [Test]
    public void FailConstructorTest()
    {
        var result = new SimpleResult<PersonEntity>();
        Assert.False(result.Success);
        Assert.False(result);
        Assert.IsNull(result.Message);
        Assert.IsNull(result.Value);
        Assert.False(result.HasValue);

        result = new SimpleResult<PersonEntity>(new Exception(ErrorMessage));
        Assert.False(result.Success);
        Assert.False(result);
        Assert.AreEqual(ErrorMessage, result.Message);
        Assert.IsNull(result.Value);
        Assert.False(result.HasValue);
    }

    [Test]
    public void SuccessConstructorTest()
    {
        var result = new SimpleResult<PersonEntity>(_person);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.IsNull(result.Message);
        Assert.AreEqual(_person, result.Value);
        Assert.IsTrue(result.HasValue);
        Assert.IsTrue(result.SuccessAndHasValue);

        result = new SimpleResult<PersonEntity>(true, _person);
        Assert.True(result.Success);
        Assert.True(result);
        Assert.IsNull(result.Message);
        Assert.AreEqual(_person, result.Value);
        Assert.IsTrue(result.HasValue);
        Assert.IsTrue(result.SuccessAndHasValue);
    }

    [Test]
    public void SuccessImplicitTest()
    {
        SimpleResult<PersonEntity> result = true;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.IsNull(result.Message);
        Assert.IsNull(result.Value);
        Assert.IsFalse(result.HasValue);
        Assert.IsFalse(result.SuccessAndHasValue);

        result = _person;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.IsNull(result.Message);
        Assert.AreEqual(_person, result.Value);
        Assert.IsTrue(result.HasValue);
        Assert.IsTrue(result.SuccessAndHasValue);
    }

    [Test]
    public void SuccessImpliciWithNullValueTest()
    {
        SimpleResult<PersonEntity> result = _nullPerson;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.IsNull(result.Message);
        Assert.IsNull(result.Value);
        Assert.IsFalse(result.HasValue);
        Assert.IsFalse(result.SuccessAndHasValue);

        result = _person;
        Assert.True(result.Success);
        Assert.True(result);
        Assert.IsNull(result.Message);
        Assert.AreEqual(_person, result.Value);
        Assert.IsTrue(result.HasValue);
        Assert.IsTrue(result.SuccessAndHasValue);
    }

    [Test]
    public void FailImplicitTest()
    {
        SimpleResult<PersonEntity> result = false;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.IsNull(result.Message);
        Assert.IsNull(result.Value);
        Assert.IsFalse(result.HasValue);
        Assert.IsFalse(result.SuccessAndHasValue);

        result = ErrorMessage;
        Assert.False(result.Success);
        Assert.False(result);
        Assert.AreEqual(ErrorMessage, result.Message);
        Assert.IsNull(result.Value);
        Assert.IsFalse(result.HasValue);
        Assert.IsFalse(result.SuccessAndHasValue);

        result = new Exception(ErrorMessage);
        Assert.False(result.Success);
        Assert.False(result);
        Assert.AreEqual(ErrorMessage, result.Message);
        Assert.IsNull(result.Value);
        Assert.IsFalse(result.HasValue);
        Assert.IsFalse(result.SuccessAndHasValue);
    }

    [Test]
    public void SuccessImplicitTValueToSimpleTest()
    {
        SimpleResult<PersonEntity> result1 = _person;
        SimpleResult result2 = result1;
        Assert.AreEqual(result1.Success, result2.Success);
        Assert.AreEqual(result1.Message, result2.Message);
        Assert.AreEqual(result1.Exception, result2.Exception);

        Assert.AreEqual(true, result2.Success);
        Assert.IsNull(result2.Message);
        Assert.IsNull(result2.Exception);
    }

    [Test]
    public void FailImplicitTValueToSimpleTest()
    {
        SimpleResult<PersonEntity> result1 = new Exception(ErrorMessage);
        SimpleResult result2 = result1;
        Assert.AreEqual(result1.Success, result2.Success);
        Assert.AreEqual(result1.Message, result2.Message);
        Assert.AreEqual(result1.Exception, result2.Exception);

        Assert.AreEqual(false, result2.Success);
        Assert.AreEqual(ErrorMessage, result2.Message);
        Assert.IsNotNull(result2.Exception);
    }
}

public class PersonEntity
{
    public PersonEntity()
    {
    }

    public PersonEntity(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}
