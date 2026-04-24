using System.Globalization;
using System.Linq;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class StringExtensionsTest
{
    private static object _nullValue = null;
    private static string _nullString = null;
    private static object _value = new object();

    [Fact]
    public void IsNullCheck()
    {
        Assert.True(_nullValue.IsNull());
        Assert.True(_nullString.IsNull());
        Assert.False(_value.IsNull());
    }

    [Fact]
    public void HasValue()
    {
        Assert.False(_nullValue.HasValue());
        Assert.False(_nullString.HasValue());
        Assert.True(_value.HasValue());
    }

    [Fact]
    public void JoinArray()
    {
        var values = new[] { "my", "name", "is", "fabio" };
        Assert.Equal("mynameisfabio", values.Join(""));
        Assert.Equal("my name is fabio", values.Join(" "));
    }

    [Fact]
    public void JoinEnumerable()
    {
        var values = new[] { "my", "name", "is", "fabio" }.AsEnumerable();
        Assert.Equal("mynameisfabio", values.Join(""));
        Assert.Equal("my name is fabio", values.Join(" "));
    }

    [Fact]
    public void SubstringBeforeFirstOccurrence_Default()
    {
        Assert.Equal("part 1", "part 1-part 2".SubstringBeforeFirstOccurrence("-"));
        Assert.Equal("part 1", "part 1-part 2-part 3".SubstringBeforeFirstOccurrence("-"));
        Assert.Empty("part 1".SubstringBeforeFirstOccurrence("x"));
        Assert.Empty(_nullString.SubstringBeforeFirstOccurrence("x"));
    }

    [Fact]
    public void SubstringBeforeFirstOccurrence_DisabledTrim()
    {
        Assert.Equal("part 1 ", "part 1 - part 2".SubstringBeforeFirstOccurrence("-", false));
        Assert.Equal("part 1 ", "part 1 - part 2-part 3".SubstringBeforeFirstOccurrence("-", false));
        Assert.Empty("part 1".SubstringBeforeFirstOccurrence("x", false));
        Assert.Empty(_nullString.SubstringBeforeFirstOccurrence("x", false));
    }

    [Fact]
    public void SubstringBeforeLastOccurrence_Default()
    {
        Assert.Equal("part 1", "part 1-part 2".SubstringBeforeLastOccurrence("-"));
        Assert.Equal("part 1-part 2", "part 1-part 2-part 3".SubstringBeforeLastOccurrence("-"));
        Assert.Empty("part 1".SubstringBeforeLastOccurrence("x"));
        Assert.Empty(_nullString.SubstringBeforeLastOccurrence("x"));
    }

    [Fact]
    public void SubstringBeforeLastOccurrence_DisabledTrim()
    {
        Assert.Equal("part 1 ", "part 1 - part 2".SubstringBeforeLastOccurrence("-", false));
        Assert.Equal("part 1 - part 2", "part 1 - part 2-part 3".SubstringBeforeLastOccurrence("-", false));
        Assert.Empty("part 1".SubstringBeforeLastOccurrence("x", false));
        Assert.Empty(_nullString.SubstringBeforeLastOccurrence("x", false));
    }

    [Fact]
    public void SubstringAfterFirstOccurrence_Default()
    {
        Assert.Equal("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
        Assert.Equal("part 2", "part 1-part 2".SubstringAfterFirstOccurrence("-"));
        Assert.Equal("part 2-part 3", "part 1-part 2-part 3".SubstringAfterFirstOccurrence("-"));
        Assert.Empty("part 1".SubstringAfterFirstOccurrence("x"));
        Assert.Empty(_nullString.SubstringAfterFirstOccurrence("x"));
    }

    [Fact]
    public void SubstringAfterFirstOccurrence_DisabledTrim()
    {
        Assert.Equal(" part 2", "part 1 - part 2".SubstringAfterFirstOccurrence("-", false));
        Assert.Equal(" part 2 - part 3", "part 1 - part 2 - part 3".SubstringAfterFirstOccurrence("-", false));
        Assert.Empty("part 1".SubstringAfterFirstOccurrence("x", false));
        Assert.Empty(_nullString.SubstringAfterFirstOccurrence("x", false));
    }

    [Fact]
    public void SubstringAfterLastOccurrence_Default()
    {
        Assert.Equal("part 2", "part 1-part 2".SubstringAfterLastOccurrence("-"));
        Assert.Equal("part 3", "part 1-part 2-part 3".SubstringAfterLastOccurrence("-"));
        Assert.Empty("part 1".SubstringAfterLastOccurrence("x"));
        Assert.Empty(_nullString.SubstringAfterLastOccurrence("x"));
    }

    [Fact]
    public void SubstringAfterLastOccurrence_DisabledTrim()
    {
        Assert.Equal(" part 2", "part 1 - part 2".SubstringAfterLastOccurrence("-", false));
        Assert.Equal(" part 3", "part 1 - part 2 - part 3".SubstringAfterLastOccurrence("-", false));
        Assert.Equal(" part 3", "part 1 - part 2 - part 3".SubstringAfterLastOccurrence("-", false));
        Assert.Empty("part 1".SubstringAfterLastOccurrence("x", false));
        Assert.Empty(_nullString.SubstringAfterLastOccurrence("x", false));
    }

    [Fact]
    public void SubstringAtOccurrenceIndex_Default()
    {
        const string value = "parte 1 - part 2 - part 3 - part 4";
        Assert.Equal("parte 1", value.SubstringAtOccurrenceIndex("-", 0));
        Assert.Equal("part 2", value.SubstringAtOccurrenceIndex("-", 1));
        Assert.Equal("part 3", value.SubstringAtOccurrenceIndex("-", 2));
        Assert.Equal("part 4", value.SubstringAtOccurrenceIndex("-", 3));
        Assert.Empty(value.SubstringAtOccurrenceIndex("-", 4, false));
        Assert.Empty(_nullString.SubstringAtOccurrenceIndex("-", 0, false));
    }

    [Fact]
    public void SubstringAtOccurrenceIndex_DisabledTrim()
    {
        const string value = "parte 1 - part 2 - part 3 - part 4";
        Assert.Equal("parte 1 ", value.SubstringAtOccurrenceIndex("-", 0, false));
        Assert.Equal(" part 2 ", value.SubstringAtOccurrenceIndex("-", 1, false));
        Assert.Equal(" part 3 ", value.SubstringAtOccurrenceIndex("-", 2, false));
        Assert.Equal(" part 4", value.SubstringAtOccurrenceIndex("-", 3, false));
        Assert.Empty(value.SubstringAtOccurrenceIndex("-", 4, false));
        Assert.Empty(_nullString.SubstringAtOccurrenceIndex("-", 0, false));
    }

    [Fact]
    public void SubstringSafe()
    {
        Assert.Equal("t", "test".SubstringSafe(-1, 1));
        Assert.Empty("test".SubstringSafe(5, 1));
        Assert.Empty("test".SubstringSafe(4, 1));
        Assert.Equal("g", "test substring".SubstringSafe(13, 1));
        Assert.Equal("g", "test substring".SubstringSafe(13, 10));
        Assert.Equal("ng", "test substring".SubstringSafe(12, 2));
        Assert.Equal("ng", "test substring".SubstringSafe(12, 20));
        Assert.Equal(" su", "test substring".SubstringSafe(4, 3));
        Assert.Equal("test", "test substring".SubstringSafe(0, 4));
        Assert.Empty(_nullString.SubstringSafe(1, 2));
    }

    [Fact]
    public void EmptyIf()
    {
        Assert.Empty("test".EmptyIf("test"));
        Assert.Empty("test".EmptyIf("TEST", true));
        Assert.Equal("test".EmptyIf("TEST"), "test");
        Assert.Equal("test".EmptyIf("a"), "test");
        Assert.Empty(_nullString.EmptyIf("a"));
    }

    [Fact]
    public void EmptyIfNull()
    {
        Assert.Empty(_nullString.EmptyIfNull());
        Assert.NotEmpty("test".EmptyIfNull());
        Assert.Equal("test", "test".EmptyIfNull());
        Assert.Equal(" ", " ".EmptyIfNull());
    }

    [Fact]
    public void EmptyIfNullOrWhiteSpace()
    {
        Assert.Empty(_nullString.EmptyIfNullOrWhiteSpace());
        Assert.NotEmpty("test".EmptyIfNullOrWhiteSpace());
        Assert.Equal("test", "test".EmptyIfNullOrWhiteSpace());
        Assert.Empty(" ".EmptyIfNullOrWhiteSpace());
    }

    [Fact]
    public void TruncateTest()
    {
        Assert.Equal("tes", "test limit".Truncate(3));
        Assert.Equal("test limit", "test limit".Truncate(100));
        Assert.Empty(_nullString.Truncate(5));
    }

    [Fact]
    public void TruncateStartTest()
    {
        Assert.Equal("mit", "test limit".TruncateStart(3));
        Assert.Equal("test limit", "test limit".TruncateStart(100));
        Assert.Empty(_nullString.TruncateStart(5));
    }

    [Fact]
    public void OnlyLettersOrNumbersOrUnderscoresOrHyphensTest()
    {
        Assert.Equal("Test", "Test".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
        Assert.Equal("Test", "{Test}".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
        Assert.Equal("Test_12-3", "{Test}_12-3!!".OnlyLettersOrNumbersOrUnderscoresOrHyphens());
    }

    [Fact]
    public void OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpacesTest()
    {
        Assert.Equal("T  es t", "T  es t".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces());
        Assert.Equal("T  es t", "{T  es t}".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces());
        Assert.Equal("Test  _12- 3", "{Test}  _12- 3!!".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces());
    }

    // ----- To Snake Case -----

    [Theory]
    [InlineData("", "")]
    [InlineData(null, "")]
    public void ToSnakeCaseTest(string value, string expected) => Assert.Equal(expected, value.ToSnakeCase());

    [Theory]
    [InlineData("ValueTest", "value_test")]
    [InlineData("ValueTest1", "value_test_1")]
    [InlineData("ValueTest123", "value_test_123")]
    [InlineData("Value1Test", "value_1_test")]
    [InlineData("Value123Test", "value_123_test")]
    [InlineData("1ValueTest", "1_value_test")]
    [InlineData("123ValueTest", "123_value_test")]
    public void PascalCaseToSnakeCaseTest(string value, string expected) => Assert.Equal(expected, value.ToSnakeCase());

    [Theory]
    [InlineData("value_test", "value_test")]
    [InlineData("value_test_1", "value_test_1")]
    [InlineData("value_test_123", "value_test_123")]
    [InlineData("Value_Test", "value_test")]
    [InlineData("Value_Test_1", "value_test_1")]
    [InlineData("Value_Test_123", "value_test_123")]
    public void SnakeCaseToSnakeCaseTest(string value, string expected) => Assert.Equal(expected, value.ToSnakeCase());

    [Theory]
    [InlineData("value-test", "value_test")]
    [InlineData("value-test-1", "value_test_1")]
    [InlineData("value-test-123", "value_test_123")]
    [InlineData("Value-Test", "value_test")]
    [InlineData("Value-Test-1", "value_test_1")]
    [InlineData("Value-Test-123", "value_test_123")]
    public void KebabCaseToSnakeCaseTest(string value, string expected) => Assert.Equal(expected, value.ToSnakeCase());

    // ----- To Kebab Case -----

    [Theory]
    [InlineData("", "")]
    [InlineData(null, "")]
    public void ToKebabCaseTest(string value, string expected) => Assert.Equal(expected, value.ToKebabCase());

    [Theory]
    [InlineData("ValueTest", "value-test")]
    [InlineData("ValueTest1", "value-test-1")]
    [InlineData("ValueTest123", "value-test-123")]
    [InlineData("Value1Test", "value-1-test")]
    [InlineData("Value123Test", "value-123-test")]
    [InlineData("1ValueTest", "1-value-test")]
    [InlineData("123ValueTest", "123-value-test")]
    public void PascalCaseToKebabCaseTest(string value, string expected) => Assert.Equal(expected, value.ToKebabCase());

    [Theory]
    [InlineData("value_test", "value-test")]
    [InlineData("value_test_1", "value-test-1")]
    [InlineData("value_test_123", "value-test-123")]
    [InlineData("Value_Test", "value-test")]
    [InlineData("Value_Test_1", "value-test-1")]
    [InlineData("Value_Test_123", "value-test-123")]
    public void SnakeCaseToKebabCaseTest(string value, string expected) => Assert.Equal(expected, value.ToKebabCase());

    [Theory]
    [InlineData("value-test", "value-test")]
    [InlineData("value-test-1", "value-test-1")]
    [InlineData("value-test-123", "value-test-123")]
    [InlineData("Value-Test", "value-test")]
    [InlineData("Value-Test-1", "value-test-1")]
    [InlineData("Value-Test-123", "value-test-123")]
    public void KebabCaseToKebabCaseTest(string value, string expected) => Assert.Equal(expected, value.ToKebabCase());

    // Tests from F# StringExtensionsTest
    [Fact]
    public void TrimStart_Test()
    {
        Assert.Equal("Value", "TestValue".TrimStart("Test"));
        Assert.Equal("TestValue", "TestValue".TrimStart("Value"));
        Assert.Equal("TestValue", "TestValue".TrimStart(Consts.NullString));
        Assert.Equal("", Consts.NullString.TrimStart("Test"));
        Assert.Equal("", Consts.NullString.TrimStart(Consts.NullString));
        Assert.Equal("Value", "TestTestValue".TrimStart("Test"));
    }

    [Fact]
    public void TrimEnd_Test()
    {
        Assert.Equal("Test", "TestValue".TrimEnd("Value"));
        Assert.Equal("TestValue", "TestValue".TrimEnd("Test"));
        Assert.Equal("TestValue", "TestValue".TrimEnd(Consts.NullString));
        Assert.Equal("", Consts.NullString.TrimEnd("Value"));
        Assert.Equal("", Consts.NullString.TrimEnd(Consts.NullString));
        Assert.Equal("Test", "TestValueValue".TrimEnd("Value"));
    }

    [Fact]
    public void AddToBeginningIfNotStartsWith_Test()
    {
        Assert.Equal("TestValue", "TestValue".AddToBeginningIfNotStartsWith("Test"));
        Assert.Equal("TestValue", "Value".AddToBeginningIfNotStartsWith("Test"));
        Assert.Equal("TestValue", Consts.NullString.AddToBeginningIfNotStartsWith("TestValue"));
        Assert.Equal("TestValue", "TestValue".AddToBeginningIfNotStartsWith(Consts.NullString));
        Assert.Equal("", Consts.NullString.AddToBeginningIfNotStartsWith(Consts.NullString));
    }

    [Fact]
    public void AddToEndIfNotEndsWith_Test()
    {
        Assert.Equal("TestValue", "TestValue".AddToEndIfNotEndsWith("Value"));
        Assert.Equal("TestValue", "Test".AddToEndIfNotEndsWith("Value"));
        Assert.Equal("TestValue", Consts.NullString.AddToEndIfNotEndsWith("TestValue"));
        Assert.Equal("TestValue", "TestValue".AddToEndIfNotEndsWith(Consts.NullString));
        Assert.Equal("", Consts.NullString.AddToEndIfNotEndsWith(Consts.NullString));
    }

    [Fact]
    public void AddToBeginningIfHasValue_Test()
    {
        Assert.Equal("", "".AddToBeginningIfHasValue("Mrs."));
        Assert.Equal("Mrs. Jhon", "Jhon".AddToBeginningIfHasValue("Mrs. "));
        Assert.Equal("", Consts.NullString.AddToBeginningIfHasValue("Mrs."));
    }

    [Fact]
    public void AddToEndIfHasValue_Test()
    {
        Assert.Equal("", "".AddToEndIfHasValue("Jhon"));
        Assert.Equal("Mrs. Jhon", "Mrs. ".AddToEndIfHasValue("Jhon"));
        Assert.Equal("", Consts.NullString.AddToEndIfHasValue("Jhon"));
    }

    [Fact]
    public void Format_Test()
    {
        Assert.Equal("My first name is Jhon and my last name is Smith",
            "My first name is {0} and my last name is {1}".Format("Jhon", "Smith"));
        Assert.Equal("My first name is {0} and my last name is {1}",
            "My first name is {0} and my last name is {1}".Format());
        Assert.Equal("", Consts.NullString.Format("Jhon", "Smith"));
    }

    [Fact]
    public void IsNullOrEmpty_Test()
    {
        Assert.True(Consts.NullString.IsNullOrEmpty());
        Assert.True("".IsNullOrEmpty());
        Assert.False(" ".IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrWhiteSpace_Test()
    {
        Assert.True(Consts.NullString.IsNullOrWhiteSpace());
        Assert.True("".IsNullOrWhiteSpace());
        Assert.True(" ".IsNullOrWhiteSpace());
        Assert.False("-".IsNullOrWhiteSpace());
    }

    [Fact]
    public void HasValue_Test()
    {
        Assert.False(Consts.NullString.HasValue());
        Assert.False("".HasValue());
        Assert.False(" ".HasValue());
        Assert.True("-".HasValue());
    }

    [Fact]
    public void EqualsIgnoreCase_Test()
    {
        Assert.True("Test".EqualsIgnoreCase("Test"));
        Assert.True("Test".EqualsIgnoreCase("test"));
        Assert.True("Test".EqualsIgnoreCase("test "));
        Assert.False("Test".EqualsIgnoreCase("test ", false));
        Assert.False("Test".EqualsIgnoreCase(Consts.NullString, false));
        Assert.True(Consts.NullString.EqualsIgnoreCase(Consts.NullString, false));
        Assert.True(Consts.NullString.EqualsIgnoreCase("", false));
        Assert.True("".EqualsIgnoreCase(Consts.NullString, false));
    }

    [Theory]
    [InlineData("0123456789", "0123456789")]
    [InlineData("a0a1a2a3a4a5a6a7a8a9", "0123456789")]
    [InlineData(null, "")]
    [InlineData("123.456", "123456")]
    public void OnlyNumbers_Test(string value, string expected)
    {
        Assert.Equal(expected, value.OnlyNumbers());
    }

    [Theory]
    [InlineData("1a23.45a6", "123.456")]
    [InlineData("1,234.56", "1234.56")]
    public void OnlyNumbers_WithFloatingPoint(string value, string expected)
    {
        Assert.Equal(expected, value.OnlyNumbers(true));
    }

    [Theory]
    [InlineData("-1a2a3a456", "-123456")]
    public void OnlyNumbers_WithNegativeSign(string value, string expected)
    {
        Assert.Equal(expected, value.OnlyNumbers(allowNegativeSign: true));
    }

    [Fact]
    public void OnlyNumbers_WithFloatingPointAndNegativeSign()
    {
        Assert.Equal("-1234.56", "-1,234.56".OnlyNumbers(true, true, CultureInfo.InvariantCulture));
        Assert.Equal("-1234.56", "-1,234.56".OnlyNumbers(true, true, Consts.CultureEnUs));
        Assert.Equal("-1234,56", "-1.234,56".OnlyNumbers(true, true, Consts.CulturePtBr));
    }

    [Theory]
    [InlineData("áéíóú", "aeiou")]
    [InlineData("âêîôû", "aeiou")]
    [InlineData("ãẽĩõũ", "aeiou")]
    [InlineData("àèìòù", "aeiou")]
    [InlineData("abc !@#$%&*()[]{}:;<>", "abc !@#$%&*()[]{}:;<>")]
    public void RemoveAccents_Test(string value, string expected)
    {
        Assert.Equal(expected, value.RemoveAccents());
    }
}
