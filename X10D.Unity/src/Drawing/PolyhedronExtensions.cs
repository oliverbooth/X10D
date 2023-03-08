using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Polyhedron" />.
/// </summary>
public static class PolyhedronExtensions
{
    /// <summary>
    ///     Adds a vertex to this polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron whose vertices to update.</param>
    /// <param name="vertex">The vertex to add.</param>
    public static void AddVertex(this Polyhedron polyhedron, Vector3Int vertex)
    {
        polyhedron.AddVertex(vertex.ToSystemVector());
    }

    /// <summary>
    ///     Adds a vertex to this polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron whose vertices to update.</param>
    /// <param name="vertex">The vertex to add.</param>
    public static void AddVertex(this Polyhedron polyhedron, Vector3 vertex)
    {
        polyhedron.AddVertex(vertex.ToSystemVector());
    }

    /// <summary>
    ///     Adds a collection of vertices to this polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    public static void AddVertices(this Polyhedron polyhedron, IEnumerable<Vector3Int> vertices)
    {
        foreach (Vector3Int vertex in vertices)
        {
            polyhedron.AddVertex(vertex);
        }
    }

    /// <summary>
    ///     Adds a collection of vertices to this polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    public static void AddVertices(this Polyhedron polyhedron, IEnumerable<Vector3> vertices)
    {
        foreach (Vector3 vertex in vertices)
        {
            polyhedron.AddVertex(vertex);
        }
    }
}
