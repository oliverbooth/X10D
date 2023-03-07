using System.Drawing;

namespace X10D.Drawing;

/// <summary>
///     Represents an ellipse that is composed of a 32-bit signed integer center point and radius.
/// </summary>
public readonly struct Ellipse : IEquatable<Ellipse>
{
    /// <summary>
    ///     The empty ellipse. That is, an ellipse whose center point is (0, 0) and whose two radii are 0.
    /// </summary>
    public static readonly Ellipse Empty = new();

    /// <summary>
    ///     The unit ellipse. That is, an ellipse whose center point is (0, 0) and whose two radii are 1.
    /// </summary>
    public static readonly Ellipse Unit = new(0, 0, 1, 1);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Ellipse" /> struct.
    /// </summary>
    /// <param name="centerX">The X coordinate of the center point.</param>
    /// <param name="centerY">The Y coordinate of the center point.</param>
    /// <param name="horizontalRadius">The horizontal radius of the ellipse.</param>
    /// <param name="verticalRadius">The vertical radius of the ellipse.</param>
    public Ellipse(int centerX, int centerY, int horizontalRadius, int verticalRadius)
        : this(new Point(centerX, centerY), new Size(horizontalRadius, verticalRadius))
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Ellipse" /> struct.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radius">The radius of the ellipse.</param>
    public Ellipse(Point center, Size radius)
    {
        Center = center;
        HorizontalRadius = radius.Width;
        VerticalRadius = radius.Height;
    }

    /// <summary>
    ///     Gets the area of the ellipse.
    /// </summary>
    /// <value>The area of the ellipse, calculated as <c>πab</c>.</value>
    public float Area
    {
        get => MathF.PI * HorizontalRadius * VerticalRadius;
    }

    /// <summary>
    ///     Gets the center point of the ellipse.
    /// </summary>
    /// <value>The center point.</value>
    public Point Center { get; }

    /// <summary>
    ///     Gets the approximate circumference of the ellipse.
    /// </summary>
    /// <value>
    ///     The approximate circumference of the ellipse, calculated as
    ///     <c>π(a+b)(3([(a-b)²]/(a+b)²(sqrt(-3(((a-b)²)/(a+b)²)+4+10))+1)</c>.
    /// </value>
    public float ApproximateCircumference
    {
        get
        {
            float aMinusB = HorizontalRadius - VerticalRadius;
            float aPlusB = HorizontalRadius + VerticalRadius;

            float aMinusB2 = aMinusB * aMinusB;
            float aPlusB2 = aPlusB * aPlusB;

            return MathF.PI * (aPlusB * (3 * (aMinusB2 / (aPlusB2 * MathF.Sqrt(-3 * (aMinusB2 / aPlusB2) + 4 + 10))) + 1));
        }
    }

    /// <summary>
    ///     Gets the horizontal radius of the ellipse.
    /// </summary>
    /// <value>The horizontal radius.</value>
    public int HorizontalRadius { get; }

    /// <summary>
    ///     Gets the radius of the ellipse.
    /// </summary>
    /// <value>The radius.</value>
    public Size Radius
    {
        get => new(HorizontalRadius, VerticalRadius);
    }

    /// <summary>
    ///     Gets the vertical radius of the ellipse.
    /// </summary>
    /// <value>The vertical radius.</value>
    public int VerticalRadius { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Ellipse" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(in Ellipse left, in Ellipse right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Ellipse" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(in Ellipse left, in Ellipse right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Circle" /> to an <see cref="Ellipse" />.
    /// </summary>
    /// <param name="circle">The circle to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static implicit operator Ellipse(in Circle circle)
    {
        return FromCircle(circle);
    }

    /// <summary>
    ///     Explicitly converts an <see cref="EllipseF" /> to an <see cref="Ellipse" />.
    /// </summary>
    /// <param name="ellipse">The ellipse to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static explicit operator Ellipse(in EllipseF ellipse)
    {
        return FromEllipseF(ellipse);
    }

    /// <summary>
    ///     Converts a <see cref="Circle" /> to an <see cref="Ellipse" />.
    /// </summary>
    /// <param name="circle">The circle to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static Ellipse FromCircle(in Circle circle)
    {
        return new Ellipse(circle.Center, new Size(circle.Radius, circle.Radius));
    }

    /// <summary>
    ///     Converts an <see cref="EllipseF" /> to an <see cref="Ellipse" />.
    /// </summary>
    /// <param name="ellipse">The ellipse to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static Ellipse FromEllipseF(in EllipseF ellipse)
    {
        PointF center = ellipse.Center;
        return new Ellipse((int)center.X, (int)center.Y, (int)ellipse.HorizontalRadius, (int)ellipse.VerticalRadius);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Ellipse ellipse && Equals(ellipse);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Ellipse other)
    {
        return HorizontalRadius.Equals(other.HorizontalRadius) && VerticalRadius.Equals(other.VerticalRadius);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(HorizontalRadius, VerticalRadius);
    }
}
