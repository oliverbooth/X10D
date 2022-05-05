using System.Diagnostics.Contracts;

namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Array" />.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    ///     Returns a read-only wrapper for the array.
    /// </summary>
    /// <param name="array">The one-dimensional, zero-based array to wrap in a read-only wrapper.</param>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <returns>A <see cref="IReadOnlyCollection{T}" /> wrapper for the specified array.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
    [Pure]
    public static IReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(array);
#else
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
#endif

        return Array.AsReadOnly(array);
    }

    /// <summary>
    ///     Clears the contents of an array.
    /// </summary>
    /// <param name="array">The array to clear.</param>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
    public static void Clear<T>(this T?[] array)
    {
        array.Clear(..);
    }

    /// <summary>
    ///     Sets a range of elements in an array to the default value of each element type.
    /// </summary>
    /// <param name="array">The array whose elements need to be cleared.</param>
    /// <param name="range">A range defining the start index and number of elements to clear.</param>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
    public static void Clear<T>(this T?[] array, Range range)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(array);
#else
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
#endif

        int index = range.Start.Value;
        int end = range.End.Value;
        if (range.End.IsFromEnd)
        {
            end = array.Length - end;
        }

        array.Clear(index, end - index);
    }

    /// <summary>
    ///     Sets a range of elements in an array to the default value of each element type.
    /// </summary>
    /// <param name="array">The array whose elements need to be cleared.</param>
    /// <param name="index">The starting index of the range of elements to clear.</param>
    /// <param name="length">The number of elements to clear.</param>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="index" /> is less than the lower bound of <paramref name="array" />.</para>
    ///     -or-
    ///     <para><paramref name="length" /> is less zero.</para>
    ///     -or-
    ///     <para>The sum of <paramref name="index" /> and <paramref name="length"/> is greater than the size of array.</para>
    /// </exception>
    public static void Clear<T>(this T?[] array, int index, int length)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(array);
#else
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
#endif

        if (length == 0 || array.Length == 0)
        {
            return;
        }

        Array.Clear(array, index, length);
    }
}
