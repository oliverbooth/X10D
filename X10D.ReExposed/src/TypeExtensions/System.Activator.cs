namespace X10D.ReExposed.TypeExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class TypeExtensions
{
    /// <inheritdoc cref="Activator.CreateInstance(Type,BindingFlags,Binder,object[],CultureInfo,object[])"/>
    public static object? CreateInstance(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors
                                  | DynamicallyAccessedMemberTypes.PublicConstructors)]
        this Type type,
        BindingFlags bindingAttr,
        Binder? binder,
        object?[]? args,
        CultureInfo? culture,
        object?[]? activationAttributes)
    {
        return Activator.CreateInstance(type, bindingAttr, binder, args, culture, activationAttributes);
    }

    /// <inheritdoc cref="Activator.CreateInstance(Type,bool)"/>
    public static object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors
                                                                   | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
                                         this Type type,
                                         bool nonPublic)
    {
        return Activator.CreateInstance(type, nonPublic);
    }
}