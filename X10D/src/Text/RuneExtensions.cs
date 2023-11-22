#if NETCOREAPP3_0_OR_GREATER
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using X10D.CompilerServices;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="Rune" />.
/// </summary>
public static class RuneExtensions
{
    /// <summary>
    ///     Returns a value indicating whether this rune constitutes an emoji.
    /// </summary>
    /// <param name="value">The rune to check.</param>
    /// <returns><see langword="true" /> if this rune is an emoji; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsEmoji(this Rune value)
    {
        return value.ToString().IsEmoji();
    }

    /// <summary>
    ///     Returns a string composed of the current rune repeated a specified number of times.
    /// </summary>
    /// <param name="value">The rune to repeat.</param>
    /// <param name="count">The number of times to repeat.</param>
    /// <returns>
    ///     A <see cref="string" /> composed of <paramref name="value" /> repeated <paramref name="count" /> times.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static string Repeat(this Rune value, int count)
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

        int length = value.Utf8SequenceLength;

        // Helpful documentation: https://en.wikipedia.org/wiki/UTF-8
        // This probably gonna break interning but whatever.
        switch (length)
        {
            case 1:
                {
                    // Codepoint 0 to 0x00FF can be directly turn into char value without any conversion.
                    return new string((char)value.Value, count);
                }

            // Codepoint 0x0080 to 0x07FF takes 2 UTF-8 bytes, and it can be represented by 1 UTF-16 character (.NET runtime use
            // UTF-16 encoding).
            // Source: https://stackoverflow.com/questions/63905684
            case 2:
            // Codepoint 0x0800 to 0xFFFF takes 3 UTF-8 bytes, and can also be represented by 1 UTF-16 character.
            case 3:
                {
                    // Codepoint 0x0080 to 0x07FF convert into 1 .NET character string, directly use string constructor.
                    unsafe
                    {
                        Span<byte> bytes = stackalloc byte[length];
                        value.EncodeToUtf8(bytes);

                        char character;
                        Encoding.UTF8.GetChars(bytes, new Span<char>(&character, 1));

                        return new string(character, count);
                    }
                }

            // Codepoint 0x10000 and beyond will takes **only** 2 UTF-16 character.
            case 4:
                {
                    return string.Create(count * 2, value, (span, _) =>
                    {
                        unsafe
                        {
                            Span<byte> bytes = stackalloc byte[4];
                            value.EncodeToUtf8(bytes);

                            int characters; // 2 characters, fit inside 1 32-bit integer.
                            Encoding.UTF8.GetChars(bytes, new Span<char>(&characters, 2));

                            MemoryMarshal.Cast<char, int>(span).Fill(characters);
                        }
                    });
                }

            // dotcover disable
            //NOSONAR
            default:
                string exceptionFormat = ExceptionMessages.UnexpectedRuneUtf8SequenceLength;
                string message = string.Format(CultureInfo.CurrentCulture, exceptionFormat, length);
#if NET7_0_OR_GREATER
                throw new UnreachableException(message);
#else
            throw new InvalidOperationException(message);
#endif
            //NOSONAR
            // dotcover enable
        }
    }
}
#endif
