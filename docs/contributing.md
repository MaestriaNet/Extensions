# CONTRIBUTING TO MAESTRIA EXTENSIONS

## Development Guidelines

- Create file with extensions method name
- `this` argument name must be `value` for single object or `values` to IEnumerable inheritances
- Put new file into folder `/src/Extensions/<extended-data-type>`
    - Expressions methods like `If`, `NullIf`, `Is`, `In`, `EmptyIf`, `Between`, must be located in `src/Extensions/Comparable` folder
    - `Numbers` extensions methods must bet located in `src/Extensions/Number`
- The `I` prefix for interfaces must be omitted from the folder name.
- `src\Settings\MaestriaExtensionSettings`: File to configure global defaults behaviors
- String extensions methods should use nullable input and non-nullable output.

## Pull Request Process

- Create fork from main repo: https://github.com/MaestriaNet/Extensions.
- Don't modify version number in props file.
- Create PR to `main` branch.
- Wait for review and approval.
