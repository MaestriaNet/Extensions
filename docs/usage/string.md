# String & Cryptography Extensions (`src/Extensions/String`)

This module provides a rich set of string manipulation, encoding, validation, and cryptographic hashing helper methods.

## Index

- [1. Case & Styling Conversions](#1-case--styling-conversions)
- [2. Substring & Truncate Safely](#2-substring--truncate-safely)
- [3. Add to Boundaries & Trimming](#3-add-to-boundaries--trimming)
- [4. Text Validations & Cleaning](#4-text-validations--cleaning)
- [5. String Comparisons (`EqualsIgnoreCase`)](#5-string-comparisons-equalsignorecase)
- [6. File Saving (`SaveAs`, `SaveAsAsync`)](#6-file-saving-saveas-saveasasync)
- [7. Base64 & Web Encodings](#7-base64--web-encodings)
- [8. Cryptographic Hashing (`src/Extensions/String/Hash`)](#8-cryptographic-hashing-srcextensionsstringhash)

---

### 1. Case & Styling Conversions

Convert strings between CamelCase, SnakeCase, or KebabCase.

- **`ToSnakeCase`**: Converts a string to `snake_case`.
- **`ToKebabCase`**: Converts a string to `kebab-case`.

#### Examples
```csharp
using Maestria.Extensions;

"UserAccountDetails".ToSnakeCase(); // "user_account_details"
"UserAccountDetails".ToKebabCase(); // "user-account-details"
```

---

### 2. Substring & Truncate Safely

Retrieve portions of strings based on character occurrences or safely limit string lengths.

#### Substring Operations
- **`SubstringBeforeFirstOccurrence(char/string)`**
- **`SubstringBeforeLastOccurrence(char/string)`**
- **`SubstringAfterFirstOccurrence(char/string)`**
- **`SubstringAfterLastOccurrence(char/string)`**
- **`SubstringAtOccurrenceIndex(char/string, occurrenceIndex)`**
- **`SubstringSafe(startIndex, length)`**: Returns a substring without throwing exceptions if bounds are exceeded.

#### Truncation
- **`Truncate(length)`**: Limits length of string, returning matching prefix.
- **`TruncateStart(length)`**: Limits length of string, returning matching suffix.

#### Examples
```csharp
using Maestria.Extensions;

string path = "src/Extensions/String/Truncate.cs";

// Substring operations
path.SubstringBeforeFirstOccurrence("/"); // "src"
path.SubstringBeforeLastOccurrence("/");  // "src/Extensions/String"
path.SubstringAfterFirstOccurrence("/");  // "Extensions/String/Truncate.cs"
path.SubstringAfterLastOccurrence("/");   // "Truncate.cs"
path.SubstringAtOccurrenceIndex("/", 1);  // "Extensions" (text between 1st and 2nd '/')
path.SubstringSafe(0, 100);               // Safely returns full string instead of throwing error

"Hello World".Truncate(5);       // "Hello"
"Hello World".TruncateStart(5);  // "World"
```

---

### 3. Add to Boundaries & Trimming

Fluent formatting methods to add prefixes/suffixes conditionally.

#### Signatures
- **`AddToBeginningIfNotStartsWith(value, ignoreCase)`**
- **`AddToBeginningIfHasValue(prefix)`**
- **`AddToEndIfNotEndsWith(value, ignoreCase)`**
- **`AddToEndIfHasValue(suffix)`**
- **`TrimStart(comparison, ignoreCase)`** / **`TrimEnd(comparison, ignoreCase)`**

#### Examples
```csharp
using Maestria.Extensions;

"/subfolder".AddToBeginningIfNotStartsWith("/"); // "/subfolder" (no duplication)
"subfolder".AddToBeginningIfNotStartsWith("/");  // "/subfolder"
"folder/".AddToEndIfNotEndsWith("/");            // "folder/"

// IfHasValue helpers (only append/prepend if the string has value)
string name = "Antigravity";
string nullName = null;
name.AddToBeginningIfHasValue("Hello "); // "Hello Antigravity"
nullName.AddToBeginningIfHasValue("Hello "); // "" (null-safe empty string)

name.AddToEndIfHasValue("!"); // "Antigravity!"
nullName.AddToEndIfHasValue("!"); // ""

// Custom trimming
"___Content___".TrimStart("_"); // "Content___"
"___Content___".TrimEnd("_");   // "___Content"
```

---

### 4. Text Validations & Cleaning

Clean and inspect strings using built-in filters.

- **`OnlyNumbers`**: Returns only digits from a string.
- **`RemoveAccents`**: Removes accent marks/diacritics from a string.
- **`OnlyLettersOrNumbersOrUnderscoresOrHyphens`**: Validates character types.
- **`OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces`**: Validates character types, allowing spaces.
- **`EscapeXml`**: Encodes string safely for XML structures.

#### Examples
```csharp
using Maestria.Extensions;

"Phone: (123) 456-7890".OnlyNumbers(); // "1234567890"
"München".RemoveAccents();               // "Munchen"

// Character type validations
"valid-string_123".OnlyLettersOrNumbersOrUnderscoresOrHyphens(); // true
"invalid string".OnlyLettersOrNumbersOrUnderscoresOrHyphens();   // false
"valid string 123".OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces(); // true

// XML escaping
"<tag>\"Value\" & 'More'</tag>".EscapeXml(); // "&lt;tag&gt;&quot;Value&quot; &amp; &apos;More&apos;&lt;/tag&gt;"
```

---

### 5. String Comparisons (`EqualsIgnoreCase`)

Provides a high-performance case-insensitive comparison that automatically trims whitespaces if specified.

- **`EqualsIgnoreCase(valueToCompare, autoTrim = true)`**

#### Examples
```csharp
using Maestria.Extensions;

string input = "  Admin  ";
bool isAdmin = input.EqualsIgnoreCase("admin"); // true (ignores case and automatically trims)
```

---

### 6. File Saving (`SaveAs`, `SaveAsAsync`)

Enables quick and fluent writing of string content directly to a file on disk.

- **`SaveAs(fileName/FileInfo, append = false)`**
- **`SaveAsAsync(fileName/FileInfo, append = false)`**

#### Examples
```csharp
using Maestria.Extensions;
using System.Threading.Tasks;

string logData = "Log entry detailed description\n";

// Synchronous save
logData.SaveAs("log.txt", append: true);

// Asynchronous save
await logData.SaveAsAsync("log.txt", append: true);
```

---

### 7. Base64 & Web Encodings

#### Base64 Encodings
- **`ToBase64(encoding)`**: Converts standard string/byte array to base64.
- **`FromBase64(encoding)`**: Decodes base64 string/byte array back to native data.

#### Web Encodings
- **`UrlEncode()`** / **`UrlDecode()`**

#### Examples
```csharp
using Maestria.Extensions;

string code = "hello world".ToBase64();
string raw = code.FromBase64();

string query = "hello world".UrlEncode(); // "hello+world"
string rawQuery = query.UrlDecode();      // "hello world"
```

---

### 8. Cryptographic Hashing (`src/Extensions/String/Hash`)

Retrieve common cryptographic hash signatures fluently from strings or byte arrays.

#### Hash Methods
- **`GetHashMd5()`**
- **`GetHashSha1()`**
- **`GetHashSha256()`**
- **`GetHashSha384()`**
- **`GetHashSha512()`**

#### Examples
```csharp
using Maestria.Extensions;

string secret = "password123";
string sha256Signature = secret.GetHashSha256(); // Returns hex hash representation
```
