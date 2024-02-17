using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using X10D.CompilerServices;

namespace X10D.Text;

/// <summary>
///     Extension methods for <see cref="ReadOnlySpan{T}" /> and <see cref="Span{T}" /> of <see cref="char" />.
/// </summary>
public static class CharSpanExtensions
{
    /// <summary>
    ///     Counts the occurrences of a substring within the current character span.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character span to count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this Span<char> haystack, ReadOnlySpan<char> needle)
    {
        return CountSubstring(haystack, needle, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Counts the occurrences of a substring within the current character span, using a specified string comparison method.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character span to count.</param>
    /// <param name="comparison">The string comparison method used for determining substring count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this Span<char> haystack, ReadOnlySpan<char> needle, StringComparison comparison)
    {
        return CountSubstring((ReadOnlySpan<char>)haystack, needle, comparison);
    }

    /// <summary>
    ///     Counts the occurrences of a substring within the current character span.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character span to count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this ReadOnlySpan<char> haystack, ReadOnlySpan<char> needle)
    {
        return CountSubstring(haystack, needle, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Counts the occurrences of a substring within the current character span, using a specified string comparison method.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character span to count.</param>
    /// <param name="comparison">The string comparison method used for determining substring count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this ReadOnlySpan<char> haystack, ReadOnlySpan<char> needle, StringComparison comparison)
    {
        if (haystack.IsEmpty || needle.IsEmpty)
        {
            return 0;
        }

        int haystackLength = haystack.Length;
        int needleLength = needle.Length;
        var count = 0;

        for (var index = 0; index < haystackLength - needleLength - 1; index++)
        {
            if (haystack[index..(index + needleLength)].Equals(needle, comparison))
            {
                count++;
            }
        }

        return count;
    }

    /// <summary>
    ///     Repeats a span of characters a specified number of times.
    /// </summary>
    /// <param name="value">The string to repeat.</param>
    /// <param name="count">The repeat count.</param>
    /// <returns>A string containing <paramref name="value" /> repeated <paramref name="count" /> times.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count" /> is less than 0.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static string Repeat(this ReadOnlySpan<char> value, int count)
    {
        switch (count)
        {
            case < 0:
                throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0);

            case 0:
                return string.Empty;

            case 1:
                return value.ToString();
        }

        var builder = new StringBuilder(value.Length * count);

        for (var i = 0; i < count; i++)
        {
            builder.Append(value);
        }

        return builder.ToString();
    }

    /// <summary>
    ///     Repeats a span of character a specified number of times, writing the result to another span of characters.
    /// </summary>
    /// <param name="value">The span of characters to repeat.</param>
    /// <param name="count">The repeat count.</param>
    /// <param name="destination">The destination span to write to.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count" /> is less than 0.</exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="destination" /> is too short to contain the repeated string.
    /// </exception>
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static void Repeat(this ReadOnlySpan<char> value, int count, Span<char> destination)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0);
        }

        if (count == 0)
        {
            return;
        }

        if (destination.Length < value.Length * count)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

        for (var iteration = 0; iteration < count; iteration++)
        {
            Span<char> slice = destination.Slice(iteration * value.Length, value.Length);
            value.CopyTo(slice);
        }
    }
}
