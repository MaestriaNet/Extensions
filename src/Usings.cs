#if NET5_0_OR_GREATER
global using NotNullWhen = System.Diagnostics.CodeAnalysis.NotNullWhenAttribute;
#else
global using NotNullWhen = Maestria.Extensions.Attributes.NotNullWhenFakeAttribute;
#endif