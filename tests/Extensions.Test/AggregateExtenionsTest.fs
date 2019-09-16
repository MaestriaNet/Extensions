namespace Maestria.Extensions.Test.``Aggregate Extensions``
open System
open FsUnit
open NUnit.Framework
open Maestria.Extensions

module Const =
    /// ===========================================
    /// Expected values
    /// ===========================================
    let dayInput = new DateTime(2019, 06, 20, 20, 40, 15)

    /// ===========================================
    /// Expected values
    /// ===========================================
    let startOfWeekExpected = new DateTime(2019, 06, 16)
    let endOfWeekExpected = (new DateTime(2019, 06, 22)).AddDays(1.0).AddTicks(-1L)
    let startOfMonthExpected = new DateTime(2019, 06, 01)
    let endOfMonthExpected = (new DateTime(2019, 06, 30)).AddDays(1.0).AddTicks(-1L)
    let weekOfMonthExpected = 4
    let weekOfYearExpected = 25

    let startOfWeekStartingInMondayExpected = new DateTime(2019, 06, 17)
    let endOfWeekStartingInMondayExpected = (new DateTime(2019, 06, 23)).AddDays(1.0).AddTicks(-1L)

    let minDateExpected = DateTime.Now.AddDays(-1.0)
    let middleDateExpected = DateTime.Today
    let maxDateExpected = DateTime.Now

    let emptyArray = Array.empty<DateTime>
    let oneItemArray = [| minDateExpected |]
    let twoItemsArray = [| minDateExpected; maxDateExpected |]
    let threeItemsArray = [| minDateExpected; middleDateExpected; maxDateExpected |]

    let emptyNullableArray = Array.empty<Nullable<DateTime>>
    let nullItemNullableArray: Nullable<DateTime> [] = [| new Nullable<DateTime>(); |]
    let oneItemNullableArray: Nullable<DateTime> [] = [| new Nullable<DateTime>(minDateExpected); |]
    let twoItemsNullableArray: Nullable<DateTime> [] = [| new Nullable<DateTime>(minDateExpected); new Nullable<DateTime>(maxDateExpected) |]
    let threeItemsNullableArray: Nullable<DateTime> [] = [| new Nullable<DateTime>(minDateExpected); new Nullable<DateTime>(middleDateExpected); new Nullable<DateTime>(maxDateExpected) |]

module Max =
    [<Test>]
    let ``Throw exception when you get the largest value of the empty nullable array``() =
        (fun () -> AggregateExtenions.Max(Const.emptyArray) |> ignore) |> should throw typeof<InvalidOperationException>

    [<Test>]
    let ``Success to get the most value``() =
        AggregateExtenions.Max(Const.oneItemArray) |> should equal Const.minDateExpected
        AggregateExtenions.Max(Const.twoItemsArray) |> should equal Const.maxDateExpected
        AggregateExtenions.Max(Const.threeItemsArray) |> should equal Const.maxDateExpected

module ``Max Nullable`` =
    [<Test>]
    let ``Do not throw exception when you get the largest value of the empty nullable array``() =
        AggregateExtenions.Max(Const.emptyNullableArray) |> should be Null

    [<Test>]
    let ``Do not throw exception when you get the largest value of the array with null items``() =
        AggregateExtenions.Max(Const.nullItemNullableArray) |> should be Null

    [<Test>]
    let ``Success to get the highest value``() =
        AggregateExtenions.Max(Const.oneItemNullableArray) |> should equal Const.minDateExpected
        AggregateExtenions.Max(Const.twoItemsNullableArray) |> should equal Const.maxDateExpected
        AggregateExtenions.Max(Const.threeItemsNullableArray) |> should equal Const.maxDateExpected

module Min =
    [<Test>]
    let ``Throw exception when you get the smallest value of the empty nullable array``() =
        (fun () -> AggregateExtenions.Min(Const.emptyArray) |> ignore) |> should throw typeof<InvalidOperationException>

    [<Test>]
    let ``Success for lowest value``() =
        AggregateExtenions.Min(Const.oneItemArray) |> should equal Const.minDateExpected
        AggregateExtenions.Min(Const.twoItemsArray) |> should equal Const.minDateExpected
        AggregateExtenions.Min(Const.threeItemsArray) |> should equal Const.minDateExpected

module ``Min Nullable`` =
    [<Test>]
    let ``Do not throw exception when you get the smallest value of the empty nullable array``() =
            AggregateExtenions.Min(Const.emptyNullableArray) |> should be Null

    [<Test>]
    let ``Do not throw exception when you get the smallest value of the array with null items``() =
        AggregateExtenions.Min(Const.nullItemNullableArray) |> should be Null

    [<Test>]
    let ``Success to get the lowest value``() =
        AggregateExtenions.Min(Const.oneItemNullableArray) |> should equal Const.minDateExpected
        AggregateExtenions.Min(Const.twoItemsNullableArray) |> should equal Const.minDateExpected
        AggregateExtenions.Min(Const.threeItemsNullableArray) |> should equal Const.minDateExpected

