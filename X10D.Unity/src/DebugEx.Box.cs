using UnityEngine;

namespace X10D.Unity;

public static partial class DebugEx
{
    /// <summary>
    ///     Draws a box.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents)
    {
        DrawBox(center, halfExtents, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified orientation.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="orientation">The orientation of the box.</param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
    {
        DrawBox(new Box(center, halfExtents, orientation), Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, in Color color)
    {
        DrawBox(center, halfExtents, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified orientation and color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="orientation">The orientation of the box.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, in Color color)
    {
        DrawBox(new Box(center, halfExtents, orientation), color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, in Color color, float duration)
    {
        DrawBox(center, halfExtents, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified orientation, color, and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="orientation">The orientation of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, in Color color, float duration)
    {
        DrawBox(new Box(center, halfExtents, orientation), color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, in Color color, float duration, bool depthTest)
    {
        DrawBox(new Box(center, halfExtents), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a box with the specified orientation, color, and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="orientation">The orientation of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, in Color color, float duration, bool depthTest)
    {
        DrawBox(new Box(center, halfExtents, orientation), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a box with the specified color.
    /// </summary>
    /// <param name="box">The box to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawBox(Box box, in Color color)
    {
        DrawBox(box, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified color and duration.
    /// </summary>
    /// <param name="box">The box to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawBox(Box box, in Color color, float duration)
    {
        DrawBox(box, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a box with the specified color and duration.
    /// </summary>
    /// <param name="box">The box to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawBox(Box box, in Color color, float duration, bool depthTest)
    {
        Debug.DrawLine(box.FrontTopLeft, box.FrontTopRight, color, duration, depthTest);
        Debug.DrawLine(box.FrontTopRight, box.FrontBottomRight, color, duration, depthTest);
        Debug.DrawLine(box.FrontBottomRight, box.FrontBottomLeft, color, duration, depthTest);
        Debug.DrawLine(box.FrontBottomLeft, box.FrontTopLeft, color, duration, depthTest);

        Debug.DrawLine(box.BackTopLeft, box.BackTopRight, color, duration, depthTest);
        Debug.DrawLine(box.BackTopRight, box.BackBottomRight, color, duration, depthTest);
        Debug.DrawLine(box.BackBottomRight, box.BackBottomLeft, color, duration, depthTest);
        Debug.DrawLine(box.BackBottomLeft, box.BackTopLeft, color, duration, depthTest);

        Debug.DrawLine(box.FrontTopLeft, box.BackTopLeft, color, duration, depthTest);
        Debug.DrawLine(box.FrontTopRight, box.BackTopRight, color, duration, depthTest);
        Debug.DrawLine(box.FrontBottomRight, box.BackBottomRight, color, duration, depthTest);
        Debug.DrawLine(box.FrontBottomLeft, box.BackBottomLeft, color, duration, depthTest);
    }
}
