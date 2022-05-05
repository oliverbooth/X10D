namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="float" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="float" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static float Product(this IEnumerable<float> source)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.Aggregate(1f, (current, value) => (current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="float" /> values that are obtained by invoking a transform function
    ///     on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static float Product<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
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
}
