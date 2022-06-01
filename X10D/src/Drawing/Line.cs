using System.Drawing;

namespace X10D.Drawing;

/// <summary>
///     Represents a line in 2D space that is composed of 32-bit signed integer X and Y coordinates.
/// </summary>
public readonly struct Line : IEquatable<Line>, IComparable<Line>, IComparable
{
    /// <summary>
    ///     The empty line. That is, a line whose start and end points are at (0, 0).
    /// </summary>
    public static readonly Line Empty = new();

    /// <summary>
    ///     The line whose start point is at (0, 0) and end point is at (1, 1).
    /// </summary>
    public static readonly Line One = new(Point.Empty, new Point(1, 1));

    /// <summary>
    ///     The line whose start point is at (0, 0) and end point is at (1, 0).
    /// </summary>
    public static readonly Line UnitX = new(Point.Empty, new Point(1, 0));

    /// <summary>
    ///     The line whose start point is at (0, 0) and end point is at (0, 1).
    /// </summary>
    public static readonly Line UnitY = new(Point.Empty, new Point(0, 1));

    /// <summary>
    ///     Initializes a new instance of the <see cref="Line" /> struct by taking the start and end points.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    public Line(Point start, Point end)
    {
        End = end;
        Start = start;
    }

    /// <summary>
    ///     Gets the end point of the line.
    /// </summary>
    /// <value>The end point.</value>
    public Point End { get; }

    /// <summary>
    ///     Gets the length of this line.
    /// </summary>
    /// <value>The length.</value>
    public float Length
    {
        get => MathF.Sqrt(LengthSquared);
    }

    /// <summary>
    ///     Gets the length of this line, squared.
    /// </summary>
    /// <value>The squared length.</value>
    public float LengthSquared
    {
        get => MathF.Pow(End.X - Start.X, 2.0f) + MathF.Pow(End.Y - Start.Y, 2.0f);
    }

    /// <summary>
    ///     Gets the start point of the line.
    /// </summary>
    /// <value>The start point.</value>
    public Point Start { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Line" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(in Line left, in Line right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Line" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(in Line left, in Line right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is less than that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is less than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <(in Line left, in Line right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is greater than that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is greater than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >(in Line left, in Line right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is less than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is less than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <=(in Line left, in Line right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the length of one line is greater than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Length" /> of <paramref name="left" /> is greater than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >=(in Line left, in Line right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    ///     Compares this instance to another object.
    /// </summary>
    /// <param name="obj">The object with with which to compare</param>
    /// <returns>
    ///     A signed number indicating the relative values of this instance and <paramref name="obj"/>.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>Less than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is less than that of <paramref name="obj" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="obj" />, or the <see cref="Length" /> of both this instance
    ///                 and <paramref name="obj" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is greater than that of <paramref name="obj" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>
    ///     Comparison internally measures the <see cref="LengthSquared" /> property to avoid calls to <see cref="MathF.Sqrt" />.
    /// <exception cref="ArgumentException"><paramref name="obj" /> is not an instance of <see cref="Line" />.</exception>
    /// </remarks>
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        if (obj is not Line other)
        {
            throw new ArgumentException($"Object must be of type {GetType()}");
        }

        return CompareTo(other);
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Line" />.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>
    ///     A signed number indicating the relative values of this instance and <paramref name="other" />.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>Less than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is less than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="other" />, or the <see cref="Length" /> of both this instance
    ///                 and <paramref name="other" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Length" /> of this instance is greater than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>
    ///     Comparison internally measures the <see cref="LengthSquared" /> property to avoid calls to <see cref="MathF.Sqrt" />.
    /// </remarks>
    public int CompareTo(Line other)
    {
        return LengthSquared.CompareTo(other.LengthSquared);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Line other && Equals(other);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Line other)
    {
        return End.Equals(other.End) && Start.Equals(other.Start);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(End, Start);
    }
}
