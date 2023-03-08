using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="PolygonF" />.
/// </summary>
public static class PolygonFExtensions
{
    /// <summary>
    ///     Adds a point to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose vertices to update.</param>
    /// <param name="vertex">The vertex to add.</param>
    public static void AddVertex(this PolygonF polygon, Vector2Int vertex)
    {
        polygon.AddVertex(vertex.ToSystemPoint());
    }

    /// <summary>
    ///     Adds a point to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose vertices to update.</param>
    /// <param name="vertex">The vertex to add.</param>
    public static void AddVertex(this PolygonF polygon, Vector2 vertex)
    {
        polygon.AddVertex(vertex.ToSystemPointF());
    }

    /// <summary>
    ///     Adds a collection of vertices to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    public static void AddVertices(this PolygonF polygon, IEnumerable<Vector2Int> vertices)
    {
        foreach (Vector2Int vertex in vertices)
        {
            polygon.AddVertex(vertex);
        }
    }

    /// <summary>
    ///     Adds a collection of vertices to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    public static void AddVertices(this PolygonF polygon, IEnumerable<Vector2> vertices)
    {
        foreach (Vector2 vertex in vertices)
        {
            polygon.AddVertex(vertex);
        }
    }
}
