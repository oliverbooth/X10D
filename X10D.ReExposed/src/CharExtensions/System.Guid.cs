namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="Guid.Parse(ReadOnlySpan{char})"/>
    public static Guid ToGuid(this ReadOnlySpan<char> chars)
    {
        return Guid.Parse(chars);
    }

    /// <inheritdoc cref="Guid.Parse(ReadOnlySpan{char})"/>
    public static Guid ToGuid(this Span<char> chars)
    {
        return Guid.Parse(chars);
    }

    /// <inheritdoc cref="Guid.ParseExact(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static Guid ToGuidExact(this ReadOnlySpan<char> chars, ReadOnlySpan<char> format)
    {
        return Guid.ParseExact(chars, format);
    }

    /// <inheritdoc cref="Guid.ParseExact(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static Guid ToGuidExact(this Span<char> chars, ReadOnlySpan<char> format)
    {
        return Guid.ParseExact(chars, format);
    }

    /// <inheritdoc cref="Guid.TryParse(ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuid(this ReadOnlySpan<char> chars, out Guid result)
    {
        return Guid.TryParse(chars, out result);
    }

    /// <inheritdoc cref="Guid.TryParse(ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuid(this Span<char> chars, out Guid result)
    {
        return Guid.TryParse(chars, out result);
    }

    /// <inheritdoc cref="Guid.TryParseExact(ReadOnlySpan{char},ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuidExact(this ReadOnlySpan<char> chars, ReadOnlySpan<char> format, out Guid result)
    {
        return Guid.TryParseExact(chars, format, out result);
    }

    /// <inheritdoc cref="Guid.TryParseExact(ReadOnlySpan{char},ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuidExact(this Span<char> chars, ReadOnlySpan<char> format, out Guid result)
    {
        return Guid.TryParseExact(chars, format, out result);
    }
}