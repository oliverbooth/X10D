using System.Diagnostics.Contracts;

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="IReadOnlyList{T}" /> of <see cref="bool" />.
/// </summary>
public static class BoolListExtensions
{
    /// <summary>
    ///     Packs a collection of booleans into a <see cref="byte" />.
    /// </summary>
    /// <param name="source">The collection of booleans to pack.</param>
    /// <returns>An 8-bit unsigned integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 8 elements.</exception>
    /// <author>Alpha Anar</author>
    [Pure]
    public static byte PackByte(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 8)
        {
            throw new ArgumentException(ExceptionMessages.SourceSpanIsTooLarge, nameof(source));
        }

        byte result = 0;

        for (var i = 0; i < source.Count; i++)
        {
            result |= (byte)(source[i] ? 1 << i : 0);
        }

        return result;
    }

    /// <summary>
    ///     Packs a collection of booleans into a <see cref="short" />.
    /// </summary>
    /// <param name="source">The collection of booleans to pack.</param>
    /// <returns>A 16-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 16 elements.</exception>
    [Pure]
    public static short PackInt16(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 16)
        {
            throw new ArgumentException(ExceptionMessages.SourceSpanIsTooLarge, nameof(source));
        }

        short result = 0;

        for (var i = 0; i < source.Count; i++)
        {
            result |= (short)(source[i] ? 1 << i : 0);
        }

        return result;
    }

    /// <summary>
    ///     Packs a collection of booleans into a <see cref="int" />.
    /// </summary>
    /// <param name="source">The collection of booleans to pack.</param>
    /// <returns>A 32-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 32 elements.</exception>
    [Pure]
    public static int PackInt32(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 32)
        {
            throw new ArgumentException(ExceptionMessages.SourceSpanIsTooLarge, nameof(source));
        }

        var result = 0;

        for (var i = 0; i < source.Count; i++)
        {
            result |= source[i] ? 1 << i : 0;
        }

        return result;
    }

    /// <summary>
    ///     Packs a collection of booleans into a <see cref="long" />.
    /// </summary>
    /// <param name="source">The collection of booleans to pack.</param>
    /// <returns>A 64-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 64 elements.</exception>
    [Pure]
    public static long PackInt64(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 64)
        {
            throw new ArgumentException(ExceptionMessages.SourceSpanIsTooLarge, nameof(source));
        }

        var result = 0L;

        for (var i = 0; i < source.Count; i++)
        {
            result |= source[i] ? 1L << i : 0;
        }

        return result;
    }
}
