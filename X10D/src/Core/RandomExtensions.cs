using System.Globalization;
using System.Text;
using X10D.Math;

#pragma warning disable CA5394

namespace X10D.Core;

/// <summary>
///     Extension methods for <see cref="System.Random" />.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    ///     Returns a random value that defined in a specified enum.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <typeparam name="T">An enum type.</typeparam>
    /// <returns>
    ///     A <typeparamref name="T" /> value at index <c>n</c> where <c>n = </c><see cref="System.Random.Next(int)" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static T Next<T>(this Random random)
        where T : struct, Enum
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(random.Next(values.Length))!;
    }

    /// <summary>
    ///     Returns either <see langword="true" /> or <see langword="false" /> based on the next generation of the current
    ///     <see cref="System.Random" />.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the return value from <see cref="System.Random.NextDouble()" /> is greater than or
    ///     equal to 0.5
    ///     -or-
    ///     <see langword="false" /> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static bool NextBoolean(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return random.NextDouble() >= 0.5;
    }

    /// <summary>
    ///     Returns a non-negative random double-precision floating point number that is less than the specified maximum.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number returned. This value must be greater than or equal to 0.
    /// </param>
    /// <returns>
    ///     A random double-precision floating point number that is greater than or equal to 0, and less than
    ///     <paramref name="maxValue" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue" /> is less than 0.</exception>
    public static double NextDouble(this Random random, double maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (maxValue < 0)
        {
            throw new ArgumentOutOfRangeException(ExceptionMessages.MaxValueGreaterThanEqualTo0);
        }

        return random.NextDouble(0, maxValue);
    }

    /// <summary>
    ///     Returns a random double-precision floating point number that is within a specified range.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number returned. This value must be greater than or equal to
    ///     <paramref name="minValue" />.
    /// </param>
    /// <returns>
    ///     A random double-precision floating point number between <paramref name="minValue" /> and
    ///     <paramref name="maxValue" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="maxValue" /> is less than <paramref name="minValue" />.
    /// </exception>
    public static double NextDouble(this Random random, double minValue, double maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (maxValue < minValue)
        {
            throw new ArgumentException(ExceptionMessages.MaxValueGreaterThanEqualToMinValue);
        }

        return MathUtility.Lerp(minValue, maxValue, random.NextDouble());
    }

    /// <summary>
    ///     Returns a random element from <paramref name="source" /> using the <see cref="System.Random" /> instance.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="source">The source collection from which to draw.</param>
    /// <returns>A random element of type <typeparamref name="T" /> from <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="random" /> is is <see langword="null" />
    ///     -or-
    ///     <paramref name="source" /> is <see langword="null" />.
    /// </exception>
    /// <example>
    ///     <code lang="csharp">
    /// var list = new List&lt;int&gt; { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    /// var random = new Random();
    /// var number = random.NextFrom(list);
    /// </code>
    /// </example>
    public static T NextFrom<T>(this Random random, IEnumerable<T> source)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source is T[] array)
        {
            return array[random.Next(array.Length)];
        }

        if (source is not IReadOnlyList<T> list)
        {
            list = source.ToList();
        }

        return list[random.Next(list.Count)];
    }

    /// <summary>
    ///     Returns a random element from the specified span of elements using the current <see cref="System.Random" /> instance.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="source">The span of elements from which to draw.</param>
    /// <returns>A random element of type <typeparamref name="T" /> from <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="random" /> is is <see langword="null" />
    ///     -or-
    ///     <paramref name="source" /> is <see langword="null" />.
    /// </exception>
    /// <example>
    ///     <code lang="csharp">
    /// Span&lt;int&gt; span = stackalloc span[5];
    /// // populate the span ...
    ///
    /// var random = new Random();
    /// var number = random.NextFrom(span);
    /// </code>
    /// </example>
    public static T NextFrom<T>(this Random random, Span<T> source)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return source[random.Next(source.Length)];
    }

    /// <summary>
    ///     Returns a random element from the specified readonly span of elements using the current <see cref="System.Random" />
    ///     instance.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="source">The readonly span of elements from which to draw.</param>
    /// <returns>A random element of type <typeparamref name="T" /> from <paramref name="source" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="random" /> is is <see langword="null" />
    ///     -or-
    ///     <paramref name="source" /> is <see langword="null" />.
    /// </exception>
    /// <example>
    ///     <code lang="csharp">
    /// Span&lt;int&gt; span = stackalloc span[5];
    /// // populate the span ...
    ///
    /// var random = new Random();
    /// var number = random.NextFrom(span.AsReadOnly());
    /// </code>
    /// </example>
    public static T NextFrom<T>(this Random random, ReadOnlySpan<T> source)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return source[random.Next(source.Length)];
    }

    /// <summary>
    ///     Returns a non-negative random integer.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>
    ///     An 8-bit unsigned integer that is greater than or equal to 0, and less than <see cref="byte.MaxValue" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static byte NextByte(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return random.NextByte(byte.MaxValue);
    }

    /// <summary>
    ///     Returns a non-negative random integer.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number to be generated. <paramref name="maxValue" /> must be greater than or
    ///     equal to 0.
    /// </param>
    /// <returns>
    ///     An 8-bit unsigned integer that is greater than or equal to 0, and less than <paramref name="maxValue" />; that is, the
    ///     range of return values ordinarily includes 0 but not <paramref name="maxValue" />. However, if
    ///     <paramref name="maxValue" /> equals 0, <paramref name="maxValue" /> is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static byte NextByte(this Random random, byte maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return random.NextByte(0, maxValue);
    }

    /// <summary>
    ///     Returns a non-negative random integer.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="minValue">The inclusive lower bound of the random number to be generated.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number to be generated. <paramref name="maxValue" /> must be greater than or
    ///     equal to <paramref name="minValue" />.
    /// </param>
    /// <returns>
    ///     An 8-bit unsigned integer greater than or equal to <paramref name="minValue" /> and less than
    ///     <paramref name="maxValue" />; that is, the range of return values includes <paramref name="minValue" /> but not
    ///     <paramref name="maxValue" />. If <paramref name="minValue" /> equals <paramref name="maxValue" />,
    ///     <paramref name="minValue" /> is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="minValue" /> is greater than <paramref name="maxValue" />.
    /// </exception>
    public static byte NextByte(this Random random, byte minValue, byte maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return (byte)random.Next(minValue, maxValue);
    }

    /// <summary>
    ///     Returns a non-negative random integer.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>
    ///     An 16-bit signed integer that is greater than or equal to 0, and less than <see cref="short.MaxValue" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static short NextInt16(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return random.NextInt16(short.MaxValue);
    }

    /// <summary>
    ///     Returns a non-negative random integer that is less than the specified maximum.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number to be generated. <paramref name="maxValue" /> must be greater than or
    ///     equal to 0.
    /// </param>
    /// <returns>
    ///     A 16-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue" />; that is, the
    ///     range of return values ordinarily includes 0 but not <paramref name="maxValue" />. However, if
    ///     <paramref name="maxValue" /> equals 0, <paramref name="maxValue" /> is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue" /> is less than 0.</exception>
    public static short NextInt16(this Random random, short maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (maxValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        }

        return random.NextInt16(0, maxValue);
    }

    /// <summary>
    ///     Returns a random integer that is within a specified range.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="minValue">The inclusive lower bound of the random number to be generated.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number to be generated. <paramref name="maxValue" /> must be greater than or
    ///     equal to <paramref name="minValue" />.
    /// </param>
    /// <returns>
    ///     An 8-bit unsigned integer greater than or equal to <paramref name="minValue" /> and less than
    ///     <paramref name="maxValue" />; that is, the range of return values includes <paramref name="minValue" /> but not
    ///     <paramref name="maxValue" />. If <paramref name="minValue" /> equals <paramref name="maxValue" />,
    ///     <paramref name="minValue" /> is returned.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="minValue" /> is greater than <paramref name="maxValue" />.
    /// </exception>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static short NextInt16(this Random random, short minValue, short maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return (short)random.Next(minValue, maxValue);
    }

