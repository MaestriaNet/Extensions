# Result & Error Handling Types (`src/DataTypes`)

This module provides utility classes (`SimpleResult` and `Try`) to make method results and error reporting much more expressive and clean, avoiding excessive exceptions.

## Index

- [1. `SimpleResult` & `SimpleResult<T>`](#1-simpleresult--simpleresultt)
- [2. `Try<TSuccess, TFailure>`](#2-trytsuccess-tfailure)

---

### 1. `SimpleResult` & `SimpleResult<T>`

A lightweight model holding a `Success` status, an optional `Message`, and an optional `Exception`. It also includes implicit conversions to and from common primitives like `bool`, `string`, `Exception`, and the underlying generic value.

#### Examples
```csharp
using Maestria.Extensions;

// Implicit casting to return SimpleResult
public SimpleResult ProcessOrder(int orderId)
{
    if (orderId <= 0)
        return "Invalid Order ID"; // Implicit cast to Failure with message
        
    try 
    {
        // Processing...
        return true; // Implicit cast to Success
    }
    catch (Exception ex)
    {
        return ex; // Implicit cast to Failure with Exception details
    }
}

// Consuming results fluently
var result = ProcessOrder(10);
if (result) // Implicitly casts to bool (result.Success)
{
    Console.WriteLine("Processed!");
}
else
{
    Console.WriteLine($"Error: {result.Message}");
}
```

#### Implicit Conversions Support

- **From `bool`**: Automatically maps to `Success = value`.
- **From `string`**: Automatically sets `Success = false` and assigns the string to `Message` (representing a failure message).
- **From `Exception`**: Automatically sets `Success = false` and assigns the exception message and object.
- **From `TValue`** (in `SimpleResult<TValue>`): Sets `Success = true` and assigns the value to the `Value` property.
- **To** `bool`, `Exception`, or `TValue`: Gets data from respective property.

**SimpleResult\<TValue\>:**

There is a property `SuccessAndHasValue` for check if `Success == true and Value != null`, but implicit cast always is from/to `Success`.

> ***Caution on `SimpleResult<TValue>`:*** *Implicit comparison `if (mySimpleResultVariable)` is equivalent to `if (mySimpleResultVariable.Success)`.*  
*Use explicit `if (mySimpleResultVariable.SuccessAndHasValue)` when result value can be null with success is true*

---

### 2. `Try<TSuccess, TFailure>`

A discriminated union type for expressing method outputs that can yield two completely different object structures in case of success vs. failure.

#### Examples
```csharp
using Maestria.Extensions;

public class UserCreated { public int Id { get; set; } }
public class ErrorDetail { public int Code { get; set; } public string Error { get; set; } }

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
