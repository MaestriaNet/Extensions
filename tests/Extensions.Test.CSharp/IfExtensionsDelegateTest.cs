using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class IfExtensionsDelegateTest
{
    const int value1 = 1;
    const int value2 = 2;
    const int value3 = 3;
    private readonly int? value1Nullable = 1;
    private readonly int? value2Nullable = 2;
    private readonly int? value3Nullable = 3;
    private int? nullValue = null;


    [Fact]
    public void IfGreater()
    {
        // Not null
        Assert.Equal(value1, value3.IfGreater(value2).Then(() => value1));
        Assert.Equal(value2, value2.IfGreater(value2).Then(() => value1));
        Assert.Equal(value1, value1.IfGreater(value2).Then(() => value3));

        Assert.Equal(value1, value3.IfGreater(value2).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfGreater(value2).Then(() => value1Nullable));
        Assert.Equal(value1, value1.IfGreater(value2).Then(() => value3Nullable));

        // Compare value nullable
        Assert.Equal(value1, value3.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value2, value2.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value1.IfGreater(value2Nullable).Then(() => value3));

        Assert.Equal(value1, value3.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value1.IfGreater(value2Nullable).Then(() => value3Nullable));

        Assert.Equal(value1, value3Nullable.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value1Nullable.IfGreater(value2Nullable).Then(() => value3));

        Assert.Equal(value1, value3Nullable.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2Nullable.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value1Nullable.IfGreater(value2Nullable).Then(() => value3Nullable));

        // Value nullable
        Assert.Equal(value1Nullable, value3Nullable.IfGreater(value2).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfGreater(value2).Then(() => value1));
        Assert.Equal(value1Nullable, value1Nullable.IfGreater(value2).Then(() => value3));

        Assert.Equal(value1Nullable, value3Nullable.IfGreater(value2).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfGreater(value2).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value1Nullable.IfGreater(value2).Then(() => value3Nullable));

        Assert.Equal(value1Nullable, value3Nullable.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value1Nullable, value1Nullable.IfGreater(value2Nullable).Then(() => value3));

        Assert.Equal(value1Nullable, value3Nullable.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value1Nullable.IfGreater(value2Nullable).Then(() => value3Nullable));

        // Nullable
        Assert.Equal(value1, value3Nullable.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfGreater(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value1Nullable.IfGreater(value2Nullable).Then(() => value3));

        Assert.Equal(value1Nullable, value3Nullable.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfGreater(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value1Nullable.IfGreater(value2Nullable).Then(() => value3Nullable));
    }

    [Fact]
    public void IfGreaterOrEqual()
    {
        // Not null
        Assert.Equal(value1, value3.IfGreaterOrEqual(value2).Then(() => value1));
        Assert.Equal(value1, value2.IfGreaterOrEqual(value2).Then(() => value1));
        Assert.Equal(value1, value1.IfGreaterOrEqual(value2).Then(() => value3));

        Assert.Equal(value1, value3.IfGreaterOrEqual(value2).Then(() => value1Nullable));
        Assert.Equal(value1, value2.IfGreaterOrEqual(value2).Then(() => value1Nullable));
        Assert.Equal(value1, value1.IfGreaterOrEqual(value2).Then(() => value3Nullable));

        // Compare value nullable
        Assert.Equal(value1, value3.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value2.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value1.IfGreaterOrEqual(value2Nullable).Then(() => value3));

        Assert.Equal(value1, value3.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value1.IfGreaterOrEqual(value2Nullable).Then(() => value3Nullable));

        Assert.Equal(value1, value3Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value1Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value3));

        Assert.Equal(value1, value3Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value1Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value3Nullable));

        // Value nullable
        Assert.Equal(value1Nullable, value3Nullable.IfGreaterOrEqual(value2).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.IfGreaterOrEqual(value2).Then(() => value1));
        Assert.Equal(value1Nullable, value1Nullable.IfGreaterOrEqual(value2).Then(() => value3));

        Assert.Equal(value1Nullable, value3Nullable.IfGreaterOrEqual(value2).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfGreaterOrEqual(value2).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value1Nullable.IfGreaterOrEqual(value2).Then(() => value3Nullable));

        Assert.Equal(value1Nullable, value3Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1Nullable, value1Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value3));

        Assert.Equal(value1Nullable, value3Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value1Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value3Nullable));

        // Nullable
        Assert.Equal(value1, value3Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value1, value1Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value3));

        Assert.Equal(value1Nullable, value3Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value1Nullable.IfGreaterOrEqual(value2Nullable).Then(() => value3Nullable));
    }

    [Fact]
    public void IfLess()
    {
        // Not null
        Assert.Equal(value1, value2.IfLess(value3).Then(() => value1));
        Assert.Equal(value2, value2.IfLess(value2).Then(() => value1));
        Assert.Equal(value2, value2.IfLess(value1).Then(() => value3));

        Assert.Equal(value1, value2.IfLess(value3).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfLess(value2).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfLess(value1).Then(() => value3Nullable));

        // Compare value nullable
        Assert.Equal(value1, value2.IfLess(value3Nullable).Then(() => value1));
        Assert.Equal(value2, value2.IfLess(value2Nullable).Then(() => value1));
        Assert.Equal(value2, value2.IfLess(value1Nullable).Then(() => value3));

        Assert.Equal(value1, value2.IfLess(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfLess(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfLess(value1Nullable).Then(() => value3Nullable));

        Assert.Equal(value1, value2Nullable.IfLess(value3Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfLess(value2Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfLess(value1Nullable).Then(() => value3));

        Assert.Equal(value1, value2Nullable.IfLess(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2Nullable.IfLess(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2Nullable.IfLess(value1Nullable).Then(() => value3Nullable));

        // Value nullable
        Assert.Equal(value1Nullable, value2Nullable.IfLess(value3).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value2).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value1).Then(() => value3));

        Assert.Equal(value1Nullable, value2Nullable.IfLess(value3).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value2).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value1).Then(() => value3Nullable));

        Assert.Equal(value1Nullable, value2Nullable.IfLess(value3Nullable).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value2Nullable).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value1Nullable).Then(() => value3));

        Assert.Equal(value1Nullable, value2Nullable.IfLess(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value1Nullable).Then(() => value3Nullable));

        // Nullable
        Assert.Equal(value1, value2Nullable.IfLess(value3Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfLess(value2Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfLess(value1Nullable).Then(() => value3));

        Assert.Equal(value1Nullable, value2Nullable.IfLess(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfLess(value1Nullable).Then(() => value3Nullable));
    }

    [Fact]
    public void IfLessOrEqual()
    {
        // Not null
        Assert.Equal(value1, value2.IfLessOrEqual(value3).Then(() => value1));
        Assert.Equal(value1, value2.IfLessOrEqual(value2).Then(() => value1));
        Assert.Equal(value3, value3.IfLessOrEqual(value2).Then(() => value3));

        Assert.Equal(value1, value2.IfLessOrEqual(value3).Then(() => value1Nullable));
        Assert.Equal(value1, value2.IfLessOrEqual(value2).Then(() => value1Nullable));
        Assert.Equal(value3, value3.IfLessOrEqual(value2).Then(() => value3Nullable));

        // Compare value nullable
        Assert.Equal(value1, value2.IfLessOrEqual(value3Nullable).Then(() => value1));
        Assert.Equal(value1, value2.IfLessOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value3, value3.IfLessOrEqual(value2Nullable).Then(() => value1));

        Assert.Equal(value1, value2.IfLessOrEqual(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2.IfLessOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value3, value3.IfLessOrEqual(value2Nullable).Then(() => value3Nullable));

        Assert.Equal(value1, value2Nullable.IfLessOrEqual(value3Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.IfLessOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value3, value3Nullable.IfLessOrEqual(value2Nullable).Then(() => value1));

        Assert.Equal(value1, value2Nullable.IfLessOrEqual(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2Nullable.IfLessOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value3, value3Nullable.IfLessOrEqual(value2Nullable).Then(() => value3Nullable));

        // Value nullable
        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value3).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value2).Then(() => value1));
        Assert.Equal(value3Nullable, value3Nullable.IfLessOrEqual(value2).Then(() => value1));

        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value3).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value2).Then(() => value1Nullable));
        Assert.Equal(value3Nullable, value3Nullable.IfLessOrEqual(value2).Then(() => value3Nullable));

        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value3Nullable).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value3Nullable, value3Nullable.IfLessOrEqual(value2Nullable).Then(() => value1));

        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value3Nullable, value3Nullable.IfLessOrEqual(value2Nullable).Then(() => value3Nullable));

        // Nullable
        Assert.Equal(value1, value2Nullable.IfLessOrEqual(value3Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.IfLessOrEqual(value2Nullable).Then(() => value1));
        Assert.Equal(value3, value3Nullable.IfLessOrEqual(value2Nullable).Then(() => value1));

        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfLessOrEqual(value2Nullable).Then(() => value1Nullable));
        Assert.Equal(value3Nullable, value3Nullable.IfLessOrEqual(value2Nullable).Then(() => value3Nullable));
    }

    [Fact]
    public void If()
    {
        Assert.Equal(value2, value2.If(value3).Then(() => value1));
        Assert.Equal(value2, value2.If(value1).Then(() => value1));
        Assert.Equal(value1, value2.If(value2).Then(() => value1));

        // Not null
        Assert.Equal(value2, value2.If(value3).Then(() => value1));
        Assert.Equal(value2, value2.If(value1).Then(() => value1));
        Assert.Equal(value1, value2.If(value2).Then(() => value1));

        Assert.Equal(value2, value2.If(value3).Then(() => value1Nullable));
        Assert.Equal(value2, value2.If(value1).Then(() => value1Nullable));
        Assert.Equal(value1, value2.If(value2).Then(() => value1Nullable));

        // Compare value nullable
        Assert.Equal(value2, value2.If(value3Nullable).Then(() => value1));
        Assert.Equal(value2, value2.If(value1Nullable).Then(() => value1));
        Assert.Equal(value1, value2.If(value2Nullable).Then(() => value1));

        Assert.Equal(value2, value2.If(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2.If(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2.If(value2Nullable).Then(() => value1Nullable));

        Assert.Equal(value2, value2Nullable.If(value3Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.If(value1Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.If(value2Nullable).Then(() => value1));

        Assert.Equal(value2, value2Nullable.If(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2Nullable.If(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2Nullable.If(value2Nullable).Then(() => value1Nullable));

        // Value nullable
        Assert.Equal(value2Nullable, value2Nullable.If(value3).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.If(value1).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.If(value2).Then(() => value1));

        Assert.Equal(value2Nullable, value2Nullable.If(value3).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.If(value1).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.If(value2).Then(() => value1Nullable));

        Assert.Equal(value2Nullable, value2Nullable.If(value3Nullable).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.If(value1Nullable).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.If(value2Nullable).Then(() => value1));

        Assert.Equal(value2Nullable, value2Nullable.If(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.If(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.If(value2Nullable).Then(() => value1Nullable));

        // Nullable
        Assert.Equal(value2, value2Nullable.If(value3Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.If(value1Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.If(value2Nullable).Then(() => value1));

        Assert.Equal(value2Nullable, value2Nullable.If(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.If(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.If(value2Nullable).Then(() => value1Nullable));
    }

    [Fact]
    public void IfNot()
    {
        // Not null
        Assert.Equal(value1, value2.IfNot(value3).Then(() => value1));
        Assert.Equal(value1, value2.IfNot(value1).Then(() => value1));
        Assert.Equal(value2, value2.IfNot(value2).Then(() => value1));

        Assert.Equal(value1, value2.IfNot(value3).Then(() => value1Nullable));
        Assert.Equal(value1, value2.IfNot(value1).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfNot(value2).Then(() => value1Nullable));

        // Compare value nullable
        Assert.Equal(value1, value2.IfNot(value3Nullable).Then(() => value1));
        Assert.Equal(value1, value2.IfNot(value1Nullable).Then(() => value1));
        Assert.Equal(value2, value2.IfNot(value2Nullable).Then(() => value1));

        Assert.Equal(value1, value2.IfNot(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2.IfNot(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2.IfNot(value2Nullable).Then(() => value1Nullable));

        Assert.Equal(value1, value2Nullable.IfNot(value3Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.IfNot(value1Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfNot(value2Nullable).Then(() => value1));

        Assert.Equal(value1, value2Nullable.IfNot(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1, value2Nullable.IfNot(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value2, value2Nullable.IfNot(value2Nullable).Then(() => value1Nullable));

        // Value nullable
        Assert.Equal(value1Nullable, value2Nullable.IfNot(value3).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.IfNot(value1).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfNot(value2).Then(() => value1));

        Assert.Equal(value1Nullable, value2Nullable.IfNot(value3).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfNot(value1).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfNot(value2).Then(() => value1Nullable));

        Assert.Equal(value1Nullable, value2Nullable.IfNot(value3Nullable).Then(() => value1));
        Assert.Equal(value1Nullable, value2Nullable.IfNot(value1Nullable).Then(() => value1));
        Assert.Equal(value2Nullable, value2Nullable.IfNot(value2Nullable).Then(() => value1));

        Assert.Equal(value1Nullable, value2Nullable.IfNot(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfNot(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfNot(value2Nullable).Then(() => value1Nullable));

        // Nullable
        Assert.Equal(value1, value2Nullable.IfNot(value3Nullable).Then(() => value1));
        Assert.Equal(value1, value2Nullable.IfNot(value1Nullable).Then(() => value1));
        Assert.Equal(value2, value2Nullable.IfNot(value2Nullable).Then(() => value1));

        Assert.Equal(value1Nullable, value2Nullable.IfNot(value3Nullable).Then(() => value1Nullable));
        Assert.Equal(value1Nullable, value2Nullable.IfNot(value1Nullable).Then(() => value1Nullable));
        Assert.Equal(value2Nullable, value2Nullable.IfNot(value2Nullable).Then(() => value1Nullable));
    }

    [Fact]
    public void IfWithNullValues()
    {
        // If
        Assert.Equal(value1, nullValue.If(nullValue).Then(() => value1));
        Assert.Null(nullValue.If(value1).Then(() => value1));
        Assert.Null(nullValue.If(value1).Then(() => value1Nullable));
        Assert.Equal(value1, value1.If(nullValue).Then(() => value2));
        Assert.Equal(value1, value1.If(nullValue).Then(() => value2Nullable));

        // IfNot
        Assert.Null(nullValue.IfNot(nullValue).Then(() => value1));
        Assert.Equal(value1, nullValue.IfNot(value2).Then(() => value1));
        Assert.Equal(value1, value2.IfNot(nullValue).Then(() => value1));
        Assert.Equal(value1Nullable, value2.IfNot(nullValue).Then(() => value1Nullable));

        // Expressions always false - null value
        Assert.Null(nullValue.IfGreater(value1).Then(() => value2));
        Assert.Null(nullValue.IfGreaterOrEqual(value1).Then(() => value2));
        Assert.Null(nullValue.IfLess(value1).Then(() => value2));
        Assert.Null(nullValue.IfLessOrEqual(value1).Then(() => value2));

        Assert.Null(nullValue.IfGreater(value1).Then(() => value2Nullable));
        Assert.Null(nullValue.IfGreaterOrEqual(value1).Then(() => value2Nullable));
        Assert.Null(nullValue.IfLess(value1).Then(() => value2Nullable));
        Assert.Null(nullValue.IfLessOrEqual(value1).Then(() => value2Nullable));

        Assert.Null(nullValue.IfGreater(nullValue).Then(() => value2));
        Assert.Null(nullValue.IfGreaterOrEqual(nullValue).Then(() => value2));
        Assert.Null(nullValue.IfLess(nullValue).Then(() => value2));
        Assert.Null(nullValue.IfLessOrEqual(nullValue).Then(() => value2));

        Assert.Null(nullValue.IfGreater(nullValue).Then(() => value2Nullable));
        Assert.Null(nullValue.IfGreaterOrEqual(nullValue).Then(() => value2Nullable));
        Assert.Null(nullValue.IfLess(nullValue).Then(() => value2Nullable));
        Assert.Null(nullValue.IfLessOrEqual(nullValue).Then(() => value2Nullable));

        // Expressions always false - null value compare
        Assert.Equal(value1, value1.IfGreater(nullValue).Then(() => value2));
        Assert.Equal(value1, value1.IfGreaterOrEqual(nullValue).Then(() => value2));
        Assert.Equal(value1, value1.IfLess(nullValue).Then(() => value2));
        Assert.Equal(value1, value1.IfLessOrEqual(nullValue).Then(() => value2));

        Assert.Equal(value1, value1.IfGreater(nullValue).Then(() => value2Nullable));
        Assert.Equal(value1, value1.IfGreaterOrEqual(nullValue).Then(() => value2Nullable));
        Assert.Equal(value1, value1.IfLess(nullValue).Then(() => value2Nullable));
        Assert.Equal(value1, value1.IfLessOrEqual(nullValue).Then(() => value2Nullable));

        Assert.Null(nullValue.IfGreater(nullValue).Then(() => value2));
        Assert.Null(nullValue.IfGreaterOrEqual(nullValue).Then(() => value2));
        Assert.Null(nullValue.IfLess(nullValue).Then(() => value2));
        Assert.Null(nullValue.IfLessOrEqual(nullValue).Then(() => value2));

        Assert.Null(nullValue.IfGreater(nullValue).Then(() => value2Nullable));
        Assert.Null(nullValue.IfGreaterOrEqual(nullValue).Then(() => value2Nullable));
        Assert.Null(nullValue.IfLess(nullValue).Then(() => value2Nullable));
        Assert.Null(nullValue.IfLessOrEqual(nullValue).Then(() => value2Nullable));
    }
}