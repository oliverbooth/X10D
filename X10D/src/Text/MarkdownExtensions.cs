namespace X10D.Text;

/// <summary>
///     Markdown-related extension methods for <see cref="string" />.
/// </summary>
public static class MarkdownExtensions
{
    /// <summary>
    ///     Formats the specified text as bold, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with bold.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDBold(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return $"**{value}**";
    }

    /// <summary>
    ///     Formats the specified text as code, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with code.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDCode(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return $"`{value}`";
    }

    /// <summary>
    ///     Formats the specified text as a code block, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with code blocks.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDCodeBlock(this string value)
    {
        return MDCodeBlock(value, string.Empty);
    }

    /// <summary>
    ///     Formats the specified text as a code block, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with code blocks.</param>
    /// <param name="language">The language to use for syntax highlighting.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDCodeBlock(this string value, string language)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return $"```{language}{Environment.NewLine}{value}{Environment.NewLine}```";
    }

    /// <summary>
    ///     Formats the specified text as a heading, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with italics.</param>
    /// <param name="level">The level of the heading.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="level" /> is less than 1 or greater than 6.</exception>
    public static string MDHeading(this string value, int level)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (level is < 1 or > 6)
        {
            throw new ArgumentOutOfRangeException(nameof(level));
        }

        return $"{'#'.Repeat(level)} {value}";
    }

    /// <summary>
    ///     Formats the specified text as italics, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with italics.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    /// <remarks>
    ///     Markdown has two methods of italicizing text: <c>*</c> and <c>_</c>. This method uses asterisks by default. To
    ///     use underscores, use <see cref="MDItalic(string, bool)" /> and pass <see langword="true" /> as the second argument.
    /// </remarks>
    public static string MDItalic(this string value)
    {
        return MDItalic(value, false);
    }

    /// <summary>
    ///     Formats the specified text as italics, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with italics.</param>
    /// <param name="useUnderscores">Whether to use underscores instead of asterisks for italicizing.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDItalic(this string value, bool useUnderscores)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return useUnderscores ? $"_{value}_" : $"*{value}*";
    }

    /// <summary>
    ///     Formats the specified text as a link, using Markdown.
    /// </summary>
    /// <param name="label">The label to use for the link.</param>
    /// <param name="url">The URL to link to.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="url" /> is null.</exception>
    public static string MDLink(this string? label, string url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        return string.IsNullOrWhiteSpace(label) ? url : $"[{label}]({url})";
    }

    /// <summary>
    ///     Formats the specified text as a link, using Markdown.
    /// </summary>
    /// <param name="label">The label to use for the link.</param>
    /// <param name="url">The URL to link to.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="url" /> is null.</exception>
    public static string MDLink(this string? label, Uri url)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        return string.IsNullOrWhiteSpace(label) ? url.ToString() : $"[{label}]({url})";
    }

    /// <summary>
    ///     Formats the specified text as a link, using Markdown.
    /// </summary>
    /// <param name="url">The URL to link to.</param>
    /// <param name="label">The label to use for the link.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="url" /> is null.</exception>
    public static string MDLink(this Uri url, string? label)
    {
        if (url is null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        return string.IsNullOrWhiteSpace(label) ? url.ToString() : $"[{label}]({url})";
    }

    /// <summary>
    ///     Formats the specified text as striked out, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with strikeout.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDStrikeOut(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return $"~~{value}~~";
    }

    /// <summary>
    ///     Formats the specified text as underlined, using Markdown.
    /// </summary>
    /// <param name="value">The value to surround with underline.</param>
    /// <returns>The formatted text.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
    public static string MDUnderline(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return $"__{value}__";
    }
}
