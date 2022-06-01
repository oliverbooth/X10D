using UnityEngine;
using X10D.Drawing;

namespace X10D.Unity;

/// <summary>
///     Represents a box that can be drawn using the <see cref="DebugEx" /> class.
/// </summary>
/// <remarks>
///     This structure serves no real purpose except to be used in tandem with <see cref="DebugEx" />. For creating a logical
///     cuboid, consider using the <see cref="Cuboid" /> structure.
/// </remarks>
public readonly struct Box
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Box" /> struct.
    /// </summary>
    /// <param name="origin">The origin of the box.</param>
    /// <param name="halfExtents">The half extents of the box.</param>
    public Box(Vector3 origin, Vector3 halfExtents)
    {
        LocalFrontTopLeft = new Vector3(-halfExtents.x, halfExtents.y, -halfExtents.z);
        LocalFrontTopRight = new Vector3(halfExtents.x, halfExtents.y, -halfExtents.z);
        LocalFrontBottomLeft = new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z);
        LocalFrontBottomRight = new Vector3(halfExtents.x, -halfExtents.y, -halfExtents.z);

        Origin = origin;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Box" /> struct.
    /// </summary>
    /// <param name="origin">The origin of the box.</param>
    /// <param name="halfExtents">The half extents of the box.</param>
    /// <param name="orientation">The orientation of the box.</param>
    public Box(Vector3 origin, Vector3 halfExtents, Quaternion orientation)
        : this(origin, halfExtents)
    {
        var localFrontTopLeft = new Vector3(-halfExtents.x, halfExtents.y, -halfExtents.z);
        var localFrontTopRight = new Vector3(halfExtents.x, halfExtents.y, -halfExtents.z);
        var localFrontBottomLeft = new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z);
        var localFrontBottomRight = new Vector3(halfExtents.x, -halfExtents.y, -halfExtents.z);

        Rotate(
            orientation,
            ref localFrontTopLeft,
            ref localFrontTopRight,
            ref localFrontBottomLeft,
            ref localFrontBottomRight);

        LocalFrontTopLeft = localFrontTopLeft;
    }

    /// <summary>
    ///     Gets the origin of the box.
    /// </summary>
    /// <value>The origin.</value>
    public Vector3 Origin { get; }

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
        get => LocalFrontTopLeft + Origin;
    }

    /// <summary>
    ///     Gets the front-top-right corner of the box, in world space.
    /// </summary>
    /// <value>The front-top-right corner.</value>
    public Vector3 FrontTopRight
    {
        get => LocalFrontTopRight + Origin;
    }

    /// <summary>
    ///     Gets the front-bottom-left corner of the box, in world space.
    /// </summary>
    /// <value>The front-bottom-left corner.</value>
    public Vector3 FrontBottomLeft
    {
        get => LocalFrontBottomLeft + Origin;
    }

    /// <summary>
    ///     Gets the front-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The front-bottom-right corner.</value>
    public Vector3 FrontBottomRight
    {
        get => LocalFrontBottomRight + Origin;
    }

    /// <summary>
    ///     Gets the back-bottom-left corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-left corner.</value>
    public Vector3 BackTopLeft
    {
        get => LocalBackTopLeft + Origin;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 BackTopRight
    {
        get => LocalBackTopRight + Origin;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 BackBottomLeft
    {
        get => LocalBackBottomLeft + Origin;
    }

    /// <summary>
    ///     Gets the back-bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The back-bottom-right corner.</value>
    public Vector3 BackBottomRight
    {
        get => LocalBackBottomRight + Origin;
    }

    /// <summary>
    ///     Implicitly converts an instance of <see cref="Bounds" /> to an instance of <see cref="Box" />.
    /// </summary>
    /// <param name="bounds">The <see cref="Bounds" /> to convert.</param>
    /// <returns>A new instance of <see cref="Box" />.</returns>
    public static implicit operator Box(Bounds bounds)
    {
        return new Box(bounds.center, bounds.extents);
    }

    /// <summary>
    ///     Implicitly converts an instance of <see cref="Bounds" /> to an instance of <see cref="Box" />.
    /// </summary>
    /// <param name="bounds">The <see cref="Bounds" /> to convert.</param>
    /// <returns>A new instance of <see cref="Box" />.</returns>
    public static implicit operator Box(BoundsInt bounds)
    {
        return new Box(bounds.center, (Vector3)bounds.size / 2.0f);
    }

    private static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        Vector3 direction = point - pivot;
        return pivot + (rotation * direction);
    }

    private static void Rotate(
        Quaternion orientation,
        ref Vector3 localFrontTopLeft,
        ref Vector3 localFrontTopRight,
        ref Vector3 localFrontBottomLeft,
        ref Vector3 localFrontBottomRight
    )
    {
        localFrontTopLeft = RotatePointAroundPivot(localFrontTopLeft, Vector3.zero, orientation);
        localFrontTopRight = RotatePointAroundPivot(localFrontTopRight, Vector3.zero, orientation);
        localFrontBottomLeft = RotatePointAroundPivot(localFrontBottomLeft, Vector3.zero, orientation);
        localFrontBottomRight = RotatePointAroundPivot(localFrontBottomRight, Vector3.zero, orientation);
    }
}
