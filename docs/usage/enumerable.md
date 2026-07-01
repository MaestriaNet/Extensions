# Enumerable & Collection Extensions (`src/Extensions/Enumerable`)

This module provides extension methods to simplify working with `IEnumerable`, arrays, dictionaries, and collections.

---

### 1. `HasItems`

Checks if an `IEnumerable` is not null and contains at least one item. Safe to use on null lists.

#### Signature
```csharp
bool HasItems<T>(this IEnumerable<T> values);
```

#### Examples
```csharp
using Maestria.Extensions;

List<string> items = new List<string> { "item" };
List<string> empty = new List<string>();
List<string> nullList = null;

items.HasItems();    // true
empty.HasItems();    // false
nullList.HasItems(); // false
```

---

### 2. Dictionaries (`TryGetValue`)

Safely attempts to fetch a value from an `IDictionary` or returns a fallback default value if the key does not exist.

#### Signature
```csharp
TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default);
```

#### Examples
```csharp
using Maestria.Extensions;

var dict = new Dictionary<string, string> { { "key1", "value1" } };

string value1 = dict.TryGetValue("key1", "fallback"); // Returns "value1"
string value2 = dict.TryGetValue("key2", "fallback"); // Returns "fallback"
```

---

### 3. Iteration Helpers (`Iterate`)

Enables simple fluent iteration (`ForEach` alternative) on collections, with support for indexes and asynchronous delegates.

#### Signatures
```csharp
// Synchronous iteration
IEnumerable<T> Iterate<T>(this IEnumerable<T> values, Action<T> action);
IEnumerable<T> Iterate<T>(this IEnumerable<T> values, Action<T, int> action);

// Asynchronous iteration
Task Iterate<T>(this IEnumerable<T> values, Func<T, Task> action);
Task Iterate<T>(this IEnumerable<T> values, Func<T, int, Task> action);
```

#### Examples
```csharp
using Maestria.Extensions;
using System.Threading.Tasks;

var numbers = new[] { 1, 2, 3 };

// Synchronous with index
numbers.Iterate((num, index) => Console.WriteLine($"Index {index}: {num}"));

// Asynchronous iteration
await numbers.Iterate(async num => {
    await Task.Delay(100);
    Console.WriteLine(num);
});
```

---

### 4. Indexing & String Joining (`WithIndex`, `Join`)

- **`WithIndex`**: Project elements along with their index using a tuple `(T Value, int Index)`.
- **`Join`**: Fluent shorthand to join an `IEnumerable` of strings with a separator.

#### Examples
```csharp
using Maestria.Extensions;

// WithIndex loop
var colors = new[] { "Red", "Blue", "Green" };
foreach (var (color, index) in colors.WithIndex())
{
    Console.WriteLine($"{index}: {color}");
}

// Join collections
string joined = colors.Join(", "); // Returns "Red, Blue, Green"
```
