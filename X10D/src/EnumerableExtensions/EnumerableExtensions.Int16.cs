namespace X10D;

public static partial class EnumerableExtensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="short" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="short" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    public static short Product(this IEnumerable<short> source)
    {
        return source.Aggregate((short)1, (current, value) => (short) (current * value));
    }
    /// <summary>
    ///     Computes the product of a sequence of <see cref="ushort" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="ushort" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    [CLSCompliant(false)]
    public static ushort Product(this IEnumerable<ushort> source)
    {
        return source.Aggregate((ushort)1, (current, value) => (ushort) (current * value));
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
}
