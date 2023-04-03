using UnityEngine;

namespace X10D.Unity;

public static partial class DebugUtility
{
    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="ray">The ray to draw.</param>
    public static void DrawRay(Ray ray)
    {
        DrawRay(ray, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="ray">The ray to draw.</param>
    /// <param name="color">The color of the line.</param>
    public static void DrawRay(Ray ray, in Color color)
    {
        DrawRay(ray, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="ray">The ray to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    public static void DrawRay(Ray ray, in Color color, float duration)
    {
        DrawRay(ray, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="ray">The ray to draw.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the line be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRay(Ray ray, in Color color, float duration, bool depthTest)
    {
        Debug.DrawRay(ray.origin, ray.direction, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="direction">The direction.</param>
    public static void DrawRay(Vector3 start, Vector3 direction)
    {
        DrawRay(start, direction, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="direction">The direction.</param>
    /// <param name="color">The color of the line.</param>
    public static void DrawRay(Vector3 start, Vector3 direction, in Color color)
    {
        DrawRay(start, direction, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="direction">The direction.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    public static void DrawRay(Vector3 start, Vector3 direction, in Color color, float duration)
    {
        DrawRay(start, direction, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a ray.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="direction">The direction.</param>
    /// <param name="color">The color of the line.</param>
    /// <param name="duration">
    ///     The duration of the line's visibility, in seconds. If 0 is passed, the line is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="true" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="true" /> will have the line be obscured by objects closer to the camera.
    /// </param>
    public static void DrawRay(Vector3 start, Vector3 direction, in Color color, float duration, bool depthTest)
    {
        Debug.DrawRay(start, direction, color, duration, depthTest);
    }
}
