namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
    {
        return string.Concat(str0, str1);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this Span<char> str0, ReadOnlySpan<char> str1)
    {
        return string.Concat(str0, str1);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
    {
        return string.Concat(str0, str1, str2);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this Span<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
    {
        return string.Concat(str0, str1, str2);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
    {
        return string.Concat(str0, str1, str2, str3);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this Span<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
    {
        return string.Concat(str0, str1, str2, str3);
    }

    /// <inheritdoc cref="string.GetHashCode(ReadOnlySpan{char})"/>
    public static int GetHashCode(this ReadOnlySpan<char> value)
    {
        return string.GetHashCode(value);
    }

    /// <inheritdoc cref="string.GetHashCode(ReadOnlySpan{char})"/>
    public static int GetHashCode(this Span<char> value)
    {
        return string.GetHashCode(value);
    }

    /// <inheritdoc cref="string.GetHashCode(ReadOnlySpan{char},StringComparison)"/>
    public static int GetHashCode(this ReadOnlySpan<char> value, StringComparison comparisonType)
    {
        return string.GetHashCode(value, comparisonType);
    }

    /// <inheritdoc cref="string.GetHashCode(ReadOnlySpan{char},StringComparison)"/>
    public static int GetHashCode(this Span<char> value, StringComparison comparisonType)
    {
        return string.GetHashCode(value, comparisonType);
    }

    /// <inheritdoc cref="string.Join{T}(char,IEnumerable{T})"/>
    public static string Join<T>(this char separator, IEnumerable<T> values)
    {
        return string.Join(separator, values);
    }

    /// <inheritdoc cref="string.Join(char,object[])"/>
    public static string Join(this char separator, params object?[] values)
    {
        return string.Join(separator, values);
    }

    /// <inheritdoc cref="string.Join(char,string[])"/>
    public static string Join(this char separator, params string?[] strings)
    {
        return string.Join(separator, strings);
    }

    /// <inheritdoc cref="string.Join(char,string[],int,int)"/>
    public static string Join(this char separator, string?[] strings, int startIndex, int count)
    {
        return string.Join(separator, strings, startIndex, count);
    }
}