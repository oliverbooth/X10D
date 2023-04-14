namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Type.GetType(string,bool,bool)"/>
    public static Type? GetType(this string typeName, bool throwOnError, bool ignoreCase = false)
    {
        return Type.GetType(typeName, throwOnError, ignoreCase);
    }

    /// <inheritdoc cref="Type.GetType(string,Func{AssemblyName,Assembly},Func{Assembly,string,bool,Type},bool,bool)"/>
    public static Type? GetType(this string typeName,
                                Func<AssemblyName, Assembly?>? assemblyResolver,
                                Func<Assembly?, string, bool, Type?>? typeResolver,
                                bool throwOnError = false,
                                bool ignoreCase = false)
    {
        return Type.GetType(typeName, assemblyResolver, typeResolver, throwOnError, ignoreCase);
    }

    /// <inheritdoc cref="Type.GetTypeFromProgID(string,string,bool)"/>
    [SupportedOSPlatform("windows")]
    public static Type? GetTypeFromProgID(this string progID, string? server, bool throwOnError = false)
    {
        return Type.GetTypeFromProgID(progID, server, throwOnError);
    }
}