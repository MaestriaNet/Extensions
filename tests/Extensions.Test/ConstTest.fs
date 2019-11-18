module Maestria.Extensions.Test.Const
open System
open System.Globalization
open FsUnit
open NUnit.Framework
open Maestria.Extensions

let CultureEnUs = CultureInfo.GetCultureInfo("en-US")
let CulturePtBr = CultureInfo.GetCultureInfo("pt-BR")

/// ===========================================
/// Input values in many data types
/// ===========================================
let DateTimeInput = new DateTime(2019, 06, 20, 20, 40, 15)

[<Literal>]
let NullString: string = null