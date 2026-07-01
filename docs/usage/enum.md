# Enum Extensions (`src/Extensions/Enum`)

This module provides extension methods to retrieve display text, descriptions, and list values from enums.

## Index

- [1. Retrieve Metadata (`GetDisplayName`, `GetDescription`)](#1-retrieve-metadata-getdisplayname-getdescription)
- [2. Retrieve All Enum Values (`GetValues`)](#2-retrieve-all-enum-values-getvalues)

---

### 1. Retrieve Metadata (`GetDisplayName`, `GetDescription`)

Extracts metadata defined via attributes like `[Display]`, `[DisplayName]`, or `[Description]` on Enum values.

#### Signatures
```csharp
string GetDisplayName(this Enum value);
string GetDescription(this Enum value);
```

#### Examples
```csharp
using Maestria.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public enum Status
{
    [Display(Name = "Active User")]
    [Description("The user is currently active.")]
    Active,
    
    [Description("Suspended account")]
    Suspended
}

// Get Display Name (falls back to Description, then the Enum string value if metadata is missing)
Status.Active.GetDisplayName();    // Returns "Active User"
Status.Suspended.GetDisplayName(); // Returns "Suspended account"

// Get Description (falls back to Display Name, then Enum string value)
Status.Active.GetDescription();    // Returns "The user is currently active."
```

---

### 2. Retrieve All Enum Values (`GetValues`)

Provides a clean static method to list all typed values of an Enum.

#### Signatures
```csharp
// Generic version
IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, Enum;

// Non-generic version
IEnumerable<object> GetValues(Type enumType);
```

#### Examples
```csharp
using Maestria.Extensions;

// Retrieve values as typed list
IEnumerable<Status> statuses = EnumExtensions.GetValues<Status>();
```
