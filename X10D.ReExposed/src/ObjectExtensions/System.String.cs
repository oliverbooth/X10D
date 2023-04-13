namespace X10D.ReExposed.ObjectExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class ObjectExtensions
{
    /// <inheritdoc cref="string.Concat(object)"/>
    public static string Concat(this object? arg0)
    {
        return string.Concat(arg0);
    }

    /// <inheritdoc cref="string.Concat(object,object)"/>
    public static string Concat(this object? arg0, object? arg1)
    {
        return string.Concat(arg0, arg1);
    }

    /// <inheritdoc cref="string.Concat(object,object,object)"/>
    public static string Concat(this object? arg0, object? arg1, object? arg2)
    {
        return string.Concat(arg0, arg1, arg2);
    }

    /// <inheritdoc cref="string.Concat(object[])"/>
    public static string Concat(this object?[] args)
    {
        return string.Concat(args);
    }
}