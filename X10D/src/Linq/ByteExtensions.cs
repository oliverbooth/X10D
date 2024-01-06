using System.Diagnostics.Contracts;

namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="byte" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="byte" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static byte Product(this IEnumerable<byte> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Aggregate((byte)1, (current, value) => (byte)(current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="sbyte" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="sbyte" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static sbyte Product(this IEnumerable<sbyte> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Aggregate((sbyte)1, (current, value) => (sbyte)(current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="byte" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static byte Product<TSource>(this IEnumerable<TSource> source, Func<TSource, byte> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="sbyte" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static sbyte Product<TSource>(this IEnumerable<TSource> source, Func<TSource, sbyte> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Returns an enumerable sequence of 8-bit integers ranging from the current value to a specified value.
    /// </summary>
    /// <param name="value">The starting value of the sequence.</param>
    /// <param name="end">The ending value of the sequence.</param>
    /// <returns>
    ///     An enumerable collection of 8-bit integers, ranging from <paramref name="value" /> to <paramref name="end" />.
    /// </returns>
    [Pure]
    public static IEnumerable<byte> RangeTo(this byte value, byte end)
    {
        byte start = System.Math.Min(value, end);
        end = System.Math.Max(value, end);

        for (byte current = start; current < end; current++)
        {
            yield return current;
        }
    }

    /// <summary>
    ///     Returns an enumerable sequence of 16-bit integers ranging from the current value to a specified value.
    /// </summary>
    /// <param name="value">The starting value of the sequence.</param>
    /// <param name="end">The ending value of the sequence.</param>
    /// <returns>
    ///     An enumerable collection of 16-bit integers, ranging from <paramref name="value" /> to <paramref name="end" />.
    /// </returns>
    [Pure]
    public static IEnumerable<short> RangeTo(this byte value, short end)
    {
        short start = System.Math.Min(value, end);
        end = System.Math.Max(value, end);

        for (short current = start; current < end; current++)
        {
            yield return current;
        }
    }

    /// <summary>
    ///     Returns an enumerable sequence of 32-bit integers ranging from the current value to a specified value.
    /// </summary>
    /// <param name="value">The starting value of the sequence.</param>
    /// <param name="end">The ending value of the sequence.</param>
    /// <returns>
    ///     An enumerable collection of 32-bit integers, ranging from <paramref name="value" /> to <paramref name="end" />.
    /// </returns>
    [Pure]
    public static IEnumerable<int> RangeTo(this byte value, int end)
    {
        int start = System.Math.Min(value, end);
        end = System.Math.Max(value, end);

        for (int current = start; current < end; current++)
        {
            yield return current;
        }
    }

    /// <summary>
    ///     Returns an enumerable sequence of 64-bit integers ranging from the current value to a specified value.
    /// </summary>
    /// <param name="value">The starting value of the sequence.</param>
    /// <param name="end">The ending value of the sequence.</param>
    /// <returns>
    ///     An enumerable collection of 64-bit integers, ranging from <paramref name="value" /> to <paramref name="end" />.
    /// </returns>
    [Pure]
    public static IEnumerable<long> RangeTo(this byte value, long end)
    {
        long start = System.Math.Min(value, end);
        end = System.Math.Max(value, end);

        for (long current = start; current < end; current++)
        {
            yield return current;
        }
    }
}
