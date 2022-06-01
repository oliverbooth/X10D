﻿using System.Drawing;

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
    public static readonly Ellipse Unit = new(Point.Empty, 1, 1);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Ellipse" /> struct.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="horizontalRadius">The horizontal radius of the ellipse.</param>
    /// <param name="verticalRadius">The vertical radius of the ellipse.</param>
    public Ellipse(Point center, int horizontalRadius, int verticalRadius)
    {
        Center = center;
        HorizontalRadius = horizontalRadius;
        VerticalRadius = verticalRadius;
    }

    public static implicit operator Ellipse(Circle circle)
    {
        return new Ellipse(circle.Center, circle.Radius, circle.Radius);
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
    public static bool operator ==(Ellipse left, Ellipse right)
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
    public static bool operator !=(Ellipse left, Ellipse right)
    {
        return !left.Equals(right);
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
