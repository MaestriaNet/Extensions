# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**Maestria.Extensions** is a C# NuGet library providing extension methods to increase productivity and improve source code writing. The library is published to NuGet.org (stable) and MyGet (preview).

- Target frameworks: .NET 10.0, 9.0, 8.0, 6.0, 5.0, and .NET Standard 2.0
- Language: C# 10
- All extension methods are designed to be safe by default

## Build and Test Commands

```bash
# Build the solution
dotnet build --configuration Release

# Run all tests
dotnet test --configuration Release

# Pack NuGet package (version from src/Version.props)
dotnet pack src/Extensions.csproj --configuration Release

# Pack with custom version
dotnet pack src/Extensions.csproj --configuration Release -p:VersionPrefix="3.7.2" -p:VersionSuffix="preview.1"
```

## Project Structure

```
src/
├── Extensions.csproj          # Main project file
├── Version.props              # Version configuration (VersionPrefix only)
├── DataTypes/                 # Core data types (SimpleResult, Try<T>)
├── Settings/                  # GlobalSettings and configuration
├── Extensions/                # Extension methods organized by category:
│   ├── Comparable/           # If/NullIf/In/Between expressions
│   ├── Enum/                 # Enum extensions
│   ├── Enumerable/           # IEnumerable/Collection extensions
│   ├── Exception/            # Exception extensions
│   ├── Number/               # Numeric type extensions
│   ├── String/               # String extensions
│   └── Other/                # Misc extensions (Guid, Base64, Hash, etc.)
├── Attributes/               # Attribute definitions
└── Internals/                # Internal helper code

tests/
└── Extensions.Test.CSharp/   # NUnit test suite
```

## Architecture Patterns

### Extension Method Organization

- Each extension method is in its own file named after the method
- Files are organized into folders by the extended data type category
- The `this` parameter is named `value` (singular) or `values` (IEnumerable)
- Folder names omit the `I` prefix for interfaces (e.g., `Enumerable` not `IEnumerable`)

### Key Data Types

**SimpleResult / SimpleResult<TValue>**: Result type with Success/Message/Exception properties. Supports implicit conversions from bool, string, Exception, and TValue for concise error handling.

**Try<TSuccess, TFailure>**: Discriminated union for expressing success/failure with different types.

**GlobalSettings**: Configurable via `Extensions.GlobalSettings.Configure(cfg => ...)` for defaults like float/double tolerance.

### Extension Method Safety

- String extensions accept nullable input but return non-nullable output
- All methods designed to avoid exceptions under normal use
- Null-safe by design

## Version Management

Version is controlled in `src/Version.props`:
```xml
<VersionPrefix>3.7.2</VersionPrefix>
```

**CRITICAL**: When creating release branches, the VersionPrefix MUST match the branch name (e.g., `release/3.7.2` requires `<VersionPrefix>3.7.2</VersionPrefix>`). This is validated by CI as a safety check.

## CI/CD Workflow (Trunk-Based)

The project uses a trunk-based workflow:

1. **Development**: All feature branches merge to `main`
2. **Release**: Create `release/x.x.x` branch from `main`
   - Update `src/Version.props` to match branch name
   - Pushing triggers preview build → MyGet + auto PR to main
3. **Publish**: Merging release PR to `main` triggers:
   - Stable version published to NuGet.org
   - GitHub release and tag created
   - Build uses the release branch commit, not main

**Workflow files**:
- `.github/workflows/validate-pr.yml` - PR validation (build + test)
- `.github/workflows/publish-versions.yml` - Package publishing

## Contributing Guidelines

When adding new extension methods:

1. Create a file named after the extension method
2. Place in appropriate `src/Extensions/<category>` folder:
   - Comparison expressions (If, NullIf, In, Between) → `Comparable/`
   - Numeric extensions → `Number/`
   - String extensions → `String/`
3. Name the `this` parameter as `value` or `values`
4. String extensions: nullable input, non-nullable output
5. Add to `src/Settings/MaestriaExtensionSettings` if global configuration is needed

**DO NOT** modify version in `src/Version.props` in feature PRs - only in release branches.

## Development Notes

- Solution file: `Maestria.Extensions.slnx` (new .slnx format)
- Uses JetBrains.Annotations and System.ComponentModel.Annotations
- Documentation XML generated for NuGet package
- NoWarn CS1591 (missing XML doc warnings suppressed)
