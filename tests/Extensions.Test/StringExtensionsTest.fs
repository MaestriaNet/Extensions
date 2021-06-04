namespace Maestria.Extensions.Test.``String Extensions``
open System.Globalization
open Maestria.Extensions
open NUnit.Framework
open FsUnit
open Maestria.Extensions.Test

module ``String check and manipulate`` =
    [<Test>]
    let TrimStart() =
        "TestValue".TrimStart("Test") |> should equal "Value"
        "TestValue".TrimStart("Value") |> should equal "TestValue"
        "TestValue".TrimStart(Const.NullString) |> should equal "TestValue"
        Const.NullString.TrimStart("Test") |> should be Null
        Const.NullString.TrimStart(Const.NullString) |> should be Null
        "TestTestValue".TrimStart("Test") |> should equal "Value"

    [<Test>]
    let TrimEnd() =
        "TestValue".TrimEnd("Value") |> should equal "Test"
        "TestValue".TrimEnd("Test") |> should equal "TestValue"
        "TestValue".TrimEnd(Const.NullString) |> should equal "TestValue"
        Const.NullString.TrimEnd("Value") |> should be Null
        Const.NullString.TrimEnd(Const.NullString) |> should be Null
        "TestValueValue".TrimEnd("Value") |> should equal "Test"

    [<Test>]
    let AddToBeginningIfNotStartsWith() =
        "TestValue".AddToBeginningIfNotStartsWith("Test") |> should equal "TestValue"
        "Value".AddToBeginningIfNotStartsWith("Test") |> should equal "TestValue"
        Const.NullString.AddToBeginningIfNotStartsWith("TestValue") |> should equal "TestValue"
        "TestValue".AddToBeginningIfNotStartsWith(Const.NullString) |> should equal "TestValue"
        Const.NullString.AddToBeginningIfNotStartsWith(Const.NullString) |> should be Null

    [<Test>]
    let AddToEndIfNotEndsWith() =
        "TestValue".AddToEndIfNotEndsWith("Value") |> should equal "TestValue"
        "Test".AddToEndIfNotEndsWith("Value") |> should equal "TestValue"
        Const.NullString.AddToEndIfNotEndsWith("TestValue") |> should equal "TestValue"
        "TestValue".AddToEndIfNotEndsWith(Const.NullString) |> should equal "TestValue"
        Const.NullString.AddToEndIfNotEndsWith(Const.NullString) |> should be Null

    [<Test>]
    let AddToBeginningIfHasValue() =
        "".AddToBeginningIfHasValue("Mrs.") |> should equal ""
        "Jhon".AddToBeginningIfHasValue("Mrs. ") |> should equal "Mrs. Jhon"
        Const.NullString.AddToBeginningIfHasValue("Mrs.") |> should be Null

    [<Test>]
    let AddToEndIfHasValue() =
        "".AddToEndIfHasValue("Jhon") |> should equal ""
        "Mrs. ".AddToEndIfHasValue("Jhon") |> should equal "Mrs. Jhon"
        Const.NullString.AddToEndIfHasValue("Jhon") |> should be Null

    [<Test>]
    let Format() =
        "My first name is {0} and my last name is {1}".Format("Jhon", "Smith") |> should equal "My first name is Jhon and my last name is Smith"
        "My first name is {0} and my last name is {1}".Format() |> should equal "My first name is {0} and my last name is {1}"
        Const.NullString.Format("Jhon", "Smith") |> should be Null

module ``Value check`` =
    [<Test>]
    let IsNullOrEmpty() =
        Const.NullString.IsNullOrEmpty() |> should be True
        "".IsNullOrEmpty() |> should be True
        " ".IsNullOrEmpty() |> should be False


    [<Test>]
    let IsNullOrWhiteSpace() =
        Const.NullString.IsNullOrWhiteSpace() |> should be True
        "".IsNullOrWhiteSpace() |> should be True
        " ".IsNullOrWhiteSpace() |> should be True
        "-".IsNullOrWhiteSpace() |> should be False

    [<Test>]
    let HasValue() =
        Const.NullString.HasValue() |> should be False
        "".HasValue() |> should be False
        " ".HasValue() |> should be False
        "-".HasValue() |> should be True

    [<Test>]
    let EqualsIgnoreCase() =
        "Test".EqualsIgnoreCase("Test") |> should be True
        "Test".EqualsIgnoreCase("test") |> should be True
        "Test".EqualsIgnoreCase("test ") |> should be True
        "Test".EqualsIgnoreCase("test ", false) |> should be False
        "Test".EqualsIgnoreCase(Const.NullString, false) |> should be False
        Const.NullString.EqualsIgnoreCase(Const.NullString, false) |> should be True
        Const.NullString.EqualsIgnoreCase("", false) |> should be True
        "".EqualsIgnoreCase(Const.NullString, false) |> should be True

module ``Text patterns`` =
    [<TestCase("0123456789", "0123456789")>]
    [<TestCase("a0a1a2a3a4a5a6a7a8a9", "0123456789")>]
    [<TestCase(Const.NullString, Const.NullString)>]
    [<TestCase("123.456", "123456")>]
    let ``Only numbers``(value: string, expected: string) =
        value.OnlyNumbers() |> should equal expected

    [<TestCase("1a23.45a6", "123.456")>]
    [<TestCase("1,234.56", "1234.56")>]
    let ``Only numbers with floating point``(value: string, expected: string) =
        value.OnlyNumbers(true) |> should equal expected

    [<TestCase("-1a2a3a456", "-123456")>]
    let ``Only numbers with negative sign``(value: string, expected: string) =
        value.OnlyNumbers(allowNegativeSign = true) |> should equal expected

    [<Test>]
    let ``Only numbers with floating point and negative sign``() =
        "-1,234.56".OnlyNumbers(true, true, CultureInfo.InvariantCulture) |> should equal "-1234.56"
        "-1,234.56".OnlyNumbers(true, true, Const.CultureEnUs) |> should equal "-1234.56"
        "-1.234,56".OnlyNumbers(true, true, Const.CulturePtBr) |> should equal "-1234,56"

    [<TestCase("áéíóú", "aeiou")>]
    [<TestCase("âêîôû", "aeiou")>]
    [<TestCase("ãẽĩõũ", "aeiou")>]
    [<TestCase("àèìòù", "aeiou")>]
    [<TestCase("abc !@#$%&*()[]{}:;<>", "abc !@#$%&*()[]{}:;<>")>]
    let ``Remove Accents``(value: string, expected: string) =
        value.RemoveAccents() |> should equal expected
