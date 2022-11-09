using System;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class SimpleResultTValueTest
    {
        const string ErrorMessage = "Test";

        private readonly Person _person = new Person(1, "Fábio");
        private readonly Person _nullPerson = null;

        [Test]
        public void FailConstructorTest()
        {
            var result = new SimpleResult<Person>();
            Assert.False(result.Success);
            Assert.False(result);
            Assert.IsNull(result.Message);
            Assert.IsNull(result.Value);
            Assert.False(result.HasValue);

            result = new SimpleResult<Person>(new Exception(ErrorMessage));
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);
            Assert.IsNull(result.Value);
            Assert.False(result.HasValue);
        }

        [Test]
        public void SuccessConstructorTest()
        {
            var result = new SimpleResult<Person>(_person);
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
            Assert.AreEqual(_person, result.Value);
            Assert.IsTrue(result.HasValue);
            Assert.IsTrue(result.SuccessAndHasValue);

            result = new SimpleResult<Person>(true, _person);
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
            SimpleResult<Person> result = true;
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
            SimpleResult<Person> result = _nullPerson;
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
            SimpleResult<Person> result = false;
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
