# Numeric Extensions (`src/Extensions/Number`)

This module provides extension methods to simplify the manipulation, rounding, and truncating of numeric types (`decimal`, `double`, `float`).

> [!NOTE]
> All extension methods in Maestria.Extensions are **null-safe** by design. If the input value is `null`, the method will return `null` without throwing a `NullReferenceException`.

## Index

- [1. `Round`](#1-round)
- [2. `RoundUp`](#2-roundup)
- [3. `Truncate`](#3-truncate)

---

### 1. `Round`

Rounds a numeric value to a specified number of fractional digits, with support for customizable `MidpointRounding` modes.

#### Signatures
```csharp
// Available for decimal, double, float (and their nullable counterparts: decimal?, double?, float?)
T Round(this T value, int digits = 0);
T Round(this T value, int digits, MidpointRounding mode);
```

#### Examples
```csharp
using Maestria.Extensions;

// Decimal rounding
decimal value = 12.3456m;
decimal rounded = value.Round(2);       // Returns 12.35
decimal defaultRounded = value.Round();  // Returns 12 (0 decimal places)

// MidpointRounding control
decimal midpointValue = 12.345m;
decimal roundUp = midpointValue.Round(2, MidpointRounding.AwayFromZero); // Returns 12.35
decimal roundEven = midpointValue.Round(2, MidpointRounding.ToEven);      // Returns 12.34

// Null-safe behavior
decimal? nullableValue = null;
decimal? result = nullableValue.Round(2); // Returns null safely
```

---

### 2. `RoundUp`

Rounds a numeric value up to the next specified fractional digit or integer.

#### Signatures
```csharp
// Available for decimal, double, float (and their nullable counterparts: decimal?, double?, float?)
T RoundUp(this T value, int digits = 0);
```

#### Examples
```csharp
using Maestria.Extensions;

double value = 10.1234;
double roundedUp = value.RoundUp(3);    // Returns 10.124
double noDecimals = value.RoundUp();    // Returns 11.0

// Null-safe behavior
double? nullableValue = null;
double? result = nullableValue.RoundUp(2); // Returns null safely
```

---

### 3. `Truncate`

Truncates a number by discarding fractional digits beyond the specified limit, without applying any rounding rules.

#### Signatures
```csharp
// Available for decimal, double, float (and their nullable counterparts: decimal?, double?, float?)
T Truncate(this T value, int digits = 0);
```

#### Examples
```csharp
using Maestria.Extensions;

float value = 5.9876f;
float truncated = value.Truncate(2);       // Returns 5.98f
float integerTruncated = value.Truncate(); // Returns 5.0f

// Null-safe behavior
float? nullableValue = null;
float? result = nullableValue.Truncate(2); // Returns null safely
```