#if !NET6_0_OR_GREATER
    /// <summary>
    ///     Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A single-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static float NextSingle(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        return (float)random.NextDouble();
    }
#endif

    /// <summary>
    ///     Returns a non-negative random single-precision floating point number that is less than the specified maximum.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number returned. This value must be greater than or equal to 0.
    /// </param>
    /// <returns>
    ///     A random single-precision floating point number that is greater than or equal to 0, and less than
    ///     <paramref name="maxValue" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="maxValue" /> is less than 0.</exception>
    public static float NextSingle(this Random random, float maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (maxValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        }

        return random.NextSingle(0, maxValue);
    }

    /// <summary>
    ///     Returns a random single-precision floating point number that is within a specified range.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">
    ///     The exclusive upper bound of the random number returned. This value must be greater than or equal to
    ///     <paramref name="minValue" />.
    /// </param>
    /// <returns>
    ///     A random single-precision floating point number between <paramref name="minValue" /> and
    ///     <paramref name="maxValue" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="maxValue" /> is less than <paramref name="minValue" />.
    /// </exception>
    public static float NextSingle(this Random random, float minValue, float maxValue)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (maxValue < minValue)
        {
            throw new ArgumentException(ExceptionMessages.MaxValueGreaterThanEqualToMinValue);
        }

        return MathUtility.Lerp(minValue, maxValue, random.NextSingle());
    }

    /// <summary>
    ///     Returns a new string of a specified length which is composed of specified characters.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <param name="source">The source collection of characters to poll.</param>
    /// <param name="length">The length of the new string to generate.</param>
    /// <returns>
    ///     A <see cref="string" /> whose length is equal to that of <paramref name="length" />, composed of characters
    ///     specified by the characters in <paramref name="source" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="random" /> is <see langword="null" />.
    ///     -or-
    ///     <paramref name="source" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length" /> is less than 0.</exception>
    public static string NextString(this Random random, IReadOnlyList<char> source, int length)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), ExceptionMessages.LengthGreaterThanOrEqualTo0);
        }

        if (length == 0)
        {
            return string.Empty;
        }

        if (length == 1)
        {
            return source[random.Next(0, source.Count)].ToString(CultureInfo.InvariantCulture);
        }

        var builder = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
            builder.Append(source[random.Next(0, source.Count)]);
        }

        return builder.ToString();
    }

    internal static Random GetShared()
    {
        return Random.Shared;
    }
}
