# Maestria.Extensions Project Rules

This file defines global behaviors, coding styles, and project rules for AI coding assistants working in this repository.

## Project rules

- Performance is very important to the runtime code. But, try to maintain a legible code.
- This project it's .net with multi-target frameworks.
    - All changes must be supported by netstandard2.0 and .net6.0 to the highest stable version.
    - When a breaking change or framework version introduced a new way to build the feature: Make code with `#if..#else..#endif` customizations by target framework.
    - Can possible remove older target frameworks in future if it generate a lot of maintenance overhead.
    - It will be possible to remove older target frameworks in the future if they create too much maintenance overhead.

## General Contribution Rules

- Maintain documentation XML generated for NuGet package.
- Ensure new extension methods follow the existing folder layout in `src/Extensions/`.
- Ensure new extension methods has unity tests in folder `tests/`.
- Ensure new extension methods has documentation in folder `docs/usage`.
- If need create checkpoint file, put in folder `./.agents/checkpoints`.
- Ensure that the markdown file has an index section.
