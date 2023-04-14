namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="string.Compare(string,int,string,int,int,bool)"/>
    public static int Compare(this string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase = false)
    {
        return string.Compare(strA, indexA, strB, indexB, length, ignoreCase);
    }

    /// <inheritdoc cref="string.Compare(string,int,string,int,int,CultureInfo,CompareOptions)"/>
    public static int Compare(this string? strA,
                              int indexA,
                              string? strB,
                              int indexB,
                              int length,
                              CultureInfo? culture,
                              CompareOptions options = CompareOptions.None)
    {
        return string.Compare(strA, indexA, strB, indexB, length, culture, options);
    }

    /// <inheritdoc cref="string.Compare(string,string,bool)"/>
    public static int Compare(this string? strA, string? strB, bool ignoreCase = false)
    {
        return string.Compare(strA, strB, ignoreCase);
    }

    /// <inheritdoc cref="string.Compare(string,string,StringComparison)"/>
    public static int Compare(this string? strA, string? strB, StringComparison comparisonType)
    {
        return string.Compare(strA, strB, comparisonType);
    }

    /// <inheritdoc cref="string.Compare(string,string,CultureInfo,CompareOptions)"/>
    public static int Compare(this string? strA, string? strB, CultureInfo? culture, CompareOptions options)
    {
        return string.Compare(strA, strB, culture, options);
    }

    /// <inheritdoc cref="string.CompareOrdinal(string,int,string,int,int)"/>
    public static int CompareOrdinal(this string strA, int indexA, string? strB, int indexB, int length)
    {
        return string.CompareOrdinal(strA, indexA, strB, indexB, length);
    }

    /// <inheritdoc cref="string.CompareOrdinal(string,string)"/>
    public static int CompareOrdinal(this string strA, string strB)
    {
        return string.CompareOrdinal(strA, strB);
    }

    /// <inheritdoc cref="string.Concat(string[])"/>
    public static string Concat(this string?[] values)
    {
        return string.Concat(values);
    }

    /// <inheritdoc cref="string.Concat(string,string)"/>
    public static string Concat(this string? str0, string? str1)
    {
        return string.Concat(str0, str1);
    }

    /// <inheritdoc cref="string.Concat(string,string,string)"/>
    public static string Concat(this string str0, string str1, string str2)
    {
        return string.Concat(str0, str1, str2);
    }

    /// <inheritdoc cref="string.Concat(string,string,string,string)"/>
    public static string Concat(this string str0, string str1, string str2, string str3)
    {
        return string.Concat(str0, str1, str2, str3);
    }

    /// <inheritdoc cref="string.Intern(string)"/>
    public static string Intern(this string str)
    {
        return string.Intern(str);
    }

    /// <inheritdoc cref="string.IsInterned(string)"/>
    public static string? IsInterned(this string str)
    {
        return string.IsInterned(str);
    }

    /// <inheritdoc cref="string.IsNullOrEmpty(string)"/>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <inheritdoc cref="string.IsNullOrWhiteSpace(string)"/>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <inheritdoc cref="string.Join{T}(string,IEnumerable{T})"/>
    public static string Join<T>(this string? separator, IEnumerable<T> values)
    {
        return string.Join(separator, values);
    }

    /// <inheritdoc cref="string.Join(string,IEnumerable{string})"/>
    public static string Join(this string? separator, IEnumerable<string?> strings)
    {
        return string.Join(separator, strings);
    }

    /// <inheritdoc cref="string.Join(string,object[])"/>
    public static string Join(this string? separator, params object?[] objects)
    {
        return string.Join(separator, objects);
    }

    /// <inheritdoc cref="string.Join(string,string[])"/>
    public static string Join(this string? separator, params string?[] strings)
    {
        return string.Join(separator, strings);
    }

    /// <inheritdoc cref="string.Join(string,string[],int,int)"/>
    public static string Join(this string? separator, string?[] strings, int startIndex, int count)
    {
        return string.Join(separator, strings, startIndex, count);
    }
}