# Comparable & Fluent Expressions (`src/Extensions/Comparable`)

This module provides fluent-syntax expressions for comparing values, range checks, containment checks (`In`), value limiting, and conditional returns.

---

### 1. Range & Containment Checks (`Between`, `In`)

These extensions offer expressive syntax for checking range bounds or containment within a set of elements.

#### `Between`
Checks if a value is within a specified inclusive range.
```csharp
bool Between<T>(this T value, T starting, T ending) where T : IComparable;
```

#### `In`
Checks if a value is contained within a specific array or set of arguments.
```csharp
bool In<T>(this T value, params T[] checkValues);
```

#### Examples
```csharp
using Maestria.Extensions;

// Between checks
int score = 85;
bool isGradeB = score.Between(80, 89); // true

// In checks
string country = "Brazil";
bool isSouthAmerica = country.In("Brazil", "Argentina", "Chile", "Uruguay"); // true
```

---

### 2. Value Limiting (`LimitMinAt`, `LimitMaxAt`)

Allows you to easily constrain comparable values to defined boundaries.

- **`LimitMinAt`**: Restricts a value to a minimum threshold (returns the threshold if the value is lower).
- **`LimitMaxAt`**: Restricts a value to a maximum threshold (returns the threshold if the value is higher).

#### Examples
```csharp
using Maestria.Extensions;

int value = 150;
int maxCapped = value.LimitMaxAt(100); // Returns 100
int minCapped = value.LimitMinAt(200); // Returns 200
```

---

### 3. Fluent Conditional Expressions (`If...Then...`)

Allows executing fluent comparison expressions of the form: `<value>.IfGreater(<value-to-compare>).Then(<result-if-true>)`.

If the condition is **false**, the original `<value>` is returned.

#### Supported Operations
- `If` / `IfNotEqual`
- `IfGreater` / `IfGreaterOrEqual`
- `IfLess` / `IfLessOrEqual`
- `IfNull` / `IfNullOrEmpty` / `IfNullOrWhiteSpace`
- `IfEmpty` (for Guids, etc.)

#### Passing Delegates
Instead of evaluating the `Then` value immediately, you can pass a delegate (`Func<T>`) so it is only executed if the condition matches:
```csharp
<value>.IfGreater(10).Then(() => CalculateExpensiveValue())
```

#### Rules

- When the condition is `false`, the original `<value>` is returned unchanged.
- When `<value>` or `<value-to-compare>` is `null`:
  - Returns `true` only if **both** are `null` and the comparison is the equality operation `If`.
  - Returns `true` if only one side is `null` and the operation is `IfNot` (not-equal).
  - When `<value>` is `Nullable<T>`, `<result-if-compare-is-true>` is always of type `Nullable<T>`.
  - When `<value>` is not `Nullable<T>`, `<result-if-compare-is-true>` may be either `Nullable<T>` or non-nullable.
  - All other comparison operations return `false` when a value is `null`.
- To return `null` from a comparison, use `<value>.NullIf(<value-to-compare>)` instead of `If(...).Then(null)`.

#### Examples

```csharp
using Maestria.Extensions;

```csharp
using Maestria.Extensions;

// Simple If/Then
int age = 15;
int ticketPrice = age.IfLess(18).Then(10); // Returns 10 (since age is less than 18)
int adultPrice = age.IfGreaterOrEqual(18).Then(20); // Returns 15 (condition false, returns original value)

int value = 100;
int resultEqual = value.If(100).Then(200); // Returns 200
int resultNotEqual = value.IfNotEqual(50).Then(300); // Returns 300
int resultGreater = value.IfGreater(50).Then(500); // Returns 500
int resultLessOrEqual = value.IfLessOrEqual(100).Then(600); // Returns 600

// Null/Empty fallback helpers
string text = null;
string display = text.IfNullOrEmpty().Then("Default Text"); // Returns "Default Text"
string wsText = "   ";
string displayWs = wsText.IfNullOrWhiteSpace().Then("Default Text"); // Returns "Default Text"
string nullVal = null;
string displayNull = nullVal.IfNull().Then("Fallback"); // Returns "Fallback"

Guid emptyGuid = Guid.Empty;
Guid newGuid = emptyGuid.IfEmpty().Then(Guid.NewGuid()); // Returns a new Guid
```

---

### 4. `NullIf` Expressions

Returns `null` if the value matches the comparison criteria, otherwise returns the original value.

#### Supported Operations
- `<object>.NullIf(<comparison-value>)`
- `<string>.NullIfEmpty()`
- `<string>.NullIfWhiteSpace()`
- `<IComparable>.NullIfIn(<params-values>)`
- `<IComparable>.NullIfBetween(<start>, <end>)`

#### Examples
```csharp
using Maestria.Extensions;

// Nullify when matching a value
string status = "None";
string result = status.NullIf("None"); // Returns null

// Nullify when in range or matching set
int rating = 5;
int? cappedRating = rating.NullIfBetween(1, 5); // Returns null
int? ratingIn = rating.NullIfIn(1, 2, 3, 5);    // Returns null

// Nullify strings based on content
string emptyText = "";
string nullEmpty = emptyText.NullIfEmpty(); // Returns null

string wsText = "   ";
string clean = wsText.NullIfWhiteSpace(); // Returns null
```

### 5. Type & Nullability Checks (`IsNull`, `IsNotNull`, `IsNullOrEmpty`, `IsNullOrWhiteSpace`, `HasValue`)

Provides expressive aliases for checking nullability, emptiness, and presence of values on objects, strings, collections, and Guids.

- **`IsNull()`**: Shorthand for `value == null` (available on `object?`).
- **`IsNotNull()`**: Shorthand for `value != null` (available on `object?`).
- **`IsNullOrEmpty()`**: Checks if null/empty for `string`, `Guid?`, `IEnumerable`, and `IEnumerable<T>`.
- **`IsNullOrWhiteSpace()`**: Checks if null/whitespace for `string`.
- **`HasValue()`**: Checks if a value is not null (for `object?`), not null/whitespace (for `string`), or not empty (for `Guid` and `Guid?`).

#### Examples
```csharp
using Maestria.Extensions;

// Object checks
object obj = null;
bool isNull = obj.IsNull();       // true
bool isNotNull = obj.IsNotNull(); // false
bool hasVal = obj.HasValue();     // false

// Collection / List checks
List<int> list = null;
list.IsNullOrEmpty();             // true

// String checks
string title = "   ";
title.IsNullOrWhiteSpace();       // true
title.HasValue();                 // false
```

---

### 6. `EmptyIf` Extensions

Returns an empty string (`""`) under specific equality or nullability conditions.

- **`EmptyIf(equalityValue, ignoreCase)`**: Returns an empty string if the value equals `equalityValue`.
- **`EmptyIfNull()`**: Returns an empty string if the value is null.
- **`EmptyIfNullOrWhiteSpace()`**: Returns an empty string if the value is null or whitespace.

#### Examples
```csharp
using Maestria.Extensions;

string text = "default";
string result = text.EmptyIf("default"); // Returns ""

string nullableText = null;
string safeText = nullableText.EmptyIfNull(); // Returns ""

string wsText = "   ";
string safeWs = wsText.EmptyIfNullOrWhiteSpace(); // Returns ""
```


