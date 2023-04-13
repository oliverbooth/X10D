namespace X10D.ReExposed.ObjectExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class ObjectExtensions
{
    /// <inheritdoc cref="string.Concat(object)"/>
    public static string Concat(this object value)
    {
        return string.Concat(value);
    }

    /// <inheritdoc cref="string.Concat(object,object)"/>
    public static string Concat(this object value, object value2)
    {
        return string.Concat(value, value2);
    }

    /// <inheritdoc cref="string.Concat(object,object,object)"/>
    public static string Concat(this object value, object value2, object value3)
    {
        return string.Concat(value, value2, value3);
    }

    /// <inheritdoc cref="string.Concat(object[])"/>
    public static string Concat(this object?[] values)
    {
        return string.Concat(values);
    }
}