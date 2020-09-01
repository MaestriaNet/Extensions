using System.Linq;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class StringExtensionsTest
    {
        private static object _nullValue = null;
        private static object _value = new object();

        [Test]
        public void IsNull()
        {
            Assert.IsTrue(_nullValue.IsNull());
            Assert.IsFalse(_value.IsNull());
        }

        [Test]
        public void HasValue()
        {
            Assert.IsFalse(_nullValue.HasValue());
            Assert.IsTrue(_value.HasValue());
        }

        [Test]
        public void JoinArray()
        {
            var values = new[] { "my", "name", "is", "fabio" };
            Assert.AreEqual("mynameisfabio", values.Join(""));
            Assert.AreEqual("my name is fabio", values.Join(" "));
        }

        [Test]
        public void JoinEnumerable()
        {
            var values = new[] { "my", "name", "is", "fabio" }.AsEnumerable();
            Assert.AreEqual("mynameisfabio", values.Join(""));
            Assert.AreEqual("my name is fabio", values.Join(" "));
        }

        [Test]
        public void SubstringBeforeFirstOccurrence_Default()
        {
            Assert.AreEqual("part 1", "part 1-part 2".SubstringBeforeFirstOccurrence("-"));
            Assert.AreEqual("part 1", "part 1-part 2".SubstringBeforeFirstOccurrence("-"));
            Assert.AreEqual("part 1", "part 1-part 2-part 3".SubstringBeforeFirstOccurrence("-"));
            Assert.Null("part 1".SubstringBeforeFirstOccurrence("x"));
        }

        [Test]
        public void SubstringBeforeFirstOccurrence_DisabledTrim()
        {
            Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
            Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
            Assert.AreEqual("part 1 ", "part 1 - part 2-part 3".SubstringBeforeFirstOccurrence("-", false));
            Assert.Null("part 1".SubstringBeforeFirstOccurrence("x", false));
        }

        [Test]
        public void SubstringAfterFirstOccurrence_Default()
        {
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
            Assert.AreEqual("part 2-part 3", "part 1-part 2-part 3".SubstringAfterFirstOccurrence("-"));
            Assert.Null("part 1".SubstringAfterFirstOccurrence("x"));
        }

        [Test]
        public void SubstringAfterFirstOccurrence_DisabledTrim()
        {
            Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
            Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
            Assert.AreEqual(" part 2 - part 3", "part 1 - part 2 - part 3".SubstringAfterFirstOccurrence("-", false));
            Assert.Null("part 1".SubstringAfterFirstOccurrence("x", false));
        }

        [Test]
        public void SubstringSafe()
        {
            Assert.IsNull("test".SubstringSafe(-1, 1));
            Assert.IsNull("test".SubstringSafe(5, 1));
            Assert.IsEmpty("test".SubstringSafe(4, 1));
            Assert.AreEqual("g", "test substring".SubstringSafe(13, 1));
            Assert.AreEqual("g", "test substring".SubstringSafe(13, 10));
            Assert.AreEqual("ng", "test substring".SubstringSafe(12, 2));
            Assert.AreEqual("ng", "test substring".SubstringSafe(12, 20));
            Assert.AreEqual(" su", "test substring".SubstringSafe(4, 3));
        }
    }
}