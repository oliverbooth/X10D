using System.Text.RegularExpressions;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    ///     Filters a sequence of strings by regular expression.
    /// </summary>
    /// <param name="source">The sequence of strings to filter.</param>
    /// <param name="pattern">The regular expression pattern to use for matching.</param>
    /// <returns>The filtered sequence.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> or <paramref name="pattern" /> is <see langword="null" />.
    /// </exception>
    public static IEnumerable<string> Grep(this IEnumerable<string> source, string pattern)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (pattern is null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }

        return Grep(source, pattern, false);
    }

    /// <summary>
    ///     Filters a sequence of strings by regular expression, optionally allowing to ignore casing.
    /// </summary>
    /// <param name="source">The sequence of strings to filter.</param>
    /// <param name="pattern">The regular expression pattern to use for matching.</param>
    /// <param name="ignoreCase">
    ///     <see langword="true" /> to ignore casing when matching; otherwise, <see langword="false" />.
    /// </param>
    /// <returns>The filtered sequence.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> or <paramref name="pattern" /> is <see langword="null" />.
    /// </exception>
    public static IEnumerable<string> Grep(this IEnumerable<string> source, string pattern, bool ignoreCase)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (pattern is null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }

#if NET6_0_OR_GREATER
        if (source.TryGetNonEnumeratedCount(out int count) && count == 0)
        {
            yield break;
        }
#endif

        var options = RegexOptions.Compiled | (ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
        var regex = new Regex(pattern, options, Regex.InfiniteMatchTimeout);

        foreach (string item in source)
        {
            if (regex.IsMatch(item))
            {
                yield return item;
            }
        }
    }
}
