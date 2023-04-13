namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="bool.Parse(ReadOnlySpan{char})"/>
    public static bool ToBool(this ReadOnlySpan<char> value)
    {
        return bool.Parse(value);
    }

    /// <inheritdoc cref="bool.Parse(ReadOnlySpan{char})"/>
    public static bool ToBool(this Span<char> value)
    {
        return bool.Parse(value);
    }

    /// <inheritdoc cref="bool.TryParse(ReadOnlySpan{char},out bool)"/>
    public static bool TryToBool(this ReadOnlySpan<char> value, out bool result)
    {
        return bool.TryParse(value, out result);
    }

    /// <inheritdoc cref="bool.TryParse(ReadOnlySpan{char},out bool)"/>
    public static bool TryToBool(this Span<char> value, out bool result)
    {
        return bool.TryParse(value, out result);
    }
}