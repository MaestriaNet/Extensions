namespace Maestria.Extensions.Test.``Syntax Extensions``
open System
open Maestria.Extensions.Test.Internal.TestUtil
open Maestria.Extensions
open NUnit.Framework
open FsUnit

module In =
    [<TestCase(MyColor.Red, [| MyColor.Red; MyColor.Green; MyColor.Blue |])>]
    [<TestCase(MyColor.Green, [| MyColor.Red; MyColor.Green; MyColor.Blue |])>]
    [<TestCase(MyColor.Blue, [| MyColor.Red; MyColor.Green; MyColor.Blue |])>]
    let ``Enum in array group`` (value: MyColor, values: MyColor array) =
        value.In(values) |> should be True

    [<TestCase(MyColor.Yellow, [| MyColor.Red; MyColor.Green; MyColor.Blue |])>]
    let ``Enum not in array group`` (value: MyColor, values: MyColor array) =
        value.In(values) |> should be False

    [<TestCase(5, [|5; 10; 15|])>]
    [<TestCase(10, [|5; 10; 15|])>]
    [<TestCase(15, [|5; 10; 15|])>]
    let ``Value in array group`` (value: int, values: int array) =
        value.In(values) |> should be True

    [<TestCase(4, [| 5; 10; 15 |])>]
    [<TestCase(8, [| 5; 10; 15 |])>]
    [<TestCase(12, [| 5; 10; 15 |])>]
    [<TestCase(16, [| 5; 10; 15 |])>]
    let ``Value not in array group``(value: int, values: int array) =
        value.In(values) |> should be False

module Between =
    [<TestCase("2019-07-23", "2019-07-20", "2019-07-25")>]
    [<TestCase("2019-07-23", "2019-07-20", "2019-07-23")>]
    [<TestCase("2019-07-23", "2019-07-23", "2019-07-25")>]
    let ``Date between interval``(value: DateTime, min: DateTime, max: DateTime) =
        value.Between(min, max) |> should be True

    [<TestCase("2019-07-23", "2019-07-21", "2019-07-22")>]
    [<TestCase("2019-07-23", "2019-07-24", "2019-07-25")>]
    let ``Date not between interval``(value: DateTime, starting: DateTime, ending: DateTime) =
        value.Between(starting, ending) |> should be False

    [<TestCase(10, 5, 15)>]
    [<TestCase(10, 10, 15)>]
    [<TestCase(10, 5, 10)>]
    let ``Value between interval``(value, min, max) =
        value.Between(min, max) |> should be True

    [<TestCase(10, 11, 15)>]
    [<TestCase(10, 5, 9)>]
    let ``Value not between interval``(value, starting, ending) =
        value.Between(starting, ending) |> should be False