using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    public static void DrawPolyhedron(Polyhedron polyhedron)
    {
        DrawPolyhedron(polyhedron, Vector2.zero, Color.white, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="offset">The drawing offset of the polyhedron.</param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Vector3 offset)
    {
        DrawPolyhedron(polyhedron, offset, Color.white, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Color color)
    {
        DrawPolyhedron(polyhedron, Vector2.zero, color, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="offset">The drawing offset of the polyhedron.</param>
    /// <param name="color">The color to use for drawing.</param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Vector3 offset, in Color color)
    {
        DrawPolyhedron(polyhedron, offset, color, DefaultDrawDuration, true);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polyhedron's visibility, in seconds. If 0 is passed, the polyhedron is visible for a single frame.
    /// </param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Color color, float duration)
    {
        DrawPolyhedron(polyhedron, Vector2.zero, color, duration, true);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="offset">The drawing offset of the polyhedron.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polyhedron's visibility, in seconds. If 0 is passed, the polyhedron is visible for a single frame.
    /// </param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Vector3 offset, in Color color, float duration)
    {
        DrawPolyhedron(polyhedron, offset, color, duration, true);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polyhedron's visibility, in seconds. If 0 is passed, the polyhedron is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Color color, float duration, bool depthTest)
    {
        DrawPolyhedron(polyhedron, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron to draw.</param>
    /// <param name="offset">The drawing offset of the polyhedron.</param>
    /// <param name="color">The color to use for drawing.</param>
    /// <param name="duration">
    ///     The duration of the polyhedron's visibility, in seconds. If 0 is passed, the polyhedron is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the box be obscured by objects closer to the camera.
    /// </param>
    public static void DrawPolyhedron(Polyhedron polyhedron, in Vector3 offset, in Color color, float duration, bool depthTest)
    {
        IReadOnlyList<System.Numerics.Vector3> points = polyhedron.Vertices;
        if (points.Count < 2)
        {
            return;
        }

        for (var i = 0; i < points.Count; i++)
        {
            int j = (i + 1) % points.Count;
            Vector3 start = points[i].ToUnityVector() + offset;
            Vector3 end = points[j].ToUnityVector() + offset;

            DrawLine(start, end, color, duration, depthTest);
        }
    }
}
