namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="bool.Parse(string)"/>
    public static bool ToBool(this string value)
    {
        return bool.Parse(value);
    }

    /// <inheritdoc cref="bool.TryParse(string,out bool)"/>
    public static bool TryToBool([NotNullWhen(true)] this string? value, out bool result)
    {
        return bool.TryParse(value, out result);
    }
}