---
name: documentation_migration
description: Guidelines and instructions for generating and migrating C# extension methods usage documentation for the Maestria.Extensions project.
---

# Maestria.Extensions Documentation Migration Skill

Use this skill when the user requests to create, update, or expand documentation for C# extension methods in this repository.

## Documentation Guidelines

- **Directory Location**: Save individual markdown files under `docs/usage/` using lowercase filenames (e.g., `number.md`, `string.md`).
- **Language**: All documentation, code comments, and explanations must be written in **English**.
- **Scope & Exclusivity**: Document every extension method from the source folder matching the documentation file name. Never group unrelated namespaces.
- **Example Coverage Requirement**: Every single method cited or listed in the documentation file **MUST** have a corresponding, functional, and clear code example showing it in action (both synchronous/asynchronous if applicable, and showing null-safe properties where relevant).
- **Null Safety Notice**: Always call out that extensions are null-safe and present examples showing input as `null` returning `null` safely without exception.
- **Progress Tracking**: Keep the `docs/readme-checkpoint.json` file updated with the migration status, utilizing the absolute files list.
