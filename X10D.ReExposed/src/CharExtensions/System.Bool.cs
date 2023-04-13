namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="bool.Parse(ReadOnlySpan{char})"/>
    public static bool ToBool(this ReadOnlySpan<char> chars)
    {
        return bool.Parse(chars);
    }

    /// <inheritdoc cref="bool.Parse(ReadOnlySpan{char})"/>
    public static bool ToBool(this Span<char> chars)
    {
        return bool.Parse(chars);
    }

    /// <inheritdoc cref="bool.TryParse(ReadOnlySpan{char},out bool)"/>
    public static bool TryToBool(this ReadOnlySpan<char> chars, out bool result)
    {
        return bool.TryParse(chars, out result);
    }

    /// <inheritdoc cref="bool.TryParse(ReadOnlySpan{char},out bool)"/>
    public static bool TryToBool(this Span<char> chars, out bool result)
    {
        return bool.TryParse(chars, out result);
    }
}