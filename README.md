# Maestria Extensions

[![Build status](https://ci.appveyor.com/api/projects/status/mvosd40vqsgrvkr0/branch/master?svg=true)](https://ci.appveyor.com/project/fabionaspolini/extensions/branch/master)
[![NuGet](https://buildstats.info/nuget/Maestria.Extensions)](https://www.nuget.org/packages/Maestria.Extensions)
[![MyGet](https://img.shields.io/myget/maestrianet/v/Maestria.Extensions?label=MyGet)](https://www.myget.org/feed/maestrianet/package/nuget/Maestria.Extensions)

[![Build History](https://buildstats.info/appveyor/chart/fabionaspolini/extensions?branch=master)](https://ci.appveyor.com/project/fabionaspolini/extensions/history?branch=master)

[![donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

## What is Maestria Extensions?

Extension function pack to increase productivity and improve source code writing.

## What is Maestria Project?

This library is part of Maestria Project.

Maestria is a project to provide productivity and elegance to your source code writing.

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
<string>.RemoveIfStartsWith(<start-comparison>, <ignore-case>)
<string>.RemoveIfEndsWith(<start-comparison>, <ignore-case>)
<string>.AddToLeftIfNotStartsWith(<start-comparison>, <ignore-case>)
<string>.AddToRightIfNotEndsWith(<start-comparison>, <ignore-case>)
<string>.AddToLeftIfHasValue(<start-comparison>, <prefix>)
<string>.AddToRightIfHasValue(<start-comparison>, <prefix>)
<string>.Format(<values-to-format>)
<string>.IsNullOrEmpty()
<string>.IsNullOrWhiteSpace()
<string>.EmptyIf(<string>)
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
<string>.LimitEnd(<length>)

// SyntaxExtensions
<object>.IsNull()
<object>.HasValue()
<object>.In(<array-of-values>)
<object>.Between(<starting-value>, <ending-value>)
var value = <string>
    .OnlyNumbers()
    .DetachedCall(x => Console.WriteLine(x)) // <<< Call a method with current value and continue execution pipeline
    .Format("mask"); // value is only the number of string formatted and only numbers are written on console

<string>
    .OnlyNumbers()
    .OutVar(out var variableToExternalFromScopeAccess) // <<< Create variable with current value on external scope and continua execution pipeline 
    .Format("mask"); // value is only the number of string formatted and only numbers are written on console 

// TruncateExtensions
<floating-point>.Truncate(<digits>)
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

// Initializer
var result = new SimpleResult
{
    Success = true,
    Message = "Successfully processed"
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

Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Maestria Extensions](https://www.nuget.org/packages/Maestria.Extensions/) from the package manager console:

```bash
PM> Install-Package Maestria.Extensions
```

or install from the dotnet cli command line:

```bash
> dotnet add package Maestria.Extensions
```

<a href="https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL">
![buy-me-a-coffee](resources/buy-me-a-coffee.png)
![smile.png](resources/smile.png)
</a>

If my contributions have helped you, please help me buying a coffee :D 

[![donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

