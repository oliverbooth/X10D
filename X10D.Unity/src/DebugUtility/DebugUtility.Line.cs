using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws a line between start and end points.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="end">The ending point.</param>
    public static void DrawLine(Vector3 start, Vector3 end)
    {
        DrawLine(start, end, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="end">The ending point.</param>
    /// <param name="color">The color of the line.</param>
    public static void DrawLine(Vector3 start, Vector3 end, in Color color)
    {
        DrawLine(start, end, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="end">The ending point.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    public static void DrawLine(Vector3 start, Vector3 end, in Color color, float duration)
    {
        DrawLine(start, end, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="end">The ending point.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the line be obscured by objects closer to the camera.
    /// </param>
    public static void DrawLine(Vector3 start, Vector3 end, in Color color, float duration, bool depthTest)
    {
        Debug.DrawLine(start, end, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    public static void DrawLine(Line line)
    {
        DrawLine(line, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    public static void DrawLine(Line line, in Color color)
    {
        DrawLine(line, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    public static void DrawLine(Line line, in Color color, float duration)
    {
        DrawLine(line, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the line be obscured by objects closer to the camera.
    /// </param>
    public static void DrawLine(Line line, in Color color, float duration, bool depthTest)
    {
        Debug.DrawLine(line.Start.ToUnityVector2(), line.End.ToUnityVector2(), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    public static void DrawLine(LineF line)
    {
        DrawLine(line, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    public static void DrawLine(LineF line, in Color color)
    {
        DrawLine(line, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    public static void DrawLine(LineF line, in Color color, float duration)
    {
        DrawLine(line, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the line be obscured by objects closer to the camera.
    /// </param>
    public static void DrawLine(LineF line, in Color color, float duration, bool depthTest)
    {
        Debug.DrawLine(line.Start.ToUnityVector2(), line.End.ToUnityVector2(), color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    public static void DrawLine(Line3D line)
    {
        DrawLine(line, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    public static void DrawLine(Line3D line, in Color color)
    {
        DrawLine(line, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    public static void DrawLine(Line3D line, in Color color, float duration)
    {
        DrawLine(line, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a line between start and end points, with the specified color.
    /// </summary>
    /// <param name="line">The line to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the line be obscured by objects closer to the camera.
    /// </param>
    public static void DrawLine(Line3D line, in Color color, float duration, bool depthTest)
    {
        Debug.DrawLine(line.Start.ToUnityVector(), line.End.ToUnityVector(), color, duration, depthTest);
    }
}
