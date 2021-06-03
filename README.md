# Maestria Extensions

[![Build status](https://ci.appveyor.com/api/projects/status/mvosd40vqsgrvkr0/branch/master?svg=true)](https://ci.appveyor.com/project/fabionaspolini/extensions/branch/master)
[![NuGet](https://buildstats.info/nuget/Maestria.Extensions)](https://www.nuget.org/packages/Maestria.Extensions)
[![MyGet](https://img.shields.io/myget/maestrianet/v/Maestria.Extensions?label=MyGet)](https://www.myget.org/feed/maestrianet/package/nuget/Maestria.Extensions)

[![Build History](https://buildstats.info/appveyor/chart/fabionaspolini/extensions?branch=master)](https://ci.appveyor.com/project/fabionaspolini/extensions/history?branch=master)

[![donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

## What is Maestria Extensions?

Extension function pack to increase productivity and improve source code writing.  
By default, all extension methods are safe.

## What is Maestria Project?

This library is part of Maestria Project.

Maestria is a project to provide productivity and elegance to your source code writing.

## Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Maestria Extensions](https://www.nuget.org/packages/Maestria.Extensions/) from the package manager console:

```bash
PM> Install-Package Maestria.Extensions
```

or install from the dotnet cli command line:

```bash
> dotnet add package Maestria.Extensions
```

## How do I get started?

First, import "Maestria.Extensions" reference:

```csharp
using Maestria.Extensions;
```

Then in your application code, use fluent syntax

```csharp
// AggregateExtenions
<Array>.Max();
<Array>.Min();

// Base64Extensions
Base64Extensions.Encode(<byte[]>)
Base64Extensions.Encode(<string>, <Encoding>)
Base64Extensions.Decode(<encoded-byte[]>, <Encoding>)
Base64Extensions.Decode(<encoded-string>, <Encoding>)

// CollectionExtensions
<IEnumerable>.IsNullOrEmpty()
<IEnumerable>.HasItems()
<IDictionary>.TryGetValue(<key>, <@default-value>)
<IEnumerable>.Iterate(item => <action>)
await <IEnumerable>.Iterate(async item => await <action>)
<IEnumerable>.Iterate((item, index) => <action>)
await <IEnumerable>.Iterate(async (item, index) => await <action>)

// EnumExtensions
<Enum>.GetDisplayName()
<Enum>.GetDescription()
EnumExtensions.GetValues<TEnum>()
EnumExtensions.GetValues(typeof(<TEnum>))

// ExceptionExtensions
<Exception>.ToLogString()
<Exception>.GetMostInner()

// HashExtensions
"value".GetHashMd5()
"value".GetHashSha1()
"value".GetHashSha256()
"value".GetHashSha384()
"value".GetHashSha512()
HashExtensions.ComputeHash(<HashAlgorithm>, "value")

// IfNullExtensions
<object>.IfNull(<output-value-when-null>)
<string>.IfNullOrEmpty(<output-value-when-null-or-empty-string>)
<string>.IfNullOrWhiteSpace(<output-value-when-null-or-empty-white-space>)

// NullIfExtensions
<object>.NullIf(<comparison-value>)
<object>.NullIfIn(<comparison-value>)
<object>.NullIfBetween(<comparison-value>)

// NullIf
<floating-point>.NullIf(<comparison-value>, <tolerance-to-comparasion>)
<string>.NullIf(<comparison-value>, <ignore-case>)
<string>.NullIfEmpty(<comparison-value>)
<string>.NullIfWhiteSpace(<comparison-value>)

// RoundExtensions
<floating-point>.Round(<digits>)
<floating-point>.Round(<digits>, <MidpointRounding>)
<floating-point>.RoundUp(<digits>)

// StringExtensions
<string>.TrimStart(<start-comparison>, <ignore-case>)
<string>.TrimEnd(<start-comparison>, <ignore-case>)
<string>.AddToBeginningIfNotStartsWith(<start-comparison>, <ignore-case>)
<string>.AddToBeginningIfHasValue(<start-comparison>, <prefix>)
<string>.AddToEndIfNotEndsWith(<start-comparison>, <ignore-case>)
<string>.AddToEndIfHasValue(<start-comparison>, <prefix>)
<string>.Format(<values-to-format>)
<string>.IsNullOrEmpty()
<string>.IsNullOrWhiteSpace()
<string>.EmptyIf(<string>)
<string>.EmptyIfNull()
<string>.EmptyIfNullOrWhiteSpace()
<string>.HasValue()
<string>.EqualsIgnoreCase(<camparison-value>, <auto-trim>)
<string>.OnlyNumbers()
<string>.RemoveAccents()
<string>.Join(<separator>)
<string>.SubstringBeforeFirstOccurrence("-")
<string>.SubstringBeforeLastOccurrence("-")
<string>.SubstringAfterFirstOccurrence("-")
<string>.SubstringAfterLastOccurrence("-")
<string>.SubstringAtOccurrenceIndex("-", 1)
<string>.SubstringSafe(<start-index>, <length>)
<string>.Limit(<length>)
<string>.LimitReverse(<length>)

// SyntaxExtensions
<object>.IsNull()
<object>.HasValue()
<object>.In(<array-of-values>)
<object>.Between(<starting-value>, <ending-value>)

// TruncateExtensions
<floating-point>.Truncate(<digits>)

// Pipelines
var value = <string>
    .OnlyNumbers()
    .DetachedCall(x => Console.WriteLine(x)) // <<< Call a method with current value and continue execution pipeline
    .Format("mask"); // value is only the number of string formatted and only numbers are written on console

<string>
    .OnlyNumbers()
    .OutVar(out var variableToExternalFromScopeAccess) // <<< Create variable with current value on external scope and continua execution pipeline 
    .Format("mask"); // value is only the number of string formatted and only numbers are written on console 
```

## If fluent expressions

It's possible to execute fluent comparisons expression with the syntax: `<value>.IfGreater(<value-to-compare>).Then(<result-if-compare-is-true>)`.

The methods for comparison operations are: `IfGreater`,` IfGreaterOrEqual`, `IfLest`. `IfLessOrEqual`,` If` and `IfNot`.

Rules:

- When condition it's `false`, result the pipeline is `<value>`.
- When `<value>` or `<value-to-compare>` is null:
    - Result only `true` if both are `null` and comparison is equality operation `If`.
    - When an only value is `null`, the result is `true` if the operation is not equality comparison `IfNot`.
    - When `<value>` is `null`, `<result-if-compare-is-true>` is `not Nullable<>` value and if comparison expression is false, return is defaut of `<value>` data type.
    - All other operations comparisons result in `false`.
- It's possible return `null` value at `<result-if-compare-is-true>`, but then indicated syntax is `<value>.NullIf(<value-to-compare>)`.

Examples:

```csharp
<IComparable>.IfGreater(10).Then(5)
<IComparable>.IfGreaterOrEqual(10).Then(5)
<IComparable>.IfLest(10).Then(5)
<IComparable>.IfLessOrEqual(10).Then(5)
<IComparable>.If(10).Then(5)
<IComparable>.IfNot(10).Then(5)
```

## Data Types

### ISimpleResult, SimpleResult and SimpleResult<TValue>

This structure has success and message for simple method result, extensible with generic TValue on "Value" property.

```csharp
SimpleResult ok = SimpleResult.Ok(<optional-message>);
SimpleResult fail = SimpleResult.Fail("Fail message");

// Implict conversions
SimpleResult ok = true;
SimpleResult fail = "Fail message"
SimpleResult fail = new Exception("Fail message")


// Initializer
var result = new SimpleResult
{
    Success = true,
    Message = "Successfully processed"
}
```

Use cases:

```csharp
public SimpleResult Execute(Args args) 
{
    if (args == null)
        return "Argument cannot be null";  // <===== Implicit cast to failure result
    try
    {
        // Execute actions
    } 
    catch (Exception e)
    {
        return e; // <===== Implicit cast to failure result
    } 
    return true; // <===== Implicit cast success result
}

public SimpleResult<int> Execute2(Args args) 
{
    if (args == null)
        return "Argument cannot be null";  // <===== Implicit cast to failure result
    try
    {
        // Execute actions
    } 
    catch (Exception e)
    {
        return e; // <===== Implicit cast to failure result
    } 
    return 10; // <===== Implicit cast success result
}

// ...

var result = Execute(...);
var result2 = Execute2(...);

if (result && result2) // <===== Implicit cast to boolean
{
    // ...
}


```

### Try<TSuccess, TFailure>

Auxiliary data type to increment the expressibility of method results when success and failure need different structures.  
To facilitate development there is support for implicit conversion.  

```csharp
public void Try<PersonCreated, CustomError> Save(Person value) 
{
    ...
    if (condition)
        return new CustomError() { Code = 999, Message = "Failure message" }
    return new PersonCreated { Id = 123 };
}

...

var result = Save(person);
if (result)
    Console.WriteLine(result.Success.Id);
else
    Console.WriteLine($"Error {result.Failure.Code}: {result.Failure.Message}");
```

## Settings

It's possible set default settings for library:

```csharp
Extensions.GlobalSettings.Configure(cfg => cfg
    .FloatAndDoubleTolerance(default-float-and-double-comparasion-tolerance) // Default is 0.00001f
```

[![buy-me-a-coffee](resources/buy-me-a-coffee.png)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)
[![smile.png](resources/smile.png)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

If my contributions helped you, please help me buy a coffee :D

[![donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)
