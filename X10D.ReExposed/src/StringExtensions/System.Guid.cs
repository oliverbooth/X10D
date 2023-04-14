namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Guid.Parse(string)"/>
    public static Guid ToGuid(this string input)
    {
        return Guid.Parse(input);
    }

    /// <inheritdoc cref="Guid.ParseExact(string,string)"/>
    public static Guid ToGuidExact(this string input, [StringSyntax(StringSyntaxAttribute.GuidFormat)] string format)
    {
        return Guid.ParseExact(input, format);
    }

    /// <inheritdoc cref="Guid.TryParse(string,out Guid)"/>
    public static bool TryToGuid([NotNullWhen(true)] this string? input, out Guid result)
    {
        return Guid.TryParse(input, out result);
    }

    /// <inheritdoc cref="Guid.TryParseExact(string,string,out Guid)"/>
    public static bool TryToGuidExact([NotNullWhen(true)] this string? input,
                                      [StringSyntax(StringSyntaxAttribute.GuidFormat)] string format,
                                      out Guid result)
    {
        return Guid.TryParseExact(input, format, out result);
    }
}