using System.Globalization;

namespace X10D.IO;

public static partial class TextWriterExtensions
{
    /// <summary>
    ///     Writes the text representation of an 8-byte signed integer to the text stream, followed by a line terminator, without
    ///     allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 8-byte signed integer to write.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteLineNoAlloc(this TextWriter writer, long value)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        writer.WriteLineNoAlloc(value, "N0".AsSpan(), CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Writes the text representation of an 8-byte signed integer to the text stream, followed by a line terminator, without
    ///     allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 8-byte signed integer to write.</param>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteLineNoAlloc(this TextWriter writer, long value, ReadOnlySpan<char> format)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        writer.WriteLineNoAlloc(value, format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Writes the text representation of an 8-byte signed integer to the text stream, followed by a line terminator, without
    ///     allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 8-byte signed integer to write.</param>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteLineNoAlloc(this TextWriter writer,
        long value,
        ReadOnlySpan<char> format,
        IFormatProvider? formatProvider)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        writer.WriteNoAlloc(value, format, formatProvider);
        writer.WriteLine();
    }
}
