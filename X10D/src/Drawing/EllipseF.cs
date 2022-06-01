﻿using System.Drawing;

namespace X10D.Drawing;

/// <summary>
///     Represents an ellipse that is composed of a single-precision floating-point center point and radius.
/// </summary>
public readonly struct EllipseF : IEquatable<EllipseF>
{
    /// <summary>
    ///     The empty ellipse. That is, an ellipse whose center point is (0, 0) and whose two radii are 0.
    /// </summary>
    public static readonly EllipseF Empty = new();

    /// <summary>
    ///     The unit ellipse. That is, an ellipse whose center point is (0, 0) and whose two radii are 1.
    /// </summary>
    public static readonly EllipseF Unit = new(PointF.Empty, 1.0f, 1.0f);

    /// <summary>
    ///     Initializes a new instance of the <see cref="EllipseF" /> struct.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="horizontalRadius">The horizontal radius of the ellipse.</param>
    /// <param name="verticalRadius">The vertical radius of the ellipse.</param>
    public EllipseF(PointF center, float horizontalRadius, float verticalRadius)
    {
        Center = center;
        HorizontalRadius = horizontalRadius;
        VerticalRadius = verticalRadius;
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
    public PointF Center { get; }

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
    public float HorizontalRadius { get; }

    /// <summary>
    ///     Gets the vertical radius of the ellipse.
    /// </summary>
    /// <value>The vertical radius.</value>
    public float VerticalRadius { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="EllipseF" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(EllipseF left, EllipseF right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="EllipseF" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(EllipseF left, EllipseF right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Circle" /> to an <see cref="EllipseF" />.
    /// </summary>
    /// <param name="circle">The circle to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static implicit operator EllipseF(Circle circle)
    {
        return new EllipseF(circle.Center, circle.Radius, circle.Radius);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="CircleF" /> to an <see cref="EllipseF" />.
    /// </summary>
    /// <param name="circle">The circle to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static implicit operator EllipseF(CircleF circle)
    {
        return new EllipseF(circle.Center, circle.Radius, circle.Radius);
    }

    /// <summary>
    ///     Implicitly converts an <see cref="Ellipse" /> to an <see cref="EllipseF" />.
    /// </summary>
    /// <param name="ellipse">The ellipse to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static implicit operator EllipseF(Ellipse ellipse)
    {
        return new EllipseF(ellipse.Center, ellipse.HorizontalRadius, ellipse.VerticalRadius);
    }

    /// <summary>
    ///     Explicitly converts an <see cref="EllipseF" /> to an <see cref="Ellipse" />.
    /// </summary>
    /// <param name="ellipse">The ellipse to convert.</param>
    /// <returns>The converted ellipse.</returns>
    public static explicit operator Ellipse(EllipseF ellipse)
    {
        PointF center = ellipse.Center;
        return new Ellipse(new Point((int)center.X, (int)center.Y), (int)ellipse.HorizontalRadius, (int)ellipse.VerticalRadius);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is EllipseF ellipse && Equals(ellipse);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(EllipseF other)
    {
        return HorizontalRadius.Equals(other.HorizontalRadius) && VerticalRadius.Equals(other.VerticalRadius);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(HorizontalRadius, VerticalRadius);
    }
}
