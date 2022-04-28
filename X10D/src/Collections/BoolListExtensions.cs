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
    public static byte Pack8Bit(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 8)
        {
            throw new ArgumentException("Source cannot contain more than than 8 elements.", nameof(source));
        }

        unsafe
        {
            fixed (bool* p = source.ToArray())
            {
                return (byte)(*(ulong*)p * 72624976668147840L >> 56); // evil fucking bit hack
            }
        }
    }

    /// <summary>
    ///     Packs a collection of booleans into a <see cref="short" />.
    /// </summary>
    /// <param name="source">The collection of booleans to pack.</param>
    /// <returns>A 16-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 16 elements.</exception>
    public static short Pack16Bit(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 16)
        {
            throw new ArgumentException("Source cannot contain more than than 16 elements.", nameof(source));
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
    public static int Pack32Bit(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 32)
        {
            throw new ArgumentException("Source cannot contain more than than 32 elements.", nameof(source));
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
    public static long Pack64Bit(this IReadOnlyList<bool> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.Count > 64)
        {
            throw new ArgumentException("Source cannot contain more than than 64 elements.", nameof(source));
        }

        var result = 0L;

        for (var i = 0; i < source.Count; i++)
        {
            result |= source[i] ? 1L << i : 0;
        }

        return result;
    }
}
