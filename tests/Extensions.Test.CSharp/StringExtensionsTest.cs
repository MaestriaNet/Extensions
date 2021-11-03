using System.Linq;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class StringExtensionsTest
    {
        private static object _nullValue = null;
        private static string _nullString = null;
        private static object _value = new object();

        [Test]
        public void IsNull()
        {
            Assert.IsTrue(_nullValue.IsNull());
            Assert.IsTrue(_nullString.IsNull());
            Assert.IsFalse(_value.IsNull());
        }

        [Test]
        public void HasValue()
        {
            Assert.IsFalse(_nullValue.HasValue());
            Assert.IsFalse(_nullString.HasValue());
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
            Assert.AreEqual("part 1", "part 1-part 2-part 3".SubstringBeforeFirstOccurrence("-"));
            Assert.IsNull("part 1".SubstringBeforeFirstOccurrence("x"));
            Assert.IsNull(_nullString.SubstringBeforeFirstOccurrence("x"));
        }

        [Test]
        public void SubstringBeforeFirstOccurrence_DisabledTrim()
        {
            Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
            Assert.AreEqual("part 1 ", "part 1 - part 2-part 3".SubstringBeforeFirstOccurrence("-", false));
            Assert.IsNull("part 1".SubstringBeforeFirstOccurrence("x", false));
            Assert.IsNull(_nullString.SubstringBeforeFirstOccurrence("x", false));
        }

        [Test]
        public void SubstringBeforeLastOccurrence_Default()
        {
            Assert.AreEqual("part 1", "part 1-part 2".SubstringBeforeLastOccurrence("-"));
            Assert.AreEqual("part 1-part 2", "part 1-part 2-part 3".SubstringBeforeLastOccurrence("-"));
            Assert.IsNull("part 1".SubstringBeforeLastOccurrence("x"));
            Assert.IsNull(_nullString.SubstringBeforeLastOccurrence("x"));
        }

        [Test]
        public void SubstringBeforeLastOccurrence_DisabledTrim()
        {
            Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeLastOccurrence("-", false));
            Assert.AreEqual("part 1 - part 2", "part 1 - part 2-part 3".SubstringBeforeLastOccurrence("-", false));
            Assert.IsNull("part 1".SubstringBeforeLastOccurrence("x", false));
            Assert.IsNull(_nullString.SubstringBeforeLastOccurrence("x", false));
        }

        [Test]
        public void SubstringAfterFirstOccurrence_Default()
        {
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
            Assert.AreEqual("part 2-part 3", "part 1-part 2-part 3".SubstringAfterFirstOccurrence("-"));
            Assert.IsNull("part 1".SubstringAfterFirstOccurrence("x"));
            Assert.IsNull(_nullString.SubstringAfterFirstOccurrence("x"));
        }

        [Test]
        public void SubstringAfterFirstOccurrence_DisabledTrim()
        {
            Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
            Assert.AreEqual(" part 2 - part 3", "part 1 - part 2 - part 3".SubstringAfterFirstOccurrence("-", false));
            Assert.IsNull("part 1".SubstringAfterFirstOccurrence("x", false));
            Assert.IsNull(_nullString.SubstringAfterFirstOccurrence("x", false));
        }

        [Test]
        public void SubstringAfterLastOccurrence_Default()
        {
            Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterLastOccurrence("-"));
            Assert.AreEqual("part 3", "part 1-part 2-part 3".SubstringAfterLastOccurrence("-"));
            Assert.IsNull("part 1".SubstringAfterLastOccurrence("x"));
            Assert.IsNull(_nullString.SubstringAfterLastOccurrence("x"));
        }

        [Test]
        public void SubstringAfterLastOccurrence_DisabledTrim()
        {
            Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterLastOccurrence("-", false));
            Assert.AreEqual(" part 3", "part 1 - part 2 - part 3".SubstringAfterLastOccurrence("-", false));
            Assert.AreEqual(" part 3", "part 1 - part 2 - part 3".SubstringAfterLastOccurrence("-", false));
            Assert.IsNull("part 1".SubstringAfterLastOccurrence("x", false));
            Assert.IsNull(_nullString.SubstringAfterLastOccurrence("x", false));
        }

        [Test]
        public void SubstringAtOccurrenceIndex_Default()
        {
            const string value = "parte 1 - part 2 - part 3 - part 4";
            Assert.AreEqual("parte 1", value.SubstringAtOccurrenceIndex("-", 0));
            Assert.AreEqual("part 2", value.SubstringAtOccurrenceIndex("-", 1));
            Assert.AreEqual("part 3", value.SubstringAtOccurrenceIndex("-", 2));
            Assert.AreEqual("part 4", value.SubstringAtOccurrenceIndex("-", 3));
            Assert.IsNull(value.SubstringAtOccurrenceIndex("-", 4, false));
            Assert.IsNull(_nullString.SubstringAtOccurrenceIndex("-", 0, false));
        }

        [Test]
        public void SubstringAtOccurrenceIndex_DisabledTrim()
        {
            const string value = "parte 1 - part 2 - part 3 - part 4";
            Assert.AreEqual("parte 1 ", value.SubstringAtOccurrenceIndex("-", 0, false));
            Assert.AreEqual(" part 2 ", value.SubstringAtOccurrenceIndex("-", 1, false));
            Assert.AreEqual(" part 3 ", value.SubstringAtOccurrenceIndex("-", 2, false));
            Assert.AreEqual(" part 4", value.SubstringAtOccurrenceIndex("-", 3, false));
            Assert.IsNull(value.SubstringAtOccurrenceIndex("-", 4, false));
            Assert.IsNull(_nullString.SubstringAtOccurrenceIndex("-", 0, false));
        }

        [Test]
        public void SubstringSafe()
        {
            Assert.AreEqual("t", "test".SubstringSafe(-1, 1));
            Assert.IsEmpty("test".SubstringSafe(5, 1));
            Assert.IsEmpty("test".SubstringSafe(4, 1));
            Assert.AreEqual("g", "test substring".SubstringSafe(13, 1));
            Assert.AreEqual("g", "test substring".SubstringSafe(13, 10));
            Assert.AreEqual("ng", "test substring".SubstringSafe(12, 2));
            Assert.AreEqual("ng", "test substring".SubstringSafe(12, 20));
            Assert.AreEqual(" su", "test substring".SubstringSafe(4, 3));
            Assert.AreEqual("test", "test substring".SubstringSafe(0, 4));
            Assert.IsNull(_nullString.SubstringSafe(1, 2));
        }

        [Test]
        public void EmptyIf()
        {
            Assert.IsEmpty("test".EmptyIf("test"));
            Assert.IsEmpty("test".EmptyIf("TEST", true));
            Assert.AreEqual("test".EmptyIf("TEST"), "test");
            Assert.AreEqual("test".EmptyIf("a"), "test");
            Assert.IsNull(_nullString.EmptyIf("a"));
        }

        [Test]
        public void EmptyIfNull()
        {
            Assert.IsEmpty(_nullString.EmptyIfNull());
            Assert.IsNotEmpty("test".EmptyIfNull());
            Assert.AreEqual("test", "test".EmptyIfNull());
            Assert.AreEqual(" ", " ".EmptyIfNull());
        }

        [Test]
        public void EmptyIfNullOrWhiteSpace()
        {
            Assert.IsEmpty(_nullString.EmptyIfNullOrWhiteSpace());
            Assert.IsNotEmpty("test".EmptyIfNullOrWhiteSpace());
            Assert.AreEqual("test", "test".EmptyIfNullOrWhiteSpace());
            Assert.IsEmpty(" ".EmptyIfNullOrWhiteSpace());
        }

        [Test]
        public void LimitTest()
        {
            Assert.AreEqual("tes", "test limit".LimitLen(3));
            Assert.AreEqual("test limit", "test limit".LimitLen(100));
            Assert.IsNull(_nullString.LimitLen(5));
        }

        [Test]
        public void LimitReverseTest()
        {
            Assert.AreEqual("mit", "test limit".LimitLenReverse(3));
            Assert.AreEqual("test limit", "test limit".LimitLenReverse(100));
            Assert.IsNull(_nullString.LimitLenReverse(5));
        }

        [Test]
        public void OnlyLettersOrNumbersOrUnderscoresOrHyphensTest()
        {
            Assert.AreEqual("Test", "Test".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
            Assert.AreEqual("Test", "{Test}".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
            Assert.AreEqual("Test_12-3", "{Test}_12-3".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
        }
    }
}
