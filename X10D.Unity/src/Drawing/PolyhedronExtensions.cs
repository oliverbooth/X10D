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
    /// <exception cref="ArgumentNullException"><paramref name="polyhedron" /> is <see langword="null" />.</exception>
    public static void AddVertex(this Polyhedron polyhedron, Vector3Int vertex)
    {
        if (polyhedron is null)
        {
            throw new ArgumentNullException(nameof(polyhedron));
        }

        polyhedron.AddVertex(vertex.ToSystemVector());
    }

    /// <summary>
    ///     Adds a vertex to this polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron whose vertices to update.</param>
    /// <param name="vertex">The vertex to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="polyhedron" /> is <see langword="null" />.</exception>
    public static void AddVertex(this Polyhedron polyhedron, Vector3 vertex)
    {
        if (polyhedron is null)
        {
            throw new ArgumentNullException(nameof(polyhedron));
        }

        polyhedron.AddVertex(vertex.ToSystemVector());
    }

    /// <summary>
    ///     Adds a collection of vertices to this polyhedron.
    /// </summary>
    /// <param name="polyhedron">The polyhedron whose vertices to update.</param>
    /// <param name="vertices">The vertices to add.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="polyhedron" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="vertices" /> is <see langword="null" />.</para>
    /// </exception>
    public static void AddVertices(this Polyhedron polyhedron, IEnumerable<Vector3Int> vertices)
    {
        if (polyhedron is null)
        {
            throw new ArgumentNullException(nameof(polyhedron));
        }

        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }

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
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="polyhedron" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="vertices" /> is <see langword="null" />.</para>
    /// </exception>
    public static void AddVertices(this Polyhedron polyhedron, IEnumerable<Vector3> vertices)
    {
        if (polyhedron is null)
        {
            throw new ArgumentNullException(nameof(polyhedron));
        }

        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }

        foreach (Vector3 vertex in vertices)
        {
            polyhedron.AddVertex(vertex);
        }
    }
}
