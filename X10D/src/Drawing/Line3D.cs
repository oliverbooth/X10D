using System.Drawing;
using System.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a line in 3D space that is composed of 32-bit signed integer X, Y and Z coordinates.
/// </summary>
public readonly struct Line3D : IEquatable<Line3D>, IComparable<Line3D>, IComparable
{
    /// <summary>
    ///     The empty line. That is, a line whose start and end points are at (0, 0).
    /// </summary>
    public static readonly Line3D Empty = new();

    /// <summary>
    ///     The line whose start point is at (0, 0, 0) and end point is at (1, 1, 1).
    /// </summary>
    public static readonly Line3D One = new(Vector3.Zero, Vector3.One);

    /// <summary>
    ///     The line whose start point is at (0, 0, 0) and end point is at (1, 0, 0).
    /// </summary>
    public static readonly Line3D UnitX = new(Vector3.Zero, Vector3.UnitX);

    /// <summary>
    ///     The line whose start point is at (0, 0, 0) and end point is at (0, 1, 0).
    /// </summary>
    public static readonly Line3D UnitY = new(Vector3.Zero, Vector3.UnitY);

    /// <summary>
    ///     The line whose start point is at (0, 0, 0) and end point is at (0, 0, 1).
    /// </summary>
    public static readonly Line3D UnitZ = new(Vector3.Zero, Vector3.UnitZ);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Line3D" /> struct by taking the start and end points.
    /// </summary>
    /// <param name="start">The start point.</param>
    /// <param name="end">The end point.</param>
    public Line3D(in Vector3 start, in Vector3 end)
    {
        End = end;
        Start = start;
    }

    /// <summary>
    ///     Gets the end point of the line.
    /// </summary>
    /// <value>The end point.</value>
    public Vector3 End { get; }

    /// <summary>
    ///     Gets the length of this line.
    /// </summary>
    /// <value>The length.</value>
    public float Length
    {
        get => (End - Start).Length();
    }

    /// <summary>
    ///     Gets the length of this line, squared.
    /// </summary>
    /// <value>The squared length.</value>
    public float LengthSquared
    {
        get => (End - Start).LengthSquared();
    }

    /// <summary>
    ///     Gets the start point of the line.
    /// </summary>
    /// <value>The start point.</value>
    public Vector3 Start { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Line3D" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Line3D left, Line3D right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Line3D" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Line3D left, Line3D right)
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
    public static bool operator <(in Line3D left, in Line3D right)
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
    public static bool operator >(in Line3D left, in Line3D right)
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
    public static bool operator <=(in Line3D left, in Line3D right)
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
    public static bool operator >=(in Line3D left, in Line3D right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Line" /> to a <see cref="LineF" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static implicit operator Line3D(in Line line)
    {
        return FromLine(line);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="LineF" /> to a <see cref="Line3D" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static implicit operator Line3D(in LineF line)
    {
        return FromLineF(line);
    }

    /// <summary>
    ///     Converts a <see cref="Line" /> to a <see cref="LineF" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static Line3D FromLine(in Line line)
    {
        Point start = line.Start;
        Point end = line.End;
        return new Line3D(new Vector3(start.X, start.Y, 0), new Vector3(end.X, end.Y, 0));
    }

    /// <summary>
    ///     Converts a <see cref="LineF" /> to a <see cref="Line3D" />.
    /// </summary>
    /// <param name="line">The line to convert.</param>
    /// <returns>The converted line.</returns>
    public static Line3D FromLineF(in LineF line)
    {
        PointF start = line.Start;
        PointF end = line.End;
        return new Line3D(new Vector3(start.X, start.Y, 0), new Vector3(end.X, end.Y, 0));
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
    /// <exception cref="ArgumentException"><paramref name="obj" /> is not an instance of <see cref="Line3D" />.</exception>
    /// </remarks>
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        if (obj is not Line3D other)
        {
            throw new ArgumentException(ExceptionMessages.ObjectIsNotAValidType);
        }

        return CompareTo(other);
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Line3D" />.
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
    public int CompareTo(Line3D other)
    {
        return LengthSquared.CompareTo(other.LengthSquared);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Line3D other && Equals(other);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Line3D other)
    {
        return End.Equals(other.End) && Start.Equals(other.Start);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(End, Start);
    }
}
