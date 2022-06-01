using UnityEngine;
using X10D.Drawing;

namespace X10D.Unity;

public static partial class DebugEx
{
    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radius">The radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    public static void DrawEllipse(Vector2 center, Vector2 radius, int sides)
    {
        DrawEllipse(center, radius.x, radius.y, sides, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radius">The radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    public static void DrawEllipse(Vector2 center, Vector2 radius, int sides, in Color color)
    {
        DrawEllipse(center, radius.x, radius.y, sides, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radius">The radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    public static void DrawEllipse(Vector2 center, Vector2 radius, int sides, in Color color, float duration)
    {
        DrawEllipse(center, radius.x, radius.y, sides, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radius">The radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(Vector2 center, Vector2 radius, int sides, in Color color, float duration, bool depthTest)
    {
        DrawEllipse(center, radius.x, radius.y, sides, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radius">The radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(Vector2 center, Vector2 radius, int sides, Vector2 offset, in Color color, float duration,
        bool depthTest)
    {
        DrawEllipse(new EllipseF(center.x, center.y, radius.x, radius.y), sides, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radiusX">The horizontal radius of the ellipse.</param>
    /// <param name="radiusY">The vertical radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    public static void DrawEllipse(Vector2 center, float radiusX, float radiusY, int sides)
    {
        DrawEllipse(center, radiusX, radiusY, sides, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radiusX">The horizontal radius of the ellipse.</param>
    /// <param name="radiusY">The vertical radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    public static void DrawEllipse(Vector2 center, float radiusX, float radiusY, int sides, in Color color)
    {
        DrawEllipse(center, radiusX, radiusY, sides, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radiusX">The horizontal radius of the ellipse.</param>
    /// <param name="radiusY">The vertical radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    public static void DrawEllipse(Vector2 center, float radiusX, float radiusY, int sides, in Color color, float duration)
    {
        DrawEllipse(center, radiusX, radiusY, sides, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radiusX">The horizontal radius of the ellipse.</param>
    /// <param name="radiusY">The vertical radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(Vector2 center, float radiusX, float radiusY, int sides, in Color color, float duration,
        bool depthTest)
    {
        DrawEllipse(center, radiusX, radiusY, sides, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse.
    /// </summary>
    /// <param name="center">The center point of the ellipse.</param>
    /// <param name="radiusX">The horizontal radius of the ellipse.</param>
    /// <param name="radiusY">The vertical radius of the ellipse.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(Vector2 center, float radiusX, float radiusY, int sides, Vector2 offset, in Color color,
        float duration, bool depthTest)
    {
        DrawEllipse(new EllipseF(center.x, center.y, radiusX, radiusY), sides, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    public static void DrawEllipse(Ellipse ellipse, int sides)
    {
        DrawEllipse((EllipseF)ellipse, sides, Vector2.zero, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    public static void DrawEllipse(Ellipse ellipse, int sides, Vector2 offset)
    {
        DrawEllipse((EllipseF)ellipse, sides, offset, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    public static void DrawEllipse(Ellipse ellipse, int sides, in Color color)
    {
        DrawEllipse((EllipseF)ellipse, sides, Vector2.zero, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    public static void DrawEllipse(Ellipse ellipse, int sides, Vector2 offset, in Color color)
    {
        DrawEllipse((EllipseF)ellipse, sides, offset, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    public static void DrawEllipse(Ellipse ellipse, int sides, in Color color, float duration)
    {
        DrawEllipse((EllipseF)ellipse, sides, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    public static void DrawEllipse(Ellipse ellipse, int sides, Vector2 offset, in Color color, float duration)
    {
        DrawEllipse((EllipseF)ellipse, sides, offset, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(Ellipse ellipse, int sides, in Color color, float duration, bool depthTest)
    {
        DrawEllipse((EllipseF)ellipse, sides, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(Ellipse ellipse, int sides, Vector2 offset, in Color color, float duration, bool depthTest)
    {
        DrawEllipse((EllipseF)ellipse, sides, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    public static void DrawEllipse(EllipseF ellipse, int sides)
    {
        DrawEllipse(ellipse, sides, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    public static void DrawEllipse(EllipseF ellipse, int sides, Vector2 offset)
    {
        DrawEllipse(ellipse, sides, offset, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    public static void DrawEllipse(EllipseF ellipse, int sides, in Color color)
    {
        DrawEllipse(ellipse, sides, Vector2.zero, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    public static void DrawEllipse(EllipseF ellipse, int sides, Vector2 offset, in Color color)
    {
        DrawEllipse(ellipse, sides, offset, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    public static void DrawEllipse(EllipseF ellipse, int sides, in Color color, float duration)
    {
        DrawEllipse(ellipse, sides, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    public static void DrawEllipse(EllipseF ellipse, int sides, Vector2 offset, in Color color, float duration)
    {
        DrawEllipse(ellipse, sides, offset, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws an ellipse with the specified color and duration.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(EllipseF ellipse, int sides, in Color color, float duration, bool depthTest)
    {
        DrawEllipse(ellipse, sides, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws an ellipse.
    /// </summary>
    /// <param name="ellipse">The ellipse to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the ellipse.</param>
    /// <param name="color">The color of the ellipse.</param>
    /// <param name="duration">
    ///     The duration of the ellipse's visibility, in seconds. If 0 is passed, the ellipse is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the ellipse be obscured by objects closer to the camera.
    /// </param>
    public static void DrawEllipse(EllipseF ellipse, int sides, Vector2 offset, in Color color, float duration, bool depthTest)
    {
        DrawPolygon(CreateEllipse(ellipse.HorizontalRadius, ellipse.VerticalRadius, sides), offset, color, duration, depthTest);
    }


    private static PolygonF CreateEllipse(float radiusX, float radiusY, int sides)
    {
        const float max = 2.0f * MathF.PI;
        float step = max / sides;

        var points = new List<System.Numerics.Vector2>();
        for (var theta = 0f; theta < max; theta += step)
        {
            float x = radiusX * MathF.Cos(theta);
            float y = radiusY * MathF.Sin(theta);
            points.Add(new System.Numerics.Vector2(x, y));
        }

        return new PolygonF(points);
    }
}
