namespace X10D.ReExposed.ObjectExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class ObjectExtensions
{
    /// <inheritdoc cref="Type.GetTypeArray(object[])"/>
    public static Type[] GetTypeArray(this object[] args)
    {
        return Type.GetTypeArray(args);
    }

    /// <inheritdoc cref="Type.GetTypeHandle(object)"/>
    public static RuntimeTypeHandle GetTypeHandle(this object o)
    {
        return Type.GetTypeHandle(o);
    }
}