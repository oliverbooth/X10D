using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Numerics;
using X10D.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a 2D polygon composed of single-precision floating-vertex vertices.
/// </summary>
public class PolygonF
{
    private readonly List<PointF> _vertices = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> class.
    /// </summary>
    public PolygonF()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> class by copying the specified polygon.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="polygon" /> is <see langword="null" />.</exception>
    public PolygonF(PolygonF polygon)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(polygon);
#else
        if (polygon is null)
        {
            throw new ArgumentNullException(nameof(polygon));
        }
#endif
        _vertices = new List<PointF>();
        for (var index = 0; index < polygon._vertices.Count; index++)
        {
            PointF vertex = polygon._vertices[index];
            _vertices.Add(vertex);
        }
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> class by constructing it from the specified vertices.
    /// </summary>
    /// <param name="vertices">An enumerable collection of vertices from which the polygon should be constructed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="vertices" /> is <see langword="null" />.</exception>
    public PolygonF(IEnumerable<Vector2> vertices)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(vertices);
#else
        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }
#endif

        _vertices = new List<PointF>();
        foreach (Vector2 vertex in vertices)
        {
            _vertices.Add(vertex.ToPointF());
        }
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> class by constructing it from the specified vertices.
    /// </summary>
    /// <param name="vertices">An enumerable collection of vertices from which the polygon should be constructed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="vertices" /> is <see langword="null" />.</exception>
    public PolygonF(IEnumerable<PointF> vertices)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(vertices);
#else
        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }
#endif

        _vertices = new List<PointF>(vertices);
    }

    /// <summary>
    ///     Gets an empty polygon. That is, a polygon with no vertices.
    /// </summary>
    /// <value>An empty polygon.</value>
    public static PolygonF Empty
    {
        get => new();
    }

    /// <summary>
    ///     Returns a value indicating whether this polygon is convex.
    /// </summary>
    /// <value><see langword="true" /> if this polygon is convex; otherwise, <see langword="false" />.</value>
    public bool IsConvex
    {
        get
        {
            if (_vertices.Count < 3)
            {
                return false;
            }

            var positive = false;
            var negative = false;
            PointF p0 = _vertices[0];

            for (var index = 1; index < _vertices.Count; index++)
            {
                PointF p1 = _vertices[index];
                float d = (p1.X - p0.X) * (p1.Y + p0.Y);

                if (d > 0)
                {
                    positive = true;
                }
                else if (d < 0)
                {
                    negative = true;
                }

                if (positive && negative)
                {
                    return false;
                }

                p0 = p1;
            }

            return true;
        }
    }

    /// <summary>
    ///     Gets the number of vertices in this polygon.
    /// </summary>
    /// <value>An <see cref="int" /> value, representing the number of vertices in this polygon.</value>
    public int VertexCount
    {
        get => _vertices.Count;
    }

    /// <summary>
    ///     Gets a read-only view of the vertices in this polygon.
    /// </summary>
    /// <value>
    ///     A <see cref="IReadOnlyList{T}" /> of <see cref="PointF" /> values, representing the vertices of this polygon.
    /// </value>
    public IReadOnlyList<PointF> Vertices
    {
        get => _vertices.AsReadOnly();
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="PolygonF" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(PolygonF? left, PolygonF? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="PolygonF" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(PolygonF? left, PolygonF? right)
    {
        return !(left == right);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Polygon" /> to a <see cref="PolygonF" />.
    /// </summary>
    /// <param name="polygon">The polygon to convert.</param>
    /// <returns>The converted polygon.</returns>
    [return: NotNullIfNotNull("polygon")]
    public static implicit operator PolygonF?(Polygon? polygon)
    {
        return polygon is null ? null : FromPolygon(polygon);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Polygon" /> to a <see cref="PolygonF" />.
    /// </summary>
    /// <param name="polygon">The polygon to convert.</param>
    /// <returns>The converted polygon.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="polygon" /> is <see langword="null" />.</exception>
    public static PolygonF FromPolygon(Polygon polygon)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(polygon);
#else
        if (polygon is null)
        {
            throw new ArgumentNullException(nameof(polygon));
        }
#endif

        var vertices = new List<PointF>();

        foreach (Point vertex in polygon.Vertices)
        {
            vertices.Add(vertex);
        }

        return new PolygonF(vertices);
    }

    /// <summary>
    ///     Adds a vertex to this polygon.
    /// </summary>
    /// <param name="vertex">The vertex to add.</param>
    public void AddVertex(PointF vertex)
    {
        _vertices.Add(vertex);
    }

    /// <summary>
    ///     Adds a vertex to this polygon.
    /// </summary>
    /// <param name="vertex">The vertex to add.</param>
    public void AddVertex(Vector2 vertex)
    {
        AddVertex(vertex.ToPointF());
    }

    /// <summary>
    ///     Adds a collection of vertices to this polygon.
    /// </summary>
    /// <param name="vertices">An enumerable collection of vertices to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="vertices" /> is <see langword="null" />.</exception>
    public void AddVertices(IEnumerable<PointF> vertices)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(vertices);
#else
        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }
#endif

        foreach (PointF vertex in vertices)
        {
            AddVertex(vertex);
        }
    }

    /// <summary>
    ///     Adds a collection of vertices to this polygon.
    /// </summary>
    /// <param name="vertices">An enumerable collection of vertices to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="vertices" /> is <see langword="null" />.</exception>
    public void AddVertices(IEnumerable<Vector2> vertices)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(vertices);
#else
        if (vertices is null)
        {
            throw new ArgumentNullException(nameof(vertices));
        }
#endif

        foreach (Vector2 vertex in vertices)
        {
            AddVertex(vertex);
        }
    }

    /// <summary>
    ///     Clears all vertices from this polygon.
    /// </summary>
    public void ClearVertices()
    {
        _vertices.Clear();
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is PolygonF polygon && Equals(polygon);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(PolygonF? other)
    {
        return other is not null && _vertices.SequenceEqual(other._vertices);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _vertices.Aggregate(0, HashCode.Combine);
    }
}
