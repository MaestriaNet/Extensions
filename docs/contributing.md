# CONTRIBUTING TO MAESTRIA EXTENSIONS

## Index

- [Development Guidelines](#development-guidelines)
- [CI/CD Workflow Overview](#cicd-workflow-overview)
- [Building and Testing Locally](#building-and-testing-locally)
- [Pull Request Process](#pull-request-process)
- [Preview Packages](#preview-packages)
- [Releasing a Stable Version - For Maintainers](#releasing-a-stable-version---for-maintainers)

---

## Development Guidelines

- Create file with extensions method name.
- `this` argument name must be `value` for single object or `values` to IEnumerable inheritances.
- Put new file into folder `/src/Extensions/<extended-data-type>`.
    - Expressions methods like `If`, `NullIf`, `Is`, `In`, `EmptyIf`, `Between`, must be located in `src/Extensions/Comparable` folder.
    - `Numbers` extensions methods must be located in `src/Extensions/Number`.
- The `I` prefix for interfaces must be omitted from the folder name.
- `src\\Settings\\MaestriaExtensionSettings`: File to configure global defaults behaviors.
- String extensions methods should use nullable input and non-nullable output.

## CI/CD Workflow Overview

The project follows a **trunk‑based development** model with `main` as the stable branch. All new work starts from `main` in a short‑lived feature branch, goes through a Pull Request (PR) validation pipeline, and is merged back into `main`. The CI system automatically creates **preview packages** for every merged PR and **stable releases** when a version tag is pushed.

### Main Pipelines

1. **Validate PR** – Runs on every PR opened or updated. It checks out the code, sets up .NET 10.0, builds the solution, and runs the test suite. The PR cannot be merged until this workflow succeeds.
2. **Publish Preview** – Triggered when a PR is merged into `main`. It determines a preview version (e.g., `2.1.2-preview.pr-61`), builds the package and publishes it to the MyGet feed for downstream testing.
3. **Publish Release** – Triggered by pushing a tag matching `vX.Y.Z`. It validates that the tag is on the latest `main` commit (or a `hotfix/*` branch), builds the stable package and publishes it to both MyGet and NuGet, then creates a GitHub Release.

## Building and Testing Locally

```bash
# Install the .NET SDK (version 10.0 is required)
# Build the solution in Release configuration
dotnet build --configuration Release

# Run the unit tests
dotnet test --configuration Release
```
These commands mirror the steps performed by the **Validate PR** workflow.

## Pull Request Process

- Fork the repository from `https://github.com/MaestriaNet/Extensions`.
- Create a feature branch from `main`.
- Implement your changes following the Development Guidelines.
- Ensure the solution builds and all tests pass locally.
- Open a Pull Request targeting the `main` branch.
- The CI will automatically run the **Validate PR** workflow. Once it passes, the PR can be reviewed and approved.
- After the PR is merged, the **Publish Preview** workflow runs automatically, providing a preview package for testing.
- When a stable release is needed, create and push a version tag as described above.

## Preview Packages

After merging a PR on `main`, the **Publish Preview** workflow generates a preview NuGet package and pushes it to the MyGet feed. This package can be consumed by downstream projects to test upcoming changes before an official release. No manual steps are required from the contributor – the CI takes care of publishing.

## Releasing a Stable Version - For Maintainers

To publish a stable version:
1. Create a Git tag following the pattern `vX.Y.Z` (e.g., `v1.2.3`). Tag creation can be done via the GitHub UI (recommended) or locally and then pushed.
2. Push the tag to the repository. This triggers the **Publish Release** workflow, which validates the tag, builds the package, publishes it to MyGet and NuGet, and creates a GitHub Release with the package attached.

[More information about the CI/CD workflow](./ci-workflow.md)

---

By following these guidelines, contributors ensure that their changes are validated, tested, and packaged consistently, maintaining the high quality of the Maestria Extensions library.

