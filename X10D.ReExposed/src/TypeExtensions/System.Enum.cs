namespace X10D.ReExposed.TypeExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class TypeExtensions
{
    /// <inheritdoc cref="Enum.Format(Type,object,string)"/>
    public static string Format(this Type enumType, object value, [StringSyntax(StringSyntaxAttribute.EnumFormat)] string format)
    {
        return Enum.Format(enumType, value, format);
    }

    /// <inheritdoc cref="Enum.GetNames(Type)"/>
    public static string[] GetNames(this Type enumType)
    {
        return Enum.GetNames(enumType);
    }

    /// <inheritdoc cref="Enum.GetUnderlyingType(Type)"/>
    public static Type GetUnderlyingType(this Type enumType)
    {
        return Enum.GetUnderlyingType(enumType);
    }

    /// <inheritdoc cref="Enum.GetValues(Type)"/>
    public static Array GetValues(this Type enumType)
    {
        return Enum.GetValues(enumType);
    }

    /// <inheritdoc cref="Enum.IsDefined(Type,object)"/>
    public static bool IsDefined(this Type enumType, object value)
    {
        return Enum.IsDefined(enumType, value);
    }

    /// <inheritdoc cref="Enum.Parse(Type,string,bool)"/>
    public static object Parse(this Type enumType, string value, bool ignoreCase = false)
    {
        return Enum.Parse(enumType, value, ignoreCase);
    }

    /// <inheritdoc cref="Enum.TryParse(Type,string,out object)"/>
    public static bool TryParse(this Type enumType, string? value, [NotNullWhen(true)] out object? result)
    {
        return Enum.TryParse(enumType, value, out result);
    }

    /// <inheritdoc cref="Enum.TryParse(Type,string,bool,out object)"/>
    public static bool TryParse(this Type enumType, string? value, bool ignoreCase, [NotNullWhen(true)] out object? result)
    {
        return Enum.TryParse(enumType, value, ignoreCase, out result);
    }
}