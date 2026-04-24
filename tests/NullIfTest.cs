using System;
using Maestria.Extensions;
using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class NullIfTest
{
    [Fact]
    public void NullIf_ReturningNull() => Assert.Null(Consts.Guid.NullIf(Consts.Guid));

    [Fact]
    public void NullIf_DontReturningNull() => Assert.Equal(Consts.Guid, Consts.Guid.NullIf(Consts.EmptyGuid));

    // Tests from F# NullIfExtensionsTest - Default
    [Fact]
    public void NullIf_ShouldBeNull()
    {
        Assert.Null(Consts.DateTimeInput.NullIf(Consts.DateTimeInput));
        Assert.Null(5.NullIf(5));
        Assert.Null(5.NullIfIn(4, 5, 6));
        Assert.Null(5.NullIfBetween(4, 6));
        Assert.Null(new Person() { Name = "test" }.NullIf(new Person() { Name = "test" }));
    }

    [Fact]
    public void NullIf_ShouldHaveValue()
    {
        Assert.Equal(Consts.DateTimeInput, Consts.DateTimeInput.NullIf(DateTime.MinValue));
        Assert.Equal(3, 3.NullIf(5));
        Assert.Equal(3, 3.NullIfIn(4, 5, 6));
        Assert.Equal(3, 3.NullIfBetween(4, 6));
        Assert.Equal(new Person() { Name = "test" }, new Person() { Name = "test" }.NullIf(new Person() { Name = "test-2" }));
    }

    // Floating point tolerance tests
    [Fact]
    public void NullIf_FloatingPointTolerance_ShouldBeNull()
    {
        Assert.Null(54f.NullIf(54.000009f));
        Assert.Null(54.0.NullIf(54.000009));
        Assert.Null(54m.NullIf(54.000009m, 0.00001m)); // Decimal requires explicit tolerance
    }

    [Fact]
    public void NullIf_FloatingPointTolerance_ShouldBeNull_NullableTypes()
    {
        Assert.Null(((float?)54f).NullIf((float?)54.000009f));
        Assert.Null(((double?)54.0).NullIf((double?)54.000009));
        Assert.Null(((decimal?)54m).NullIf((decimal?)54.000009m, 0.00001m));
    }

    [Fact]
    public void NullIf_FloatingPointTolerance_ShouldHaveValue()
    {
        Assert.Equal(54f, 54f.NullIf(54.00001f));
        Assert.Equal(54.0, 54.0.NullIf(54.00001));
        Assert.Equal(54m, 54m.NullIf(54.00001m));
        Assert.Equal(54m, 54m.NullIf(54.000009m)); // Decimal without tolerance
    }

    [Fact]
    public void NullIf_FloatingPointTolerance_ShouldHaveValue_NullableTypes()
    {
        Assert.Equal(54f, ((float?)54f).NullIf((float?)54.00001f));
        Assert.Equal(54.0, ((double?)54.0).NullIf((double?)54.00001));
        Assert.Equal(54m, ((decimal?)54m).NullIf((decimal?)54.00001m));
        Assert.Equal(54m, ((decimal?)54m).NullIf((decimal?)54.000009m));
    }

    // String tests
    [Fact]
    public void NullIf_String_IfEmpty()
    {
        Assert.Null("".NullIfEmpty());
        Assert.Equal("test", "test".NullIfEmpty());
    }

    [Fact]
    public void NullIf_String_IfWhiteSpace()
    {
        Assert.Null("  ".NullIfWhiteSpace());
        Assert.Equal("test", "test".NullIfWhiteSpace());
    }

    [Fact]
    public void NullIf_String_IgnoreCase()
    {
        Assert.Null("test".NullIf("test"));
        Assert.Equal("test", "test".NullIf("TEST"));
        Assert.Null("test".NullIf("test", false));
        Assert.Equal("test", "test".NullIf("TEST", false));
        Assert.Null("test".NullIf("test", true));
        Assert.Null("test".NullIf("TEST", true));
        Assert.Equal("test", "test".NullIf(Consts.NullString));
        Assert.Null(Consts.NullString.NullIf(Consts.NullString));
    }
}