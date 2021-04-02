using System;
using Maestria.Extensions.DataTypes;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class SimpleResultTValueTest
    {
        const string ErrorMessage = "Test";
        const string ExceptionStack = "Test\r\nType: System.Exception\r\n";

        private readonly Person _person = new Person(1, "Fábio");

        [Test]
        public void FailConstructorTest()
        {
            var result = new SimpleResult<Person>();
            Assert.False(result.Success);
            Assert.False(result);
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Value);

            result = new SimpleResult<Person>(new Exception(ErrorMessage));
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);
            Assert.AreEqual(ExceptionStack, result.Exception.GetAllMessages());
            Assert.IsNull(result.Value);
        }

        [Test]
        public void SuccessConstructorTest()
        {
            var result = new SimpleResult<Person>(_person);
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
            Assert.AreEqual(_person, result.Value);

            result = new SimpleResult<Person>(true, _person);
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
            Assert.AreEqual(_person, result.Value);
        }

        [Test]
        public void SuccessImplicitTest()
        {
            SimpleResult<Person> result = true;
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Value);

            result = _person;
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
            Assert.AreEqual(_person, result.Value);
        }

        [Test]
        public void FailImplicitTest()
        {
            SimpleResult<Person> result = false;
            Assert.False(result.Success);
            Assert.False(result);
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Value);

            result = ErrorMessage;
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);
            Assert.IsNull(result.Value);

            result = new Exception(ErrorMessage);
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);
            Assert.AreEqual(ExceptionStack, result.Exception.GetAllMessages());
            Assert.IsNull(result.Value);
        }

        [Test]
        public void SuccessImplicitTValueToSimpleTest()
        {
            SimpleResult<Person> result1 = _person;
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
            SimpleResult<Person> result1 = new Exception(ErrorMessage);
            SimpleResult result2 = result1;
            Assert.AreEqual(result1.Success, result2.Success);
            Assert.AreEqual(result1.Message, result2.Message);
            Assert.AreEqual(result1.Exception, result2.Exception);

            Assert.AreEqual(false, result2.Success);
            Assert.AreEqual(ErrorMessage, result2.Message);
            Assert.AreEqual(ExceptionStack, result2.Exception.GetAllMessages());
            Assert.IsNotNull(result2.Exception);
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
}
