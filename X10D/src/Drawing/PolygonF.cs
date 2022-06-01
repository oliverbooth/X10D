using System.Drawing;
using System.Numerics;
using X10D.Numerics;

namespace X10D.Drawing;

/// <summary>
///     Represents a 2D polygon composed of single-precision floating-point points.
/// </summary>
public struct PolygonF
{
    /// <summary>
    ///     The empty polygon. That is, a polygon with no points.
    /// </summary>
    public static readonly PolygonF Empty = new(ArraySegment<PointF>.Empty);

    private PointF[]? _points;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> struct by copying the specified polygon.
    /// </summary>
    public PolygonF(PolygonF polygon)
        : this(polygon._points ?? Array.Empty<PointF>())
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> struct by constructing it from the specified points.
    /// </summary>
    /// <param name="points">An enumerable collection of points from which the polygon should be constructed.</param>
    public PolygonF(IEnumerable<Vector2> points)
        : this(points.Select(p => p.ToPointF()))
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(points);
#else
        if (points is null)
        {
            throw new ArgumentNullException(nameof(points));
        }
#endif
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonF" /> struct by constructing it from the specified points.
    /// </summary>
    /// <param name="points">An enumerable collection of points from which the polygon should be constructed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="points" /> is <see langword="null" />.</exception>
    public PolygonF(IEnumerable<PointF> points)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(points);
#else
        if (points is null)
        {
            throw new ArgumentNullException(nameof(points));
        }
#endif

        _points = points.ToArray();
    }

    /// <summary>
    ///     Returns a value indicating whether this polygon is convex.
    /// </summary>
    /// <value><see langword="true" /> if this polygon is convex; otherwise, <see langword="false" />.</value>
    public bool IsConvex
    {
        get
        {
            if (_points is null || _points.Length < 3)
            {
                return false;
            }

            var positive = false;
            var negative = false;
            PointF p0 = _points[0];

            for (var index = 1; index < _points.Length; index++)
            {
                PointF p1 = _points[index];
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
    ///     Gets the number of points in this polygon.
    /// </summary>
    /// <value>An <see cref="int" /> value, representing the number of points in this polygon.</value>
    public int PointCount
    {
        get => _points?.Length ?? 0;
    }

    /// <summary>
    ///     Gets a read-only view of the points in this polygon.
    /// </summary>
    /// <value>A <see cref="IReadOnlyList{T}" /> of <see cref="PointF" /> values, representing the points of this polygon.</value>
    public IReadOnlyList<PointF> Points
    {
        get => _points?.ToArray() ?? ArraySegment<PointF>.Empty;
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
    public static bool operator ==(PolygonF left, PolygonF right)
    {
        return left.Equals(right);
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
    public static bool operator !=(PolygonF left, PolygonF right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Explicitly converts a <see cref="Polygon" /> to a <see cref="PolygonF" />.
    /// </summary>
    /// <param name="polygon">The polygon to convert.</param>
    /// <returns>The converted polygon.</returns>
    public static explicit operator Polygon(PolygonF polygon)
    {
        var points = new List<Point>();

        foreach (PointF point in polygon.Points)
        {
            points.Add(new Point((int)point.X, (int)point.Y));
        }

        return new Polygon(points);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="Polygon" /> to a <see cref="PolygonF" />.
    /// </summary>
    /// <param name="polygon">The polygon to convert.</param>
    /// <returns>The converted polygon.</returns>
    public static implicit operator PolygonF(Polygon polygon)
    {
        var points = new List<PointF>();

        foreach (Point point in polygon.Points)
        {
            points.Add(point);
        }

        return new PolygonF(points);
    }

    /// <summary>
    ///     Adds a point to this polygon.
    /// </summary>
    /// <param name="point">The point to add.</param>
    public void AddPoint(PointF point)
    {
        _points ??= Array.Empty<PointF>();
        Span<PointF> span = stackalloc PointF[_points.Length + 1];
        _points.CopyTo(span);
        span[^1] = point;
        _points = span.ToArray();
    }

    /// <summary>
    ///     Adds a point to this polygon.
    /// </summary>
    /// <param name="point">The point to add.</param>
    public void AddPoint(Vector2 point)
    {
        AddPoint(point.ToPointF());
    }

    /// <summary>
    ///     Adds a collection of points to this polygon.
    /// </summary>
    /// <param name="points">An enumerable collection of points to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="points" /> is <see langword="null" />.</exception>
    public void AddPoints(IEnumerable<PointF> points)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(points);
#else
        if (points is null)
        {
            throw new ArgumentNullException(nameof(points));
        }
#endif

        foreach (PointF point in points)
        {
            AddPoint(point);
        }
    }

    /// <summary>
    ///     Adds a collection of points to this polygon.
    /// </summary>
    /// <param name="points">An enumerable collection of points to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="points" /> is <see langword="null" />.</exception>
    public void AddPoints(IEnumerable<Vector2> points)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(points);
#else
        if (points is null)
        {
            throw new ArgumentNullException(nameof(points));
        }
#endif

        foreach (Vector2 point in points)
        {
            AddPoint(point);
        }
    }

    /// <summary>
    ///     Clears all points from this polygon.
    /// </summary>
    public void ClearPoints()
    {
        _points = Array.Empty<PointF>();
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
    public bool Equals(PolygonF other)
    {
        return _points switch
        {
            null when other._points is null => true,
            null => false,
            not null when other._points is null => false,
            _ => _points.SequenceEqual(other._points)
        };
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        PointF[] points = _points ?? Array.Empty<PointF>();
        return points.Aggregate(0, HashCode.Combine);
    }
}
