namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="decimal" />.
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="decimal" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="decimal" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static decimal Product(this IEnumerable<decimal> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.Aggregate(1m, (current, value) => (current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="decimal" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static decimal Product<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.Select(selector).Product();
    }
}
