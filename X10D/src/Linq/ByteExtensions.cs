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
    public static byte Product(this IEnumerable<byte> source)
    {
        return source.Aggregate((byte)1, (current, value) => (byte)(current * value));
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="sbyte" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="sbyte" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    [CLSCompliant(false)]
    public static sbyte Product(this IEnumerable<sbyte> source)
    {
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
    public static byte Product<TSource>(this IEnumerable<TSource> source, Func<TSource, byte> selector)
    {
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
    [CLSCompliant(false)]
    public static sbyte Product<TSource>(this IEnumerable<TSource> source, Func<TSource, sbyte> selector)
    {
        return source.Select(selector).Product();
    }
}
