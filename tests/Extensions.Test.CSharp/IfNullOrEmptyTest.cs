using NUnit.Framework;
using Maestria.Extensions;
using System;

namespace Extensions.Test.CSharp
{
    public class IfNullOrEmptyTest
    {
        [Test]
        public void IfNullOrEmpty_EmptyStringTest() => Assert.True(Consts.EmptyString.IsNullOrEmpty());

        [Test]
        public void IfNullOrEmpty_EmptyStringFailTest() => Assert.False(Consts.Text.IsNullOrEmpty());

        [Test]
        public void IfNullOrEmpty_EmptyGuidTest() => Assert.True(Consts.EmptyGuid.IsEmpty());

        [Test]
        public void IfNullOrEmpty_EmptyGuidFailTest() => Assert.False(Guid.NewGuid().IsEmpty());

        [Test]
        public void IfNullOrEmpty_NullGuidTest() => Assert.True(Consts.NullGuid.IsNullOrEmpty());

        [Test]
        public void IfNullOrEmpty_NullGuidFailTest() => Assert.False(((Guid?) Guid.NewGuid()).IsNullOrEmpty());
    }
}