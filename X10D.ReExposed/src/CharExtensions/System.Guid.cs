namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="Guid.Parse(ReadOnlySpan{char})"/>
    public static Guid ToGuid(this ReadOnlySpan<char> input)
    {
        return Guid.Parse(input);
    }

    /// <inheritdoc cref="Guid.Parse(ReadOnlySpan{char})"/>
    public static Guid ToGuid(this Span<char> input)
    {
        return Guid.Parse(input);
    }

    /// <inheritdoc cref="Guid.ParseExact(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static Guid ToGuidExact(this ReadOnlySpan<char> input,
                                   [StringSyntax(StringSyntaxAttribute.GuidFormat)] ReadOnlySpan<char> format)
    {
        return Guid.ParseExact(input, format);
    }

    /// <inheritdoc cref="Guid.ParseExact(ReadOnlySpan{char},ReadOnlySpan{char})"/>
    public static Guid ToGuidExact(this Span<char> input,
                                   [StringSyntax(StringSyntaxAttribute.GuidFormat)] ReadOnlySpan<char> format)
    {
        return Guid.ParseExact(input, format);
    }

    /// <inheritdoc cref="Guid.TryParse(ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuid(this ReadOnlySpan<char> input, out Guid result)
    {
        return Guid.TryParse(input, out result);
    }

    /// <inheritdoc cref="Guid.TryParse(ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuid(this Span<char> input, out Guid result)
    {
        return Guid.TryParse(input, out result);
    }

    /// <inheritdoc cref="Guid.TryParseExact(ReadOnlySpan{char},ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuidExact(this ReadOnlySpan<char> input,
                                      [StringSyntax(StringSyntaxAttribute.GuidFormat)] ReadOnlySpan<char> format,
                                      out Guid result)
    {
        return Guid.TryParseExact(input, format, out result);
    }

    /// <inheritdoc cref="Guid.TryParseExact(ReadOnlySpan{char},ReadOnlySpan{char},out Guid)"/>
    public static bool TryToGuidExact(this Span<char> input,
                                      [StringSyntax(StringSyntaxAttribute.GuidFormat)] ReadOnlySpan<char> format,
                                      out Guid result)
    {
        return Guid.TryParseExact(input, format, out result);
    }
}