namespace X10D.ReExposed.IFormatProviderExtensions;

/// <summary>
///     Extension methods for<see cref="IFormatProvider"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class FormatProviderExtensions
{
    /// <inheritdoc cref="string.Format(IFormatProvider,string,object)"/>
    public static string Format(this IFormatProvider formatProvider, string format, object value)
    {
        return string.Format(formatProvider, format, value);
    }

    /// <inheritdoc cref="string.Format(IFormatProvider,string,object,object)"/>
    public static string Format(this IFormatProvider formatProvider, string format, object value, object value2)
    {
        return string.Format(formatProvider, format, value, value2);
    }

    /// <inheritdoc cref="string.Format(IFormatProvider,string,object,object,object)"/>
    public static string Format(this IFormatProvider formatProvider, string format, object value, object value2, object value3)
    {
        return string.Format(formatProvider, format, value, value2, value3);
    }

    /// <inheritdoc cref="string.Format(IFormatProvider,string,object[])"/>
    public static string Format(this IFormatProvider formatProvider, string format, params object[] values)
    {
        return string.Format(formatProvider, format, values);
    }

    /// <inheritdoc cref="string.Format(string,object)"/>
    public static string Format(this string format, object value)
    {
        return string.Format(format, value);
    }

    /// <inheritdoc cref="string.Format(string,object,object)"/>
    public static string Format(this string format, object value, object value2)
    {
        return string.Format(format, value, value2);
    }

    /// <inheritdoc cref="string.Format(string,object,object,object)"/>
    public static string Format(this string format, object value, object value2, object value3)
    {
        return string.Format(format, value, value2, value3);
    }

    /// <inheritdoc cref="string.Format(string,object[])"/>
    public static string Format(this string format, params object[] values)
    {
        return string.Format(format, values);
    }
}