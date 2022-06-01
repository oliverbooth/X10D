using System.Drawing;

namespace X10D.Drawing;

/// <summary>
///     Represents a 2D polygon composed of 32-bit signed integer points.
/// </summary>
public struct Polygon : IEquatable<Polygon>
{
    /// <summary>
    ///     The empty polygon. That is, a polygon with no points.
    /// </summary>
    public static readonly Polygon Empty = new();

    private Point[]? _points;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Polygon" /> struct by copying the specified polygon.
    /// </summary>
    public Polygon(Polygon polygon)
        : this(polygon._points ?? ArraySegment<Point>.Empty)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Polygon" /> struct by constructing it from the specified points.
    /// </summary>
    /// <param name="points">An enumerable collection of points from which the polygon should be constructed.</param>
    public Polygon(IEnumerable<Point> points)
    {
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
            Point p0 = _points[0];

            for (var index = 1; index < _points.Length; index++)
            {
                Point p1 = _points[index];
                int d = (p1.X - p0.X) * (p1.Y + p0.Y);

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
    /// <value>A <see cref="IReadOnlyList{T}" /> of <see cref="Point" /> values, representing the points of this polygon.</value>
    public IReadOnlyList<Point> Points
    {
        get => _points?.ToArray() ?? ArraySegment<Point>.Empty;
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Polygon" /> are equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Polygon left, Polygon right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Returns a value indicating whether two instances of <see cref="Polygon" /> are not equal.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are considered not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Polygon left, Polygon right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Adds a point to this polygon.
    /// </summary>
    /// <param name="point">The point to add.</param>
    public void AddPoint(Point point)
    {
        _points ??= Array.Empty<Point>();
        Span<Point> span = stackalloc Point[_points.Length + 1];
        _points.CopyTo(span);
        span[^1] = point;
        _points = span.ToArray();
    }

    /// <summary>
    ///     Adds a collection of points to this polygon.
    /// </summary>
    /// <param name="points">An enumerable collection of points to add.</param>
    /// <exception cref="ArgumentNullException"><paramref name="points" /> is <see langword="null" />.</exception>
    public void AddPoints(IEnumerable<Point> points)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(points);
#else
        if (points is null)
        {
            throw new ArgumentNullException(nameof(points));
        }
#endif

        foreach (Point point in points)
        {
            AddPoint(point);
        }
    }

    /// <summary>
    ///     Clears all points from this polygon.
    /// </summary>
    public void ClearPoints()
    {
        _points = Array.Empty<Point>();
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is Polygon polygon && Equals(polygon);
    }

    /// <summary>
    ///     Returns a value indicating whether this instance and another instance are equal.
    /// </summary>
    /// <param name="other">The instance with which to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if this instance and <paramref name="other" /> are considered equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Polygon other)
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
        Point[] points = _points ?? Array.Empty<Point>();
        return points.Aggregate(0, HashCode.Combine);
    }
}
