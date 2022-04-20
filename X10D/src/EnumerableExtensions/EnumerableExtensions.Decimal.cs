﻿namespace X10D;

public static partial class EnumerableExtensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="decimal" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="decimal" /> values that are used to calculate the product.</param>
    /// <returns>The product the values in the sequence.</returns>
    public static decimal Product(this IEnumerable<decimal> source)
    {
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
    public static decimal Product<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
    {
        return source.Select(selector).Product();
    }
}
