using System;
namespace Extensions.Test.CSharp
{
    public class Consts
    {
        public const string EmptyString = "";
        public const string WhiteSpace = " ";
        public const string Text = "abcdef";
        public static readonly Guid EmptyGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public static readonly Guid? NullGuid = null;
        public static readonly Guid Guid = Guid.Parse("2cdfb5b1-f9c1-43b3-b79d-4900baaf430c");
    }
}