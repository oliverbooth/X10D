namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="char.ConvertToUtf32(char,char)"/>
    public static int ConvertToUtf32(this char highSurrogate, char lowSurrogate)
    {
        return char.ConvertToUtf32(highSurrogate, lowSurrogate);
    }

    /// <inheritdoc cref="char.GetNumericValue(char)"/>
    public static double GetNumericValue(this char value)
    {
        return char.GetNumericValue(value);
    }

    /// <inheritdoc cref="char.GetUnicodeCategory(char)"/>
    public static UnicodeCategory GetUnicodeCategory(this char value)
    {
        return char.GetUnicodeCategory(value);
    }

    /// <inheritdoc cref="char.IsControl(char)"/>
    public static bool IsControl(this char value)
    {
        return char.IsControl(value);
    }

    /// <inheritdoc cref="char.IsDigit(char)"/>
    public static bool IsDigit(this char value)
    {
        return char.IsDigit(value);
    }

    /// <inheritdoc cref="char.IsHighSurrogate(char)"/>
    public static bool IsHighSurrogate(this char value)
    {
        return char.IsHighSurrogate(value);
    }

    /// <inheritdoc cref="char.IsLetter(char)"/>
    public static bool IsLetter(this char value)
    {
        return char.IsLetter(value);
    }

    /// <inheritdoc cref="char.IsLetterOrDigit(char)"/>
    public static bool IsLetterOrDigit(this char value)
    {
        return char.IsLetterOrDigit(value);
    }

    /// <inheritdoc cref="char.IsLower(char)"/>
    public static bool IsLower(this char value)
    {
        return char.IsLower(value);
    }

    /// <inheritdoc cref="char.IsLowSurrogate(char)"/>
    public static bool IsLowSurrogate(this char value)
    {
        return char.IsLowSurrogate(value);
    }

    /// <inheritdoc cref="char.IsNumber(char)"/>
    public static bool IsNumber(this char value)
    {
        return char.IsNumber(value);
    }

    /// <inheritdoc cref="char.IsPunctuation(char)"/>
    public static bool IsPunctuation(this char value)
    {
        return char.IsPunctuation(value);
    }

    /// <inheritdoc cref="char.IsSeparator(char)"/>
    public static bool IsSeparator(this char value)
    {
        return char.IsSeparator(value);
    }

    /// <inheritdoc cref="char.IsSurrogate(char)"/>
    public static bool IsSurrogate(this char value)
    {
        return char.IsSurrogate(value);
    }

    /// <inheritdoc cref="char.IsSurrogatePair(char,char)"/>
    public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate)
    {
        return char.IsSurrogatePair(highSurrogate, lowSurrogate);
    }

    /// <inheritdoc cref="char.IsSymbol(char)"/>
    public static bool IsSymbol(this char value)
    {
        return char.IsSymbol(value);
    }

    /// <inheritdoc cref="char.IsUpper(char)"/>
    public static bool IsUpper(this char value)
    {
        return char.IsUpper(value);
    }

    /// <inheritdoc cref="char.IsWhiteSpace(char)"/>
    public static bool IsWhiteSpace(this char value)
    {
        return char.IsWhiteSpace(value);
    }

    /// <inheritdoc cref="char.ToLower(char,CultureInfo)"/>
    public static char ToLower(this char value, CultureInfo? culture = null)
    {
        return char.ToLower(value, culture ?? CultureInfo.CurrentCulture);
    }

    /// <inheritdoc cref="char.ToLowerInvariant(char)"/>
    public static char ToLowerInvariant(this char value)
    {
        return char.ToLowerInvariant(value);
    }

    /// <inheritdoc cref="char.ToUpper(char,CultureInfo)"/>
    public static char ToUpper(this char value, CultureInfo? culture = null)
    {
        return char.ToUpper(value, culture ?? CultureInfo.CurrentCulture);
    }

    /// <inheritdoc cref="char.ToUpperInvariant(char)"/>
    public static char ToUpperInvariant(this char value)
    {
        return char.ToUpperInvariant(value);
    }
}