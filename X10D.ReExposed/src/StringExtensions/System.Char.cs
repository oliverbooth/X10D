namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="char.Parse(string)"/>
    public static char ToChar(this string s)
    {
        return char.Parse(s);
    }

    /// <inheritdoc cref="char.TryParse(string,out char)"/>
    public static bool TryToChar([NotNullWhen(true)] this string? s, out char result)
    {
        return char.TryParse(s, out result);
    }
}