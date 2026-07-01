# Other & Utility Extensions (`src/Extensions/Other`)

This module provides utility extension methods that assist in fluent code flow and local variable handling.

## Index

- [1. Variable Out-scoping (`OutVar`)](#1-variable-out-scoping-outvar)

---

### 1. Variable Out-scoping (`OutVar`)

Creates a variable in an outer scope while maintaining the fluent method call chain. This allows you to inspect, store, or reference a value at any point during a chain of extension method executions.

#### Signature
```csharp
T OutVar<T>(this T value, out T target);
```

#### Examples
```csharp
using Maestria.Extensions;

var result = "MyRawValue123"
    .OnlyNumbers()
    .OutVar(out var extractedNumbers) // "extractedNumbers" variable is declared and populated here
    .Format("mask"); // execution pipeline continues

// You can now access "extractedNumbers" outside the pipeline
Console.WriteLine(extractedNumbers); // Outputs only numbers
```
