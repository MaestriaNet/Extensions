using System;
using Maestria.Extensions;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp;

public class NullIfTest
{
    [Test]
    public void NullIf_ReturningNull() => Assert.Null(Consts.Guid.NullIf(Consts.Guid));

    [Test]
    public void NullIf_DontReturningNull() => Assert.AreEqual(Consts.Guid, Consts.Guid.NullIf(Consts.EmptyGuid));

    // Tests from F# NullIfExtensionsTest - Default
    [Test]
    public void NullIf_ShouldBeNull()
    {
        Assert.IsNull(Consts.DateTimeInput.NullIf(Consts.DateTimeInput));
        Assert.IsNull(5.NullIf(5));
        Assert.IsNull(5.NullIfIn(4, 5, 6));
        Assert.IsNull(5.NullIfBetween(4, 6));
        Assert.IsNull(new Person() { Name = "test" }.NullIf(new Person() { Name = "test" }));
    }

    [Test]
    public void NullIf_ShouldHaveValue()
    {
        Assert.AreEqual(Consts.DateTimeInput, Consts.DateTimeInput.NullIf(DateTime.MinValue));
        Assert.AreEqual(3, 3.NullIf(5));
        Assert.AreEqual(3, 3.NullIfIn(4, 5, 6));
        Assert.AreEqual(3, 3.NullIfBetween(4, 6));
        Assert.AreEqual(new Person() { Name = "test" }, new Person() { Name = "test" }.NullIf(new Person() { Name = "test-2" }));
    }

    // Floating point tolerance tests
    [Test]
    public void NullIf_FloatingPointTolerance_ShouldBeNull()
    {
        Assert.IsNull(54f.NullIf(54.000009f));
        Assert.IsNull(54.0.NullIf(54.000009));
        Assert.IsNull(54m.NullIf(54.000009m, 0.00001m)); // Decimal requires explicit tolerance
    }

    [Test]
    public void NullIf_FloatingPointTolerance_ShouldBeNull_NullableTypes()
    {
        Assert.IsNull(((float?)54f).NullIf((float?)54.000009f));
        Assert.IsNull(((double?)54.0).NullIf((double?)54.000009));
        Assert.IsNull(((decimal?)54m).NullIf((decimal?)54.000009m, 0.00001m));
    }

    [Test]
    public void NullIf_FloatingPointTolerance_ShouldHaveValue()
    {
        Assert.AreEqual(54f, 54f.NullIf(54.00001f));
        Assert.AreEqual(54.0, 54.0.NullIf(54.00001));
        Assert.AreEqual(54m, 54m.NullIf(54.00001m));
        Assert.AreEqual(54m, 54m.NullIf(54.000009m)); // Decimal without tolerance
    }

    [Test]
    public void NullIf_FloatingPointTolerance_ShouldHaveValue_NullableTypes()
    {
        Assert.AreEqual(54f, ((float?)54f).NullIf((float?)54.00001f));
        Assert.AreEqual(54.0, ((double?)54.0).NullIf((double?)54.00001));
        Assert.AreEqual(54m, ((decimal?)54m).NullIf((decimal?)54.00001m));
        Assert.AreEqual(54m, ((decimal?)54m).NullIf((decimal?)54.000009m));
    }

    // String tests
    [Test]
    public void NullIf_String_IfEmpty()
    {
        Assert.IsNull("".NullIfEmpty());
        Assert.AreEqual("test", "test".NullIfEmpty());
    }

    [Test]
    public void NullIf_String_IfWhiteSpace()
    {
        Assert.IsNull("  ".NullIfWhiteSpace());
        Assert.AreEqual("test", "test".NullIfWhiteSpace());
    }

    [Test]
    public void NullIf_String_IgnoreCase()
    {
        Assert.IsNull("test".NullIf("test"));
        Assert.AreEqual("test", "test".NullIf("TEST"));
        Assert.IsNull("test".NullIf("test", false));
        Assert.AreEqual("test", "test".NullIf("TEST", false));
        Assert.IsNull("test".NullIf("test", true));
        Assert.IsNull("test".NullIf("TEST", true));
        Assert.AreEqual("test", "test".NullIf(Consts.NullString));
        Assert.IsNull(Consts.NullString.NullIf(Consts.NullString));
    }
}