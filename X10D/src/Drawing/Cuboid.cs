using System.Numerics;
using X10D.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a cuboid in 3D space, which uses single-precision floating-point numbers for its coordinates.
/// </summary>
public readonly struct Cuboid : IEquatable<Cuboid>
{
    /// <summary>
    ///     The empty cuboid. That is, a cuboid whose size is zero.
    /// </summary>
    public static readonly Cuboid Empty = new();

    /// <summary>
    ///     A cube. That is, a cuboid whose size is the same in all three dimensions.
    /// </summary>
    /// <value>A cube with the size (1, 1, 1).</value>
    public static readonly Cuboid Cube = new(0, 0, 0, 1, 1, 1);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Cuboid" /> struct.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The size.</param>
    public Cuboid(in Vector3 center, in Vector3 size)
    {
        Center = center;
        Size = size;
        Orientation = Quaternion.Identity;

        Vector3 halfExtents = Size / 2.0f;
        LocalFrontTopLeft = new Vector3(-halfExtents.X, halfExtents.Y, -halfExtents.Z);
        LocalFrontTopRight = new Vector3(halfExtents.X, halfExtents.Y, -halfExtents.Z);
        LocalFrontBottomLeft = new Vector3(-halfExtents.X, -halfExtents.Y, -halfExtents.Z);
        LocalFrontBottomRight = new Vector3(halfExtents.X, -halfExtents.Y, -halfExtents.Z);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Cuboid" /> struct.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The size.</param>
    /// <param name="orientation">The orientation of the cuboid.</param>
    public Cuboid(in Vector3 center, in Vector3 size, in Quaternion orientation)
        : this(center, size)
    {
        Orientation = orientation;

        Vector3 halfExtents = Size / 2.0f;
        var localFrontTopLeft = new Vector3(-halfExtents.X, halfExtents.Y, -halfExtents.Z);
        var localFrontTopRight = new Vector3(halfExtents.X, halfExtents.Y, -halfExtents.Z);
        var localFrontBottomLeft = new Vector3(-halfExtents.X, -halfExtents.Y, -halfExtents.Z);
        var localFrontBottomRight = new Vector3(halfExtents.X, -halfExtents.Y, -halfExtents.Z);

        Rotate(
            orientation,
            ref localFrontTopLeft,
            ref localFrontTopRight,
            ref localFrontBottomLeft,
            ref localFrontBottomRight);

        LocalFrontTopLeft = localFrontTopLeft;
    }

    /// <summary>
    ///     Gets the center point of the cuboid.
    /// </summary>
    /// <value>The center point.</value>
    public Vector3 Center { get; }

    /// <summary>
    ///     Gets the orientation of this cuboid.
    /// </summary>
    /// <value>The orientation.</value>
    public Quaternion Orientation { get; }

    /// <summary>
    ///     Gets the size of the cuboid.
    /// </summary>
    /// <value>The size.</value>
    public Vector3 Size { get; }

    /// <summary>
    ///     Gets the front-top-left corner of the box, in local space.
    /// </summary>
    /// <value>The front-top-left corner.</value>
    public Vector3 LocalFrontTopLeft { get; }

    /// <summary>
    ///     Gets the front-top-right corner of the box, in local space.
    /// </summary>
    /// <value>The front-top-right corner.</value>
    public Vector3 LocalFrontTopRight { get; }

    /// <summary>
    ///     Gets the front-bottom-left corner of the box, in local space.
    /// </summary>
    /// <value>The front-bottom-left corner.</value>
    public Vector3 LocalFrontBottomLeft { get; }

    /// <summary>
    ///     Gets the front-bottom-right corner of the box, in local space.
    /// </summary>
    /// <value>The front-bottom-right corner.</value>
    public Vector3 LocalFrontBottomRight { get; }

    /// <summary>
    ///     Gets the back-top-left corner of the box, in local space.
    /// </summary>
    /// <value>The back-top-left corner.</value>
    public Vector3 LocalBackTopLeft
    {
        get => -LocalFrontBottomRight;
    }

    /// <summary>
    ///     Gets the back-top-right corner of the box, in local space.
    /// </summary>
    /// <value>The back-top-right corner.</value>
    public Vector3 LocalBackTopRight
    {
        get => -LocalFrontBottomLeft;
    }

    /// <summary>
    ///     Gets the back-bottom-left corner of the box, in local space.
    /// </summary>
    /// <value>The back-bottom-left corner.</value>
    public Vector3 LocalBackBottomLeft
    {
        get => -LocalFrontTopRight;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in local space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 LocalBackBottomRight
    {
        get => -LocalFrontTopLeft;
    }

    /// <summary>
    ///     Gets the front-top-left corner of the box, in world space.
    /// </summary>
    /// <value>The front-top-left corner.</value>
    public Vector3 FrontTopLeft
    {
        get => LocalFrontTopLeft + Center;
    }

    /// <summary>
    ///     Gets the front-top-right corner of the box, in world space.
    /// </summary>
    /// <value>The front-top-right corner.</value>
    public Vector3 FrontTopRight
    {
        get => LocalFrontTopRight + Center;
    }

    /// <summary>
    ///     Gets the front-bottom-left corner of the box, in world space.
    /// </summary>
    /// <value>The front-bottom-left corner.</value>
    public Vector3 FrontBottomLeft
    {
        get => LocalFrontBottomLeft + Center;
    }

    /// <summary>
    ///     Gets the front-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The front-bottom-right corner.</value>
    public Vector3 FrontBottomRight
    {
        get => LocalFrontBottomRight + Center;
    }

    /// <summary>
    ///     Gets the back-bottom-left corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-left corner.</value>
    public Vector3 BackTopLeft
    {
        get => LocalBackTopLeft + Center;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 BackTopRight
    {
        get => LocalBackTopRight + Center;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 BackBottomLeft
    {
        get => LocalBackBottomLeft + Center;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 BackBottomRight
    {
        get => LocalBackBottomRight + Center;
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
    public static bool operator ==(Cuboid left, Cuboid right)
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
    public static bool operator !=(Cuboid left, Cuboid right)
    {
        return !left.Equals(right);
    }

    private static Vector3 RotatePointAroundPivot(in Vector3 point, in Vector3 pivot, in Quaternion rotation)
    {
        Vector3 direction = point - pivot;
        return pivot + rotation.Multiply(direction);
    }

    private static void Rotate(
        in Quaternion orientation,
        ref Vector3 localFrontTopLeft,
        ref Vector3 localFrontTopRight,
        ref Vector3 localFrontBottomLeft,
        ref Vector3 localFrontBottomRight
    )
    {
        localFrontTopLeft = RotatePointAroundPivot(localFrontTopLeft, Vector3.Zero, orientation);
        localFrontTopRight = RotatePointAroundPivot(localFrontTopRight, Vector3.Zero, orientation);
        localFrontBottomLeft = RotatePointAroundPivot(localFrontBottomLeft, Vector3.Zero, orientation);
        localFrontBottomRight = RotatePointAroundPivot(localFrontBottomRight, Vector3.Zero, orientation);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Cuboid other && Equals(other);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Cuboid other)
    {
        return Center.Equals(other.Center) && Size.Equals(other.Size) && Orientation.Equals(other.Orientation);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Center, Size, LocalFrontTopLeft);
    }
}
