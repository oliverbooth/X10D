namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this ReadOnlySpan<char> chars, ReadOnlySpan<char> chars2)
    {
        return string.Concat(chars, chars2);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this Span<char> chars, ReadOnlySpan<char> chars2)
    {
        return string.Concat(chars, chars2);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this ReadOnlySpan<char> chars, ReadOnlySpan<char> chars2, ReadOnlySpan<char> chars3)
    {
        return string.Concat(chars, chars2, chars3);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this Span<char> chars, ReadOnlySpan<char> chars2, ReadOnlySpan<char> chars3)
    {
        return string.Concat(chars, chars2, chars3);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this ReadOnlySpan<char> chars, ReadOnlySpan<char> chars2, ReadOnlySpan<char> chars3, ReadOnlySpan<char> chars4)
    {
        return string.Concat(chars, chars2, chars3, chars4);
    }

    /// <inheritdoc cref="string.Concat(ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static string Concat(this Span<char> chars, ReadOnlySpan<char> chars2, ReadOnlySpan<char> chars3, ReadOnlySpan<char> chars4)
    {
        return string.Concat(chars, chars2, chars3, chars4);
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