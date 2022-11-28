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
    public static int CountSubstring(this Span<char> haystack, Span<char> needle)
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
    public static int CountSubstring(this Span<char> haystack, Span<char> needle, StringComparison comparison)
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
    ///     Splits a span of characters into substrings based on a specific delimiting character.
    /// </summary>
    /// <param name="value">The span of characters to split.</param>
    /// <param name="separator">A character that delimits the substring in this character span.</param>
    /// <param name="destination">
    ///     When this method returns, will be populated with the <see cref="Range" /> values pointing to where each substring
    ///     starts and ends in <paramref name="value" />.
    /// </param>
    /// <returns>
    ///     The number of substrings within <paramref name="value" />. This value is always correct regardless of the length of
    ///     <paramref name="destination" />.
    /// </returns>
    public static int Split(this Span<char> value, char separator, Span<Range> destination)
    {
        return ((ReadOnlySpan<char>)value).Split(separator, destination);
    }

    /// <summary>
    ///     Splits a span of characters into substrings based on a specific delimiting character.
    /// </summary>
    /// <param name="value">The span of characters to split.</param>
    /// <param name="separator">A character that delimits the substring in this character span.</param>
    /// <param name="destination">
    ///     When this method returns, will be populated with the <see cref="Range" /> values pointing to where each substring
    ///     starts and ends in <paramref name="value" />.
    /// </param>
    /// <returns>
    ///     The number of substrings within <paramref name="value" />. This value is always correct regardless of the length of
    ///     <paramref name="destination" />.
    /// </returns>
    public static int Split(this ReadOnlySpan<char> value, char separator, Span<Range> destination)
    {
        Span<char> buffer = stackalloc char[value.Length];
        var matches = 0;

        for (int index = 0, bufferLength = 0, startIndex = 0; index < value.Length; index++)
        {
            bool end = index == value.Length - 1;
            if (end)
            {
                bufferLength++;
            }

            if (value[index] == separator || end)
            {
                if (destination.Length > matches)
                {
                    // I was going to use new Range(startIndex, startIndex + bufferLength)
                    // but the .. operator is just so fucking cool so +1 for brevity over
                    // clarity!
                    // ... Ok I know this is probably a bad idea but come on, isn't it neat
                    // that you can use any integer expression as either operand to the .. operator?
                    // SOMEBODY AGREE WITH ME!
                    destination[matches] = startIndex..(startIndex + bufferLength);
                }

                startIndex = index + 1;
                bufferLength = 0;
                matches++;
            }
            else
            {
                buffer[bufferLength++] = value[index];
            }
        }

        return matches;
    }
}
