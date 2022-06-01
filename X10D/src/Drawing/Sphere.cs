using System.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a sphere in 3D space, which uses single-precision floating-point numbers for its coordinates.
/// </summary>
public readonly struct Sphere : IEquatable<Sphere>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Sphere" /> struct.
    /// </summary>
    /// <param name="centerX">The X coordinate of the center point.</param>
    /// <param name="centerY">The Y coordinate of the center point.</param>
    /// <param name="centerZ">The Z coordinate of the center point.</param>
    /// <param name="radius">The radius.</param>
    public Sphere(float centerX, float centerY, float centerZ, float radius)
        : this(new Vector3(centerX, centerY, centerZ), radius)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Sphere" /> struct.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="radius">The radius.</param>
    public Sphere(Vector3 center, float radius)
    {
        Center = center;
        Radius = radius;
    }

    /// <summary>
    ///     Gets the center-point of the sphere.
    /// </summary>
    /// <value>The center point.</value>
    public Vector3 Center { get; }

    /// <summary>
    ///     Gets the radius of the sphere.
    /// </summary>
    /// <value>The radius.</value>
    public float Radius { get; }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Cuboid" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Sphere left, Sphere right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Cuboid" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Sphere left, Sphere right)
    {
        return !left.Equals(right);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Sphere other && Equals(other);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Sphere other)
    {
        return Center.Equals(other.Center) && Radius.Equals(other.Radius);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Center, Radius);
    }
}
