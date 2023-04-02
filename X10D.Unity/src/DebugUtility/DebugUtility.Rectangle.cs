using System.Drawing;
using UnityEngine;
using X10D.Unity.Drawing;
using Color = UnityEngine.Color;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws a rectangle.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    public static void DrawRectangle(Vector2 center, Vector2 size)
    {
        DrawRectangle(center, size, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Vector2 center, Vector2 size, in Color color)
    {
        DrawRectangle(center, size, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="size">The extents of the box.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Vector2 center, Vector2 size, in Color color, float duration)
    {
        DrawRectangle(center, size, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
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
    public static void DrawRectangle(Vector2 center, Vector2 size, in Color color, float duration, bool depthTest)
    {
        DrawRectangle(new Rect(center, size), color, duration, depthTest);
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
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(Rect rect, in Color color, float duration, bool depthTest)
    {
        var topLeft = new Vector2(rect.xMin, rect.yMin);
        var topRight = new Vector2(rect.xMax, rect.yMin);
        var bottomLeft = new Vector2(rect.xMin, rect.yMax);
        var bottomRight = new Vector2(rect.xMax, rect.yMax);

        DrawLine(topLeft, topRight, color, duration, depthTest);
        DrawLine(topRight, bottomRight, color, duration, depthTest);
        DrawLine(bottomRight, bottomLeft, color, duration, depthTest);
        DrawLine(bottomLeft, topLeft, color, duration, depthTest);
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
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(RectInt rect, in Color color, float duration, bool depthTest)
    {
        DrawRectangle(new Rect(rect.center, rect.size), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="rectangle">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(Rectangle rectangle, in Color color)
    {
        DrawRectangle(rectangle, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rectangle">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(Rectangle rectangle, in Color color, float duration)
    {
        DrawRectangle(rectangle, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rectangle">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(Rectangle rectangle, in Color color, float duration, bool depthTest)
    {
        var origin = new Vector2(rectangle.X + rectangle.Width / 2.0f, rectangle.Y + rectangle.Height / 2.0f);
        var rect = new Rect(origin, rectangle.Size.ToUnityVector2());
        DrawRectangle(rect, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color.
    /// </summary>
    /// <param name="rectangle">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    public static void DrawRectangle(RectangleF rectangle, in Color color)
    {
        DrawRectangle(rectangle, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rectangle">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    public static void DrawRectangle(RectangleF rectangle, in Color color, float duration)
    {
        DrawRectangle(rectangle, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a rectangle with the specified color and duration.
    /// </summary>
    /// <param name="rectangle">The rectangle to draw.</param>
    /// <param name="color">The color of the box.</param>
    /// <param name="duration">
    ///     The duration of the box's visibility, in seconds. If 0 is passed, the box is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRectangle(RectangleF rectangle, in Color color, float duration, bool depthTest)
    {
        var origin = new Vector2(rectangle.X + rectangle.Width / 2.0f, rectangle.Y + rectangle.Height / 2.0f);
        var rect = new Rect(origin, rectangle.Size.ToUnityVector2());
        DrawRectangle(rect, color, duration, depthTest);
    }
}
