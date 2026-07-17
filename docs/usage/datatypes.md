# Result & Error Handling Types (`src/DataTypes`)

This module provides utility classes (`SimpleResult` and `Try`) to make method results and error reporting much more expressive and clean, avoiding excessive exceptions.

## Index

- [1. `Result` & `Result<T>` (Obsoleted `SimpleResult`)](#1-result--resultt-obsoleted-simpleresult)
- [2. `Try<TSuccess, TFailure>`](#2-trytsuccess-tfailure)

---

### 1. `Result` & `Result<T>` (Obsoleted `SimpleResult`)

An immutable, lightweight structure containing a `Success` status, an optional `Message`, and an optional `Exception`. It provides deconstruction support, and implicit primitive conversions.

> [!IMPORTANT]
> `SimpleResult` and `ISimpleResult` are deprecated. Use `Result` and `IResult` instead.
> Unlike `SimpleResult`, the new `Result` struct is strictly immutable (`readonly struct`), which prevents bugs related to mutable structs.

#### Examples
```csharp
using Maestria.Extensions;

// 1. Fluent Creation & Deconstruction
public Result<int> GetUserAge(string userId)
{
    if (string.IsNullOrWhiteSpace(userId))
        return "User ID cannot be empty"; // Implicitly cast to Failure

    try
    {
        int age = FetchAgeFromDb(userId);
        return age; // Implicitly cast to Success (Result<int>)
    }
    catch (Exception ex)
    {
        return ex; // Implicitly cast to Failure with Exception details
    }
}

// Verify success by implicitly operator
var result = GetUserAge("user_123");
if (result)
    Console.WriteLine($"Age: {age}");
else
    Console.WriteLine($"Error: {message}");

// Consuming with Deconstruction:
var (success, age, message) = result;

// 2. Functional Mapping & Binding
var finalizedResult = GetUserAge("user_123")
    .Map(age => $"User is {age} years old")               // Result<int> -> Result<string>
    .Bind(text => SendNotification(text));                // Result<string> -> Result (void)
```

#### Implicit Conversions Support

- **From `bool`**: Maps to `Success = value`.
- **From `string`** (only on non-generic `Result`): Sets `Success = false` and assigns the string to `Message` (representing a failure).
- **From `Exception`**: Sets `Success = false` and assigns the exception details.
- **From `TValue`** (in `Result<TValue>`): Sets `Success = true` and assigns the value to `Value`.
- **To `bool`**: Returns `Success` for `Result`. For `Result<TValue>`, it returns `SuccessAndHasValue` (guaranteeing that the value is not null when `true`).
- **To `TValue`**: Returns the `Value`.
- **To `Exception`**: Returns the `Exception`.

> ***Caution on string ambiguity resolved:*** *In `Result<TValue>`, the implicit conversion from `string` to Failure is removed to prevent compiler errors when `TValue` is a `string` (which would conflict with the conversion to Success). Use `Result<string>.Fail(message)` explicitly when returning a string-based failure.*

#### Operations

- **`Deconstruct`**: Allows destructuring a Result into tuple patterns (e.g. `var (success, value, message) = result;`).

---

### 2. `Try<TSuccess, TFailure>`

A discriminated union type for expressing method outputs that can yield two completely different object structures in case of success vs. failure.

#### Examples
```csharp
using Maestria.Extensions;

public class UserCreated 
{
    public int Id { get; set; }
}

public class ErrorDetail 
{
    public int Code { get; set; }
    public string Error { get; set; }
}

public Try<UserCreated, ErrorDetail> RegisterUser(string username)
{
    if (string.IsNullOrWhiteSpace(username))
    {
        return new ErrorDetail { Code = 400, Error = "Username cannot be empty" }; // Implicit cast to Failure
    }
    
    return new UserCreated { Id = 42 }; // Implicit cast to Success
}

// Consumption
var signupResult = RegisterUser("antigravity");
if (signupResult) // Casts to boolean (Success check)
{
    Console.WriteLine($"Success: Created user ID {signupResult.Value.Id}");
}
else
{
    Console.WriteLine($"Failed ({signupResult.Failure.Code}): {signupResult.Failure.Error}");
}
```

#### Implicit Conversions Support

- **From** `TSuccess`: Automatically maps to a `Value` instance and sets the `Success` property to `true`.
- **From** `TFailure`: Automatically maps to a `Failure` instance and sets the `Success` property to `false`.
- **To** `bool`: Returns the value of the `Success` property.
- **To** `TSuccess`: Returns the value of the `Value` property if the result is a success.
- **To** `TFailure`: Returns the value of the `Failure` property if the result is a failure.
