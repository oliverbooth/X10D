using System.Drawing;

namespace X10D.Drawing;

/// <summary>
///     Represents a circle that is composed of a 32-bit signed integer center point and radius.
/// </summary>
public readonly struct Circle : IEquatable<Circle>, IComparable<Circle>, IComparable
{
    /// <summary>
    ///     The empty circle. That is, a circle whose center point is (0, 0) and whose radius is 0.
    /// </summary>
    public static readonly Circle Empty = new();

    /// <summary>
    ///     The unit circle. That is, a circle whose center point is (0, 0) and whose radius is 1.
    /// </summary>
    public static readonly Circle Unit = new(0, 0, 1);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Circle" /> struct.
    /// </summary>
    /// <param name="centerX">The X coordinate of the center point.</param>
    /// <param name="centerY">The Y coordinate of the center point.</param>
    /// <param name="radius">The radius of the circle.</param>
    public Circle(int centerX, int centerY, int radius)
        : this(new Point(centerX, centerY), radius)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Circle" /> struct.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    public Circle(Point center, int radius)
    {
        Center = center;
        Radius = radius;
    }

    /// <summary>
    ///     Gets the area of the circle.
    /// </summary>
    /// <value>The area of the circle, calculated as <c>πr²</c>.</value>
    public float Area
    {
        get => MathF.PI * Radius * Radius;
    }

    /// <summary>
    ///     Gets the center point of the circle.
    /// </summary>
    /// <value>The center point.</value>
    public Point Center { get; }

    /// <summary>
    ///     Gets the circumference of the circle.
    /// </summary>
    /// <value>The circumference of the circle, calculated as <c>2πr</c>.</value>
    public float Circumference
    {
        get => 2 * MathF.PI * Radius;
    }

    /// <summary>
    ///     Gets the diameter of the circle.
    /// </summary>
    /// <value>The diameter. This is always twice the <see cref="Radius" />.</value>
    public int Diameter
    {
        get => Radius * 2;
    }

    /// <summary>
    ///     Gets the radius of the circle.
    /// </summary>
    /// <value>The radius.</value>
    public int Radius { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Circle" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Circle left, Circle right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Circle" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Circle left, Circle right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is less than that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is less than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <(Circle left, Circle right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is greater than to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is greater than that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >(Circle left, Circle right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is less than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is less than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <=(Circle left, Circle right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the radius of one circle is greater than or equal to that of another.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Radius" /> of <paramref name="left" /> is greater than or equal to that of
    ///     <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >=(Circle left, Circle right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    ///     Explicitly converts a <see cref="Circle" /> to a <see cref="CircleF" />.
    /// </summary>
    /// <param name="circle">The circle to convert.</param>
    /// <returns>The converted circle.</returns>
    public static explicit operator Circle(CircleF circle)
    {
        return Circle.FromCircleF(circle);
    }

    /// <summary>
    ///     Converts a <see cref="Circle" /> to a <see cref="CircleF" />.
    /// </summary>
    /// <param name="circle">The circle to convert.</param>
    /// <returns>The converted circle.</returns>
    public static Circle FromCircleF(CircleF circle)
    {
        PointF center = circle.Center;
        return new Circle(new Point((int)center.X, (int)center.Y), (int)circle.Radius);
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Circle" />.
    /// </summary>
    /// <param name="obj">The other object.</param>
    /// <returns>
    ///     A signed number indicating the relative values of this instance and <paramref name="obj" />.
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
    ///                 The <see cref="Radius" /> of this instance is less than that of <paramref name="obj" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="obj" />, or the <see cref="Radius" /> of both this instance
    ///                 and <paramref name="obj" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Radius" /> of this instance is greater than that of <paramref name="obj" />, or
    ///                 <paramref name="obj" /> is <see langword="null" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>Comparison only takes into consideration the <see cref="Radius" />.</remarks>
    /// <exception cref="ArgumentException"><paramref name="obj" /> is not an instance of <see cref="Circle" />.</exception>
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return 1;
        }

        if (obj is not Circle other)
        {
            throw new ArgumentException(ExceptionMessages.ObjectIsNotAValidType);
        }

        return CompareTo(other);
    }

    /// <summary>
    ///     Compares this instance to another <see cref="Circle" />.
    /// </summary>
    /// <param name="other">The other circle.</param>
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
    ///                 The <see cref="Radius" /> of this instance is less than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Zero</term>
    ///             <description>
    ///                 This instance is equal to <paramref name="other" />, or the <see cref="Radius" /> of both this instance
    ///                 and <paramref name="other" /> are not a number (<see cref="float.NaN" />),
    ///                 <see cref="float.PositiveInfinity" />, or <see cref="float.NegativeInfinity" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Greater than zero</term>
    ///             <description>
    ///                 The <see cref="Radius" /> of this instance is greater than that of <paramref name="other" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <remarks>Comparison only takes into consideration the <see cref="Radius" />.</remarks>
    public int CompareTo(Circle other)
    {
        return Radius.CompareTo(other.Radius);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Circle circle && Equals(circle);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Circle other)
    {
        return Center.Equals(other.Center) && Radius.Equals(other.Radius);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Center, Radius);
    }
}
