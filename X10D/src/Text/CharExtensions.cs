﻿using System.Diagnostics.Contracts;
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsEmoji(this char value)
    {
        return value.ToString().IsEmoji();
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
}
