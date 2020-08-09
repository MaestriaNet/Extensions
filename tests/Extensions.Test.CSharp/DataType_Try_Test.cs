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
                Assert.NotNull(result.Success);
                Assert.Null(result.Failure);
                Assert.AreEqual(true, result.Successfully);
                Assert.AreEqual(false, result.Failed);

                TestOk implicitCastSuccess = result;
                TestError implicitCastFailure = result;
                Assert.AreEqual(result.Success, implicitCastSuccess);
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
                Assert.Null(result.Success);
                Assert.NotNull(result.Failure);
                Assert.AreEqual(false, result.Successfully);
                Assert.AreEqual(true, result.Failed);

                TestOk implicitCastSuccess = result;
                TestError implicitCastFailure = result;
                Assert.AreEqual(result.Success, implicitCastSuccess);
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
}
