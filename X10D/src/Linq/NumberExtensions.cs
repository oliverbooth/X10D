using System.Diagnostics.Contracts;
using System.Numerics;

namespace X10D.Linq;

/// <summary>
///     LINQ-inspired extension methods for <see cref="IEnumerable{T}" /> of <see cref="INumber{TSelf}" />.
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    ///     Computes the product of a sequence of <see cref="INumber{TSelf}" /> values.
    /// </summary>
    /// <param name="source">A sequence of <see cref="int" /> values that are used to calculate the product.</param>
    /// <typeparam name="TNumber">The type of the number for which to compute the product.</typeparam>
    /// <returns>The product the values in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static TNumber Product<TNumber>(this IEnumerable<TNumber> source)
        where TNumber : INumber<TNumber>
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Aggregate(TNumber.MultiplicativeIdentity, (current, value) => current * value);
    }

    /// <summary>
    ///     Computes the product of a sequence of <see cref="INumber{TSelf}" /> values that are obtained by invoking a transform
    ///     function on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a product.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TNumber">The type of the number for which to compute the product.</typeparam>
    /// <returns>The product of the projected values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static TNumber Product<TSource, TNumber>(this IEnumerable<TSource> source, Func<TSource, TNumber> selector)
        where TNumber : INumber<TNumber>
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Select(selector).Product();
    }

    /// <summary>
    ///     Returns an enumerable sequence of numbers ranging from the current value to a specified value.
    /// </summary>
    /// <param name="value">The starting value of the sequence.</param>
    /// <param name="end">The ending value of the sequence.</param>
    /// <typeparam name="TNumber">The type of the number for which to compute the product.</typeparam>
    /// <returns>
    ///     An enumerable collection of <typeparamref name="TNumber"/>, ranging from <paramref name="value" /> to
    ///     <paramref name="end" />.
    /// </returns>
    [Pure]
    public static IEnumerable<TNumber> RangeTo<TNumber>(this TNumber value, TNumber end)
        where TNumber : INumber<TNumber>
    {
        TNumber start = TNumber.Min(value, end);
        end = TNumber.Max(value, end);

        for (TNumber current = start; current < end; current++)
        {
            yield return current;
        }
    }
}
