namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Activator.CreateInstance(string,string,bool,BindingFlags,Binder,object[],CultureInfo,object[])"/>
    public static ObjectHandle? CreateInstance(this string assemblyName,
                                               string typeName,
                                               bool ignoreCase = false,
                                               BindingFlags bindingFlags = BindingFlags.Default,
                                               Binder? binder = null,
                                               object?[]? args = null,
                                               CultureInfo? culture = null,
                                               object?[]? activationAttributes = null)
    {
        return Activator.CreateInstance(assemblyName,
                                        typeName,
                                        ignoreCase,
                                        bindingFlags,
                                        binder,
                                        args,
                                        culture,
                                        activationAttributes);
    }

    /// <inheritdoc cref="Activator.CreateInstance(string,string,bool,BindingFlags,Binder,object[],CultureInfo,object[])"/>
    public static ObjectHandle? CreateInstanceFrom(this string assemblyFile,
                                                   string typeName,
                                                   bool ignoreCase = false,
                                                   BindingFlags bindingFlags = BindingFlags.Default,
                                                   Binder? binder = null,
                                                   object?[]? args = null,
                                                   CultureInfo? culture = null,
                                                   object?[]? activationAttributes = null)
    {
        return Activator.CreateInstanceFrom(assemblyFile,
                                            typeName,
                                            ignoreCase,
                                            bindingFlags,
                                            binder,
                                            args,
                                            culture,
                                            activationAttributes);
    }
}