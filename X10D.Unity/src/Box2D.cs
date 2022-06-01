using System.Drawing;
using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Represents a 2D box that can be drawn using the <see cref="DebugEx" /> class.
/// </summary>
/// <remarks>
///     This structure serves no real purpose except to be used in tandem with <see cref="DebugEx" />. For creating a logical
///     rectangle, consider using the <see cref="Rectangle" />, <see cref="RectangleF" />, <see cref="Rect" />, or
///     <see cref="RectInt" /> structures.
/// </remarks>
public readonly struct Box2D
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Box2D" /> struct.
    /// </summary>
    /// <param name="origin">The origin of the box.</param>
    /// <param name="halfExtents">The half extents of the box.</param>
    public Box2D(Vector2 origin, Vector2 halfExtents)
    {
        LocalTopLeft = new Vector2(-halfExtents.x, halfExtents.y);
        LocalTopRight = new Vector2(halfExtents.x, halfExtents.y);
        LocalBottomLeft = new Vector2(-halfExtents.x, -halfExtents.y);
        LocalBottomRight = new Vector2(halfExtents.x, -halfExtents.y);

        Origin = origin;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Box2D" /> struct.
    /// </summary>
    /// <param name="origin">The origin of the box.</param>
    /// <param name="halfExtents">The half extents of the box.</param>
    /// <param name="rotation">The rotation of the box.</param>
    public Box2D(Vector2 origin, Vector2 halfExtents, float rotation)
        : this(origin, halfExtents)
    {
        var localTopLeft = new Vector2(-halfExtents.x, halfExtents.y);
        var localTopRight = new Vector2(halfExtents.x, halfExtents.y);
        var localBottomLeft = new Vector2(-halfExtents.x, -halfExtents.y);
        var localBottomRight = new Vector2(halfExtents.x, -halfExtents.y);

        Rotate(
            rotation,
            ref localTopLeft,
            ref localTopRight,
            ref localBottomLeft,
            ref localBottomRight);

        LocalTopLeft = localTopLeft;
    }

    /// <summary>
    ///     Gets the origin of the box.
    /// </summary>
    /// <value>The origin.</value>
    public Vector2 Origin { get; }

    /// <summary>
    ///     Gets the top-left corner of the box, in local space.
    /// </summary>
    /// <value>The top-left corner.</value>
    public Vector2 LocalTopLeft { get; }

    /// <summary>
    ///     Gets the top-right corner of the box, in local space.
    /// </summary>
    /// <value>The top-right corner.</value>
    public Vector2 LocalTopRight { get; }

    /// <summary>
    ///     Gets the bottom-left corner of the box, in local space.
    /// </summary>
    /// <value>The bottom-left corner.</value>
    public Vector2 LocalBottomLeft { get; }

    /// <summary>
    ///     Gets the bottom-right corner of the box, in local space.
    /// </summary>
    /// <value>The bottom-right corner.</value>
    public Vector2 LocalBottomRight { get; }

    /// <summary>
    ///     Gets the top-left corner of the box, in world space.
    /// </summary>
    /// <value>The top-left corner.</value>
    public Vector2 TopLeft
    {
        get => LocalTopLeft + Origin;
    }

    /// <summary>
    ///     Gets the top-right corner of the box, in world space.
    /// </summary>
    /// <value>The top-right corner.</value>
    public Vector2 TopRight
    {
        get => LocalTopRight + Origin;
    }

    /// <summary>
    ///     Gets the bottom-left corner of the box, in world space.
    /// </summary>
    /// <value>The bottom-left corner.</value>
    public Vector2 BottomLeft
    {
        get => LocalBottomLeft + Origin;
    }

    /// <summary>
    ///     Gets the bottom-right corner of the box, in world space.
    /// </summary>
    /// <value>The bottom-right corner.</value>
    public Vector2 BottomRight
    {
        get => LocalBottomRight + Origin;
    }

    /// <summary>
    ///     Implicitly converts an instance of <see cref="Rect" /> to an instance of <see cref="Box2D" />.
    /// </summary>
    /// <param name="rect">The <see cref="Rect" /> to convert.</param>
    /// <returns>A new instance of <see cref="Box2D" />.</returns>
    public static implicit operator Box2D(Rect rect)
    {
        return new Box2D(rect.center, rect.size / 2f);
    }

    /// <summary>
    ///     Implicitly converts an instance of <see cref="RectInt" /> to an instance of <see cref="Box2D" />.
    /// </summary>
    /// <param name="rect">The <see cref="RectInt" /> to convert.</param>
    /// <returns>A new instance of <see cref="Box2D" />.</returns>
    public static implicit operator Box2D(RectInt rect)
    {
        return new Box2D(rect.center, (Vector2)rect.size / 2.0f);
    }

    private static Vector2 RotatePointAroundPivot(Vector2 point, Vector2 pivot, float rotation)
    {
        Vector2 direction = point - pivot;
        return pivot + (rotation * direction);
    }

    private static void Rotate(
        float rotation,
        ref Vector2 localTopLeft,
        ref Vector2 localTopRight,
        ref Vector2 localBottomLeft,
        ref Vector2 localBottomRight
    )
    {
        localTopLeft = RotatePointAroundPivot(localTopLeft, Vector2.zero, rotation);
        localTopRight = RotatePointAroundPivot(localTopRight, Vector2.zero, rotation);
        localBottomLeft = RotatePointAroundPivot(localBottomLeft, Vector2.zero, rotation);
        localBottomRight = RotatePointAroundPivot(localBottomRight, Vector2.zero, rotation);
    }
}
