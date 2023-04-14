namespace X10D.ReExposed.TypeExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class TypeExtensions
{
    /// <inheritdoc cref="Array.CreateInstance(Type,int)"/>
    public static Array CreateArray(this Type elementType, int length)
    {
        return Array.CreateInstance(elementType, length);
    }

    /// <inheritdoc cref="Array.CreateInstance(Type,int,int)"/>
    public static Array CreateArray(this Type elementType, int length1, int length2)
    {
        return Array.CreateInstance(elementType, length1, length2);
    }

    /// <inheritdoc cref="Array.CreateInstance(Type,int,int,int)"/>
    public static Array CreateArray(this Type elementType, int length1, int length2, int length3)
    {
        return Array.CreateInstance(elementType, length1, length2, length3);
    }

    /// <inheritdoc cref="Array.CreateInstance(Type,int[],int[])"/>
    public static Array CreateArray(this Type elementType, int[] lengths, int[] lowerBounds)
    {
        return Array.CreateInstance(elementType, lengths, lowerBounds);
    }

    /// <inheritdoc cref="Array.CreateInstance(Type,int[])"/>
    public static Array CreateArray(this Type elementType, params int[] lengths)
    {
        return Array.CreateInstance(elementType, lengths);
    }

    /// <inheritdoc cref="Array.CreateInstance(Type,long[])"/>
    public static Array CreateArray(this Type elementType, params long[] lengths)
    {
        return Array.CreateInstance(elementType, lengths);
    }
}