using UnityEngine;
using X10D.Drawing;
using X10D.Numerics;
using X10D.Unity.Numerics;
using Quaternion = System.Numerics.Quaternion;

namespace X10D.Unity;

public static partial class DebugEx
{
    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="segments">The number of segments to generate.</param>
    public static void DrawCircle(Vector2 center, float radius, int segments)
    {
        DrawCircle(center, radius, segments, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    public static void DrawCircle(Vector2 center, float radius, int segments, in Color color)
    {
        DrawCircle(center, radius, segments, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    public static void DrawCircle(Vector2 center, float radius, int segments, in Color color, float duration)
    {
        DrawCircle(center, radius, segments, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    public static void DrawCircle(Vector2 center, float radius, int segments, in Color color, float duration, bool depthTest)
    {
        DrawCircle(center, radius, segments, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a circle.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    public static void DrawCircle(Vector2 center, float radius, int segments, in Vector3 offset, in Color color, float duration,
        bool depthTest)
    {
        DrawCircle(new CircleF(center.ToSystemVector(), radius), segments, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    public static void DrawCircle(in Circle circle, int segments)
    {
        DrawCircle((CircleF)circle, segments, Vector2.zero, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    public static void DrawCircle(in Circle circle, int segments, in Vector3 offset)
    {
        DrawCircle((CircleF)circle, segments, offset, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    public static void DrawCircle(in Circle circle, int segments, in Color color)
    {
        DrawCircle((CircleF)circle, segments, Vector2.zero, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    public static void DrawCircle(in Circle circle, int segments, in Vector3 offset, in Color color)
    {
        DrawCircle((CircleF)circle, segments, offset, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    public static void DrawCircle(in Circle circle, int segments, in Color color, float duration)
    {
        DrawCircle((CircleF)circle, segments, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    public static void DrawCircle(in Circle circle, int segments, in Vector3 offset, in Color color, float duration)
    {
        DrawCircle((CircleF)circle, segments, offset, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    public static void DrawCircle(in Circle circle, int segments, in Color color, float duration, bool depthTest)
    {
        DrawCircle((CircleF)circle, segments, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a circle.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    public static void DrawCircle(in Circle circle, int segments, in Vector3 offset, in Color color, float duration, bool depthTest)
    {
        DrawCircle((CircleF)circle, segments, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    public static void DrawCircle(in CircleF circle, int segments)
    {
        DrawCircle(circle, segments, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    public static void DrawCircle(in CircleF circle, int segments, in Vector3 offset)
    {
        DrawCircle(circle, segments, offset, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    public static void DrawCircle(in CircleF circle, int segments, in Color color)
    {
        DrawCircle(circle, segments, Vector2.zero, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    public static void DrawCircle(in CircleF circle, int segments, in Vector3 offset, in Color color)
    {
        DrawCircle(circle, segments, offset, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    public static void DrawCircle(in CircleF circle, int segments, in Color color, float duration)
    {
        DrawCircle(circle, segments, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    public static void DrawCircle(in CircleF circle, int segments, in Vector3 offset, in Color color, float duration)
    {
        DrawCircle(circle, segments, offset, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a circle with the specified color and duration.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    public static void DrawCircle(in CircleF circle, int segments, in Color color, float duration, bool depthTest)
    {
        DrawCircle(circle, segments, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a circle.
    /// </summary>
    /// <param name="circle">The circle to draw.</param>
    /// <param name="segments">The number of segments to generate.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    public static void DrawCircle(in CircleF circle, int segments, in Vector3 offset, in Color color, float duration, bool depthTest)
    {
        DrawPolyhedron(CreateCircle(circle.Radius, segments, Vector3.zero), offset, color, duration, depthTest);
    }

    private static Polyhedron CreateCircle(float radius, int segments, in Vector3 axis)
    {
        const float max = 2.0f * MathF.PI;
        float step = max / segments;

        var points = new List<System.Numerics.Vector3>();
        for (var theta = 0f; theta < max; theta += step)
        {
            float x = radius * MathF.Cos(theta);
            float y = radius * MathF.Sin(theta);
            var vector = new System.Numerics.Vector3(x, y, 0);

            if (axis != Vector3.zero)
            {
                vector = Quaternion.CreateFromAxisAngle(axis.ToSystemVector(), MathF.PI / 2.0f).Multiply(vector);
            }

            points.Add(vector);
        }

        return new Polyhedron(points);
    }
}
