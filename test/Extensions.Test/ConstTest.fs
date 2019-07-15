module Maestria.Data.Extensions.Test.Const
open System
open System
open System.Globalization

/// ===========================================
/// Expected values
/// ===========================================
let FixedPointExpected: int64 = 16L
let FloatingPointExpected: decimal = 17.0001m
let DateTimeExpected = DateTime.Today
let StringExpected = "test value"
let StringNumberInput = "16.1"
let StringNumberPtBrInput = "16,1"
let StringNumberToFixedPointExpected = 16
let StringNumberToFloatingPointExpected = 16.1
let StringDateInput = "2019-06-30"
let StringDatePtBrInput = "30/06/2019"
let StringDateExpected = new DateTime(2019, 06, 30)

/// ===========================================
/// Constants
/// ===========================================
let CulturePtBr = CultureInfo.CreateSpecificCulture("pt-BR")