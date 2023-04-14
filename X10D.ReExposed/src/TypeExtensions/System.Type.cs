namespace X10D.ReExposed.TypeExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class TypeExtensions
{
    /// <inheritdoc cref="Type.GetTypeCode(Type)"/>
    public static TypeCode GetTypeCode(this Type? type)
    {
        return Type.GetTypeCode(type);
    }

    /// <inheritdoc cref="Type.MakeGenericSignatureType(Type,Type[])"/>
    public static Type MakeGenericSignatureType(this Type genericTypeDefinition, params Type[] typeArguments)
    {
        return Type.MakeGenericSignatureType(genericTypeDefinition, typeArguments);
    }
}