namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="string.Compare(string,int,string,int,int,bool)"/>
    public static int Compare(this string? value, int valueIndex, string? value2, int value2Index, int length, bool ignoreCase = false)
    {
        return string.Compare(value, valueIndex, value2, value2Index, length, ignoreCase);
    }

    /// <inheritdoc cref="string.Compare(string,int,string,int,int,CultureInfo,CompareOptions)"/>
    public static int Compare(this string? value,
                              int valueIndex,
                              string? value2,
                              int value2Index,
                              int length,
                              CultureInfo? culture,
                              CompareOptions options = CompareOptions.None)
    {
        return string.Compare(value, valueIndex, value2, value2Index, length, culture, options);
    }

    /// <inheritdoc cref="string.Compare(string,string,StringComparison)"/>
    public static int Compare(this string? value, string? value2, StringComparison comparisonType = StringComparison.CurrentCulture)
    {
        return string.Compare(value, value2, comparisonType);
    }

    /// <inheritdoc cref="string.Compare(string,string,CultureInfo,CompareOptions)"/>
    public static int Compare(this string? value, string? value2, CultureInfo? culture = null, CompareOptions options = CompareOptions.None)
    {
        return string.Compare(value, value2, culture ?? CultureInfo.CurrentCulture, options);
    }

    /// <inheritdoc cref="string.CompareOrdinal(string,int,string,int,int)"/>
    public static int CompareOrdinal(this string value, int valueIndex, string value2, int valueIndex2, int length)
    {
        return string.CompareOrdinal(value, valueIndex, value2, valueIndex2, length);
    }

    /// <inheritdoc cref="string.CompareOrdinal(string,string)"/>
    public static int CompareOrdinal(this string value, string value2)
    {
        return string.CompareOrdinal(value, value2);
    }

    /// <inheritdoc cref="string.Concat(string[])"/>
    public static string Concat(this string?[] values)
    {
        return string.Concat(values);
    }

    /// <inheritdoc cref="string.Concat(string,string)"/>
    public static string Concat(this string value, string value2)
    {
        return string.Concat(value, value2);
    }

    /// <inheritdoc cref="string.Concat(string,string,string)"/>
    public static string Concat(this string value, string value2, string value3)
    {
        return string.Concat(value, value2, value3);
    }

    /// <inheritdoc cref="string.Concat(string,string,string,string)"/>
    public static string Concat(this string value, string value2, string value3, string value4)
    {
        return string.Concat(value, value2, value3, value4);
    }

    /// <inheritdoc cref="string.Intern(string)"/>
    public static string Intern(this string value)
    {
        return string.Intern(value);
    }

    /// <inheritdoc cref="string.IsInterned(string)"/>
    public static string? IsInterned(this string value)
    {
        return string.IsInterned(value);
    }

    /// <inheritdoc cref="string.IsNullOrEmpty(string)"/>
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <inheritdoc cref="string.IsNullOrWhiteSpace(string)"/>
    public static bool IsNullOrWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <inheritdoc cref="string.Join{T}(string,IEnumerable{T})"/>
    public static string Join<T>(this string separator, IEnumerable<T> values)
    {
        return string.Join(separator, values);
    }

    /// <inheritdoc cref="string.Join(string,IEnumerable{string})"/>
    public static string Join(this string separator, IEnumerable<string?> strings)
    {
        return string.Join(separator, strings);
    }

    /// <inheritdoc cref="string.Join(string,object[])"/>
    public static string Join(this string separator, params object?[] objects)
    {
        return string.Join(separator, objects);
    }

    /// <inheritdoc cref="string.Join(string,string[])"/>
    public static string Join(this string separator, params string?[] strings)
    {
        return string.Join(separator, strings);
    }

    /// <inheritdoc cref="string.Join(string,string[],int,int)"/>
    public static string Join(this string separator, string?[] strings, int startIndex, int count)
    {
        return string.Join(separator, strings, startIndex, count);
    }
}