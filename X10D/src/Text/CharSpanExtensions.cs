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
}
