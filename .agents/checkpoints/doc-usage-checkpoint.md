# Checkpoint: Documentation Migration status

- Language: English
- Target Directory: docs/usage/

## Layout

Keep the directory structure organized and consistent with document method by markdown file.

```
- **docs/usage/<file-name>.md**: Methods documented separed by comma sorted by name (both, markdown and method names).
```

## Tracking

- [x] **docs/usage/comparable.md**: `Between`, `EmptyIf`, `EmptyIfNull`, `EmptyIfNullOrWhiteSpace`, `HasValue`, `If`, `IfEmpty`, `IfGreater`, `IfGreaterOrEqual`, `IfLess`, `IfLessOrEqual`, `IfNotEqual`, `IfNull`, `IfNullOrEmpty`, `IfNullOrWhiteSpace`, `In`, `IsNotNull`, `IsNull`, `IsNullOrEmpty`, `IsNullOrWhiteSpace`, `LimitToMax`, `LimitToMin`, `NullIf`, `NullIfBetween`, `NullIfEmpty`, `NullIfIn`, `NullIfWhiteSpace`
- [x] **docs/usage/datatypes.md**: `Result`, `SimpleResult`, `Try`
- [x] **docs/usage/enum.md**: `GetDescription`, `GetDisplayName`, `GetValues`
- [x] **docs/usage/enumerable.md**: `HasItems`, `Iterate`, `Join`, `TryGetValue`, `WithIndex`
- [x] **docs/usage/exception.md**: `GetAllMessages`, `GetMostInner`
- [x] **docs/usage/number.md**: `Round`, `RoundUp`, `Truncate`
- [x] **docs/usage/other.md**: `OutVar`
- [x] **docs/usage/string.md**: `AddToBeginningIfHasValue`, `AddToBeginningIfNotStartsWith`, `AddToEndIfHasValue`, `AddToEndIfNotEndsWith`, `EscapeXml`, `EqualsIgnoreCase`, `FromBase64`, `OnlyLettersOrNumbersOrUnderscoresOrHyphens`, `OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces`, `OnlyNumbers`, `RemoveAccents`, `SaveAs`, `SaveAsAsync`, `SubstringAfterFirstOccurrence`, `SubstringAfterLastOccurrence`, `SubstringAtOccurrenceIndex`, `SubstringBeforeFirstOccurrence`, `SubstringBeforeLastOccurrence`, `SubstringSafe`, `ToBase64`, `ToHash`, `ToHashMd5`, `ToHashSha1`, `ToHashSha256`, `ToHashSha384`, `ToHashSha512`, `ToHashSha3_256`, `ToHashSha3_384`, `ToHashSha3_512`, `ToKebabCase`, `ToSnakeCase`, `TrimEnd`, `TrimStart`, `Truncate`, `TruncateStart`, `UrlDecode`, `UrlEncode`

