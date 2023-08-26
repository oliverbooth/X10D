using System.Globalization;
using X10D.Math;

namespace X10D.IO;

public static partial class TextWriterExtensions
{
    /// <summary>
    ///     Writes the text representation of an 8-byte signed integer to the text stream, without allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 8-byte signed integer to write.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteNoAlloc(this TextWriter writer, long value)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        WriteNoAlloc(writer, value, "N0".AsSpan(), CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Writes the text representation of an 8-byte signed integer to the text stream, without allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 8-byte signed integer to write.</param>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteNoAlloc(this TextWriter writer, long value, ReadOnlySpan<char> format)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        WriteNoAlloc(writer, value, format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Writes the text representation of an 8-byte signed integer to the text stream, without allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 8-byte signed integer to write.</param>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteNoAlloc(this TextWriter writer,
        long value,
        ReadOnlySpan<char> format,
        IFormatProvider? formatProvider)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        int digitCount = value.CountDigits();
        Span<char> buffer = stackalloc char[System.Math.Max(value < 0 ? digitCount + 1 : digitCount, 100)];
        if (value.TryFormat(buffer, out int charsWritten, format, formatProvider))
        {
            Span<char> truncated = buffer[..charsWritten];
            for (var index = 0; index < truncated.Length; index++)
            {
                writer.Write(truncated[index]);
            }
        }
        else
        {
            writer.Write(value.ToString(format.ToString(), formatProvider));
        }
    }
}
