using System.Text;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="Rune" />.
/// </summary>
public static class RuneExtensions
{
    /// <summary>
    ///     Returns a string composed of the current rune repeated a specified number of times.
    /// </summary>
    /// <param name="value">The rune to repeat.</param>
    /// <param name="count">The number of times to repeat.</param>
    /// <returns>
    ///     A <see cref="string" /> composed of <paramref name="value" /> repeated <paramref name="count" /> times.
    /// </returns>
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

        int utf8SequenceLength = value.Utf8SequenceLength;
        Span<byte> utf8 = stackalloc byte[utf8SequenceLength];
        value.EncodeToUtf8(utf8);

        Span<byte> buffer = stackalloc byte[utf8.Length * count];
        for (var index = 0; index < count; index++)
        {
            utf8.CopyTo(buffer.Slice(index * utf8.Length, utf8.Length));
        }

        return Encoding.UTF8.GetString(buffer);
    }
}
