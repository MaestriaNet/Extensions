using System;
using Maestria.Extensions;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class IfExtensionsTest
    {
        const int value1 = 1;
        const int value2 = 2;
        const int value3 = 3;
        private readonly int? value1Nullable = 1;
        private readonly int? value2Nullable = 2;
        private readonly int? value3Nullable = 3;
        

        [Test]
        public void IfGreater()
        {
            Assert.AreEqual(value1, value3.IfGreater(value2).Then(value1));
            Assert.AreEqual(value2, value2.IfGreater(value2).Then(value1));
            Assert.AreEqual(value1, value1.IfGreater(value2).Then(value3));

            //Assert.AreEqual(value1, value3.IfGreater(value2Nullable).Then(value1));
            // Assert.AreEqual(value1, value3Nullable.IfGreater(value2).Then(value1).Value);
            // Assert.AreEqual(value1, value3Nullable.IfGreater(value2Nullable).Then(value1).Value);
        }

        [Test]
        public void IfGreaterOrEqual()
        {
            Assert.AreEqual(value1, value3.IfGreaterOrEqual(value2).Then(value1));
            Assert.AreEqual(value1, value2.IfGreaterOrEqual(value2).Then(value1));
            Assert.AreEqual(value1, value1.IfGreaterOrEqual(value2).Then(value3));
        }

        [Test]
        public void IfLess()
        {
            Assert.AreEqual(value1, value2.IfLess(value3).Then(value1));
            Assert.AreEqual(value2, value2.IfLess(value2).Then(value1));
            Assert.AreEqual(value2, value2.IfLess(value1).Then(value3));
        }

        [Test]
        public void IfLessOrEqual()
        {
            Assert.AreEqual(value1, value2.IfLessOrEqual(value3).Then(value1));
            Assert.AreEqual(value1, value2.IfLessOrEqual(value2).Then(value1));
            Assert.AreEqual(value3, value3.IfLessOrEqual(value2).Then(value1));
        }

        [Test]
        public void If()
        {
            Assert.AreEqual(value2, value2.If(value3).Then(value1));
            Assert.AreEqual(value2, value2.If(value1).Then(value1));
            Assert.AreEqual(value1, value2.If(value2).Then(value1));
        }

        [Test]
        public void IfNot()
        {
            Assert.AreEqual(value1, value2.IfNot(value3).Then(value1));
            Assert.AreEqual(value1, value2.IfNot(value1).Then(value1));
            Assert.AreEqual(value2, value2.IfNot(value2).Then(value1));
        }
    }
}