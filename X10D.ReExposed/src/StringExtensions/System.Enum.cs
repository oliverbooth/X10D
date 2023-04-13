namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Enum.Parse{T}(string,bool)"/>
    public static T ToEnum<T>(this string value, bool ignoreCase = false)
        where T : struct, Enum
    {
        return Enum.Parse<T>(value, ignoreCase);
    }

    /// <inheritdoc cref="Enum.TryParse{T}(string,bool,out T)"/>
    public static bool TryToEnum<T>(this string value, out T result, bool ignoreCase = false)
        where T : struct, Enum
    {
        return Enum.TryParse(value, ignoreCase, out result);
    }
}