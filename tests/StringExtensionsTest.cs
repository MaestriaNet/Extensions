using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp;

public class StringExtensionsTest
{
    private static object _nullValue = null;
    private static string _nullString = null;
    private static object _value = new object();

    [Test]
    public void IsNullCheck()
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
        Assert.IsEmpty("part 1".SubstringBeforeFirstOccurrence("x"));
        Assert.IsEmpty(_nullString.SubstringBeforeFirstOccurrence("x"));
    }

    [Test]
    public void SubstringBeforeFirstOccurrence_DisabledTrim()
    {
        Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
        Assert.AreEqual("part 1 ", "part 1 - part 2-part 3".SubstringBeforeFirstOccurrence("-", false));
        Assert.IsEmpty("part 1".SubstringBeforeFirstOccurrence("x", false));
        Assert.IsEmpty(_nullString.SubstringBeforeFirstOccurrence("x", false));
    }

    [Test]
    public void SubstringBeforeLastOccurrence_Default()
    {
        Assert.AreEqual("part 1", "part 1-part 2".SubstringBeforeLastOccurrence("-"));
        Assert.AreEqual("part 1-part 2", "part 1-part 2-part 3".SubstringBeforeLastOccurrence("-"));
        Assert.IsEmpty("part 1".SubstringBeforeLastOccurrence("x"));
        Assert.IsEmpty(_nullString.SubstringBeforeLastOccurrence("x"));
    }

    [Test]
    public void SubstringBeforeLastOccurrence_DisabledTrim()
    {
        Assert.AreEqual("part 1 ", "part 1 - part 2".SubstringBeforeLastOccurrence("-", false));
        Assert.AreEqual("part 1 - part 2", "part 1 - part 2-part 3".SubstringBeforeLastOccurrence("-", false));
        Assert.IsEmpty("part 1".SubstringBeforeLastOccurrence("x", false));
        Assert.IsEmpty(_nullString.SubstringBeforeLastOccurrence("x", false));
    }

    [Test]
    public void SubstringAfterFirstOccurrence_Default()
    {
        Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
        Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
        Assert.AreEqual("part 2-part 3", "part 1-part 2-part 3".SubstringAfterFirstOccurrence("-"));
        Assert.IsEmpty("part 1".SubstringAfterFirstOccurrence("x"));
        Assert.IsEmpty(_nullString.SubstringAfterFirstOccurrence("x"));
    }

    [Test]
    public void SubstringAfterFirstOccurrence_DisabledTrim()
    {
        Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
        Assert.AreEqual(" part 2 - part 3", "part 1 - part 2 - part 3".SubstringAfterFirstOccurrence("-", false));
        Assert.IsEmpty("part 1".SubstringAfterFirstOccurrence("x", false));
        Assert.IsEmpty(_nullString.SubstringAfterFirstOccurrence("x", false));
    }

    [Test]
    public void SubstringAfterLastOccurrence_Default()
    {
        Assert.AreEqual("part 2", "part 1-part 2".SubstringAfterLastOccurrence("-"));
        Assert.AreEqual("part 3", "part 1-part 2-part 3".SubstringAfterLastOccurrence("-"));
        Assert.IsEmpty("part 1".SubstringAfterLastOccurrence("x"));
        Assert.IsEmpty(_nullString.SubstringAfterLastOccurrence("x"));
    }

    [Test]
    public void SubstringAfterLastOccurrence_DisabledTrim()
    {
        Assert.AreEqual(" part 2", "part 1 - part 2".SubstringAfterLastOccurrence("-", false));
        Assert.AreEqual(" part 3", "part 1 - part 2 - part 3".SubstringAfterLastOccurrence("-", false));
        Assert.AreEqual(" part 3", "part 1 - part 2 - part 3".SubstringAfterLastOccurrence("-", false));
        Assert.IsEmpty("part 1".SubstringAfterLastOccurrence("x", false));
        Assert.IsEmpty(_nullString.SubstringAfterLastOccurrence("x", false));
    }

    [Test]
    public void SubstringAtOccurrenceIndex_Default()
    {
        const string value = "parte 1 - part 2 - part 3 - part 4";
        Assert.AreEqual("parte 1", value.SubstringAtOccurrenceIndex("-", 0));
        Assert.AreEqual("part 2", value.SubstringAtOccurrenceIndex("-", 1));
        Assert.AreEqual("part 3", value.SubstringAtOccurrenceIndex("-", 2));
        Assert.AreEqual("part 4", value.SubstringAtOccurrenceIndex("-", 3));
        Assert.IsEmpty(value.SubstringAtOccurrenceIndex("-", 4, false));
        Assert.IsEmpty(_nullString.SubstringAtOccurrenceIndex("-", 0, false));
    }

    [Test]
    public void SubstringAtOccurrenceIndex_DisabledTrim()
    {
        const string value = "parte 1 - part 2 - part 3 - part 4";
        Assert.AreEqual("parte 1 ", value.SubstringAtOccurrenceIndex("-", 0, false));
        Assert.AreEqual(" part 2 ", value.SubstringAtOccurrenceIndex("-", 1, false));
        Assert.AreEqual(" part 3 ", value.SubstringAtOccurrenceIndex("-", 2, false));
        Assert.AreEqual(" part 4", value.SubstringAtOccurrenceIndex("-", 3, false));
        Assert.IsEmpty(value.SubstringAtOccurrenceIndex("-", 4, false));
        Assert.IsEmpty(_nullString.SubstringAtOccurrenceIndex("-", 0, false));
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
        Assert.IsEmpty(_nullString.SubstringSafe(1, 2));
    }

    [Test]
    public void EmptyIf()
    {
        Assert.IsEmpty("test".EmptyIf("test"));
        Assert.IsEmpty("test".EmptyIf("TEST", true));
        Assert.AreEqual("test".EmptyIf("TEST"), "test");
        Assert.AreEqual("test".EmptyIf("a"), "test");
        Assert.IsEmpty(_nullString.EmptyIf("a"));
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
    public void TruncateTest()
    {
        Assert.AreEqual("tes", "test limit".Truncate(3));
        Assert.AreEqual("test limit", "test limit".Truncate(100));
        Assert.IsEmpty(_nullString.Truncate(5));
    }

    [Test]
    public void TruncateStartTest()
    {
        Assert.AreEqual("mit", "test limit".TruncateStart(3));
        Assert.AreEqual("test limit", "test limit".TruncateStart(100));
        Assert.IsEmpty(_nullString.TruncateStart(5));
    }

    [Test]
    public void OnlyLettersOrNumbersOrUnderscoresOrHyphensTest()
    {
        Assert.AreEqual("Test", "Test".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
        Assert.AreEqual("Test", "{Test}".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
        Assert.AreEqual("Test_12-3", "{Test}_12-3!!".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
    }

    [Test]
    public void OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpacesTest()
    {
        Assert.AreEqual("T  es t", "T  es t".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces());
        Assert.AreEqual("T  es t", "{T  es t}".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces());
        Assert.AreEqual("Test  _12- 3", "{Test}  _12- 3!!".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces());
    }

    // ----- To Snake Case -----

    [TestCase("", "")]
    [TestCase(null, "")]
    public void ToSnakeCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToSnakeCase());

    [TestCase("ValueTest", "value_test")]
    [TestCase("ValueTest1", "value_test_1")]
    [TestCase("ValueTest123", "value_test_123")]
    [TestCase("Value1Test", "value_1_test")]
    [TestCase("Value123Test", "value_123_test")]
    [TestCase("1ValueTest", "1_value_test")]
    [TestCase("123ValueTest", "123_value_test")]
    public void PascalCaseToSnakeCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToSnakeCase());

    [TestCase("value_test", "value_test")]
    [TestCase("value_test_1", "value_test_1")]
    [TestCase("value_test_123", "value_test_123")]
    [TestCase("Value_Test", "value_test")]
    [TestCase("Value_Test_1", "value_test_1")]
    [TestCase("Value_Test_123", "value_test_123")]
    public void SnakeCaseToSnakeCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToSnakeCase());

    [TestCase("value-test", "value_test")]
    [TestCase("value-test-1", "value_test_1")]
    [TestCase("value-test-123", "value_test_123")]
    [TestCase("Value-Test", "value_test")]
    [TestCase("Value-Test-1", "value_test_1")]
    [TestCase("Value-Test-123", "value_test_123")]
    public void KebabCaseToSnakeCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToSnakeCase());

    // ----- To Kebab Case -----

    [TestCase("", "")]
    [TestCase(null, "")]
    public void ToKebabCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToKebabCase());

    [TestCase("ValueTest", "value-test")]
    [TestCase("ValueTest1", "value-test-1")]
    [TestCase("ValueTest123", "value-test-123")]
    [TestCase("Value1Test", "value-1-test")]
    [TestCase("Value123Test", "value-123-test")]
    [TestCase("1ValueTest", "1-value-test")]
    [TestCase("123ValueTest", "123-value-test")]
    public void PascalCaseToKebabCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToKebabCase());

    [TestCase("value_test", "value-test")]
    [TestCase("value_test_1", "value-test-1")]
    [TestCase("value_test_123", "value-test-123")]
    [TestCase("Value_Test", "value-test")]
    [TestCase("Value_Test_1", "value-test-1")]
    [TestCase("Value_Test_123", "value-test-123")]
    public void SnakeCaseToKebabCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToKebabCase());

    [TestCase("value-test", "value-test")]
    [TestCase("value-test-1", "value-test-1")]
    [TestCase("value-test-123", "value-test-123")]
    [TestCase("Value-Test", "value-test")]
    [TestCase("Value-Test-1", "value-test-1")]
    [TestCase("Value-Test-123", "value-test-123")]
    public void KebabCaseToKebabCaseTest(string value, string expected) => Assert.AreEqual(expected, value.ToKebabCase());

    // Tests from F# StringExtensionsTest
    [Test]
    public void TrimStart_Test()
    {
        Assert.AreEqual("Value", "TestValue".TrimStart("Test"));
        Assert.AreEqual("TestValue", "TestValue".TrimStart("Value"));
        Assert.AreEqual("TestValue", "TestValue".TrimStart(Consts.NullString));
        Assert.AreEqual("", Consts.NullString.TrimStart("Test"));
        Assert.AreEqual("", Consts.NullString.TrimStart(Consts.NullString));
        Assert.AreEqual("Value", "TestTestValue".TrimStart("Test"));
    }

    [Test]
    public void TrimEnd_Test()
    {
        Assert.AreEqual("Test", "TestValue".TrimEnd("Value"));
        Assert.AreEqual("TestValue", "TestValue".TrimEnd("Test"));
        Assert.AreEqual("TestValue", "TestValue".TrimEnd(Consts.NullString));
        Assert.AreEqual("", Consts.NullString.TrimEnd("Value"));
        Assert.AreEqual("", Consts.NullString.TrimEnd(Consts.NullString));
        Assert.AreEqual("Test", "TestValueValue".TrimEnd("Value"));
    }

    [Test]
    public void AddToBeginningIfNotStartsWith_Test()
    {
        Assert.AreEqual("TestValue", "TestValue".AddToBeginningIfNotStartsWith("Test"));
        Assert.AreEqual("TestValue", "Value".AddToBeginningIfNotStartsWith("Test"));
        Assert.AreEqual("TestValue", Consts.NullString.AddToBeginningIfNotStartsWith("TestValue"));
        Assert.AreEqual("TestValue", "TestValue".AddToBeginningIfNotStartsWith(Consts.NullString));
        Assert.AreEqual("", Consts.NullString.AddToBeginningIfNotStartsWith(Consts.NullString));
    }

    [Test]
    public void AddToEndIfNotEndsWith_Test()
    {
        Assert.AreEqual("TestValue", "TestValue".AddToEndIfNotEndsWith("Value"));
        Assert.AreEqual("TestValue", "Test".AddToEndIfNotEndsWith("Value"));
        Assert.AreEqual("TestValue", Consts.NullString.AddToEndIfNotEndsWith("TestValue"));
        Assert.AreEqual("TestValue", "TestValue".AddToEndIfNotEndsWith(Consts.NullString));
        Assert.AreEqual("", Consts.NullString.AddToEndIfNotEndsWith(Consts.NullString));
    }

    [Test]
    public void AddToBeginningIfHasValue_Test()
    {
        Assert.AreEqual("", "".AddToBeginningIfHasValue("Mrs."));
        Assert.AreEqual("Mrs. Jhon", "Jhon".AddToBeginningIfHasValue("Mrs. "));
        Assert.AreEqual("", Consts.NullString.AddToBeginningIfHasValue("Mrs."));
    }

    [Test]
    public void AddToEndIfHasValue_Test()
    {
        Assert.AreEqual("", "".AddToEndIfHasValue("Jhon"));
        Assert.AreEqual("Mrs. Jhon", "Mrs. ".AddToEndIfHasValue("Jhon"));
        Assert.AreEqual("", Consts.NullString.AddToEndIfHasValue("Jhon"));
    }

    [Test]
    public void Format_Test()
    {
        Assert.AreEqual("My first name is Jhon and my last name is Smith",
            "My first name is {0} and my last name is {1}".Format("Jhon", "Smith"));
        Assert.AreEqual("My first name is {0} and my last name is {1}",
            "My first name is {0} and my last name is {1}".Format());
        Assert.AreEqual("", Consts.NullString.Format("Jhon", "Smith"));
    }

    [Test]
    public void IsNullOrEmpty_Test()
    {
        Assert.IsTrue(Consts.NullString.IsNullOrEmpty());
        Assert.IsTrue("".IsNullOrEmpty());
        Assert.IsFalse(" ".IsNullOrEmpty());
    }

    [Test]
    public void IsNullOrWhiteSpace_Test()
    {
        Assert.IsTrue(Consts.NullString.IsNullOrWhiteSpace());
        Assert.IsTrue("".IsNullOrWhiteSpace());
        Assert.IsTrue(" ".IsNullOrWhiteSpace());
        Assert.IsFalse("-".IsNullOrWhiteSpace());
    }

    [Test]
    public void HasValue_Test()
    {
        Assert.IsFalse(Consts.NullString.HasValue());
        Assert.IsFalse("".HasValue());
        Assert.IsFalse(" ".HasValue());
        Assert.IsTrue("-".HasValue());
    }

    [Test]
    public void EqualsIgnoreCase_Test()
    {
        Assert.IsTrue("Test".EqualsIgnoreCase("Test"));
        Assert.IsTrue("Test".EqualsIgnoreCase("test"));
        Assert.IsTrue("Test".EqualsIgnoreCase("test "));
        Assert.IsFalse("Test".EqualsIgnoreCase("test ", false));
        Assert.IsFalse("Test".EqualsIgnoreCase(Consts.NullString, false));
        Assert.IsTrue(Consts.NullString.EqualsIgnoreCase(Consts.NullString, false));
        Assert.IsTrue(Consts.NullString.EqualsIgnoreCase("", false));
        Assert.IsTrue("".EqualsIgnoreCase(Consts.NullString, false));
    }

    [TestCase("0123456789", "0123456789")]
    [TestCase("a0a1a2a3a4a5a6a7a8a9", "0123456789")]
    [TestCase(null, "")]
    [TestCase("123.456", "123456")]
    public void OnlyNumbers_Test(string value, string expected)
    {
        Assert.AreEqual(expected, value.OnlyNumbers());
    }

    [TestCase("1a23.45a6", "123.456")]
    [TestCase("1,234.56", "1234.56")]
    public void OnlyNumbers_WithFloatingPoint(string value, string expected)
    {
        Assert.AreEqual(expected, value.OnlyNumbers(true));
    }

    [TestCase("-1a2a3a456", "-123456")]
    public void OnlyNumbers_WithNegativeSign(string value, string expected)
    {
        Assert.AreEqual(expected, value.OnlyNumbers(allowNegativeSign: true));
    }

    [Test]
    public void OnlyNumbers_WithFloatingPointAndNegativeSign()
    {
        Assert.AreEqual("-1234.56", "-1,234.56".OnlyNumbers(true, true, CultureInfo.InvariantCulture));
        Assert.AreEqual("-1234.56", "-1,234.56".OnlyNumbers(true, true, Consts.CultureEnUs));
        Assert.AreEqual("-1234,56", "-1.234,56".OnlyNumbers(true, true, Consts.CulturePtBr));
    }

    [TestCase("áéíóú", "aeiou")]
    [TestCase("âêîôû", "aeiou")]
    [TestCase("ãẽĩõũ", "aeiou")]
    [TestCase("àèìòù", "aeiou")]
    [TestCase("abc !@#$%&*()[]{}:;<>", "abc !@#$%&*()[]{}:;<>")]
    public void RemoveAccents_Test(string value, string expected)
    {
        Assert.AreEqual(expected, value.RemoveAccents());
    }
}
