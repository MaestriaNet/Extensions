# Maestria.Extensions Breaking Changes

## 3.4.1

- LimitLen and LimitLenReverd: Marked as obsolete. Use Truncate or TruncateStart.

## 3.4.1

- EmptyIf(string, string, bool): Always return a value, now return string empty when input value is null.
- GetAllMessages(Exception, ...): Marked as obsolete. Create similiar method in your project.
