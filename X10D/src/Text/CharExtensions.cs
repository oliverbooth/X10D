using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="char" />.
/// </summary>
public static class CharExtensions
{
    /// <summary>
    ///     Returns a value indicating whether this character constitutes an emoji.
    /// </summary>
    /// <param name="value">The character to check.</param>
    /// <returns><see langword="true" /> if this character is an emoji; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsEmoji(this char value)
    {
#if NET7_0_OR_GREATER
        Span<char> chars = stackalloc char[1];
        chars[0] = value;
        return EmojiRegex.Value.IsMatch(chars);
#else
        return EmojiRegex.Value.IsMatch(value.ToString());
#endif
    }

    /// <summary>
    ///     Returns a string composed of the current character repeated a specified number of times.
    /// </summary>
    /// <param name="value">The character to repeat.</param>
    /// <param name="count">The number of times to repeat.</param>
    /// <returns>
    ///     A <see cref="string" /> composed of <paramref name="value" /> repeated <paramref name="count" /> times.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static string Repeat(this char value, int count)
    {
        return count switch
        {
            < 0 => throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0),
            0 => string.Empty,
            1 => value.ToString(),
            _ => new string(value, count)
        };
    }

    /// <summary>
    ///     Writes a character to a span of characters, repeated a specified number of times.
    /// </summary>
    /// <param name="value">The character to repeat.</param>
    /// <param name="count">The number of times to repeat.</param>
    /// <param name="destination">The span of characters into which the repeated characters will be written.</param>
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static void Repeat(this char value, int count, Span<char> destination)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0);
        }

        if (count == 0)
        {
            return;
        }

        if (destination.Length < count)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

        for (var i = 0; i < count; i++)
        {
            destination[i] = value;
        }
    }
}
