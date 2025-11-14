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
}
