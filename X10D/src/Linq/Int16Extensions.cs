namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="long" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="short" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="short" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    public static short Product(this IEnumerable<short> source)
    {
        return source.Aggregate((short)1, (current, value) => (short)(current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="ushort" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="ushort" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    [CLSCompliant(false)]
    public static ushort Product(this IEnumerable<ushort> source)
    {
        return source.Aggregate((ushort)1, (current, value) => (ushort)(current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="short" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    public static short Product<TSource>(this IEnumerable<TSource> source, Func<TSource, short> selector)
    {
        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="ushort" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    [CLSCompliant(false)]
    public static ushort Product<TSource>(this IEnumerable<TSource> source, Func<TSource, ushort> selector)
    {
        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Returns an enumerable sequence of 16-bit integers ranging from the current value to a specified value.
    /// </summary>
    /// <param name="value">The starting value of the sequence.</param>
    /// <param name="end">The ending value of the sequence.</param>
    /// <returns>
    ///     An enumerable collection of 16-bit integers, ranging from <paramref name="value" /> to <paramref name="end" />.
    /// </returns>
    public static IEnumerable<short> RangeTo(this short value, short end)
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
    public static IEnumerable<int> RangeTo(this short value, int end)
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
    public static IEnumerable<long> RangeTo(this short value, long end)
    {
        long start = System.Math.Min(value, end);
        end = System.Math.Max(value, end);

        for (long current = start; current < end; current++)
        {
            yield return current;
        }
    }
}
