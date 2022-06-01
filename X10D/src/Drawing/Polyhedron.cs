using System.Drawing;
using System.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a 3D polyhedron composed of single-precision floating-point points.
/// </summary>
public class Polyhedron : IEquatable<Polyhedron>
{
    private readonly List<Vector3> _vertices = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="Polyhedron" /> class.
    /// </summary>
    public Polyhedron()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Polyhedron" /> class by copying the specified polyhedron.
    /// </summary>
    public Polyhedron(Polyhedron polyhedron)
        : this(polyhedron._vertices)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Polyhedron" /> class by constructing it from the specified vertices.
    /// </summary>
    /// <param name="vertices">An enumerable collection of vertices from which the polyhedron should be constructed.</param>
    public Polyhedron(IEnumerable<Vector3> vertices)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(vertices);
#else
        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }
#endif

        _vertices = new List<Vector3>(vertices);
    }

    /// <summary>
    ///     Gets an empty polyhedron. That is, a polygon with no vertices.
    /// </summary>
    /// <value>An empty polyhedron.</value>
    public static Polyhedron Empty
    {
        get => new();
    }

    /// <summary>
    ///     Returns a value indicating whether this polyhedron is convex.
    /// </summary>
    /// <value><see langword="true" /> if this polyhedron is convex; otherwise, <see langword="false" />.</value>
    public bool IsConvex
    {
        get
        {
            if (_vertices.Count < 4)
            {
                return false;
            }

            Vector3[] vertices = _vertices.ToArray();
            int n = vertices.Length;

            for (var i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                int k = (i + 2) % n;

                if (Vector3.Cross(vertices[j] - vertices[i], vertices[k] - vertices[j]).LengthSquared() < 1e-6f)
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    ///     Gets the number of vertices in this polyhedron.
    /// </summary>
    /// <value>An <see cref="int" /> value, representing the number of vertices in this polyhedron.</value>
    public int VertexCount
    {
        get => _vertices.Count;
    }

    /// <summary>
    ///     Gets a read-only view of the vertices in this polyhedron.
    /// </summary>
    /// <value>
    ///     A <see cref="IReadOnlyList{T}" /> of <see cref="Vector3" /> values, representing the vertices of this polyhedron.
    /// </value>
    public IReadOnlyList<Vector3> Vertices
    {
        get => _vertices.AsReadOnly();
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Polyhedron" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Polyhedron left, Polyhedron right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Polyhedron" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Polyhedron left, Polyhedron right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Polygon" /> to a <see cref="Polyhedron" />.
    /// </summary>
    /// <param name="polygon">The polyhedron to convert.</param>
    /// <returns>The converted polyhedron.</returns>
    public static implicit operator Polyhedron(Polygon polygon)
    {
        var points = new List<Vector3>();

        foreach (Point point in polygon.Vertices)
        {
            points.Add(new Vector3(point.X, point.Y, 0));
        }

        return new Polyhedron(points);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="PolygonF" /> to a <see cref="Polyhedron" />.
    /// </summary>
    /// <param name="polygon">The polyhedron to convert.</param>
    /// <returns>The converted polyhedron.</returns>
    public static implicit operator Polyhedron(PolygonF polygon)
    {
        var points = new List<Vector3>();

        foreach (PointF point in polygon.Vertices)
        {
            points.Add(new Vector3(point.X, point.Y, 0));
        }

        return new Polyhedron(points);
    }

    /// <summary>
    ///     Adds a vertex to this polyhedron.
    /// </summary>
    /// <param name="vertex">The vertex to add.</param>
    public void AddVertex(Vector3 vertex)
    {
        _vertices.Add(vertex);
    }

    /// <summary>
    ///     Adds a collection of vertices to this polyhedron.
    /// </summary>
    /// <param name="vertices">An enumerable collection of vertices to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="vertices" /> is <see langword="null" />.</exception>
    public void AddVertices(IEnumerable<Vector3> vertices)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(vertices);
#else
        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }
#endif

        foreach (Vector3 vertex in vertices)
        {
            AddVertex(vertex);
        }
    }

    /// <summary>
    ///     Clears all vertices from this polyhedron.
    /// </summary>
    public void ClearVertices()
    {
        _vertices.Clear();
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Polyhedron polyhedron && Equals(polyhedron);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Polyhedron other)
    {
        return _vertices.SequenceEqual(other._vertices);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _vertices.Aggregate(0, HashCode.Combine);
    }
}
