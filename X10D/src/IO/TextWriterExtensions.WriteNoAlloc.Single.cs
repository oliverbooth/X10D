using System.Globalization;

namespace X10D.IO;

public static partial class TextWriterExtensions
{
    /// <summary>
    ///     Writes the text representation of a 4-byte floating-point value to the text stream, without allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 4-byte floating-point value to write.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteNoAlloc(this TextWriter writer, float value)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(writer);
#else
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }
#endif

        WriteNoAlloc(writer, value, "N0".AsSpan(), CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Writes the text representation of a 4-byte floating-point value to the text stream, without allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 4-byte floating-point value to write.</param>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteNoAlloc(this TextWriter writer, float value, ReadOnlySpan<char> format)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(writer);
#else
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }
#endif

        WriteNoAlloc(writer, value, format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Writes the text representation of a 4-byte floating-point value to the text stream, without allocating a string.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter" /> to write to.</param>
    /// <param name="value">The 4-byte floating-point value to write.</param>
    /// <param name="format">A standard or custom numeric format string.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <remarks>This method may still allocate if the integer is too large to fit in a stack-allocated buffer.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="TextWriter" /> is closed.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    public static void WriteNoAlloc(this TextWriter writer, float value, ReadOnlySpan<char> format,
        IFormatProvider? formatProvider)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(writer);
#else
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }
#endif

        Span<char> buffer = stackalloc char[100];
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
