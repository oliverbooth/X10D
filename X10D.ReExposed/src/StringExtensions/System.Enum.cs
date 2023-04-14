namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Enum.Parse{T}(string,bool)"/>
    public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = false)
        where TEnum : struct, Enum
    {
        return Enum.Parse<TEnum>(value, ignoreCase);
    }

    /// <inheritdoc cref="Enum.TryParse{T}(string,out T)"/>
    public static bool TryToEnum<TEnum>([NotNullWhen(true)] this string? value, out TEnum result)
        where TEnum : struct, Enum
    {
        return Enum.TryParse(value, out result);
    }

    /// <inheritdoc cref="Enum.TryParse{T}(string,bool,out T)"/>
    public static bool TryToEnum<TEnum>([NotNullWhen(true)] this string? value, bool ignoreCase, out TEnum result)
        where TEnum : struct, Enum
    {
        return Enum.TryParse(value, ignoreCase, out result);
    }
}