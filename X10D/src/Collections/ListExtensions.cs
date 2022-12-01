using System.Diagnostics;
using System.Diagnostics.Contracts;
using X10D.Core;

#pragma warning disable CA5394

namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="IList{T}" /> and <see cref="IReadOnlyList{T}" />.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    ///     Assigns the given value to each element of the list.
    /// </summary>
    /// <param name="source">The list to be filled.</param>
    /// <param name="value">The value to assign to each list element.</param>
    /// <typeparam name="T">The type of the elements in the list.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static void Fill<T>(this IList<T> source, T value)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        for (var i = 0; i < source.Count; i++)
        {
            source[i] = value;
        }
    }

    /// <summary>
    ///     Assigns the given value to the elements of the list which are within the range of <paramref name="startIndex" />
    ///     (inclusive) and the next <paramref name="count" /> number of indices.
    /// </summary>
    /// <param name="source">The list to be filled.</param>
    /// <param name="value">The value to assign to each list element.</param>
    /// <param name="startIndex">A 32-bit integer that represents the index in the list at which filling begins.</param>
    /// <param name="count">The number of elements to fill.</param>
    /// <typeparam name="T">The type of the elements in the list.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="startIndex" /> is less than 0.</para>
    ///     -or-
    ///     <para><paramref name="count" /> is less than 0.</para>
    ///     -or-
    ///     <para><paramref name="startIndex" /> + <paramref name="count" /> exceeds the bounds of the list.</para>
    /// </exception>
    public static void Fill<T>(this IList<T> source, T value, int startIndex, int count)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (startIndex + count > source.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (count == 0 || source.Count == 0)
        {
            return;
        }

        for (int index = startIndex; index < startIndex + count; index++)
        {
            source[index] = value;
        }
    }

    /// <summary>
    ///     Searches for the specified object and returns the zero-based index of the first occurrence within the entire
    ///     <see cref="IReadOnlyList{T}" />.
    /// </summary>
    /// <param name="source">The list to search</param>
    /// <param name="item">
    ///     The object to locate in the <see cref="IReadOnlyList{T}" />. The value can be <see langword="true" /> for reference
    ///     types.
    /// </param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     The zero-based index of the first occurrence of item within the entire <see cref="List{T}" />, if found; otherwise,
    ///     -1.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static int IndexOf<T>(this IReadOnlyList<T?> source, T? item)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.IndexOf(item, 0, source.Count);
    }

    /// <summary>
    ///     Searches for the specified object and returns the zero-based index of the first occurrence within the range of
    ///     elements in the <see cref="IReadOnlyList{T}" /> that extends from the specified index to the last element.
    /// </summary>
    /// <param name="source">The list to search</param>
    /// <param name="item">
    ///     The object to locate in the <see cref="IReadOnlyList{T}" />. The value can be <see langword="true" /> for reference
    ///     types.
    /// </param>
    /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     The zero-based index of the first occurrence of item within the range of elements in the
    ///     <see cref="IReadOnlyList{T}" /> that starts at index and contains count number of elements, if found; otherwise, -1.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex" /> is outside the range of valid indexes for the <see cref="IReadOnlyList{T}" />.
    /// </exception>
    public static int IndexOf<T>(this IReadOnlyList<T?> source, T? item, int startIndex)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        return source.IndexOf(item, startIndex, source.Count - startIndex);
    }

    /// <summary>
    ///     Searches for the specified object and returns the zero-based index of the first occurrence within the range of
    ///     elements in the <see cref="IReadOnlyList{T}" /> that starts at the specified index and contains the specified number
    ///     of elements.
    /// </summary>
    /// <param name="source">The list to search</param>
    /// <param name="item">
    ///     The object to locate in the <see cref="IReadOnlyList{T}" />. The value can be <see langword="true" /> for reference
    ///     types.
    /// </param>
    /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
    /// <param name="count">The number of elements in the section to search.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     The zero-based index of the first occurrence of item within the range of elements in the
    ///     <see cref="IReadOnlyList{T}" /> that starts at index and contains count number of elements, if found; otherwise, -1.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para>
    ///         <paramref name="startIndex" /> is outside the range of valid indexes for the <see cref="IReadOnlyList{T}" />.
    ///     </para>
    ///     -or-
    ///     <para><paramref name="count" /> is less than 0.</para>
    ///     -or-
    ///     <para>
    ///         <paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in the
    ///         <see cref="IReadOnlyList{T}" />.
    ///     </para>
    /// </exception>
    public static int IndexOf<T>(this IReadOnlyList<T?> source, T? item, int startIndex, int count)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        if (startIndex < 0 || startIndex > source.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), ExceptionMessages.IndexOutOfRange);
        }

        if (count < 0 || count > source.Count - startIndex)
        {
            throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeInRange);
        }

        int endIndex = startIndex + count;
        for (int index = startIndex; index < endIndex; index++)
        {
            if (EqualityComparer<T>.Default.Equals(source[index]!, item!))
            {
                return index;
            }
        }

        return -1;
    }

    /// <summary>
    ///     Returns a random element from the current list using a specified <see cref="System.Random" /> instance.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The source collection from which to draw.</param>
    /// <param name="random">
    ///     The <see cref="System.Random" /> instance to use for the shuffling. If <see langword="null" /> is specified, a shared
    ///     instance is used.
    /// </param>
    /// <returns>A random element of type <typeparamref name="T" /> from <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <example>
    ///     <code lang="csharp">
    /// var list = new List&lt;int&gt; { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    /// var number = list.Random();
    ///     </code>
    /// </example>
    [Pure]
    public static T Random<T>(this IReadOnlyList<T> source, Random? random = null)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        random ??= RandomExtensions.GetShared();
        return random.NextFrom(source);
    }

    /// <summary>
    ///     Removes a range of elements from the list.
    /// </summary>
    /// <param name="source">The list whose elements to remove.</param>
    /// <param name="range">The range of elements to remove.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="range" /> defines an invalid range.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="range" /> defines an end index whose value is greater than or equal to the count of elements in the
    ///     list.
    /// </exception>
    public static void RemoveRange<T>(this IList<T> source, Range range)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        int start = range.Start.IsFromEnd ? source.Count - range.Start.Value : range.Start.Value;
        int end = range.End.IsFromEnd ? source.Count - range.End.Value : range.End.Value;

        if (end < start)
        {
            throw new ArgumentException(ExceptionMessages.EndIndexLessThanStartIndex);
        }

        if (end >= source.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(range), ExceptionMessages.EndIndexGreaterThanCount);
        }

        for (int index = end; index >= start; index--)
        {
            source.RemoveAt(index);
        }
    }

    /// <summary>
    ///     Reorganizes the elements in a list by implementing a Fisher-Yates shuffle.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The <see cref="IList{T}" /> to shuffle.</param>
    /// <param name="random">
    ///     The <see cref="System.Random" /> instance to use for the shuffling. If <see langword="null" /> is specified, a shared
    ///     instance is used.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static void Shuffle<T>(this IList<T> source, Random? random = null)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        random ??= RandomExtensions.GetShared();

        int count = source.Count;
        while (count > 0)
        {
            int index = random.Next(count--);
            (source[count], source[index]) = (source[index], source[count]);
        }
    }

    /// <summary>
    ///     Swaps all elements in a list with the elements in another list.
    /// </summary>
    /// <param name="source">The first list.</param>
    /// <param name="other">The second list.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" /> and <paramref name="other" />.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="other" /> is <see langword="null" />.</para>
    /// </exception>
    public static void Swap<T>(this IList<T> source, IList<T> other)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(other);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }
#endif

        int min = System.Math.Min(source.Count, other.Count);
        for (var index = 0; index < min; index++)
        {
            (source[index], other[index]) = (other[index], source[index]);
        }

        if (other.Count < source.Count)
        {
            for (int index = min; index < source.Count;)
            {
                other.Add(source[index]);
                source.RemoveAt(index);
            }
        }
        else if (source.Count < other.Count)
        {
            for (int index = min; index < other.Count;)
            {
                source.Add(other[index]);
                other.RemoveAt(index);
            }
        }
    }
}
