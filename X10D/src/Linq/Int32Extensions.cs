using System.Diagnostics.Contracts;

namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="int" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="int" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static int Product(this IEnumerable<int> source)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.Aggregate(1, (current, value) => current * value);
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="uint" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="uint" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static uint Product(this IEnumerable<uint> source)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.Aggregate(1u, (current, value) => current * value);
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="int" /> values that are obtained by invoking a transform function on
    ///     each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static int Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="uint" /> values that are obtained by invoking a transform function on
    ///     each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static uint Product<TSource>(this IEnumerable<TSource> source, Func<TSource, uint> selector)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.Select(selector).Product();
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
    public static IEnumerable<int> RangeTo(this int value, int end)
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
    public static IEnumerable<long> RangeTo(this int value, long end)
    {
        long start = System.Math.Min(value, end);
        end = System.Math.Max(value, end);

        for (long current = start; current < end; current++)
        {
            yield return current;
        }
    }
}
