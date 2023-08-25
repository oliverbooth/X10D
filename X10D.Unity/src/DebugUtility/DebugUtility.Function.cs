using UnityEngine;
using X10D.Drawing;
using X10D.Numerics;
using X10D.Unity.Numerics;
using Quaternion = System.Numerics.Quaternion;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws a function plot.
    /// </summary>
    /// <param name="function">The function to plot.</param>
    /// <param name="xMin">The minimum X value.</param>
    /// <param name="xMax">The maximum X value.</param>
    public static void DrawFunction(Func<float, float> function, float xMin, float xMax)
    {
        DrawFunction(function, xMin, xMax, 0.1f, Vector3.zero, Color.white, 0.0f, false);
    }

    /// <summary>
    ///     Draws a function plot.
    /// </summary>
    /// <param name="function">The function to plot.</param>
    /// <param name="xMin">The minimum X value.</param>
    /// <param name="xMax">The maximum X value.</param>
    /// <param name="step">The X increment.</param>
    /// <param name="offset">The drawing offset of the circle.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="duration">
    ///     The duration of the circle's visibility, in seconds. If 0 is passed, the circle is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the circle be obscured by objects closer to the camera.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="function" /> is <see langword="null" />.</exception>
    public static void DrawFunction(Func<float, float> function, float xMin, float xMax, float step, in Vector3 offset,
        in Color color, float duration,
        bool depthTest)
    {
        if (function is null)
        {
            throw new ArgumentNullException(nameof(function));
        }

        DrawUnjoinedPolyhedron(CreateFunction(function, xMin, xMax, step, Vector3.zero), offset, color, duration, depthTest);
    }

    private static Polyhedron CreateFunction(Func<float, float> function, float xMin, float xMax, float step, in Vector3 axis)
    {
        var points = new List<System.Numerics.Vector3>();
        for (float x = xMin; x < xMax; x += step)
        {
            float y = function(x);
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
