# Maestria.Extensions

[![NuGet Version](https://img.shields.io/nuget/v/Maestria.Extensions)](https://www.nuget.org/packages/Maestria.Extensions/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Maestria.Extensions)](https://www.nuget.org/packages/Maestria.Extensions/)
[![Apimundo](https://img.shields.io/badge/Maestria.Extensions%20API-Apimundo-728199.svg)](https://apimundo.com/organizations/nuget-org/nuget-feeds/public/packages/Maestria.Extensions/versions/latest?tab=types)

---

[![buy-me-a-coffee](https://raw.githubusercontent.com/MaestriaNet/Extensions/master/resources/buy-me-a-coffee.png)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)
[![smile.png](https://raw.githubusercontent.com/MaestriaNet/Extensions/master/resources/smile.png)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

If my contributions helped you, please help me buy a coffee :D

[![donate](https://raw.githubusercontent.com/MaestriaNet/Extensions/master/resources/btn_donate.gif)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

---

## What is Maestria.Extensions?

Extension function pack to increase productivity and improve source code writing.
By default, all extension methods are safe.

## What is Maestria Project?

This library is part of Maestria Project.

Maestria is a project to provide productivity and elegance to your source code writing.

## Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Maestria.Extensions](https://www.nuget.org/packages/Maestria.Extensions/) from the package manager console:

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

Then in your application code, use fluent syntax:

```csharp
// 1. Numeric rounding
using Maestria.Extensions;
decimal value = 3.14159m;
var rounded = value.Round(2); // 3.14
// Detailed: [Number extensions](docs/usage/number.md)

// 2. Range check
int score = 85;
bool isGradeB = score.Between(80, 89); // true
// Detailed: [Comparable extensions](docs/usage/comparable.md)

// 3. Enum display name
DayOfWeek day = DayOfWeek.Monday;
string name = day.GetDisplayName(); // "Monday"
// Detailed: [Enum extensions](docs/usage/enum.md)

// 4. Collection has items
var list = new[] { 1, 2, 3 };
bool has = list.HasItems(); // true
// Detailed: [Enumerable extensions](docs/usage/enumerable.md)

// 5. Exception messages
try { throw new InvalidOperationException("Invalid"); }
catch (Exception ex) { var msg = ex.GetAllMessages(); }
// Detailed: [Exception extensions](docs/usage/exception.md)

// 6. String trimming
string path = "/folder/";
var trimmed = path.TrimEnd("/"); // "/folder"
// Detailed: [String extensions](docs/usage/string.md)

// 7. XML escaping
string xml = "<tag>\"Value\" & More</tag>";
var escaped = xml.EscapeXml(); // "&lt;tag&gt;&quot;Value&quot; &amp; More&lt;/tag&gt;"
// Detailed: [String extensions](docs/usage/string.md)

// 8. Base64 encoding
string text = "hello";
var b64 = text.ToBase64(); // "aGVsbG8="
// Detailed: [String extensions](docs/usage/string.md)

// 9. Guid handling
Guid guid = Guid.Empty;
var newGuid = guid.IfEmpty().Then(Guid.NewGuid());
// Detailed: [Other extensions](docs/usage/other.md)

// 10. Pipeline example
var result = "12345"
    .OnlyNumbers()
    .Format("{0:###-##}"); // "123-45"
// Detailed: [String extensions](docs/usage/string.md)
```

There are many more extension methods available. See the full documentation:

| Topic | Description |
|---|---|
| [Number extensions](docs/usage/number.md) | `Round`, `RoundUp`, `Truncate` for numeric types |
| [Comparable extensions](docs/usage/comparable.md) | `Between`, `In`, `LimitMinAt`, `LimitMaxAt`, fluent `If...Then`, `NullIf` |
| [Enum extensions](docs/usage/enum.md) | `GetDisplayName`, `GetDescription`, `GetValues` |
| [Enumerable extensions](docs/usage/enumerable.md) | `HasItems`, `IsNullOrEmpty`, `Iterate`, `TryGetValue`, `WithIndex` |
| [Exception extensions](docs/usage/exception.md) | `GetAllMessages`, `GetMostInner` |
| [String extensions](docs/usage/string.md) | Trimming, substring, hashing, Base64, encoding, and more |
| [Other extensions](docs/usage/other.md) | `OutVar` and pipeline helpers |
| [Data types](docs/usage/datatypes.md) | `SimpleResult`, `Try<TSuccess, TFailure>` |


## Data Types

The library ships with two expressive result types that eliminate boilerplate error handling:

```csharp
// SimpleResult — implicit conversions keep method signatures clean
public SimpleResult Save(Order order)
{
    if (order == null) return "Order cannot be null"; // implicit failure
    // ...
    return true; // implicit success
}

var result = Save(order);
if (result) Console.WriteLine("Saved!");
else        Console.WriteLine(result.Message);

// Try<TSuccess, TFailure> — distinct types for success and failure
public Try<OrderCreated, ValidationError> Submit(Order order) { ... }

var r = Submit(order);
if (r) Console.WriteLine($"Order ID: {r.Value.Id}");
else   Console.WriteLine($"Error {r.Failure.Code}: {r.Failure.Message}");
```

> See [docs/usage/datatypes.md](docs/usage/datatypes.md) for full documentation, implicit conversion rules, `SimpleResult<T>`, and advanced usage.

## Settings

It's possible set default settings for library:

```csharp
Extensions.GlobalSettings.Configure(cfg => cfg
    .FloatAndDoubleTolerance(default-float-and-double-comparasion-tolerance) // Default is 0.00001f
```



## Documentations

See additional documentations at [docs](docs) folder.

- [changelog.md](docs/changelog.md): List of changes by version and breaking changes.
- [ci-workflow.md](docs/ci-workflow.md): Description of the CI workflow used in the project.
- [contributing.md](docs/contributing.md): How to contribute to the project.

### Usage Guides

- [Number extensions](docs/usage/number.md)
- [Comparable & fluent expressions](docs/usage/comparable.md)
- [Enum extensions](docs/usage/enum.md)
- [Enumerable & collection extensions](docs/usage/enumerable.md)
- [Exception extensions](docs/usage/exception.md)
- [String extensions](docs/usage/string.md)
- [Other extensions](docs/usage/other.md)
- [Data types](docs/usage/datatypes.md)

---

[![buy-me-a-coffee](https://raw.githubusercontent.com/MaestriaNet/Extensions/master/resources/buy-me-a-coffee.png)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)
[![smile.png](https://raw.githubusercontent.com/MaestriaNet/Extensions/master/resources/smile.png)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)

If my contributions helped you, please help me buy a coffee :D

[![donate](https://raw.githubusercontent.com/MaestriaNet/Extensions/master/resources/btn_donate.gif)](https://www.paypal.com/donate?hosted_button_id=8RSES6GAYH9BL)
