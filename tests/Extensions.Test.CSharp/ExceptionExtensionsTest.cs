using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Maestria.Extensions.Test.CSharp
{
    public class ExceptionExtensionsTest
    {
        #region Nested classes to test

        public class MyExceptionTest
        {
            public void Execute(string value) => int.Parse(value);
        }

        public class MyExceptionTest2
        {
            public void Execute(string value) => new MyExceptionTest().Execute(value);
        }

        public class MyExceptionTest3
        {
            public void Execute(string value) => new MyExceptionTest2().Execute(value);
        }

        #endregion

        //[Test]
        public void ToLogString()
        {
            try
            {
                // int.Parse("a");
                new MyExceptionTest3().Execute("a");
            }
            catch (Exception ex)
            {
                var logMsg = ex.GetAllMessages();
                string expected = $@"Input string was not in a correct format.
Type: System.FormatException
StackTrace:    at System.Number.StringToNumber(ReadOnlySpan`1 str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   at System.Number.ParseInt32(ReadOnlySpan`1 s, NumberStyles style, NumberFormatInfo info)
   at System.Int32.Parse(String s)
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest.Execute(String value) in {_currentFilePath}:line 13
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest2.Execute(String value) in {_currentFilePath}:line 18
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest3.Execute(String value) in {_currentFilePath}:line 23
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.ToLogString() in {_currentFilePath}:line 34";
                Assert.AreEqual(expected.Replace("\r\n", "\n"), logMsg.Replace("\r\n", "\n"));
            }
        }

        //[Test]
        public void ToLogString_OneInner()
        {
            try
            {
                // int.Parse("a");
                new MyExceptionTest3().Execute("a");
            }
            catch (Exception ex)
            {
                try
                {
                    throw new Exception("Error to execute my method", ex);
                }
                catch (Exception ex2)
                {
                    var logMsg = ex2.GetAllMessages();
                    string expected = $@"Error to execute my method
Type: System.Exception
Inner: System.FormatException -> Input string was not in a correct format.
StackTrace:    at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.ToLogString_OneInner() in {_currentFilePath}:line 64
   at System.Number.StringToNumber(ReadOnlySpan`1 str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   at System.Number.ParseInt32(ReadOnlySpan`1 s, NumberStyles style, NumberFormatInfo info)
   at System.Int32.Parse(String s)
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest.Execute(String value) in {_currentFilePath}:line 13
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest2.Execute(String value) in {_currentFilePath}:line 18
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest3.Execute(String value) in {_currentFilePath}:line 23
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.ToLogString_OneInner() in {_currentFilePath}:line 58";
                    Assert.AreEqual(expected.Replace("\r\n", "\n"), logMsg.Replace("\r\n", "\n"));
                }
            }
        }

        //[Test]
        public void ToLogString_TwoInner()
        {
            try
            {
                // int.Parse("a");
                new MyExceptionTest3().Execute("a");
            }
            catch (Exception ex)
            {
                try
                {
                    try
                    {
                        throw new Exception("First exception", ex);
                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("Second exception", ex2);
                    }
                }
                catch (Exception ex2)
                {
                    var logMsg = ex2.GetAllMessages();
                    string expected = $@"Second exception
Type: System.Exception
Inner 1: System.Exception -> First exception
Inner 0: System.FormatException -> Input string was not in a correct format.
StackTrace:    at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.ToLogString_TwoInner() in {_currentFilePath}:line 103
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.ToLogString_TwoInner() in {_currentFilePath}:line 99
   at System.Number.StringToNumber(ReadOnlySpan`1 str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   at System.Number.ParseInt32(ReadOnlySpan`1 s, NumberStyles style, NumberFormatInfo info)
   at System.Int32.Parse(String s)
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest.Execute(String value) in {_currentFilePath}:line 13
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest2.Execute(String value) in {_currentFilePath}:line 18
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.MyExceptionTest3.Execute(String value) in {_currentFilePath}:line 23
   at Maestria.Extensions.Test.CSharp.ExceptionExtensionsTest.ToLogString_TwoInner() in {_currentFilePath}:line 91";
                    Assert.AreEqual(expected.Replace("\r\n", "\n"), logMsg.Replace("\r\n", "\n"));
                }
            }
        }

        private string _currentFilePath;
        [OneTimeSetUp]
        public void Init()
        {
            _currentFilePath = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        }

        [Test]
        public void GetMostInner()
        {
            var ex1 = new Exception("exception 1");
            var ex2 = new Exception("exception 2", ex1);
            var ex3 = new Exception("exception 3", ex2);
            Assert.AreSame(ex1, ex3.GetMostInner());
            Assert.AreSame(ex1, ex1.GetMostInner());
        }
    }
}