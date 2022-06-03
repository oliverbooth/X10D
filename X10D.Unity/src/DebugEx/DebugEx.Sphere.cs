using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity;

public static partial class DebugEx
{
    /// <summary>
    ///     Draws a sphere with the specified color.
    /// </summary>
    /// <param name="center">The center point of the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="sides">The number of sides to generate.</param>
    public static void DrawSphere(Vector3 center, float radius, int sides)
    {
        DrawSphere(center, radius, sides, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color.
    /// </summary>
    /// <param name="center">The center point of the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the sphere.</param>
    public static void DrawSphere(Vector3 center, float radius, int sides, in Color color)
    {
        DrawSphere(center, radius, sides, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    public static void DrawSphere(Vector3 center, float radius, int sides, in Color color, float duration)
    {
        DrawSphere(center, radius, sides, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color and duration.
    /// </summary>
    /// <param name="center">The center point of the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the sphere be obscured by objects closer to the camera.
    /// </param>
    public static void DrawSphere(Vector3 center, float radius, int sides, in Color color, float duration, bool depthTest)
    {
        DrawSphere(center, radius, sides, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a sphere.
    /// </summary>
    /// <param name="center">The center point of the sphere.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the sphere.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the sphere be obscured by objects closer to the camera.
    /// </param>
    public static void DrawSphere(Vector3 center, float radius, int sides, Vector2 offset, in Color color, float duration,
        bool depthTest)
    {
        DrawSphere(new Sphere(center.ToSystemVector(), radius), sides, offset, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    public static void DrawSphere(Sphere sphere, int sides)
    {
        DrawSphere(sphere, sides, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the sphere.</param>
    public static void DrawSphere(Sphere sphere, int sides, Vector2 offset)
    {
        DrawSphere(sphere, sides, offset, Color.white, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the sphere.</param>
    public static void DrawSphere(Sphere sphere, int sides, in Color color)
    {
        DrawSphere(sphere, sides, Vector2.zero, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the sphere.</param>
    /// <param name="color">The color of the sphere.</param>
    public static void DrawSphere(Sphere sphere, int sides, Vector2 offset, in Color color)
    {
        DrawSphere(sphere, sides, offset, color, DefaultDrawDuration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color and duration.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    public static void DrawSphere(Sphere sphere, int sides, in Color color, float duration)
    {
        DrawSphere(sphere, sides, Vector2.zero, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color and duration.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the sphere.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    public static void DrawSphere(Sphere sphere, int sides, Vector2 offset, in Color color, float duration)
    {
        DrawSphere(sphere, sides, offset, color, duration, DefaultDepthTest);
    }

    /// <summary>
    ///     Draws a sphere with the specified color and duration.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the sphere be obscured by objects closer to the camera.
    /// </param>
    public static void DrawSphere(Sphere sphere, int sides, in Color color, float duration, bool depthTest)
    {
        DrawSphere(sphere, sides, Vector2.zero, color, duration, depthTest);
    }

    /// <summary>
    ///     Draws a sphere.
    /// </summary>
    /// <param name="sphere">The sphere to draw.</param>
    /// <param name="sides">The number of sides to generate.</param>
    /// <param name="offset">The drawing offset of the sphere.</param>
    /// <param name="color">The color of the sphere.</param>
    /// <param name="duration">
    ///     The duration of the sphere's visibility, in seconds. If 0 is passed, the sphere is visible for a single frame.
    /// </param>
    /// <param name="depthTest">
    ///     <see langword="DefaultDepthTest" /> if depth test should be applied; otherwise, <see langword="false" />. Passing
    ///     <see langword="DefaultDepthTest" /> will have the sphere be obscured by objects closer to the camera.
    /// </param>
    public static void DrawSphere(Sphere sphere, int sides, in Vector3 offset, in Color color, float duration, bool depthTest)
    {
        DrawPolyhedron(CreateCircle(sphere.Radius, sides, Vector3.zero), offset, color, duration, depthTest);
        DrawPolyhedron(CreateCircle(sphere.Radius, sides, Vector3.left), offset, color, duration, depthTest);
        DrawPolyhedron(CreateCircle(sphere.Radius, sides, Vector3.up), offset, color, duration, depthTest);
    }
}
