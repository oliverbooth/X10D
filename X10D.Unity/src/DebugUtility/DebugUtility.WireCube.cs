using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws an axis-aligned bounding box.
    /// </summary>
    /// <param name="bounds">The bounding box to draw.</param>
    public static void DrawWireCube(in Bounds bounds)
    {
        DrawWireCube(bounds.center, bounds.size, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an axis-aligned bounding box.
    /// </summary>
    /// <param name="bounds">The bounding box to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawWireCube(in Bounds bounds, in Color color)
    {
        DrawWireCube(bounds.center, bounds.size, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an axis-aligned bounding box.
    /// </summary>
    /// <param name="bounds">The bounding box to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawWireCube(in Bounds bounds, in Color color, float duration)
    {
        DrawWireCube(bounds.center, bounds.size, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an axis-aligned bounding box.
    /// </summary>
    /// <param name="bounds">The bounding box to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawWireCube(in Bounds bounds, in Color color, float duration, bool depthTest)
    {
        DrawWireCube(bounds.center, bounds.size, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with a center and a size.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    public static void DrawWireCube(Vector3 center, Vector3 size)
    {
        DrawWireCube(center, size, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified orientation.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="orientation">The orientation of the box.</param>
    public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion orientation)
    {
        DrawWireCube(new Cuboid(center.ToSystemVector(), size.ToSystemVector(), orientation.ToSystemQuaternion()), Color.white,
            DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawWireCube(Vector3 center, Vector3 size, in Color color)
    {
        DrawWireCube(center, size, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified orientation and color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="orientation">The orientation of the box.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion orientation, in Color color)
    {
        DrawWireCube(new Cuboid(center.ToSystemVector(), size.ToSystemVector(), orientation.ToSystemQuaternion()), color,
            DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawWireCube(Vector3 center, Vector3 size, in Color color, float duration)
    {
        DrawWireCube(center, size, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified orientation, color, and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="orientation">The orientation of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion orientation, in Color color, float duration)
    {
        DrawWireCube(new Cuboid(center.ToSystemVector(), size.ToSystemVector(), orientation.ToSystemQuaternion()), color,
            duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawWireCube(Vector3 center, Vector3 size, in Color color, float duration, bool depthTest)
    {
        DrawWireCube(new Cuboid(center.ToSystemVector(), size.ToSystemVector()), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified orientation, color, and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="orientation">The orientation of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion orientation, in Color color, float duration,
        bool depthTest)
    {
        DrawWireCube(new Cuboid(center.ToSystemVector(), size.ToSystemVector(), orientation.ToSystemQuaternion()), color,
            duration, depthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified color.
    /// </summary>
    /// <param name="cuboid">The cuboid to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawWireCube(in Cuboid cuboid, in Color color)
    {
        DrawWireCube(cuboid, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified color and duration.
    /// </summary>
    /// <param name="cuboid">The cuboid to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawWireCube(in Cuboid cuboid, in Color color, float duration)
    {
        DrawWireCube(cuboid, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a wireframe cube with the specified color and duration.
    /// </summary>
    /// <param name="cuboid">The cuboid to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawWireCube(in Cuboid cuboid, in Color color, float duration, bool depthTest)
    {
        Vector3 frontTopLeft = cuboid.FrontTopLeft.ToUnityVector();
        Vector3 frontTopRight = cuboid.FrontTopRight.ToUnityVector();
        Vector3 frontBottomRight = cuboid.FrontBottomRight.ToUnityVector();
        Vector3 frontBottomLeft = cuboid.FrontBottomLeft.ToUnityVector();
        Vector3 backTopLeft = cuboid.BackTopLeft.ToUnityVector();
        Vector3 backTopRight = cuboid.BackTopRight.ToUnityVector();
        Vector3 backBottomRight = cuboid.BackBottomRight.ToUnityVector();
        Vector3 backBottomLeft = cuboid.BackBottomLeft.ToUnityVector();

        Debug.DrawLine(frontTopLeft, frontTopRight, color, duration, depthTest);
        Debug.DrawLine(frontTopRight, frontBottomRight, color, duration, depthTest);
        Debug.DrawLine(frontBottomRight, frontBottomLeft, color, duration, depthTest);
        Debug.DrawLine(frontBottomLeft, frontTopLeft, color, duration, depthTest);

        Debug.DrawLine(backTopLeft, backTopRight, color, duration, depthTest);
        Debug.DrawLine(backTopRight, backBottomRight, color, duration, depthTest);
        Debug.DrawLine(backBottomRight, backBottomLeft, color, duration, depthTest);
        Debug.DrawLine(backBottomLeft, backTopLeft, color, duration, depthTest);

        Debug.DrawLine(frontTopLeft, backTopLeft, color, duration, depthTest);
        Debug.DrawLine(frontTopRight, backTopRight, color, duration, depthTest);
        Debug.DrawLine(frontBottomRight, backBottomRight, color, duration, depthTest);
        Debug.DrawLine(frontBottomLeft, backBottomLeft, color, duration, depthTest);
    }
}
