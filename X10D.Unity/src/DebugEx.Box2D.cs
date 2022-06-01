using System.Drawing;
using UnityEngine;
using X10D.Unity.Drawing;
using Color = UnityEngine.Color;

namespace X10D.Unity;

public static partial class DebugEx
{
    /// <summary>
    ///     Draws a rectangle.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents)
    {
        DrawRectangle(center, halfExtents, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified rotation.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="rotation">The rotation of the box.</param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, float rotation)
    {
        DrawRectangle(new Box2D(center, halfExtents, rotation), Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, in Color color)
    {
        DrawRectangle(center, halfExtents, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified rotation and color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="rotation">The rotation of the box.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, float rotation, in Color color)
    {
        DrawRectangle(new Box2D(center, halfExtents, rotation), color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, in Color color, float duration)
    {
        DrawRectangle(center, halfExtents, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified rotation, color, and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="rotation">The rotation of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, float rotation, in Color color, float duration)
    {
        DrawRectangle(new Box2D(center, halfExtents, rotation), color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
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
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, in Color color, float duration, bool depthTest)
    {
        DrawRectangle(new Box2D(center, halfExtents), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified rotation, color, and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="halfExtents">The extents of the box, halved.</param>
    /// <param name="rotation">The rotation of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(Vector2 center, Vector2 halfExtents, float rotation, in Color color, float duration,
        bool depthTest)
    {
        DrawRectangle(new Box2D(center, halfExtents, rotation), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="box">The box to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Box2D box, in Color color)
    {
        DrawRectangle(box, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="box">The box to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Box2D box, in Color color, float duration)
    {
        DrawRectangle(box, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
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
    public static void DrawRectangle(Box2D box, in Color color, float duration, bool depthTest)
    {
        Debug.DrawLine(box.TopLeft, box.TopRight, color, duration, depthTest);
        Debug.DrawLine(box.TopRight, box.BottomRight, color, duration, depthTest);
        Debug.DrawLine(box.BottomRight, box.BottomLeft, color, duration, depthTest);
        Debug.DrawLine(box.BottomLeft, box.TopLeft, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Rect rect, in Color color)
    {
        DrawRectangle(rect, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Rect rect, in Color color, float duration)
    {
        DrawRectangle(rect, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(Rect rect, in Color color, float duration, bool depthTest)
    {
        var box = new Box2D(rect.center, rect.size / 2.0f);
        DrawRectangle(box, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(RectInt rect, in Color color)
    {
        DrawRectangle(rect, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(RectInt rect, in Color color, float duration)
    {
        DrawRectangle(rect, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(RectInt rect, in Color color, float duration, bool depthTest)
    {
        var box = new Box2D(rect.center, (Vector2)rect.size / 2.0f);
        DrawRectangle(box, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Rectangle rect, in Color color)
    {
        DrawRectangle(rect, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Rectangle rect, in Color color, float duration)
    {
        DrawRectangle(rect, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(Rectangle rect, in Color color, float duration, bool depthTest)
    {
        var origin = new Vector2(rect.X + rect.Width / 2.0f, rect.Y + rect.Height / 2.0f);
        Vector2 halfExtents = rect.Size.ToUnityVector2() / 2.0f;

        var box = new Box2D(origin, halfExtents);
        DrawRectangle(box, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(RectangleF rect, in Color color)
    {
        DrawRectangle(rect, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(RectangleF rect, in Color color, float duration)
    {
        DrawRectangle(rect, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rect">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(RectangleF rect, in Color color, float duration, bool depthTest)
    {
        var origin = new Vector2(rect.X + rect.Width / 2.0f, rect.Y + rect.Height / 2.0f);
        Vector2 halfExtents = rect.Size.ToUnityVector2() / 2.0f;

        var box = new Box2D(origin, halfExtents);
        DrawRectangle(box, color, duration, depthTest);
    }
}
