'1.0.0'# Maestria Extensions

[![Build status](https://ci.appveyor.com/api/projects/status/mvosd40vqsgrvkr0/branch/master?svg=true)](https://ci.appveyor.com/project/fabionaspolini/extensions/branch/master)
[![NuGet](https://buildstats.info/nuget/Maestria.Extensions)](https://www.nuget.org/packages/Maestria.Extensions)
[![MyGet](https://buildstats.info/myget/maestrianet/Maestria.Extensions)](https://www.myget.org/feed/maestrianet/package/nuget/Maestria.Extensions)

[![Build History](https://buildstats.info/appveyor/chart/fabionaspolini/extensions?branch=master)](https://ci.appveyor.com/project/fabionaspolini/extensions/history?branch=master)

### What is Maestria Extensions?
Extension function pack to increase productivity and improve source code writing.

### What is Maestria Project?
This library is part of Maestria Project.

Maestria is a project to provide productivity and elegance to your source code writing.

### How do I get started?
First, import "Maestria.Extensions" reference:

```csharp
using Maestria.Extensions;

// AggregateExtenions
<Array>.Max();
<Array>.Min();

// Base64Extensions
Base64Extensions.Encode("value", <Encoding>)
Base64Extensions.Decode("encoded-value", <Encoding>)

// CollectionExtensions
<IEnumerable>.IsNullOrEmpty()
<IEnumerable>.HasItems()
<IEnumerable>.Iterate((arg) => <action>)
<IEnumerable>.IterateSafe((arg) => <action>)
<IEnumerable>.IterateAsync((arg) => <action>)
<IEnumerable>.IterateSafeAsync((arg) => <action>)

// EnumExtensions
<Enum>.GetDisplayName()
<Enum>.GetDescription()
EnumExtensions.GetValues<TEnum>()

// ExceptionExtensions
<Exception>.GetMessageWithInner()

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

// NullIfExtensions to floating point (Float, Double and Decimal)
<floating-point>.NullIf(<comparison-value>, <tolerance-to-comparasion>)

NullIfExtensions to string
<string>.NullIf(<comparison-value>, <ignore-case>)
<string>.NullIfEmpty(<comparison-value>)
<string>.NullIfWhiteSpace(<comparison-value>)

// ReflectionExtensions
<type>.IsInheritedOrImplements(<parent-type>)

// RoundExtensions
<floating-point>.Round()
<floating-point>.Round(<digits>)
<floating-point>.Round(<digits>, <MidpointRounding>)

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
<string>.HasValue()
<string>.EqualsIgnoreCase(<camparison-value>, <auto-trim>)
<string>.OnlyNumbers()
<string>.RemoveAccents()

// SyntaxExtensions
<object>.In(<array-of-values>)
<object>.Between(<starting-value>, <ending-value>)

// TruncateExtensions
<floating-point>.Truncate()
<floating-point>.Truncate(<digits>)
```

It's possible set default culture format for library, when not configured, default culture is CultureInfo.InvariantCulture:
```csharp
Extensions.GlobalSettings.Configure(cfg => cfg
    .FloatAndDoubleTolerance(default-float-and-double-comparasion-tolerance)    
```

Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Maestria Extensions](https://www.nuget.org/packages/Maestria.Extensions/) from the package manager console:

```
PM> Install-Package Maestria.Extensions
```

or install from the dotnet cli command line:
```
> dotnet add package Maestria.Extensions
``` 