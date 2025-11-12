# CHANGELOG

## 3.4.2

### BREAKING CHANGES

- String extensions methods returns string empty when input is null
    - New methods Truncate e TruncateStart
    - TrimStart
    - TrimEnd
    - AddToBeginningIfHasValue
    - AddToBeginningIfNotStartsWith
    - All anothred string extensions methods

## 3.4.1

### BREAKING CHANGES

- LimitLen and LimitLenReverse: Marked as obsolete. Use Truncate or TruncateStart.

## 3.4.0

### BREAKING CHANGES

- EmptyIf(string, string, bool): Always return a value, now return string empty when input value is null.
- GetAllMessages(Exception, ...): Marked as obsolete. Create similiar method in your project.



If input is null value, returns is empty string