using Xunit;

namespace Maestria.Extensions.Test.CSharp;

public class DataType_Try_Test
{
    [Fact]
    public void Try_Test_Ok()
    {
        var result = TryTestMock(true);
        if (result)
        {
            Assert.NotNull(result.Value);
            Assert.Null(result.Failure);
            Assert.Equal(true, result.Success);
            Assert.Equal(false, result.Failed);

            TestOk implicitCastSuccess = result;
            TestError implicitCastFailure = result;
            Assert.Equal(result.Value, implicitCastSuccess);
            Assert.Equal(result.Failure, implicitCastFailure);
        }
        else
            Assert.Fail();
    }

    [Fact]
    public void Try_Test_Failure()
    {
        var result = TryTestMock(false);
        if (result)
            Assert.Fail();
        else
        {
            Assert.Null(result.Value);
            Assert.NotNull(result.Failure);
            Assert.Equal(false, result.Success);
            Assert.Equal(true, result.Failed);

            TestOk implicitCastSuccess = result;
            TestError implicitCastFailure = result;
            Assert.Equal(result.Value, implicitCastSuccess);
            Assert.Equal(result.Failure, implicitCastFailure);
        }
    }

    [Fact]
    public void Try_Test_Struct_Ok()
    {
        var result = TryTestMockStruct(true);
        if (result)
        {
            Assert.Equal(true, result.Success);
            Assert.Equal(false, result.Failed);

            TestOkStruct implicitCastSuccess = result;
            TestErrorStruct implicitCastFailure = result;
            Assert.Equal(result.Value, implicitCastSuccess);
            Assert.Equal(result.Failure, implicitCastFailure);
        }
        else
            Assert.Fail();
    }

    [Fact]
    public void Try_Test_Struct_Failure()
    {
        var result = TryTestMockStruct(false);
        if (result)
            Assert.Fail();
        else
        {
            Assert.Equal(false, result.Success);
            Assert.Equal(true, result.Failed);

            TestOkStruct implicitCastSuccess = result;
            TestErrorStruct implicitCastFailure = result;
            Assert.Equal(result.Value, implicitCastSuccess);
            Assert.Equal(result.Failure, implicitCastFailure);
        }
    }

    private Try<TestOk, TestError> TryTestMock(bool success)
    {
        if (success)
            return new TestOk();
        else
            return new TestError();
    }

    private Try<TestOkStruct, TestErrorStruct> TryTestMockStruct(bool success)
    {
        if (success)
            return new TestOkStruct();
        else
            return new TestErrorStruct();
    }
}

class TestOk
{
    int Id { get; set; }
}

class TestError
{
    int Code { get; set; }
    string Message { get; set; }
}

struct TestOkStruct
{
    int Id { get; set; }
}

struct TestErrorStruct
{
    int Code { get; set; }
    string Message { get; set; }
}
