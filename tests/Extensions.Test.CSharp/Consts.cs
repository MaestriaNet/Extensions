using System;
using System.Globalization;

namespace Maestria.Extensions.Test.CSharp;

public class Consts
{
    public const string EmptyString = "";
    public const string WhiteSpace = " ";
    public const string Text = "abcdef";
    public static readonly Guid EmptyGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");
    public static readonly Guid? NullGuid = null;
    public static readonly Guid Guid = Guid.Parse("2cdfb5b1-f9c1-43b3-b79d-4900baaf430c");
    public static readonly Guid? GuidNullable = Guid.Parse("2cdfb5b1-f9c1-43b3-b79d-4900baaf430c");

    // From F# ConstTest
    public static readonly CultureInfo CultureEnUs = CultureInfo.GetCultureInfo("en-US");
    public static readonly CultureInfo CulturePtBr = CultureInfo.GetCultureInfo("pt-BR");
    public static readonly DateTime DateTimeInput = new DateTime(2019, 06, 20, 20, 40, 15);
    public const string NullString = null;
}

// Test helper types from F# TestUtil
public enum MyColor
{
    Red = 0,
    Green = 1,
    Blue = 2,
    Yellow = 3,
    White = 4,
    Black = 5
}

public class Person
{
    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Person person && Name == person.Name;
    }

    public override int GetHashCode()
    {
        return Name?.GetHashCode() ?? 0;
    }
}