using System;
using Maestria.Extensions;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class SimpleResultTest
    {
        const string ErrorMessage = "Test";
        const string ExceptionStack = "Test\r\nType: System.Exception\r\n";

        [Test]
        public void FailConstructorTest()
        {
            var result = new SimpleResult();
            Assert.False(result.Success);
            Assert.False(result);
            Assert.IsNull(result.Message);

            result = new SimpleResult(new Exception(ErrorMessage));
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);
            Assert.AreEqual(ExceptionStack, result.Exception.GetAllMessages());
        }

        [Test]
        public void SuccessConstructorTest()
        {
            var result = new SimpleResult(true);
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
        }

        [Test]
        public void SuccessImplicitTest()
        {
            SimpleResult result = true;
            Assert.True(result.Success);
            Assert.True(result);
            Assert.IsNull(result.Message);
        }

        [Test]
        public void FailImplicitTest()
        {
            SimpleResult result = false;
            Assert.False(result.Success);
            Assert.False(result);
            Assert.IsNull(result.Message);

            result = ErrorMessage;
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);

            result = new Exception(ErrorMessage);
            Assert.False(result.Success);
            Assert.False(result);
            Assert.AreEqual(ErrorMessage, result.Message);
            Assert.AreEqual(ExceptionStack, result.Exception.GetAllMessages());
        }

        [Test]
        public void ImplicitConversionTest()
        {
            var source = new SimpleResult(true, "Test");
            var sourceValue = new SimpleResult<int>(true, 15, "Test");

            SimpleResult<int> destinationLostingValue = source;
            SimpleResult destinationWhitoutValue = sourceValue;

            Assert.IsTrue(destinationLostingValue.Success);
            Assert.IsTrue(destinationWhitoutValue.Success);
            Assert.AreEqual("Test", destinationLostingValue.Message);
            Assert.AreEqual("Test", destinationWhitoutValue.Message);
            Assert.AreEqual(0, destinationLostingValue.Value);
        }
    }
}
