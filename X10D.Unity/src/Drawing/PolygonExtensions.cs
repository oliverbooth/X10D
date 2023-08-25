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
    /// <exception cref="ArgumentNullException"><paramref name="polygon" /> is <see langword="null" />.</exception>
    public static void AddVertex(this Polygon polygon, Vector2Int point)
    {
        if (polygon is null)
        {
            throw new ArgumentNullException(nameof(polygon));
        }

        polygon.AddVertex(point.ToSystemPoint());
    }

    /// <summary>
    ///     Adds a collection of vertices to this polygon.
    /// </summary>
    /// <param name="polygon">The polygon whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="polygon" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="vertices" /> is <see langword="null" />.</para>
    /// </exception>
    public static void AddVertices(this Polygon polygon, IEnumerable<Vector2Int> vertices)
    {
        if (polygon is null)
        {
            throw new ArgumentNullException(nameof(polygon));
        }

        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }

        foreach (Vector2Int vertex in vertices)
        {
            polygon.AddVertex(vertex);
        }
    }
}
