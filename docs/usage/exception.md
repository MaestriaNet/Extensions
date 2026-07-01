# Exception Extensions (`src/Extensions/Exception`)

This module provides extension methods to inspect, extract, and format exceptions and inner exception details.

---

### 1. `GetMostInner`

Traverses the `InnerException` chain and retrieves the root cause exception.

#### Signature
```csharp
Exception GetMostInner(this Exception exception);
```

#### Examples
```csharp
using Maestria.Extensions;
using System;

try
{
    throw new Exception("Root Exception", new Exception("Parent Exception", new Exception("Child Cause")));
}
catch (Exception ex)
{
    Exception root = ex.GetMostInner();
    Console.WriteLine(root.Message); // Prints "Child Cause"
}
```

---

### 2. `GetAllMessages`

Flattens the entire exception tree hierarchy, extracting error messages from all inner exceptions and `AggregateException` instances. It reformats them into a single string with customizable separators.

#### Signatures
```csharp
string GetAllMessages(this Exception exception, string separator = " -> ", bool uniqueOnly = true);
```

#### Examples
```csharp
using Maestria.Extensions;
using System;

try
{
    throw new Exception("SQL Connection Failed", new Exception("Access Denied"));
}
catch (Exception ex)
{
    string fullError = ex.GetAllMessages(); 
    // Returns: "SQL Connection Failed -> Access Denied"
    
    string customSeparator = ex.GetAllMessages(" | ");
    // Returns: "SQL Connection Failed | Access Denied"
}
```
