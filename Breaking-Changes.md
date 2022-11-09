# Maestria.Extensions Breaking Changes

## 3.4.2

- String extensions methods returns string empty when input is null
    - New methods Truncate e TruncateStart
    - TrimStart
    - TrimEnd
    - AddToBeginningIfHasValue
    - AddToBeginningIfNotStartsWith
    - All anothred string extensions methods

## 3.4.1

- LimitLen and LimitLenReverse: Marked as obsolete. Use Truncate or TruncateStart.

## 3.4.1

- EmptyIf(string, string, bool): Always return a value, now return string empty when input value is null.
- GetAllMessages(Exception, ...): Marked as obsolete. Create similiar method in your project.



If input is null value, returns is empty string