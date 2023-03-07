using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Polygon" />.
/// </summary>
public static class PolygonExtensions
{
    /// <summary>
    ///     Adds a vertex to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose points to update.</param>
    /// <param name="point">The point to add.</param>
    public static void AddVertex(this Polygon polygon, Vector2Int point)
    {
        polygon.AddVertex(point.ToSystemPoint());
    }

    /// <summary>
    ///     Adds a collection of vertices to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    public static void AddVertices(this Polygon polygon, IEnumerable<Vector2Int> vertices)
    {
        foreach (Vector2Int vertex in vertices)
        {
            polygon.AddVertex(vertex);
        }
    }
}
