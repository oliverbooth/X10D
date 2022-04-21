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
    public static int Product(this IEnumerable<int> source)
    {
        return source.Aggregate(1, (current, value) => current * value);
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="uint" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="uint" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    [CLSCompliant(false)]
    public static uint Product(this IEnumerable<uint> source)
    {
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
    public static int Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
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
    [CLSCompliant(false)]
    public static uint Product<TSource>(this IEnumerable<TSource> source, Func<TSource, uint> selector)
    {
        return source.Select(selector).Product();
    }
}
