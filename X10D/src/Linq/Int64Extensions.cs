namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="long" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="long" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    public static long Product(this IEnumerable<long> source)
    {
        return source.Aggregate(1L, (current, value) => current * value);
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="ulong" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="ulong" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    [CLSCompliant(false)]
    public static ulong Product(this IEnumerable<ulong> source)
    {
        return source.Aggregate(1UL, (current, value) => current * value);
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="long" /> values that are obtained by invoking a transform function on
    ///     each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    public static long Product<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="ulong" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    [CLSCompliant(false)]
    public static ulong Product<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> selector)
    {
        return source.Select(selector).Product();
    }
}
