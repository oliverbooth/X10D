using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Drawing;
using PointF = System.Drawing.PointF;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    public static void DrawPolygon(Polygon polygon)
    {
        DrawPolygon((PolygonF)polygon, Vector2.zero, Color.white, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    public static void DrawPolygon(Polygon polygon, in Vector3 offset)
    {
        DrawPolygon((PolygonF)polygon, offset, Color.white, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    public static void DrawPolygon(Polygon polygon, in Color color)
    {
        DrawPolygon((PolygonF)polygon, Vector2.zero, color, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    /// <param name="color">The color to use for drawing.</param>
    public static void DrawPolygon(Polygon polygon, in Vector3 offset, in Color color)
    {
        DrawPolygon((PolygonF)polygon, offset, color, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    public static void DrawPolygon(Polygon polygon, in Color color, float duration)
    {
        DrawPolygon((PolygonF)polygon, Vector2.zero, color, duration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    public static void DrawPolygon(Polygon polygon, in Vector3 offset, in Color color, float duration)
    {
        DrawPolygon((PolygonF)polygon, offset, color, duration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawPolygon(Polygon polygon, in Color color, float duration, bool depthTest)
    {
        DrawPolygon((PolygonF)polygon, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawPolygon(Polygon polygon, in Vector3 offset, in Color color, float duration, bool depthTest)
    {
        DrawPolygon((PolygonF)polygon, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    public static void DrawPolygon(PolygonF polygon)
    {
        DrawPolygon(polygon, Vector2.zero, Color.white, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    public static void DrawPolygon(PolygonF polygon, in Vector3 offset)
    {
        DrawPolygon(polygon, offset, Color.white, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    public static void DrawPolygon(PolygonF polygon, in Color color)
    {
        DrawPolygon(polygon, Vector2.zero, color, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    /// <param name="color">The color to use for drawing.</param>
    public static void DrawPolygon(PolygonF polygon, in Vector3 offset, in Color color)
    {
        DrawPolygon(polygon, offset, color, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    public static void DrawPolygon(PolygonF polygon, in Color color, float duration)
    {
        DrawPolygon(polygon, Vector2.zero, color, duration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    public static void DrawPolygon(PolygonF polygon, in Vector3 offset, in Color color, float duration)
    {
        DrawPolygon(polygon, offset, color, duration, true);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawPolygon(PolygonF polygon, in Color color, float duration, bool depthTest)
    {
        DrawPolygon(polygon, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a polygon.
    /// </summary>
    /// <param name="polygon">The polygon to draw.</param>
    /// <param name="offset">The drawing offset of the polygon.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polygon's visibility, in seconds. If 0 is passed, the polygon is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="polygon" /> is <see langword="null" />.</exception>
    public static void DrawPolygon(PolygonF polygon, in Vector3 offset, in Color color, float duration, bool depthTest)
    {
        if (polygon is null)
        {
            throw new ArgumentNullException(nameof(polygon));
        }

        IReadOnlyList<PointF> points = polygon.Vertices;
        if (points.Count < 2)
        {
            return;
        }

        for (var i = 0; i < points.Count; i++)
        {
            int j = (i + 1) % points.Count;
            Vector3 start = (Vector3)points[i].ToUnityVector2() + offset;
            Vector3 end = (Vector3)points[j].ToUnityVector2() + offset;

            DrawLine(start, end, color, duration, depthTest);
        }
    }
}
