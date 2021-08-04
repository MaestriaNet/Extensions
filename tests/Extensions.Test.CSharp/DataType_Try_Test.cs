using Maestria.Extensions.DataTypes;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class DataType_Try_Test
    {
        [Test]
        public void Try_Test_Ok()
        {
            var result = TryTestMock(true);
            if (result)
            {
                Assert.NotNull(result.Value);
                Assert.Null(result.Failure);
                Assert.AreEqual(true, result.Success);
                Assert.AreEqual(false, result.Failed);

                TestOk implicitCastSuccess = result;
                TestError implicitCastFailure = result;
                Assert.AreEqual(result.Value, implicitCastSuccess);
                Assert.AreEqual(result.Failure, implicitCastFailure);
            }
            else
                Assert.Fail();
        }

        [Test]
        public void Try_Test_Failure()
        {
            var result = TryTestMock(false);
            if (result)
                Assert.Fail();
            else
            {
                Assert.Null(result.Value);
                Assert.NotNull(result.Failure);
                Assert.AreEqual(false, result.Success);
                Assert.AreEqual(true, result.Failed);

                TestOk implicitCastSuccess = result;
                TestError implicitCastFailure = result;
                Assert.AreEqual(result.Value, implicitCastSuccess);
                Assert.AreEqual(result.Failure, implicitCastFailure);
            }
        }

        [Test]
        public void Try_Test_Struct_Ok()
        {
            var result = TryTestMockStruct(true);
            if (result)
            {
                Assert.AreEqual(true, result.Success);
                Assert.AreEqual(false, result.Failed);

                TestOkStruct implicitCastSuccess = result;
                TestErrorStruct implicitCastFailure = result;
                Assert.AreEqual(result.Value, implicitCastSuccess);
                Assert.AreEqual(result.Failure, implicitCastFailure);
            }
            else
                Assert.Fail();
        }

        [Test]
        public void Try_Test_Struct_Failure()
        {
            var result = TryTestMockStruct(false);
            if (result)
                Assert.Fail();
            else
            {
                Assert.AreEqual(false, result.Success);
                Assert.AreEqual(true, result.Failed);

                TestOkStruct implicitCastSuccess = result;
                TestErrorStruct implicitCastFailure = result;
                Assert.AreEqual(result.Value, implicitCastSuccess);
                Assert.AreEqual(result.Failure, implicitCastFailure);
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
}
