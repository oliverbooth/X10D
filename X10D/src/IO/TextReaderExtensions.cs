namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="TextReader" />.
/// </summary>
public static class TextReaderExtensions
{
    /// <summary>
    ///     Enumerates the lines provided by the current text reader.
    /// </summary>
    /// <param name="reader">The reader whose lines to enumerate.</param>
    /// <returns>An enumerable collection of lines as read from <paramref name="reader" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <see langword="null" />.</exception>
    public static IEnumerable<string> EnumerateLines(this TextReader reader)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(reader);
#else
        if (reader is null)
        {
            throw new ArgumentNullException(nameof(reader));
        }
#endif

        while (reader.ReadLine() is { } line)
        {
            yield return line;
        }
    }

    /// <summary>
    ///     Asynchronously enumerates the lines provided by the current text reader.
    /// </summary>
    /// <param name="reader">The reader whose lines to enumerate.</param>
    /// <returns>An asynchronous enumerable collection of lines as read from <paramref name="reader" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <see langword="null" />.</exception>
    public static async IAsyncEnumerable<string> EnumerateLinesAsync(this TextReader reader)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(reader);
#else
        if (reader is null)
        {
            throw new ArgumentNullException(nameof(reader));
        }
#endif

        while (await reader.ReadLineAsync().ConfigureAwait(false) is { } line)
        {
            yield return line;
        }
    }
}
